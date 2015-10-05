using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PLS_NO_POSTERINO.Classes;

namespace PLS_NO_POSTERINO
{
    public partial class MainWindowForm : Form
    {

        private readonly ProcessWindowHandler _processWindowHandler;

        #region - - - - - - - -   I N I T I A L I Z E   - - - - - - - -

        public MainWindowForm()
        {
            new ProcessWindowHandler(this);
            this.InitializeComponent();
            this._processWindowHandler = ProcessWindowHandler.Instance;
            this._processWindowHandler.OnAutoModeStarted += delegate { SetActive(); };
            this.LoadUserInterface();
        }

        private void LoadUserInterface()
        {
            this.cbxTitleKind.Items.Clear();
            this.cbxTitleKind.Items.AddRange(H.ConvertAllTitleKindToString());
            this.cbxTitleKind.SelectedIndex = 1;
            this.WindowState = FormWindowState.Maximized;
        }


        private void MainWindowForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.notifyIcon1.Visible = true;
                this.notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }
            else
                this.notifyIcon1.Visible = false;
        }

        private void MainWindow_FormClosing(object pSender, FormClosingEventArgs pE)
        {
            if (this._processWindowHandler.IsActive)
            {
                pE.Cancel = true;
                this._processWindowHandler.StartBleepThread();
            }
        }

        #endregion

        #region - - - - - - - -   E V E N T H A N D L E R S   - - - - - - - -

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.notifyIcon1.Visible = false;
        }

        private void btnSetFormWindow_Click(object sender, System.EventArgs e)
        {
            this._processWindowHandler.FormWindow = NativeWin32.GetActiveProcessWindow();
            this.gbxSetup.Enabled = true;
            this.btnSetFormWindow.Enabled = false;
            this.btnSetFormWindow.Visible = false;
        }

        private void btnPasswordReal_Click(object sender, System.EventArgs e)
        {
            if (String.IsNullOrEmpty(this.tbxPasswordReal.Text))
                MessageBox.Show("Password cannot be empty", "Empty password", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            else
                this._processWindowHandler.Password = this.tbxPasswordReal.Text;
        }

        private void btnAddTitle_Click(object sender, System.EventArgs e)
        {
            if (String.IsNullOrEmpty(this.tbxTitle.Text))
                return;
            TitlesToBlock lvTtb = new TitlesToBlock(this.tbxTitle.Text, H.ConvertKindStringToKind(this.cbxTitleKind.SelectedItem.ToString()));
            this._processWindowHandler.ListTitlesToBlocks.Add(lvTtb);
            this.lbTriggeredTitles.Items.Add(lvTtb.ToString());
            this.tbxTitle.Clear();
        }

        private void btnAddCurrentProcess_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("After you click OK, you have 3 seconds to select the process", "Select process",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Timer lvSelectProcessTimer = new Timer();
            lvSelectProcessTimer.Tick += delegate
            {
                tbxTitle.Text = NativeWin32.GetActiveProcessWindow().Title;
                lvSelectProcessTimer.Stop();
                lvSelectProcessTimer.Dispose();
            };
            lvSelectProcessTimer.Interval = 3000;
            lvSelectProcessTimer.Start();
        }

        private void chbxActive_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.chbxActive.Checked)
                if (!this.SetActive())
                    this.chbxActive.Checked = false;
        }

        private void chbxAutoMode_CheckedChanged(object sender, System.EventArgs e)
        {
            if (String.IsNullOrEmpty(this._processWindowHandler.Password))
            {
                MessageBox.Show("Password cannot be empty", "Empty password", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                this.chbxAutoMode.Checked = false;
            }
            else
                this._processWindowHandler.SetAutoModusActive(this.chbxAutoMode.Checked);
        }

        private void btnPasswordOk_Click(object sender, System.EventArgs e)
        {
            // returns IsActive
            if (!this._processWindowHandler.CheckPassword(this.tbxPassword.Text))
            {
                this.chbxActive.Checked = false;
                this.gbxSetup.Enabled = true;
            }
            this.tbxPassword.Clear();
            this.chbxAutoMode.Checked = false;
        }
        /// <summary>
        /// Refresh rate to set current process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numRefreshRate_ValueChanged(object sender, EventArgs e)
        {
            this._processWindowHandler.ListeningTimer.Interval = (int)this.numRefreshRate.Value;
        }
        private void numAutoModeSeconds_ValueChanged(object sender, EventArgs e)
        {
            this._processWindowHandler.AutoModeAfkInMs = (int)this.numAutoModeSeconds.Value;
        }
        private void numAFKRate_ValueChanged(object sender, EventArgs e)
        {
            this._processWindowHandler.AfkCheckTimer.Interval = (int)this.numAFKRate.Value * 1000;
        }

        #endregion

        private bool SetActive()
        {
            if (this._processWindowHandler.SetActive(true))
            {
                this.gbxSetup.Enabled = false;
                return true;
            }
            MessageBox.Show("Password cannot be empty", "Empty password", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return false;
            // Password is used to enabled groupbox
        }

        private void numWaitForPassword_ValueChanged(object sender, EventArgs e)
        {
            this._processWindowHandler.WaitForPassword = (int)this.numWaitForPassword.Value;
        }

        private void chbxLock_CheckedChanged(object sender, EventArgs e)
        {
            this._processWindowHandler.LockPc = this.chbxLock.Checked;
        }
    }
}
