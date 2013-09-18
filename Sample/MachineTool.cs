/*
 * Copyright Copyright 2012, System Insights, Inc.
 *
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *
 *       http://www.apache.org/licenses/LICENSE-2.0
 *
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdapterLab
{
    using MTConnect;
    using NAudio;
    using NAudio.Wave;

    public partial class MachineTool : Form
    {
        Adapter mAdapter = new Adapter();
        Event mAvail = new Event("avail");
        Event mEStop = new Event("estop");

        Event mMode = new Event("mode");
        Event mExec = new Event("exec");

        Event mProgram = new Event("program");
        Message mMessage = new Message("message");

        Sample mPosition = new Sample("position");
        Sample mLoad = new Sample("load");

        Condition mSystem = new Condition("system");
        Condition mTemp = new Condition("temp");
        Condition mOverload = new Condition("overload");
        Condition mTravel = new Condition("travel");
        Condition mFillLevel = new Condition("cool_low", true);

        TimeSeries mAudio = new TimeSeries("audio", 1000);
        WaveIn mWave;
        
        public MachineTool()
        {
            InitializeComponent();
            stop.Enabled = false;

            mAdapter.AddDataItem(mAvail);
            mAvail.Value = "AVAILABLE";

            mAdapter.AddDataItem(mEStop);

            mAdapter.AddDataItem(mMode);
            mAdapter.AddDataItem(mExec);

            mAdapter.AddDataItem(mProgram);
            mAdapter.AddDataItem(mMessage);

            mAdapter.AddDataItem(mPosition);
            mAdapter.AddDataItem(mLoad);

            mAdapter.AddDataItem(mSystem);
            mAdapter.AddDataItem(mTemp);
            mAdapter.AddDataItem(mOverload);
            mAdapter.AddDataItem(mTravel);
            mAdapter.AddDataItem(mFillLevel);

            mAdapter.AddDataItem(mAudio);

            int count = WaveIn.DeviceCount;
            for (int dev = 0; dev < count; dev++)
            {
                WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(dev);
                Console.WriteLine("Device {0}: {1}, {2} channels",
                    dev, deviceInfo.ProductName, deviceInfo.Channels);
            }

            mWave = new WaveIn();
            mWave.DeviceNumber = 0;
            mWave.WaveFormat = new WaveFormat(1000, 1);
            mWave.DataAvailable += waveIn_DataAvailable;
        }

        private void start_Click(object sender, EventArgs e)
        {
            // Start the adapter lib with the port number in the text box
            mAdapter.Port = Convert.ToInt32(port.Text);
            mAdapter.Start();

            // Disable start and enable stop.
            start.Enabled = false;
            stop.Enabled = true;

            // Start our periodic timer
            gather.Interval = 1000;
            gather.Enabled = true;

            mSystem.Normal();
            mTemp.Normal();
            mOverload.Normal();
            mTravel.Normal();
            mFillLevel.Normal();

            mWave.StartRecording();
        }

        private void stop_Click(object sender, EventArgs e)
        {
            // Stop everything...
            mAdapter.Stop();
            stop.Enabled = false;
            start.Enabled = true;
            gather.Enabled = false;

            mWave.StopRecording();
        }

        private void gather_Tick(object sender, EventArgs e)
        {
            mAdapter.Begin();

            if (estop.Checked)
                mEStop.Value = "TRIGGERED";
            else
                mEStop.Value = "ARMED";

            if (automatic.Checked)
                mMode.Value = "AUTOMATIC";
            else if (mdi.Checked)
                mMode.Value = "MANUAL_DATA_INPUT";
            else // edit & manual
                mMode.Value = "MANUAL";

            if (running.Checked)
                mExec.Value = "ACTIVE";
            else if (feedhold.Checked)
                mExec.Value = "FEED_HOLD";
            else
                mExec.Value = "READY";

            mProgram.Value = program.Text;

            if (messageCode.Text.Length > 0)
            {
                mMessage.Code = messageCode.Text;
                mMessage.Value = messageText.Text;
            }

            mLoad.Value = load.Value;
            mPosition.Value = position.Value;

            if (flazBat.Checked)
                mSystem.Add(Condition.Level.FAULT, "Yur Flaz Bat is flapping", "FLAZBAT");
            if (something.Checked)
                mSystem.Add(Condition.Level.WARNING, "Something went wrong", "AKAK");

            if (overtemp.Checked)
                mTemp.Add(Condition.Level.WARNING, "Temperature is too high", "OT");
            if (overload.Checked)
                mOverload.Add(Condition.Level.FAULT, "Axis overload", "OL");
            if (travel.Checked)
                mTravel.Add(Condition.Level.FAULT, "Travel outside boundaries", "OP");

            mAdapter.SendChanged();
        }

        private void load_Scroll(object sender, ScrollEventArgs e)
        {
            loadValue.Text = load.Value.ToString();
        }

        private void position_Scroll(object sender, ScrollEventArgs e)
        {
            mPosition.Value = position.Value;
            mAdapter.SendChanged();

            positionValue.Text = position.Value.ToString();
        }

        private void coolant_CheckedChanged(object sender, EventArgs e)
        {
            if (coolant.Checked)
                mFillLevel.Add(Condition.Level.WARNING, "Coolant Low", "COOL", "LOW");
            else
                mFillLevel.Clear("COOL");
            mAdapter.SendChanged();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CuttingToolForm toolWindow = new CuttingToolForm(mAdapter);
            toolWindow.Show(this);
        }

        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            double[] samples = new double[e.BytesRecorded / 2];
            for (int i = 0; i < e.BytesRecorded; i += 2)
            {
                short sample = (short)((e.Buffer[i + 1] << 8) |
                                e.Buffer[i]);
                samples[i / 2] = sample / 32768.0;
            }
            mAudio.Values = samples;
            mAdapter.SendChanged();
        }
     }
}
