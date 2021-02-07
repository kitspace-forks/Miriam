namespace Miriam
{
    partial class FormSettings
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.checkBoxEnableMelting = new System.Windows.Forms.CheckBox();
            this.panelMelting = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.CboxTolerance = new System.Windows.Forms.ComboBox();
            this.labelTempE = new System.Windows.Forms.Label();
            this.CboxTempE = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CboxInterval = new System.Windows.Forms.ComboBox();
            this.LabelTempU = new System.Windows.Forms.Label();
            this.LabelTempM = new System.Windows.Forms.Label();
            this.CboxTempU = new System.Windows.Forms.ComboBox();
            this.CboxTempM = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cBoxMesDuration = new System.Windows.Forms.ComboBox();
            this.cBoxMesInterval = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cBoxMesETemp = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cBoxMesThrTemp = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cBoxMesUTemp = new System.Windows.Forms.ComboBox();
            this.cBoxMesMTemp = new System.Windows.Forms.ComboBox();
            this.textBoxFnamePrefix = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonSaveAs = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.folderBrowserSaveRes = new System.Windows.Forms.FolderBrowserDialog();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.panelMelting.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(333, 382);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.AccessibleDescription = "Save settings and exit";
            this.buttonOk.Location = new System.Drawing.Point(252, 382);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // checkBoxEnableMelting
            // 
            this.checkBoxEnableMelting.AutoSize = true;
            this.checkBoxEnableMelting.Location = new System.Drawing.Point(25, 222);
            this.checkBoxEnableMelting.Name = "checkBoxEnableMelting";
            this.checkBoxEnableMelting.Size = new System.Drawing.Size(90, 17);
            this.checkBoxEnableMelting.TabIndex = 3;
            this.checkBoxEnableMelting.Text = "Melting curve";
            this.checkBoxEnableMelting.UseVisualStyleBackColor = true;
            this.checkBoxEnableMelting.CheckedChanged += new System.EventHandler(this.checkBoxEnableMelting_CheckedChanged);
            // 
            // panelMelting
            // 
            this.panelMelting.Controls.Add(this.label2);
            this.panelMelting.Controls.Add(this.CboxTolerance);
            this.panelMelting.Controls.Add(this.labelTempE);
            this.panelMelting.Controls.Add(this.CboxTempE);
            this.panelMelting.Controls.Add(this.label1);
            this.panelMelting.Controls.Add(this.CboxInterval);
            this.panelMelting.Controls.Add(this.LabelTempU);
            this.panelMelting.Controls.Add(this.LabelTempM);
            this.panelMelting.Controls.Add(this.CboxTempU);
            this.panelMelting.Controls.Add(this.CboxTempM);
            this.panelMelting.Enabled = false;
            this.panelMelting.Location = new System.Drawing.Point(10, 246);
            this.panelMelting.Name = "panelMelting";
            this.panelMelting.Size = new System.Drawing.Size(221, 159);
            this.panelMelting.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 120);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Tolerance [deg.]";
            // 
            // CboxTolerance
            // 
            this.CboxTolerance.FormattingEnabled = true;
            this.CboxTolerance.Location = new System.Drawing.Point(123, 117);
            this.CboxTolerance.Margin = new System.Windows.Forms.Padding(2);
            this.CboxTolerance.Name = "CboxTolerance";
            this.CboxTolerance.Size = new System.Drawing.Size(82, 21);
            this.CboxTolerance.TabIndex = 48;
            // 
            // labelTempE
            // 
            this.labelTempE.AutoSize = true;
            this.labelTempE.Location = new System.Drawing.Point(62, 65);
            this.labelTempE.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTempE.Name = "labelTempE";
            this.labelTempE.Size = new System.Drawing.Size(57, 13);
            this.labelTempE.TabIndex = 47;
            this.labelTempE.Text = "Extra temp";
            // 
            // CboxTempE
            // 
            this.CboxTempE.FormattingEnabled = true;
            this.CboxTempE.Location = new System.Drawing.Point(123, 62);
            this.CboxTempE.Margin = new System.Windows.Forms.Padding(2);
            this.CboxTempE.Name = "CboxTempE";
            this.CboxTempE.Size = new System.Drawing.Size(82, 21);
            this.CboxTempE.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 93);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Measure interval [s]";
            // 
            // CboxInterval
            // 
            this.CboxInterval.FormattingEnabled = true;
            this.CboxInterval.Location = new System.Drawing.Point(123, 90);
            this.CboxInterval.Margin = new System.Windows.Forms.Padding(2);
            this.CboxInterval.Name = "CboxInterval";
            this.CboxInterval.Size = new System.Drawing.Size(82, 21);
            this.CboxInterval.TabIndex = 44;
            // 
            // LabelTempU
            // 
            this.LabelTempU.AutoSize = true;
            this.LabelTempU.Location = new System.Drawing.Point(57, 37);
            this.LabelTempU.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelTempU.Name = "LabelTempU";
            this.LabelTempU.Size = new System.Drawing.Size(62, 13);
            this.LabelTempU.TabIndex = 43;
            this.LabelTempU.Text = "Upper temp";
            // 
            // LabelTempM
            // 
            this.LabelTempM.AutoSize = true;
            this.LabelTempM.Location = new System.Drawing.Point(55, 9);
            this.LabelTempM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelTempM.Name = "LabelTempM";
            this.LabelTempM.Size = new System.Drawing.Size(64, 13);
            this.LabelTempM.TabIndex = 42;
            this.LabelTempM.Text = "Middle temp";
            // 
            // CboxTempU
            // 
            this.CboxTempU.FormattingEnabled = true;
            this.CboxTempU.Location = new System.Drawing.Point(123, 34);
            this.CboxTempU.Margin = new System.Windows.Forms.Padding(2);
            this.CboxTempU.Name = "CboxTempU";
            this.CboxTempU.Size = new System.Drawing.Size(82, 21);
            this.CboxTempU.TabIndex = 41;
            // 
            // CboxTempM
            // 
            this.CboxTempM.FormattingEnabled = true;
            this.CboxTempM.Location = new System.Drawing.Point(123, 6);
            this.CboxTempM.Margin = new System.Windows.Forms.Padding(2);
            this.CboxTempM.Name = "CboxTempM";
            this.CboxTempM.Size = new System.Drawing.Size(82, 21);
            this.CboxTempM.TabIndex = 40;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cBoxMesDuration);
            this.panel1.Controls.Add(this.cBoxMesInterval);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cBoxMesETemp);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cBoxMesThrTemp);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cBoxMesUTemp);
            this.panel1.Controls.Add(this.cBoxMesMTemp);
            this.panel1.Location = new System.Drawing.Point(11, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 185);
            this.panel1.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 154);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 52;
            this.label8.Text = "Duration [min]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Box temp threshold";
            // 
            // cBoxMesDuration
            // 
            this.cBoxMesDuration.FormattingEnabled = true;
            this.cBoxMesDuration.Location = new System.Drawing.Point(123, 151);
            this.cBoxMesDuration.Margin = new System.Windows.Forms.Padding(2);
            this.cBoxMesDuration.Name = "cBoxMesDuration";
            this.cBoxMesDuration.Size = new System.Drawing.Size(82, 21);
            this.cBoxMesDuration.TabIndex = 50;
            // 
            // cBoxMesInterval
            // 
            this.cBoxMesInterval.FormattingEnabled = true;
            this.cBoxMesInterval.Location = new System.Drawing.Point(123, 122);
            this.cBoxMesInterval.Margin = new System.Windows.Forms.Padding(2);
            this.cBoxMesInterval.Name = "cBoxMesInterval";
            this.cBoxMesInterval.Size = new System.Drawing.Size(82, 21);
            this.cBoxMesInterval.TabIndex = 48;
            this.cBoxMesInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cBoxMesInterval_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 67);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "Extra temp";
            // 
            // cBoxMesETemp
            // 
            this.cBoxMesETemp.FormattingEnabled = true;
            this.cBoxMesETemp.Location = new System.Drawing.Point(123, 64);
            this.cBoxMesETemp.Margin = new System.Windows.Forms.Padding(2);
            this.cBoxMesETemp.Name = "cBoxMesETemp";
            this.cBoxMesETemp.Size = new System.Drawing.Size(82, 21);
            this.cBoxMesETemp.TabIndex = 46;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 125);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Measure interval [s]";
            // 
            // cBoxMesThrTemp
            // 
            this.cBoxMesThrTemp.FormatString = "N2";
            this.cBoxMesThrTemp.FormattingEnabled = true;
            this.cBoxMesThrTemp.Location = new System.Drawing.Point(123, 93);
            this.cBoxMesThrTemp.Margin = new System.Windows.Forms.Padding(2);
            this.cBoxMesThrTemp.Name = "cBoxMesThrTemp";
            this.cBoxMesThrTemp.Size = new System.Drawing.Size(82, 21);
            this.cBoxMesThrTemp.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 38);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Upper temp";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "Middle temp";
            // 
            // cBoxMesUTemp
            // 
            this.cBoxMesUTemp.FormattingEnabled = true;
            this.cBoxMesUTemp.Location = new System.Drawing.Point(123, 35);
            this.cBoxMesUTemp.Margin = new System.Windows.Forms.Padding(2);
            this.cBoxMesUTemp.Name = "cBoxMesUTemp";
            this.cBoxMesUTemp.Size = new System.Drawing.Size(82, 21);
            this.cBoxMesUTemp.TabIndex = 41;
            // 
            // cBoxMesMTemp
            // 
            this.cBoxMesMTemp.FormatString = "N2";
            this.cBoxMesMTemp.FormattingEnabled = true;
            this.cBoxMesMTemp.Location = new System.Drawing.Point(123, 6);
            this.cBoxMesMTemp.Margin = new System.Windows.Forms.Padding(2);
            this.cBoxMesMTemp.Name = "cBoxMesMTemp";
            this.cBoxMesMTemp.Size = new System.Drawing.Size(82, 21);
            this.cBoxMesMTemp.TabIndex = 40;
            // 
            // textBoxFnamePrefix
            // 
            this.textBoxFnamePrefix.Location = new System.Drawing.Point(266, 91);
            this.textBoxFnamePrefix.Name = "textBoxFnamePrefix";
            this.textBoxFnamePrefix.Size = new System.Drawing.Size(86, 20);
            this.textBoxFnamePrefix.TabIndex = 7;
            this.textBoxFnamePrefix.Text = "miriam";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(266, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Filename prefix:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(266, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Results storage folder:";
            // 
            // buttonSaveAs
            // 
            this.buttonSaveAs.Location = new System.Drawing.Point(490, 39);
            this.buttonSaveAs.Name = "buttonSaveAs";
            this.buttonSaveAs.Size = new System.Drawing.Size(28, 20);
            this.buttonSaveAs.TabIndex = 36;
            this.buttonSaveAs.Text = "...";
            this.buttonSaveAs.UseVisualStyleBackColor = true;
            this.buttonSaveAs.Click += new System.EventHandler(this.buttonSaveAs_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "Measurement settings";
            // 
            // folderBrowserSaveRes
            // 
            this.folderBrowserSaveRes.Description = "Select the directory to save the measurements data";
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.Location = new System.Drawing.Point(269, 39);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.ReadOnly = true;
            this.textBoxFolder.Size = new System.Drawing.Size(222, 20);
            this.textBoxFolder.TabIndex = 38;
            this.textBoxFolder.Text = "(results folder)";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 415);
            this.Controls.Add(this.textBoxFolder);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.buttonSaveAs);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxFnamePrefix);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelMelting);
            this.Controls.Add(this.checkBoxEnableMelting);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Name = "FormSettings";
            this.Text = "Miriam Settings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.panelMelting.ResumeLayout(false);
            this.panelMelting.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.CheckBox checkBoxEnableMelting;
        private System.Windows.Forms.Panel panelMelting;
        private System.Windows.Forms.Label labelTempE;
        private System.Windows.Forms.ComboBox CboxTempE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CboxInterval;
        private System.Windows.Forms.Label LabelTempU;
        private System.Windows.Forms.Label LabelTempM;
        private System.Windows.Forms.ComboBox CboxTempU;
        private System.Windows.Forms.ComboBox CboxTempM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CboxTolerance;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cBoxMesInterval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cBoxMesETemp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cBoxMesThrTemp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cBoxMesUTemp;
        private System.Windows.Forms.ComboBox cBoxMesMTemp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cBoxMesDuration;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxFnamePrefix;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonSaveAs;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserSaveRes;
        private System.Windows.Forms.TextBox textBoxFolder;
    }
}