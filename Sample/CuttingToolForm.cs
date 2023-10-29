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
using MTConnect;

namespace AdapterLab
{
     public partial class CuttingToolForm : Form
     {
          private readonly Adapter mAdapter;

          public CuttingToolForm(Adapter adapter)
          {
               InitializeComponent();
               mAdapter = adapter;
          }

          private void Button1_Click(object sender, EventArgs e)
          {
               CuttingTool tool = new CuttingTool(assetId.Text, toolId.Text, serialNumber.Text)
               {
                    Description = description.Text,
                    Manufacturers = manufacturers.Text
               };

               List<string> status = new List<string>();
               if (statusUsed.Checked)
               {
                    status.Add("USED");
               }

               if (statusNew.Checked)
               {
                    status.Add("NEW");
               }

               if (statusAllocated.Checked)
               {
                    status.Add("ALLOCATED");
               }

               if (statusMeasured.Checked)
               {
                    status.Add("MEASURED");
               }

               if (statusBroken.Checked)
               {
                    status.Add("BROKEN");
               }

               _ = tool.AddStatus(status.ToArray());

               MTConnect.CuttingTool.LifeType type = MTConnect.CuttingTool.LifeType.MINUTES;
               if (lifeType.Text == "PART_COUNT")
               {
                    type = MTConnect.CuttingTool.LifeType.PART_COUNT;
               }
               else if (lifeType.Text == "WEAR")
               {
                    type = MTConnect.CuttingTool.LifeType.WEAR;
               }

               MTConnect.CuttingTool.Direction dir = MTConnect.CuttingTool.Direction.UP;
               if (lifeDirection.Text == "DOWN")
               {
                    dir = MTConnect.CuttingTool.Direction.DOWN;
               }

               _ = tool.AddLife(type, dir, lifeValue.Text, lifeInitial.Text, lifeLimit.Text);

               _ = tool.AddProperty("ProcessSpindleSpeed", new string[]
                    { "nominal", speedNominal.Text,
                   "minimum", speedMin.Text,
                   "maximum", speedMax.Text}, speed.Text);

               _ = tool.AddMeasurement("FunctionalLength", "LF", double.Parse(lengthVal.Text), double.Parse(lengthNom.Text),
                   double.Parse(lengthMin.Text), double.Parse(lengthMax.Text));
               _ = tool.AddMeasurement("CuttingDiameterMax", "DC", double.Parse(diaVal.Text), double.Parse(diaNom.Text),
                   double.Parse(diaMin.Text), double.Parse(diaMax.Text));

               mAdapter.AddAsset(tool);

               this.Close();
          }

          private void Button2_Click(object sender, EventArgs e)
          {
               this.Close();
          }
     }
}
