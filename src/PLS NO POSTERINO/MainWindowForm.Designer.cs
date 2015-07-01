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
            this.tbxPasswordReal = new System.Windows.Forms.MaskedTextBox();
            this.tbxPassword = new System.Windows.Forms.MaskedTextBox();
            this.lvTitlesToBlock = new System.Windows.Forms.ListView();
            this.gbxSetup = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numAutoModeSeconds = new System.Windows.Forms.NumericUpDown();
            this.chbxAutoMode = new System.Windows.Forms.CheckBox();
            this.chbxActive = new System.Windows.Forms.CheckBox();
            this.cbxTitleKind = new System.Windows.Forms.ComboBox();
            this.btnAddCurrentProcess = new System.Windows.Forms.Button();
            this.btnAddTitle = new System.Windows.Forms.Button();
            this.tbxTitle = new System.Windows.Forms.TextBox();
            this.btnPasswordOk = new System.Windows.Forms.Button();
            this.btnPasswordReal = new System.Windows.Forms.Button();
            this.gbxSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoModeSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxPasswordReal
            // 
            this.tbxPasswordReal.Location = new System.Drawing.Point(84, 19);
            this.tbxPasswordReal.Name = "tbxPasswordReal";
            this.tbxPasswordReal.Size = new System.Drawing.Size(100, 20);
            this.tbxPasswordReal.TabIndex = 0;
            this.tbxPasswordReal.UseSystemPasswordChar = true;
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(173, 255);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(100, 20);
            this.tbxPassword.TabIndex = 1;
            this.tbxPassword.UseSystemPasswordChar = true;
            // 
            // lvTitlesToBlock
            // 
            this.lvTitlesToBlock.Location = new System.Drawing.Point(198, 19);
            this.lvTitlesToBlock.Name = "lvTitlesToBlock";
            this.lvTitlesToBlock.Size = new System.Drawing.Size(181, 97);
            this.lvTitlesToBlock.TabIndex = 2;
            this.lvTitlesToBlock.UseCompatibleStateImageBehavior = false;
            // 
            // gbxSetup
            // 
            this.gbxSetup.Controls.Add(this.btnPasswordReal);
            this.gbxSetup.Controls.Add(this.label1);
            this.gbxSetup.Controls.Add(this.numAutoModeSeconds);
            this.gbxSetup.Controls.Add(this.chbxAutoMode);
            this.gbxSetup.Controls.Add(this.chbxActive);
            this.gbxSetup.Controls.Add(this.cbxTitleKind);
            this.gbxSetup.Controls.Add(this.btnAddCurrentProcess);
            this.gbxSetup.Controls.Add(this.btnAddTitle);
            this.gbxSetup.Controls.Add(this.tbxTitle);
            this.gbxSetup.Controls.Add(this.lvTitlesToBlock);
            this.gbxSetup.Controls.Add(this.tbxPasswordReal);
            this.gbxSetup.Location = new System.Drawing.Point(12, 12);
            this.gbxSetup.Name = "gbxSetup";
            this.gbxSetup.Size = new System.Drawing.Size(385, 201);
            this.gbxSetup.TabIndex = 3;
            this.gbxSetup.TabStop = false;
            this.gbxSetup.Text = "Setup";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Password";
            // 
            // numAutoModeSeconds
            // 
            this.numAutoModeSeconds.Location = new System.Drawing.Point(108, 173);
            this.numAutoModeSeconds.Name = "numAutoModeSeconds";
            this.numAutoModeSeconds.Size = new System.Drawing.Size(58, 20);
            this.numAutoModeSeconds.TabIndex = 9;
            // 
            // chbxAutoMode
            // 
            this.chbxAutoMode.AutoSize = true;
            this.chbxAutoMode.Location = new System.Drawing.Point(25, 176);
            this.chbxAutoMode.Name = "chbxAutoMode";
            this.chbxAutoMode.Size = new System.Drawing.Size(77, 17);
            this.chbxAutoMode.TabIndex = 8;
            this.chbxAutoMode.Text = "Auto mode";
            this.chbxAutoMode.UseVisualStyleBackColor = true;
            this.chbxAutoMode.CheckedChanged += new System.EventHandler(this.chbxAutoMode_CheckedChanged);
            // 
            // chbxActive
            // 
            this.chbxActive.AutoSize = true;
            this.chbxActive.Location = new System.Drawing.Point(25, 153);
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
            this.cbxTitleKind.Size = new System.Drawing.Size(100, 21);
            this.cbxTitleKind.TabIndex = 6;
            this.cbxTitleKind.Text = "Contains";
            // 
            // btnAddCurrentProcess
            // 
            this.btnAddCurrentProcess.Location = new System.Drawing.Point(84, 122);
            this.btnAddCurrentProcess.Name = "btnAddCurrentProcess";
            this.btnAddCurrentProcess.Size = new System.Drawing.Size(108, 23);
            this.btnAddCurrentProcess.TabIndex = 5;
            this.btnAddCurrentProcess.Text = "Current Proces";
            this.btnAddCurrentProcess.UseVisualStyleBackColor = true;
            this.btnAddCurrentProcess.Click += new System.EventHandler(this.btnAddCurrentProcess_Click);
            // 
            // btnAddTitle
            // 
            this.btnAddTitle.Location = new System.Drawing.Point(304, 149);
            this.btnAddTitle.Name = "btnAddTitle";
            this.btnAddTitle.Size = new System.Drawing.Size(75, 23);
            this.btnAddTitle.TabIndex = 4;
            this.btnAddTitle.Text = "Add";
            this.btnAddTitle.UseVisualStyleBackColor = true;
            this.btnAddTitle.Click += new System.EventHandler(this.btnAddTitle_Click);
            // 
            // tbxTitle
            // 
            this.tbxTitle.Location = new System.Drawing.Point(198, 124);
            this.tbxTitle.Name = "tbxTitle";
            this.tbxTitle.Size = new System.Drawing.Size(100, 20);
            this.tbxTitle.TabIndex = 3;
            this.tbxTitle.Text = "Facebook";
            // 
            // btnPasswordOk
            // 
            this.btnPasswordOk.Location = new System.Drawing.Point(279, 253);
            this.btnPasswordOk.Name = "btnPasswordOk";
            this.btnPasswordOk.Size = new System.Drawing.Size(75, 23);
            this.btnPasswordOk.TabIndex = 11;
            this.btnPasswordOk.Text = "OK";
            this.btnPasswordOk.UseVisualStyleBackColor = true;
            this.btnPasswordOk.Click += new System.EventHandler(this.btnPasswordOk_Click);
            // 
            // btnPasswordReal
            // 
            this.btnPasswordReal.Location = new System.Drawing.Point(108, 45);
            this.btnPasswordReal.Name = "btnPasswordReal";
            this.btnPasswordReal.Size = new System.Drawing.Size(75, 23);
            this.btnPasswordReal.TabIndex = 12;
            this.btnPasswordReal.Text = "OK";
            this.btnPasswordReal.UseVisualStyleBackColor = true;
            this.btnPasswordReal.Click += new System.EventHandler(this.btnPasswordReal_Click);
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 309);
            this.Controls.Add(this.btnPasswordOk);
            this.Controls.Add(this.gbxSetup);
            this.Controls.Add(this.tbxPassword);
            this.Name = "MainWindowForm";
            this.Text = "PLS NO POSTERINO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindowForm_Load);
            this.gbxSetup.ResumeLayout(false);
            this.gbxSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoModeSeconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox tbxPasswordReal;
        private System.Windows.Forms.MaskedTextBox tbxPassword;
        private System.Windows.Forms.ListView lvTitlesToBlock;
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
    }
}

