namespace Laba1_Object_
{
    partial class Object
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Object));
            this.bStop = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.chSimulation = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Xin1Low_button = new System.Windows.Forms.Button();
            this.Xin1High_button4 = new System.Windows.Forms.Button();
            this.lblInput1 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.tmSimulation = new System.Windows.Forms.Timer(this.components);
            this.bReset = new System.Windows.Forms.Button();
            this.Xin1_label = new System.Windows.Forms.Label();
            this.Gout_label = new System.Windows.Forms.Label();
            this.bSpeedUp = new System.Windows.Forms.Button();
            this.Xin2_label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Set_button = new System.Windows.Forms.Button();
            this.Td_label = new System.Windows.Forms.Label();
            this.Ti_label = new System.Windows.Forms.Label();
            this.Kp_label = new System.Windows.Forms.Label();
            this.Td_textBox = new System.Windows.Forms.TextBox();
            this.Ti_textBox = new System.Windows.Forms.TextBox();
            this.Kp_textBox = new System.Windows.Forms.TextBox();
            this.autoValue_textBox = new System.Windows.Forms.TextBox();
            this.isManual_checkBox = new System.Windows.Forms.CheckBox();
            this.SecondRegConf_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chSimulation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bStop
            // 
            this.bStop.Location = new System.Drawing.Point(9, 41);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(75, 23);
            this.bStop.TabIndex = 15;
            this.bStop.Text = "Stop";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(9, 12);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 14;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // chSimulation
            // 
            chartArea1.Name = "ChartArea1";
            this.chSimulation.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chSimulation.Legends.Add(legend1);
            this.chSimulation.Location = new System.Drawing.Point(90, 210);
            this.chSimulation.Name = "chSimulation";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chSimulation.Series.Add(series1);
            this.chSimulation.Size = new System.Drawing.Size(687, 289);
            this.chSimulation.TabIndex = 10;
            this.chSimulation.Text = "chart1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(90, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(687, 174);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // Xin1Low_button
            // 
            this.Xin1Low_button.Location = new System.Drawing.Point(309, 15);
            this.Xin1Low_button.Name = "Xin1Low_button";
            this.Xin1Low_button.Size = new System.Drawing.Size(46, 23);
            this.Xin1Low_button.TabIndex = 22;
            this.Xin1Low_button.Text = "-";
            this.Xin1Low_button.UseVisualStyleBackColor = true;
            this.Xin1Low_button.Visible = false;
            this.Xin1Low_button.Click += new System.EventHandler(this.button3_Click);
            // 
            // Xin1High_button4
            // 
            this.Xin1High_button4.Location = new System.Drawing.Point(309, 41);
            this.Xin1High_button4.Name = "Xin1High_button4";
            this.Xin1High_button4.Size = new System.Drawing.Size(46, 23);
            this.Xin1High_button4.TabIndex = 21;
            this.Xin1High_button4.Text = "+";
            this.Xin1High_button4.UseVisualStyleBackColor = true;
            this.Xin1High_button4.Visible = false;
            this.Xin1High_button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblInput1
            // 
            this.lblInput1.AutoSize = true;
            this.lblInput1.Location = new System.Drawing.Point(324, 67);
            this.lblInput1.Name = "lblInput1";
            this.lblInput1.Size = new System.Drawing.Size(31, 13);
            this.lblInput1.TabIndex = 26;
            this.lblInput1.Text = "Input";
            this.lblInput1.Click += new System.EventHandler(this.lblInput1_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(392, 80);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(37, 13);
            this.lblResult.TabIndex = 25;
            this.lblResult.Text = "Result";
            // 
            // tmSimulation
            // 
            this.tmSimulation.Tick += new System.EventHandler(this.tmSimulation_Tick);
            // 
            // bReset
            // 
            this.bReset.Location = new System.Drawing.Point(9, 99);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(75, 23);
            this.bReset.TabIndex = 29;
            this.bReset.Text = "Reset";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // Xin1_label
            // 
            this.Xin1_label.AutoSize = true;
            this.Xin1_label.Location = new System.Drawing.Point(275, 41);
            this.Xin1_label.Name = "Xin1_label";
            this.Xin1_label.Size = new System.Drawing.Size(28, 13);
            this.Xin1_label.TabIndex = 30;
            this.Xin1_label.Text = "Xin1";
            // 
            // Gout_label
            // 
            this.Gout_label.AutoSize = true;
            this.Gout_label.Location = new System.Drawing.Point(519, 164);
            this.Gout_label.Name = "Gout_label";
            this.Gout_label.Size = new System.Drawing.Size(30, 13);
            this.Gout_label.TabIndex = 32;
            this.Gout_label.Text = "Gout";
            this.Gout_label.Click += new System.EventHandler(this.label3_Click);
            // 
            // bSpeedUp
            // 
            this.bSpeedUp.Location = new System.Drawing.Point(9, 70);
            this.bSpeedUp.Name = "bSpeedUp";
            this.bSpeedUp.Size = new System.Drawing.Size(75, 23);
            this.bSpeedUp.TabIndex = 16;
            this.bSpeedUp.Text = "x10";
            this.bSpeedUp.UseVisualStyleBackColor = true;
            this.bSpeedUp.Click += new System.EventHandler(this.bSpeedUp_Click);
            // 
            // Xin2_label
            // 
            this.Xin2_label.AutoSize = true;
            this.Xin2_label.Location = new System.Drawing.Point(275, 122);
            this.Xin2_label.Name = "Xin2_label";
            this.Xin2_label.Size = new System.Drawing.Size(28, 13);
            this.Xin2_label.TabIndex = 33;
            this.Xin2_label.Text = "Xin2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(309, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(309, 122);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 23);
            this.button2.TabIndex = 35;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Input";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Set_button
            // 
            this.Set_button.Location = new System.Drawing.Point(108, 58);
            this.Set_button.Name = "Set_button";
            this.Set_button.Size = new System.Drawing.Size(40, 23);
            this.Set_button.TabIndex = 54;
            this.Set_button.Text = "Set";
            this.Set_button.UseVisualStyleBackColor = true;
            this.Set_button.Click += new System.EventHandler(this.Set_button_Click);
            // 
            // Td_label
            // 
            this.Td_label.AutoSize = true;
            this.Td_label.Location = new System.Drawing.Point(117, 147);
            this.Td_label.Name = "Td_label";
            this.Td_label.Size = new System.Drawing.Size(20, 13);
            this.Td_label.TabIndex = 53;
            this.Td_label.Text = "Td";
            // 
            // Ti_label
            // 
            this.Ti_label.AutoSize = true;
            this.Ti_label.Location = new System.Drawing.Point(117, 121);
            this.Ti_label.Name = "Ti_label";
            this.Ti_label.Size = new System.Drawing.Size(16, 13);
            this.Ti_label.TabIndex = 52;
            this.Ti_label.Text = "Ti";
            // 
            // Kp_label
            // 
            this.Kp_label.AutoSize = true;
            this.Kp_label.Location = new System.Drawing.Point(117, 91);
            this.Kp_label.Name = "Kp_label";
            this.Kp_label.Size = new System.Drawing.Size(20, 13);
            this.Kp_label.TabIndex = 51;
            this.Kp_label.Text = "Kp";
            // 
            // Td_textBox
            // 
            this.Td_textBox.Location = new System.Drawing.Point(139, 140);
            this.Td_textBox.Name = "Td_textBox";
            this.Td_textBox.Size = new System.Drawing.Size(100, 20);
            this.Td_textBox.TabIndex = 50;
            // 
            // Ti_textBox
            // 
            this.Ti_textBox.Location = new System.Drawing.Point(139, 114);
            this.Ti_textBox.Name = "Ti_textBox";
            this.Ti_textBox.Size = new System.Drawing.Size(100, 20);
            this.Ti_textBox.TabIndex = 49;
            // 
            // Kp_textBox
            // 
            this.Kp_textBox.Location = new System.Drawing.Point(139, 88);
            this.Kp_textBox.Name = "Kp_textBox";
            this.Kp_textBox.Size = new System.Drawing.Size(100, 20);
            this.Kp_textBox.TabIndex = 48;
            // 
            // autoValue_textBox
            // 
            this.autoValue_textBox.Location = new System.Drawing.Point(154, 60);
            this.autoValue_textBox.Name = "autoValue_textBox";
            this.autoValue_textBox.Size = new System.Drawing.Size(100, 20);
            this.autoValue_textBox.TabIndex = 47;
            this.autoValue_textBox.Text = "30";
            // 
            // isManual_checkBox
            // 
            this.isManual_checkBox.AutoSize = true;
            this.isManual_checkBox.Location = new System.Drawing.Point(175, 37);
            this.isManual_checkBox.Name = "isManual_checkBox";
            this.isManual_checkBox.Size = new System.Drawing.Size(48, 17);
            this.isManual_checkBox.TabIndex = 46;
            this.isManual_checkBox.Text = "Auto";
            this.isManual_checkBox.UseVisualStyleBackColor = true;
            this.isManual_checkBox.CheckedChanged += new System.EventHandler(this.isManual_checkBox_CheckedChanged_1);
            // 
            // SecondRegConf_label
            // 
            this.SecondRegConf_label.AutoSize = true;
            this.SecondRegConf_label.Location = new System.Drawing.Point(635, 37);
            this.SecondRegConf_label.Name = "SecondRegConf_label";
            this.SecondRegConf_label.Size = new System.Drawing.Size(74, 13);
            this.SecondRegConf_label.TabIndex = 55;
            this.SecondRegConf_label.Text = "Optimal config";
            // 
            // Object
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 484);
            this.Controls.Add(this.SecondRegConf_label);
            this.Controls.Add(this.Set_button);
            this.Controls.Add(this.Td_label);
            this.Controls.Add(this.Ti_label);
            this.Controls.Add(this.Kp_label);
            this.Controls.Add(this.Td_textBox);
            this.Controls.Add(this.Ti_textBox);
            this.Controls.Add(this.Kp_textBox);
            this.Controls.Add(this.autoValue_textBox);
            this.Controls.Add(this.isManual_checkBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Xin2_label);
            this.Controls.Add(this.Gout_label);
            this.Controls.Add(this.Xin1_label);
            this.Controls.Add(this.bReset);
            this.Controls.Add(this.lblInput1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.Xin1Low_button);
            this.Controls.Add(this.Xin1High_button4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bSpeedUp);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.chSimulation);
            this.Name = "Object";
            this.Text = "Object";
            ((System.ComponentModel.ISupportInitialize)(this.chSimulation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chSimulation;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Xin1Low_button;
        private System.Windows.Forms.Button Xin1High_button4;
        private System.Windows.Forms.Label lblInput1;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Timer tmSimulation;
        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.Label Xin1_label;
        private System.Windows.Forms.Label Gout_label;
        private System.Windows.Forms.Button bSpeedUp;
        private System.Windows.Forms.Label Xin2_label;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Set_button;
        private System.Windows.Forms.Label Td_label;
        private System.Windows.Forms.Label Ti_label;
        private System.Windows.Forms.Label Kp_label;
        private System.Windows.Forms.TextBox Td_textBox;
        private System.Windows.Forms.TextBox Ti_textBox;
        private System.Windows.Forms.TextBox Kp_textBox;
        private System.Windows.Forms.TextBox autoValue_textBox;
        private System.Windows.Forms.CheckBox isManual_checkBox;
        private System.Windows.Forms.Label SecondRegConf_label;
    }
}