namespace AdapterLab
{
    partial class CuttingToolForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.description = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.manufacturers = new System.Windows.Forms.TextBox();
            this.assetId = new System.Windows.Forms.TextBox();
            this.toolId = new System.Windows.Forms.TextBox();
            this.serialNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lifeTypeLabel = new System.Windows.Forms.Label();
            this.lifeType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lifeDirection = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lifeInitial = new System.Windows.Forms.TextBox();
            this.lifeLimit = new System.Windows.Forms.TextBox();
            this.lifeValue = new System.Windows.Forms.TextBox();
            this.statusNew = new System.Windows.Forms.CheckBox();
            this.statusUsed = new System.Windows.Forms.CheckBox();
            this.statusMeasured = new System.Windows.Forms.CheckBox();
            this.statusAllocated = new System.Windows.Forms.CheckBox();
            this.statusBroken = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.speed = new System.Windows.Forms.TextBox();
            this.speedMin = new System.Windows.Forms.TextBox();
            this.speedNominal = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.speedMax = new System.Windows.Forms.TextBox();
            this.diaMax = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.diaVal = new System.Windows.Forms.TextBox();
            this.diaMin = new System.Windows.Forms.TextBox();
            this.diaNom = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lengthMax = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lengthVal = new System.Windows.Forms.TextBox();
            this.lengthMin = new System.Windows.Forms.TextBox();
            this.lengthNom = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(314, 446);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 100;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(233, 446);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 101;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.description);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.manufacturers);
            this.groupBox1.Controls.Add(this.assetId);
            this.groupBox1.Controls.Add(this.toolId);
            this.groupBox1.Controls.Add(this.serialNumber);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 95);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Identity";
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(90, 66);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(280, 20);
            this.description.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Description";
            // 
            // manufacturers
            // 
            this.manufacturers.Location = new System.Drawing.Point(90, 41);
            this.manufacturers.Name = "manufacturers";
            this.manufacturers.Size = new System.Drawing.Size(100, 20);
            this.manufacturers.TabIndex = 3;
            // 
            // assetId
            // 
            this.assetId.Location = new System.Drawing.Point(90, 14);
            this.assetId.Name = "assetId";
            this.assetId.Size = new System.Drawing.Size(100, 20);
            this.assetId.TabIndex = 1;
            // 
            // toolId
            // 
            this.toolId.Location = new System.Drawing.Point(270, 40);
            this.toolId.Name = "toolId";
            this.toolId.Size = new System.Drawing.Size(100, 20);
            this.toolId.TabIndex = 4;
            // 
            // serialNumber
            // 
            this.serialNumber.Location = new System.Drawing.Point(270, 13);
            this.serialNumber.Name = "serialNumber";
            this.serialNumber.Size = new System.Drawing.Size(100, 20);
            this.serialNumber.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(196, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tool Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Manufacturers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Serial Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asset Id";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lifeValue);
            this.groupBox2.Controls.Add(this.lifeLimit);
            this.groupBox2.Controls.Add(this.lifeInitial);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lifeDirection);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lifeType);
            this.groupBox2.Controls.Add(this.lifeTypeLabel);
            this.groupBox2.Location = new System.Drawing.Point(13, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(376, 68);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Life";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.statusBroken);
            this.groupBox3.Controls.Add(this.statusAllocated);
            this.groupBox3.Controls.Add(this.statusMeasured);
            this.groupBox3.Controls.Add(this.statusUsed);
            this.groupBox3.Controls.Add(this.statusNew);
            this.groupBox3.Location = new System.Drawing.Point(12, 114);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(377, 45);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.lengthMax);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.lengthVal);
            this.groupBox4.Controls.Add(this.lengthMin);
            this.groupBox4.Controls.Add(this.lengthNom);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.diaMax);
            this.groupBox4.Controls.Add(this.diaVal);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.diaMin);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.diaNom);
            this.groupBox4.Location = new System.Drawing.Point(12, 309);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(377, 117);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Measurements";
            // 
            // lifeTypeLabel
            // 
            this.lifeTypeLabel.AutoSize = true;
            this.lifeTypeLabel.Location = new System.Drawing.Point(7, 16);
            this.lifeTypeLabel.Name = "lifeTypeLabel";
            this.lifeTypeLabel.Size = new System.Drawing.Size(31, 13);
            this.lifeTypeLabel.TabIndex = 10;
            this.lifeTypeLabel.Text = "Type";
            // 
            // lifeType
            // 
            this.lifeType.FormattingEnabled = true;
            this.lifeType.Items.AddRange(new object[] {
            "MINUTES",
            "PART_COUNT",
            "WEAR"});
            this.lifeType.Location = new System.Drawing.Point(44, 13);
            this.lifeType.Name = "lifeType";
            this.lifeType.Size = new System.Drawing.Size(121, 21);
            this.lifeType.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(171, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Direction";
            // 
            // lifeDirection
            // 
            this.lifeDirection.FormattingEnabled = true;
            this.lifeDirection.Items.AddRange(new object[] {
            "UP",
            "DOWN"});
            this.lifeDirection.Location = new System.Drawing.Point(227, 13);
            this.lifeDirection.Name = "lifeDirection";
            this.lifeDirection.Size = new System.Drawing.Size(121, 21);
            this.lifeDirection.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Initial";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(134, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Limit";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(254, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Value";
            // 
            // lifeInitial
            // 
            this.lifeInitial.Location = new System.Drawing.Point(44, 40);
            this.lifeInitial.Name = "lifeInitial";
            this.lifeInitial.Size = new System.Drawing.Size(75, 20);
            this.lifeInitial.TabIndex = 3;
            // 
            // lifeLimit
            // 
            this.lifeLimit.Location = new System.Drawing.Point(168, 40);
            this.lifeLimit.Name = "lifeLimit";
            this.lifeLimit.Size = new System.Drawing.Size(75, 20);
            this.lifeLimit.TabIndex = 4;
            // 
            // lifeValue
            // 
            this.lifeValue.Location = new System.Drawing.Point(294, 39);
            this.lifeValue.Name = "lifeValue";
            this.lifeValue.ShortcutsEnabled = false;
            this.lifeValue.Size = new System.Drawing.Size(75, 20);
            this.lifeValue.TabIndex = 5;
            // 
            // statusNew
            // 
            this.statusNew.AutoSize = true;
            this.statusNew.Location = new System.Drawing.Point(11, 20);
            this.statusNew.Name = "statusNew";
            this.statusNew.Size = new System.Drawing.Size(48, 17);
            this.statusNew.TabIndex = 0;
            this.statusNew.Text = "New";
            this.statusNew.UseVisualStyleBackColor = true;
            // 
            // statusUsed
            // 
            this.statusUsed.AutoSize = true;
            this.statusUsed.Location = new System.Drawing.Point(65, 20);
            this.statusUsed.Name = "statusUsed";
            this.statusUsed.Size = new System.Drawing.Size(51, 17);
            this.statusUsed.TabIndex = 1;
            this.statusUsed.Text = "Used";
            this.statusUsed.UseVisualStyleBackColor = true;
            // 
            // statusMeasured
            // 
            this.statusMeasured.AutoSize = true;
            this.statusMeasured.Location = new System.Drawing.Point(122, 20);
            this.statusMeasured.Name = "statusMeasured";
            this.statusMeasured.Size = new System.Drawing.Size(73, 17);
            this.statusMeasured.TabIndex = 2;
            this.statusMeasured.Text = "Measured";
            this.statusMeasured.UseVisualStyleBackColor = true;
            // 
            // statusAllocated
            // 
            this.statusAllocated.AutoSize = true;
            this.statusAllocated.Location = new System.Drawing.Point(197, 20);
            this.statusAllocated.Name = "statusAllocated";
            this.statusAllocated.Size = new System.Drawing.Size(70, 17);
            this.statusAllocated.TabIndex = 3;
            this.statusAllocated.Text = "Allocated";
            this.statusAllocated.UseVisualStyleBackColor = true;
            // 
            // statusBroken
            // 
            this.statusBroken.AutoSize = true;
            this.statusBroken.Location = new System.Drawing.Point(271, 20);
            this.statusBroken.Name = "statusBroken";
            this.statusBroken.Size = new System.Drawing.Size(60, 17);
            this.statusBroken.TabIndex = 4;
            this.statusBroken.Text = "Broken";
            this.statusBroken.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.speedMax);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.speed);
            this.groupBox5.Controls.Add(this.speedMin);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.speedNominal);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Location = new System.Drawing.Point(12, 243);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(377, 60);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Properties";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Process Spindle Speed";
            // 
            // speed
            // 
            this.speed.Location = new System.Drawing.Point(327, 32);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(43, 20);
            this.speed.TabIndex = 4;
            // 
            // speedMin
            // 
            this.speedMin.Location = new System.Drawing.Point(155, 32);
            this.speedMin.Name = "speedMin";
            this.speedMin.Size = new System.Drawing.Size(40, 20);
            this.speedMin.TabIndex = 2;
            // 
            // speedNominal
            // 
            this.speedNominal.Location = new System.Drawing.Point(57, 32);
            this.speedNominal.Name = "speedNominal";
            this.speedNominal.Size = new System.Drawing.Size(41, 20);
            this.speedNominal.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(287, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Value";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(101, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Minimum";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Nominal";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(201, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(27, 13);
            this.label14.TabIndex = 25;
            this.label14.Text = "Max";
            // 
            // speedMax
            // 
            this.speedMax.Location = new System.Drawing.Point(241, 32);
            this.speedMax.Name = "speedMax";
            this.speedMax.Size = new System.Drawing.Size(40, 20);
            this.speedMax.TabIndex = 3;
            // 
            // diaMax
            // 
            this.diaMax.Location = new System.Drawing.Point(241, 86);
            this.diaMax.Name = "diaMax";
            this.diaMax.Size = new System.Drawing.Size(40, 20);
            this.diaMax.TabIndex = 7;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(201, 89);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(27, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "Max";
            // 
            // diaVal
            // 
            this.diaVal.Location = new System.Drawing.Point(327, 86);
            this.diaVal.Name = "diaVal";
            this.diaVal.Size = new System.Drawing.Size(43, 20);
            this.diaVal.TabIndex = 8;
            // 
            // diaMin
            // 
            this.diaMin.Location = new System.Drawing.Point(155, 86);
            this.diaMin.Name = "diaMin";
            this.diaMin.Size = new System.Drawing.Size(40, 20);
            this.diaMin.TabIndex = 6;
            // 
            // diaNom
            // 
            this.diaNom.Location = new System.Drawing.Point(57, 86);
            this.diaNom.Name = "diaNom";
            this.diaNom.Size = new System.Drawing.Size(41, 20);
            this.diaNom.TabIndex = 5;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 89);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 13);
            this.label16.TabIndex = 28;
            this.label16.Text = "Nominal";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(287, 89);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 13);
            this.label17.TabIndex = 30;
            this.label17.Text = "Value";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(101, 89);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 13);
            this.label18.TabIndex = 29;
            this.label18.Text = "Minimum";
            // 
            // lengthMax
            // 
            this.lengthMax.Location = new System.Drawing.Point(241, 41);
            this.lengthMax.Name = "lengthMax";
            this.lengthMax.Size = new System.Drawing.Size(40, 20);
            this.lengthMax.TabIndex = 3;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(201, 44);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(27, 13);
            this.label19.TabIndex = 41;
            this.label19.Text = "Max";
            // 
            // lengthVal
            // 
            this.lengthVal.Location = new System.Drawing.Point(327, 41);
            this.lengthVal.Name = "lengthVal";
            this.lengthVal.Size = new System.Drawing.Size(43, 20);
            this.lengthVal.TabIndex = 4;
            // 
            // lengthMin
            // 
            this.lengthMin.Location = new System.Drawing.Point(155, 41);
            this.lengthMin.Name = "lengthMin";
            this.lengthMin.Size = new System.Drawing.Size(40, 20);
            this.lengthMin.TabIndex = 2;
            // 
            // lengthNom
            // 
            this.lengthNom.Location = new System.Drawing.Point(57, 41);
            this.lengthNom.Name = "lengthNom";
            this.lengthNom.Size = new System.Drawing.Size(41, 20);
            this.lengthNom.TabIndex = 1;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 44);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(45, 13);
            this.label20.TabIndex = 36;
            this.label20.Text = "Nominal";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(287, 44);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(34, 13);
            this.label21.TabIndex = 38;
            this.label21.Text = "Value";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(101, 44);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 13);
            this.label22.TabIndex = 37;
            this.label22.Text = "Minimum";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(7, 25);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(90, 13);
            this.label23.TabIndex = 27;
            this.label23.Text = "Functiona Length";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 66);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(49, 13);
            this.label24.TabIndex = 43;
            this.label24.Text = "Diameter";
            // 
            // CuttingTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 481);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "CuttingTool";
            this.Text = "Cutting Tool";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox manufacturers;
        private System.Windows.Forms.TextBox assetId;
        private System.Windows.Forms.TextBox toolId;
        private System.Windows.Forms.TextBox serialNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lifeTypeLabel;
        private System.Windows.Forms.ComboBox lifeType;
        private System.Windows.Forms.ComboBox lifeDirection;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox lifeValue;
        private System.Windows.Forms.TextBox lifeLimit;
        private System.Windows.Forms.TextBox lifeInitial;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox statusAllocated;
        private System.Windows.Forms.CheckBox statusMeasured;
        private System.Windows.Forms.CheckBox statusUsed;
        private System.Windows.Forms.CheckBox statusNew;
        private System.Windows.Forms.CheckBox statusBroken;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox speedMax;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox speed;
        private System.Windows.Forms.TextBox speedMin;
        private System.Windows.Forms.TextBox speedNominal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox lengthMax;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox lengthVal;
        private System.Windows.Forms.TextBox lengthMin;
        private System.Windows.Forms.TextBox lengthNom;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox diaMax;
        private System.Windows.Forms.TextBox diaVal;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox diaMin;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox diaNom;
    }
}