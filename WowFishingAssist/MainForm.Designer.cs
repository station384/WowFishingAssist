namespace WowFishingAssist
{
    partial class MainForm
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
            this.pbViewPane = new System.Windows.Forms.PictureBox();
            this.buStartStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numDifferenceThreshold = new System.Windows.Forms.NumericUpDown();
            this.numPerBackgroundUpdate = new System.Windows.Forms.NumericUpDown();
            this.numMsPerBackgroupUpdate = new System.Windows.Forms.NumericUpDown();
            this.cbSuppressNoise = new System.Windows.Forms.CheckBox();
            this.buApplySettings = new System.Windows.Forms.Button();
            this.gbColorFilters = new System.Windows.Forms.GroupBox();
            this.rbGreyScaleFilter = new System.Windows.Forms.RadioButton();
            this.rbBlueFilter = new System.Windows.Forms.RadioButton();
            this.rbGreenFilter = new System.Windows.Forms.RadioButton();
            this.rbRedFilter = new System.Windows.Forms.RadioButton();
            this.rbNoFiltering = new System.Windows.Forms.RadioButton();
            this.lblWhoWroteIt = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSellJunk = new System.Windows.Forms.CheckBox();
            this.numMinBobClickTime = new System.Windows.Forms.NumericUpDown();
            this.numMaxBobClickTime = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbHerringLure = new System.Windows.Forms.CheckBox();
            this.lblCastCount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblLureTime = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numCastsBeforeSell = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.gbBaitType = new System.Windows.Forms.GroupBox();
            this.rbBait1ET = new System.Windows.Forms.RadioButton();
            this.cbUseBait = new System.Windows.Forms.CheckBox();
            this.frameCaptureRateMS = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.cbPointFishing = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbViewPane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDifferenceThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPerBackgroundUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMsPerBackgroupUpdate)).BeginInit();
            this.gbColorFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinBobClickTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxBobClickTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCastsBeforeSell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.gbBaitType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frameCaptureRateMS)).BeginInit();
            this.SuspendLayout();
            // 
            // pbViewPane
            // 
            this.pbViewPane.Location = new System.Drawing.Point(69, 18);
            this.pbViewPane.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbViewPane.Name = "pbViewPane";
            this.pbViewPane.Size = new System.Drawing.Size(628, 352);
            this.pbViewPane.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbViewPane.TabIndex = 0;
            this.pbViewPane.TabStop = false;
            // 
            // buStartStop
            // 
            this.buStartStop.Location = new System.Drawing.Point(464, 732);
            this.buStartStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buStartStop.Name = "buStartStop";
            this.buStartStop.Size = new System.Drawing.Size(112, 35);
            this.buStartStop.TabIndex = 1;
            this.buStartStop.Text = "Start";
            this.buStartStop.UseVisualStyleBackColor = true;
            this.buStartStop.Click += new System.EventHandler(this.buStartStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 385);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "DifferenceThreshold";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 423);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "FramesPerBackgroundUpdate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 463);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(257, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "MillisecondsPerBackgroundUpdate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(591, 618);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "SuppressNoise";
            // 
            // numDifferenceThreshold
            // 
            this.numDifferenceThreshold.Location = new System.Drawing.Point(278, 382);
            this.numDifferenceThreshold.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numDifferenceThreshold.Name = "numDifferenceThreshold";
            this.numDifferenceThreshold.Size = new System.Drawing.Size(74, 26);
            this.numDifferenceThreshold.TabIndex = 6;
            this.numDifferenceThreshold.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // numPerBackgroundUpdate
            // 
            this.numPerBackgroundUpdate.Location = new System.Drawing.Point(278, 420);
            this.numPerBackgroundUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numPerBackgroundUpdate.Name = "numPerBackgroundUpdate";
            this.numPerBackgroundUpdate.Size = new System.Drawing.Size(74, 26);
            this.numPerBackgroundUpdate.TabIndex = 7;
            this.numPerBackgroundUpdate.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numMsPerBackgroupUpdate
            // 
            this.numMsPerBackgroupUpdate.Location = new System.Drawing.Point(278, 460);
            this.numMsPerBackgroupUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numMsPerBackgroupUpdate.Name = "numMsPerBackgroupUpdate";
            this.numMsPerBackgroupUpdate.Size = new System.Drawing.Size(74, 26);
            this.numMsPerBackgroupUpdate.TabIndex = 8;
            this.numMsPerBackgroupUpdate.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // cbSuppressNoise
            // 
            this.cbSuppressNoise.AutoSize = true;
            this.cbSuppressNoise.Checked = true;
            this.cbSuppressNoise.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSuppressNoise.Location = new System.Drawing.Point(716, 618);
            this.cbSuppressNoise.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbSuppressNoise.Name = "cbSuppressNoise";
            this.cbSuppressNoise.Size = new System.Drawing.Size(22, 21);
            this.cbSuppressNoise.TabIndex = 9;
            this.cbSuppressNoise.UseVisualStyleBackColor = true;
            // 
            // buApplySettings
            // 
            this.buApplySettings.Location = new System.Drawing.Point(238, 731);
            this.buApplySettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buApplySettings.Name = "buApplySettings";
            this.buApplySettings.Size = new System.Drawing.Size(112, 35);
            this.buApplySettings.TabIndex = 10;
            this.buApplySettings.Text = "Apply";
            this.buApplySettings.UseVisualStyleBackColor = true;
            this.buApplySettings.Click += new System.EventHandler(this.buApplySettings_Click);
            // 
            // gbColorFilters
            // 
            this.gbColorFilters.Controls.Add(this.rbGreyScaleFilter);
            this.gbColorFilters.Controls.Add(this.rbBlueFilter);
            this.gbColorFilters.Controls.Add(this.rbGreenFilter);
            this.gbColorFilters.Controls.Add(this.rbRedFilter);
            this.gbColorFilters.Controls.Add(this.rbNoFiltering);
            this.gbColorFilters.Location = new System.Drawing.Point(585, 386);
            this.gbColorFilters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbColorFilters.Name = "gbColorFilters";
            this.gbColorFilters.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbColorFilters.Size = new System.Drawing.Size(180, 217);
            this.gbColorFilters.TabIndex = 15;
            this.gbColorFilters.TabStop = false;
            this.gbColorFilters.Text = "Color Filters";
            // 
            // rbGreyScaleFilter
            // 
            this.rbGreyScaleFilter.AutoSize = true;
            this.rbGreyScaleFilter.Location = new System.Drawing.Point(10, 177);
            this.rbGreyScaleFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbGreyScaleFilter.Name = "rbGreyScaleFilter";
            this.rbGreyScaleFilter.Size = new System.Drawing.Size(112, 24);
            this.rbGreyScaleFilter.TabIndex = 4;
            this.rbGreyScaleFilter.TabStop = true;
            this.rbGreyScaleFilter.Text = "Grey Scale";
            this.rbGreyScaleFilter.UseVisualStyleBackColor = true;
            // 
            // rbBlueFilter
            // 
            this.rbBlueFilter.AutoSize = true;
            this.rbBlueFilter.Location = new System.Drawing.Point(10, 142);
            this.rbBlueFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbBlueFilter.Name = "rbBlueFilter";
            this.rbBlueFilter.Size = new System.Drawing.Size(129, 24);
            this.rbBlueFilter.TabIndex = 3;
            this.rbBlueFilter.TabStop = true;
            this.rbBlueFilter.Text = "Blue Channel";
            this.rbBlueFilter.UseVisualStyleBackColor = true;
            // 
            // rbGreenFilter
            // 
            this.rbGreenFilter.AutoSize = true;
            this.rbGreenFilter.Location = new System.Drawing.Point(10, 105);
            this.rbGreenFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbGreenFilter.Name = "rbGreenFilter";
            this.rbGreenFilter.Size = new System.Drawing.Size(142, 24);
            this.rbGreenFilter.TabIndex = 2;
            this.rbGreenFilter.TabStop = true;
            this.rbGreenFilter.Text = "Green Channel";
            this.rbGreenFilter.UseVisualStyleBackColor = true;
            // 
            // rbRedFilter
            // 
            this.rbRedFilter.AutoSize = true;
            this.rbRedFilter.Location = new System.Drawing.Point(10, 68);
            this.rbRedFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbRedFilter.Name = "rbRedFilter";
            this.rbRedFilter.Size = new System.Drawing.Size(127, 24);
            this.rbRedFilter.TabIndex = 1;
            this.rbRedFilter.TabStop = true;
            this.rbRedFilter.Text = "Red Channel";
            this.rbRedFilter.UseVisualStyleBackColor = true;
            // 
            // rbNoFiltering
            // 
            this.rbNoFiltering.AutoSize = true;
            this.rbNoFiltering.Checked = true;
            this.rbNoFiltering.Location = new System.Drawing.Point(10, 31);
            this.rbNoFiltering.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbNoFiltering.Name = "rbNoFiltering";
            this.rbNoFiltering.Size = new System.Drawing.Size(100, 24);
            this.rbNoFiltering.TabIndex = 0;
            this.rbNoFiltering.TabStop = true;
            this.rbNoFiltering.Text = "Full Color";
            this.rbNoFiltering.UseVisualStyleBackColor = true;
            // 
            // lblWhoWroteIt
            // 
            this.lblWhoWroteIt.AutoSize = true;
            this.lblWhoWroteIt.Location = new System.Drawing.Point(14, 748);
            this.lblWhoWroteIt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWhoWroteIt.Name = "lblWhoWroteIt";
            this.lblWhoWroteIt.Size = new System.Drawing.Size(137, 20);
            this.lblWhoWroteIt.TabIndex = 16;
            this.lblWhoWroteIt.Text = "By Michael Sutton";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 720);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Wow Fishing Assist";
            // 
            // cbSellJunk
            // 
            this.cbSellJunk.AutoSize = true;
            this.cbSellJunk.Location = new System.Drawing.Point(438, 386);
            this.cbSellJunk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbSellJunk.Name = "cbSellJunk";
            this.cbSellJunk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbSellJunk.Size = new System.Drawing.Size(94, 24);
            this.cbSellJunk.TabIndex = 18;
            this.cbSellJunk.Text = "Sell junk";
            this.cbSellJunk.UseVisualStyleBackColor = true;
            // 
            // numMinBobClickTime
            // 
            this.numMinBobClickTime.Location = new System.Drawing.Point(278, 532);
            this.numMinBobClickTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numMinBobClickTime.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numMinBobClickTime.Name = "numMinBobClickTime";
            this.numMinBobClickTime.Size = new System.Drawing.Size(74, 26);
            this.numMinBobClickTime.TabIndex = 19;
            this.numMinBobClickTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinBobClickTime.ValueChanged += new System.EventHandler(this.numMinBobClickTime_ValueChanged);
            // 
            // numMaxBobClickTime
            // 
            this.numMaxBobClickTime.Location = new System.Drawing.Point(278, 572);
            this.numMaxBobClickTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numMaxBobClickTime.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numMaxBobClickTime.Name = "numMaxBobClickTime";
            this.numMaxBobClickTime.Size = new System.Drawing.Size(74, 26);
            this.numMaxBobClickTime.TabIndex = 20;
            this.numMaxBobClickTime.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMaxBobClickTime.ValueChanged += new System.EventHandler(this.numMaxBobClickTime_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 535);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(203, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Minimum Bobber Click Time";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 575);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(207, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "Maximum Bobber Click Time";
            // 
            // cbHerringLure
            // 
            this.cbHerringLure.AutoSize = true;
            this.cbHerringLure.Location = new System.Drawing.Point(378, 422);
            this.cbHerringLure.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbHerringLure.Name = "cbHerringLure";
            this.cbHerringLure.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbHerringLure.Size = new System.Drawing.Size(156, 24);
            this.cbHerringLure.TabIndex = 23;
            this.cbHerringLure.Text = "Use Herring Lure";
            this.cbHerringLure.UseVisualStyleBackColor = true;
            this.cbHerringLure.CheckedChanged += new System.EventHandler(this.cbHerringLure_CheckedChanged);
            // 
            // lblCastCount
            // 
            this.lblCastCount.AutoEllipsis = true;
            this.lblCastCount.Location = new System.Drawing.Point(117, 692);
            this.lblCastCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCastCount.Name = "lblCastCount";
            this.lblCastCount.Size = new System.Drawing.Size(78, 28);
            this.lblCastCount.TabIndex = 24;
            this.lblCastCount.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 692);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "Cast:Junk";
            // 
            // lblLureTime
            // 
            this.lblLureTime.AutoEllipsis = true;
            this.lblLureTime.Location = new System.Drawing.Point(370, 692);
            this.lblLureTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLureTime.Name = "lblLureTime";
            this.lblLureTime.Size = new System.Drawing.Size(78, 28);
            this.lblLureTime.TabIndex = 26;
            this.lblLureTime.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(273, 692);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 20);
            this.label10.TabIndex = 27;
            this.label10.Text = "Lure Cast";
            // 
            // numCastsBeforeSell
            // 
            this.numCastsBeforeSell.Location = new System.Drawing.Point(278, 652);
            this.numCastsBeforeSell.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numCastsBeforeSell.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCastsBeforeSell.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numCastsBeforeSell.Name = "numCastsBeforeSell";
            this.numCastsBeforeSell.Size = new System.Drawing.Size(74, 26);
            this.numCastsBeforeSell.TabIndex = 28;
            this.numCastsBeforeSell.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numCastsBeforeSell.ValueChanged += new System.EventHandler(this.numCastsBeforeSell_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(96, 654);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 20);
            this.label8.TabIndex = 29;
            this.label8.Text = "Sell Junk Cast Count";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(44, 615);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(187, 20);
            this.label11.TabIndex = 31;
            this.label11.Text = "Time to Hold Mouse Click";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(278, 612);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(74, 26);
            this.numericUpDown1.TabIndex = 30;
            this.numericUpDown1.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // gbBaitType
            // 
            this.gbBaitType.Controls.Add(this.rbBait1ET);
            this.gbBaitType.Enabled = false;
            this.gbBaitType.Location = new System.Drawing.Point(375, 555);
            this.gbBaitType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbBaitType.Name = "gbBaitType";
            this.gbBaitType.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbBaitType.Size = new System.Drawing.Size(201, 101);
            this.gbBaitType.TabIndex = 32;
            this.gbBaitType.TabStop = false;
            this.gbBaitType.Text = "Bait Type";
            // 
            // rbBait1ET
            // 
            this.rbBait1ET.AutoSize = true;
            this.rbBait1ET.Checked = true;
            this.rbBait1ET.Location = new System.Drawing.Point(9, 28);
            this.rbBait1ET.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbBait1ET.Name = "rbBait1ET";
            this.rbBait1ET.Size = new System.Drawing.Size(133, 24);
            this.rbBait1ET.TabIndex = 5;
            this.rbBait1ET.TabStop = true;
            this.rbBait1ET.Text = "Elysian Thade";
            this.rbBait1ET.UseVisualStyleBackColor = true;
            // 
            // cbUseBait
            // 
            this.cbUseBait.AutoSize = true;
            this.cbUseBait.Location = new System.Drawing.Point(438, 457);
            this.cbUseBait.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbUseBait.Name = "cbUseBait";
            this.cbUseBait.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbUseBait.Size = new System.Drawing.Size(96, 24);
            this.cbUseBait.TabIndex = 33;
            this.cbUseBait.Text = "Use Bait";
            this.cbUseBait.UseVisualStyleBackColor = true;
            this.cbUseBait.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // frameCaptureRateMS
            // 
            this.frameCaptureRateMS.Location = new System.Drawing.Point(277, 495);
            this.frameCaptureRateMS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.frameCaptureRateMS.Name = "frameCaptureRateMS";
            this.frameCaptureRateMS.Size = new System.Drawing.Size(74, 26);
            this.frameCaptureRateMS.TabIndex = 34;
            this.frameCaptureRateMS.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.frameCaptureRateMS.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(111, 498);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(155, 20);
            this.label12.TabIndex = 35;
            this.label12.Text = "Frame Capture Rate";
            this.label12.Visible = false;
            // 
            // cbPointFishing
            // 
            this.cbPointFishing.AutoSize = true;
            this.cbPointFishing.Location = new System.Drawing.Point(408, 491);
            this.cbPointFishing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbPointFishing.Name = "cbPointFishing";
            this.cbPointFishing.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbPointFishing.Size = new System.Drawing.Size(126, 24);
            this.cbPointFishing.TabIndex = 36;
            this.cbPointFishing.Text = "Point Fishing";
            this.cbPointFishing.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 785);
            this.Controls.Add(this.cbPointFishing);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.frameCaptureRateMS);
            this.Controls.Add(this.cbUseBait);
            this.Controls.Add(this.gbBaitType);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numCastsBeforeSell);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblLureTime);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblCastCount);
            this.Controls.Add(this.cbHerringLure);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numMaxBobClickTime);
            this.Controls.Add(this.numMinBobClickTime);
            this.Controls.Add(this.cbSellJunk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblWhoWroteIt);
            this.Controls.Add(this.gbColorFilters);
            this.Controls.Add(this.buApplySettings);
            this.Controls.Add(this.cbSuppressNoise);
            this.Controls.Add(this.numMsPerBackgroupUpdate);
            this.Controls.Add(this.numPerBackgroundUpdate);
            this.Controls.Add(this.numDifferenceThreshold);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buStartStop);
            this.Controls.Add(this.pbViewPane);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Wow Fishing Assist";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbViewPane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDifferenceThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPerBackgroundUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMsPerBackgroupUpdate)).EndInit();
            this.gbColorFilters.ResumeLayout(false);
            this.gbColorFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinBobClickTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxBobClickTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCastsBeforeSell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.gbBaitType.ResumeLayout(false);
            this.gbBaitType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frameCaptureRateMS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbViewPane;
        private System.Windows.Forms.Button buStartStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numDifferenceThreshold;
        private System.Windows.Forms.NumericUpDown numPerBackgroundUpdate;
        private System.Windows.Forms.NumericUpDown numMsPerBackgroupUpdate;
        private System.Windows.Forms.CheckBox cbSuppressNoise;
        private System.Windows.Forms.Button buApplySettings;
        private System.Windows.Forms.GroupBox gbColorFilters;
        private System.Windows.Forms.RadioButton rbBlueFilter;
        private System.Windows.Forms.RadioButton rbGreenFilter;
        private System.Windows.Forms.RadioButton rbRedFilter;
        private System.Windows.Forms.RadioButton rbNoFiltering;
        private System.Windows.Forms.RadioButton rbGreyScaleFilter;
        private System.Windows.Forms.Label lblWhoWroteIt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbSellJunk;
        private System.Windows.Forms.NumericUpDown numMinBobClickTime;
        private System.Windows.Forms.NumericUpDown numMaxBobClickTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbHerringLure;
        private System.Windows.Forms.Label lblCastCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblLureTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numCastsBeforeSell;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.GroupBox gbBaitType;
        private System.Windows.Forms.RadioButton rbBait1ET;
        private System.Windows.Forms.CheckBox cbUseBait;
        private System.Windows.Forms.NumericUpDown frameCaptureRateMS;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox cbPointFishing;
    }
}

