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
            this.labelTempE = new System.Windows.Forms.Label();
            this.CboxTempE = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CboxInterval = new System.Windows.Forms.ComboBox();
            this.LabelTempU = new System.Windows.Forms.Label();
            this.LabelTempM = new System.Windows.Forms.Label();
            this.CboxTempU = new System.Windows.Forms.ComboBox();
            this.CboxTempM = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CboxTolerance = new System.Windows.Forms.ComboBox();
            this.panelMelting.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(713, 415);
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
            this.buttonOk.Location = new System.Drawing.Point(632, 415);
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
            this.checkBoxEnableMelting.Location = new System.Drawing.Point(27, 21);
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
            this.panelMelting.Location = new System.Drawing.Point(12, 45);
            this.panelMelting.Name = "panelMelting";
            this.panelMelting.Size = new System.Drawing.Size(221, 159);
            this.panelMelting.TabIndex = 4;
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
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelMelting);
            this.Controls.Add(this.checkBoxEnableMelting);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Name = "FormSettings";
            this.Text = "Miriam Settings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.panelMelting.ResumeLayout(false);
            this.panelMelting.PerformLayout();
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
    }
}