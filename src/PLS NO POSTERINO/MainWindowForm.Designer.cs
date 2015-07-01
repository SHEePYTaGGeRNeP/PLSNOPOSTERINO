namespace PLS_NO_POSTERINO
{
    partial class MainWindowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindowForm));
            this.tbxPasswordReal = new System.Windows.Forms.MaskedTextBox();
            this.tbxPassword = new System.Windows.Forms.MaskedTextBox();
            this.gbxSetup = new System.Windows.Forms.GroupBox();
            this.lbTriggeredTitles = new System.Windows.Forms.ListBox();
            this.btnPasswordReal = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numAutoModeSeconds = new System.Windows.Forms.NumericUpDown();
            this.chbxAutoMode = new System.Windows.Forms.CheckBox();
            this.chbxActive = new System.Windows.Forms.CheckBox();
            this.cbxTitleKind = new System.Windows.Forms.ComboBox();
            this.btnAddCurrentProcess = new System.Windows.Forms.Button();
            this.btnAddTitle = new System.Windows.Forms.Button();
            this.tbxTitle = new System.Windows.Forms.TextBox();
            this.btnPasswordOk = new System.Windows.Forms.Button();
            this.btnSetFormWindow = new System.Windows.Forms.Button();
            this.numRefreshRate = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numAFKRate = new System.Windows.Forms.NumericUpDown();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.gbxSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoModeSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRefreshRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAFKRate)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxPasswordReal
            // 
            this.tbxPasswordReal.Location = new System.Drawing.Point(75, 19);
            this.tbxPasswordReal.Name = "tbxPasswordReal";
            this.tbxPasswordReal.Size = new System.Drawing.Size(100, 20);
            this.tbxPasswordReal.TabIndex = 0;
            this.tbxPasswordReal.UseSystemPasswordChar = true;
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(132, 374);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(100, 20);
            this.tbxPassword.TabIndex = 1;
            this.tbxPassword.UseSystemPasswordChar = true;
            // 
            // gbxSetup
            // 
            this.gbxSetup.Controls.Add(this.label3);
            this.gbxSetup.Controls.Add(this.numAFKRate);
            this.gbxSetup.Controls.Add(this.label2);
            this.gbxSetup.Controls.Add(this.numRefreshRate);
            this.gbxSetup.Controls.Add(this.lbTriggeredTitles);
            this.gbxSetup.Controls.Add(this.btnPasswordReal);
            this.gbxSetup.Controls.Add(this.label1);
            this.gbxSetup.Controls.Add(this.numAutoModeSeconds);
            this.gbxSetup.Controls.Add(this.chbxAutoMode);
            this.gbxSetup.Controls.Add(this.chbxActive);
            this.gbxSetup.Controls.Add(this.cbxTitleKind);
            this.gbxSetup.Controls.Add(this.btnAddCurrentProcess);
            this.gbxSetup.Controls.Add(this.btnAddTitle);
            this.gbxSetup.Controls.Add(this.tbxTitle);
            this.gbxSetup.Controls.Add(this.tbxPasswordReal);
            this.gbxSetup.Enabled = false;
            this.gbxSetup.Location = new System.Drawing.Point(12, 40);
            this.gbxSetup.Name = "gbxSetup";
            this.gbxSetup.Size = new System.Drawing.Size(434, 314);
            this.gbxSetup.TabIndex = 3;
            this.gbxSetup.TabStop = false;
            this.gbxSetup.Text = "Setup";
            // 
            // lbTriggeredTitles
            // 
            this.lbTriggeredTitles.FormattingEnabled = true;
            this.lbTriggeredTitles.Location = new System.Drawing.Point(198, 19);
            this.lbTriggeredTitles.Name = "lbTriggeredTitles";
            this.lbTriggeredTitles.Size = new System.Drawing.Size(230, 95);
            this.lbTriggeredTitles.TabIndex = 13;
            // 
            // btnPasswordReal
            // 
            this.btnPasswordReal.Location = new System.Drawing.Point(75, 45);
            this.btnPasswordReal.Name = "btnPasswordReal";
            this.btnPasswordReal.Size = new System.Drawing.Size(99, 23);
            this.btnPasswordReal.TabIndex = 12;
            this.btnPasswordReal.Text = "Set password";
            this.btnPasswordReal.UseVisualStyleBackColor = true;
            this.btnPasswordReal.Click += new System.EventHandler(this.btnPasswordReal_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Password";
            // 
            // numAutoModeSeconds
            // 
            this.numAutoModeSeconds.Location = new System.Drawing.Point(370, 266);
            this.numAutoModeSeconds.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numAutoModeSeconds.Name = "numAutoModeSeconds";
            this.numAutoModeSeconds.Size = new System.Drawing.Size(58, 20);
            this.numAutoModeSeconds.TabIndex = 9;
            this.numAutoModeSeconds.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numAutoModeSeconds.ValueChanged += new System.EventHandler(this.numAutoModeSeconds_ValueChanged);
            // 
            // chbxAutoMode
            // 
            this.chbxAutoMode.AutoSize = true;
            this.chbxAutoMode.Location = new System.Drawing.Point(210, 267);
            this.chbxAutoMode.Name = "chbxAutoMode";
            this.chbxAutoMode.Size = new System.Drawing.Size(161, 17);
            this.chbxAutoMode.TabIndex = 8;
            this.chbxAutoMode.Text = "Auto mode after AFK for (ms)";
            this.chbxAutoMode.UseVisualStyleBackColor = true;
            this.chbxAutoMode.CheckedChanged += new System.EventHandler(this.chbxAutoMode_CheckedChanged);
            // 
            // chbxActive
            // 
            this.chbxActive.AutoSize = true;
            this.chbxActive.Location = new System.Drawing.Point(16, 291);
            this.chbxActive.Name = "chbxActive";
            this.chbxActive.Size = new System.Drawing.Size(56, 17);
            this.chbxActive.TabIndex = 7;
            this.chbxActive.Text = "Active";
            this.chbxActive.UseVisualStyleBackColor = true;
            this.chbxActive.CheckedChanged += new System.EventHandler(this.chbxActive_CheckedChanged);
            // 
            // cbxTitleKind
            // 
            this.cbxTitleKind.FormattingEnabled = true;
            this.cbxTitleKind.Location = new System.Drawing.Point(198, 151);
            this.cbxTitleKind.Name = "cbxTitleKind";
            this.cbxTitleKind.Size = new System.Drawing.Size(132, 21);
            this.cbxTitleKind.TabIndex = 6;
            this.cbxTitleKind.Text = "Contains";
            // 
            // btnAddCurrentProcess
            // 
            this.btnAddCurrentProcess.Location = new System.Drawing.Point(84, 122);
            this.btnAddCurrentProcess.Name = "btnAddCurrentProcess";
            this.btnAddCurrentProcess.Size = new System.Drawing.Size(108, 23);
            this.btnAddCurrentProcess.TabIndex = 5;
            this.btnAddCurrentProcess.Text = "Select Process";
            this.btnAddCurrentProcess.UseVisualStyleBackColor = true;
            this.btnAddCurrentProcess.Click += new System.EventHandler(this.btnAddCurrentProcess_Click);
            // 
            // btnAddTitle
            // 
            this.btnAddTitle.Location = new System.Drawing.Point(353, 149);
            this.btnAddTitle.Name = "btnAddTitle";
            this.btnAddTitle.Size = new System.Drawing.Size(75, 23);
            this.btnAddTitle.TabIndex = 4;
            this.btnAddTitle.Text = "Add";
            this.btnAddTitle.UseVisualStyleBackColor = true;
            this.btnAddTitle.Click += new System.EventHandler(this.btnAddTitle_Click);
            // 
            // tbxTitle
            // 
            this.tbxTitle.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.tbxTitle.Location = new System.Drawing.Point(198, 124);
            this.tbxTitle.Name = "tbxTitle";
            this.tbxTitle.Size = new System.Drawing.Size(230, 20);
            this.tbxTitle.TabIndex = 3;
            this.tbxTitle.Text = "facebook";
            // 
            // btnPasswordOk
            // 
            this.btnPasswordOk.Location = new System.Drawing.Point(238, 372);
            this.btnPasswordOk.Name = "btnPasswordOk";
            this.btnPasswordOk.Size = new System.Drawing.Size(75, 23);
            this.btnPasswordOk.TabIndex = 11;
            this.btnPasswordOk.Text = "OK";
            this.btnPasswordOk.UseVisualStyleBackColor = true;
            this.btnPasswordOk.Click += new System.EventHandler(this.btnPasswordOk_Click);
            // 
            // btnSetFormWindow
            // 
            this.btnSetFormWindow.Location = new System.Drawing.Point(12, 11);
            this.btnSetFormWindow.Name = "btnSetFormWindow";
            this.btnSetFormWindow.Size = new System.Drawing.Size(75, 23);
            this.btnSetFormWindow.TabIndex = 13;
            this.btnSetFormWindow.Text = "Set Window";
            this.btnSetFormWindow.UseVisualStyleBackColor = true;
            this.btnSetFormWindow.Click += new System.EventHandler(this.btnSetFormWindow_Click);
            // 
            // numRefreshRate
            // 
            this.numRefreshRate.Location = new System.Drawing.Point(107, 267);
            this.numRefreshRate.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numRefreshRate.Name = "numRefreshRate";
            this.numRefreshRate.Size = new System.Drawing.Size(58, 20);
            this.numRefreshRate.TabIndex = 15;
            this.numRefreshRate.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numRefreshRate.ValueChanged += new System.EventHandler(this.numRefreshRate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Refresh rate (ms)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(207, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Check user away rate (ms)";
            // 
            // numAFKRate
            // 
            this.numAFKRate.Location = new System.Drawing.Point(370, 235);
            this.numAFKRate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numAFKRate.Name = "numAFKRate";
            this.numAFKRate.Size = new System.Drawing.Size(58, 20);
            this.numAFKRate.TabIndex = 17;
            this.numAFKRate.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numAFKRate.ValueChanged += new System.EventHandler(this.numAFKRate_ValueChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "Double Click to open";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "PLS NO POSTERINO";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 445);
            this.Controls.Add(this.btnSetFormWindow);
            this.Controls.Add(this.btnPasswordOk);
            this.Controls.Add(this.gbxSetup);
            this.Controls.Add(this.tbxPassword);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindowForm";
            this.Text = "PLS NO POSTERINO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Resize += new System.EventHandler(this.MainWindowForm_Resize);
            this.gbxSetup.ResumeLayout(false);
            this.gbxSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoModeSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRefreshRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAFKRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox tbxPasswordReal;
        private System.Windows.Forms.MaskedTextBox tbxPassword;
        private System.Windows.Forms.GroupBox gbxSetup;
        private System.Windows.Forms.ComboBox cbxTitleKind;
        private System.Windows.Forms.Button btnAddCurrentProcess;
        private System.Windows.Forms.Button btnAddTitle;
        private System.Windows.Forms.TextBox tbxTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numAutoModeSeconds;
        private System.Windows.Forms.CheckBox chbxAutoMode;
        private System.Windows.Forms.CheckBox chbxActive;
        private System.Windows.Forms.Button btnPasswordOk;
        private System.Windows.Forms.Button btnPasswordReal;
        private System.Windows.Forms.Button btnSetFormWindow;
        private System.Windows.Forms.ListBox lbTriggeredTitles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numRefreshRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numAFKRate;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

