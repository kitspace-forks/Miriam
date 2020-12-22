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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label_results_folder = new System.Windows.Forms.Label();
            this.buttonSaveAs = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
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
            this.panel1.Controls.Add(this.comboBox7);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBox3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.comboBox4);
            this.panel1.Controls.Add(this.comboBox5);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(11, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 185);
            this.panel1.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(123, 122);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(82, 21);
            this.comboBox1.TabIndex = 48;
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
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(123, 64);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(82, 21);
            this.comboBox2.TabIndex = 46;
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
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(123, 93);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(82, 21);
            this.comboBox3.TabIndex = 44;
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
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(123, 35);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(82, 21);
            this.comboBox4.TabIndex = 41;
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(123, 6);
            this.comboBox5.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(82, 21);
            this.comboBox5.TabIndex = 40;
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(123, 151);
            this.comboBox7.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(82, 21);
            this.comboBox7.TabIndex = 50;
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(266, 91);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(86, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "miriam";
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
            // label_results_folder
            // 
            this.label_results_folder.AutoSize = true;
            this.label_results_folder.Location = new System.Drawing.Point(266, 45);
            this.label_results_folder.Name = "label_results_folder";
            this.label_results_folder.Size = new System.Drawing.Size(75, 13);
            this.label_results_folder.TabIndex = 10;
            this.label_results_folder.Text = "(results_folder)";
            // 
            // buttonSaveAs
            // 
            this.buttonSaveAs.Location = new System.Drawing.Point(380, 12);
            this.buttonSaveAs.Name = "buttonSaveAs";
            this.buttonSaveAs.Size = new System.Drawing.Size(28, 29);
            this.buttonSaveAs.TabIndex = 36;
            this.buttonSaveAs.Text = "...";
            this.buttonSaveAs.UseVisualStyleBackColor = true;
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
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 415);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.buttonSaveAs);
            this.Controls.Add(this.label_results_folder);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox1);
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label_results_folder;
        private System.Windows.Forms.Button buttonSaveAs;
        private System.Windows.Forms.Label label11;
    }
}