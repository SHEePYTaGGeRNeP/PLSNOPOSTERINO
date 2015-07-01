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
            InitializeComponent();
            _processWindowHandler = ProcessWindowHandler.Instance;
            _processWindowHandler.OnAutoModeStarted += delegate { SetActive(); };
            this.LoadUserInterface();
        }

        private void LoadUserInterface()
        {
            cbxTitleKind.Items.Clear();
            cbxTitleKind.Items.AddRange(H.ConvertAllTitleKindToString());
            cbxTitleKind.SelectedIndex = 1;
            this.WindowState = FormWindowState.Maximized;
        }


        private void MainWindowForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }
            else
                notifyIcon1.Visible = false;
        }

        private void MainWindow_FormClosing(object pSender, FormClosingEventArgs pE)
        {
            if (_processWindowHandler.IsActive)
            {
                pE.Cancel = true;
                _processWindowHandler.StartBleepThread();
            }
        }

        #endregion

        #region - - - - - - - -   E V E N T H A N D L E R S   - - - - - - - -

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void btnSetFormWindow_Click(object sender, System.EventArgs e)
        {
            _processWindowHandler.FormWindow = NativeWin32.GetActiveProcessWindow();
            gbxSetup.Enabled = true;
            btnSetFormWindow.Enabled = false;
            btnSetFormWindow.Visible = false;
        }

        private void btnPasswordReal_Click(object sender, System.EventArgs e)
        {
            if (String.IsNullOrEmpty(tbxPasswordReal.Text))
                MessageBox.Show("Password cannot be empty", "Empty password", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            else
                _processWindowHandler.Password = tbxPasswordReal.Text;
        }

        private void btnAddTitle_Click(object sender, System.EventArgs e)
        {
            if (String.IsNullOrEmpty(tbxTitle.Text))
                return;
            TitlesToBlock lvTtb = new TitlesToBlock(tbxTitle.Text, H.ConvertKindStringToKind(cbxTitleKind.SelectedItem.ToString()));
            _processWindowHandler.ListTitlesToBlocks.Add(lvTtb);
            lbTriggeredTitles.Items.Add(lvTtb.ToString());
            tbxTitle.Clear();
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
            if (chbxActive.Checked)
                if (!SetActive())
                    chbxActive.Checked = false;
        }

        private void chbxAutoMode_CheckedChanged(object sender, System.EventArgs e)
        {
            if (String.IsNullOrEmpty(_processWindowHandler.Password))
            {
                MessageBox.Show("Password cannot be empty", "Empty password", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                chbxAutoMode.Checked = false;
            }
            else
                _processWindowHandler.SetAutoModusActive(chbxAutoMode.Checked);
        }

        private void btnPasswordOk_Click(object sender, System.EventArgs e)
        {
            // returns IsActive
            if (!_processWindowHandler.CheckPassword(tbxPassword.Text))
            {
                chbxActive.Checked = false;
                gbxSetup.Enabled = true;
            }
            tbxPassword.Clear();
        }
        /// <summary>
        /// Refresh rate to set current process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numRefreshRate_ValueChanged(object sender, EventArgs e)
        {
            _processWindowHandler.ListeningTimer.Interval = (int)numRefreshRate.Value;
        }
        private void numAutoModeSeconds_ValueChanged(object sender, EventArgs e)
        {
            _processWindowHandler.AutoModeAfkInMs = (int)numAutoModeSeconds.Value;
        }
        private void numAFKRate_ValueChanged(object sender, EventArgs e)
        {
            _processWindowHandler.AfkCheckTimer.Interval = (int)numAFKRate.Value * 1000;
        }

        #endregion

        private bool SetActive()
        {
            if (_processWindowHandler.SetActive(true))
            {
                gbxSetup.Enabled = false;
                return true;
            }
            MessageBox.Show("Password cannot be empty", "Empty password", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return false;
            // Password is used to enabled groupbox
        }

    }
}
