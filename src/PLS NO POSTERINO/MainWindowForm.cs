using System.Collections.Generic;
using System.Windows.Forms;
using PLS_NO_POSTERINO.Classes;

namespace PLS_NO_POSTERINO
{
    public partial class MainWindowForm : Form
    {

        private ProcessWindowHandler _processWindowHandler;

        #region - - - - - - - -   I N I T I A L I Z E   - - - - - - - -

        public MainWindowForm()
        {
            InitializeComponent();
            _processWindowHandler = ProcessWindowHandler.Instance;
            this.LoadUserInterface();
        }

        public MainWindowForm(string pPassword, IEnumerable<TitlesToBlock> pBlockList)
        {
            _processWindowHandler.ListTitlesToBlocks =new List<TitlesToBlock>(pBlockList);
            _processWindowHandler.Password = pPassword;
            this.LoadUserInterface();
        }
        private void MainWindowForm_Load(object sender, System.EventArgs e)
        {
            _processWindowHandler.FormWindow = NativeWin32.GetActiveProcessWindow();
        }

        private void LoadUserInterface()
        {
            cbxTitleKind.Items.Clear();
            cbxTitleKind.Items.AddRange(H.ConvertAllTitleKindToString());
            cbxTitleKind.SelectedIndex = 0;
        }


        private void MainWindow_FormClosing(object pSender, FormClosingEventArgs pE)
        {
            _processWindowHandler.DoOnClose();
        }

        #endregion

        #region - - - - - - - -   E V E N T H A N D L E R S   - - - - - - - -


        private void btnPasswordReal_Click(object sender, System.EventArgs e)
        {
            _processWindowHandler.Password = tbxPasswordReal.Text;
        }

        private void btnAddTitle_Click(object sender, System.EventArgs e)
        {
            TitlesToBlock lvTtb = new TitlesToBlock(tbxTitle.Text, H.ConvertKindStringToKind(cbxTitleKind.SelectedItem.ToString()));
            _processWindowHandler.ListTitlesToBlocks.Add(lvTtb);
            lvTitlesToBlock.Items.Add(lvTtb.ToString());
        }

        private void btnAddCurrentProcess_Click(object sender, System.EventArgs e)
        {
            // TODO check title of current process
        }

        private void chbxActive_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chbxActive.Checked)
            {
                _processWindowHandler.SetActive(true);
                gbxSetup.Enabled = false;
            }
        }

        private void chbxAutoMode_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void btnPasswordOk_Click(object sender, System.EventArgs e)
        {
            // returns IsActive
            if (!_processWindowHandler.CheckPassword(tbxPassword.Text))
            {
                gbxSetup.Enabled = true;
                chbxActive.Checked = false;
            }
            tbxPassword.Clear();
        }
        #endregion

    }
}
