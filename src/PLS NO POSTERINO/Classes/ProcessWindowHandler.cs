using System;
using System.Collections.Generic;
using System.Threading;

namespace PLS_NO_POSTERINO.Classes
{
    public class ProcessWindowHandler
    {
        public static readonly ProcessWindowHandler Instance = new ProcessWindowHandler();

        public List<TitlesToBlock> ListTitlesToBlocks { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; private set; }
        public NativeWin32.ProcessWindow FormWindow { get; set; }

        private Thread _bleepThread;

        public ProcessWindowHandler()
        {
            ListTitlesToBlocks = new List<TitlesToBlock>();
        }

        public void SetActive(bool pIsActive)
        {
            IsActive = pIsActive;
            if (IsActive)
                new Thread(ThreadedListen).Start();
        }

        private void ThreadedListen()
        {
            while (IsActive)
            {
                NativeWin32.ProcessWindow lvCurrentProcessWindow = NativeWin32.GetActiveProcessWindow();
                if (H.TitlesToBlockContainsTitle(ListTitlesToBlocks, lvCurrentProcessWindow.Title))
                {
                    NativeWin32.SetForegroundWindow(FormWindow.hWnd.ToInt32());
                    lvCurrentProcessWindow = NativeWin32.GetActiveProcessWindow();
                    System.Windows.Forms.SendKeys.SendWait("E");
                    this.StartBleepThread();
                }
                Thread.Sleep(100);
            }

        }

        /// <summary>
        /// Returns IsActive
        /// </summary>
        /// <param name="pPassword"></param>
        /// <returns>Returns IsActive</returns>
        public bool CheckPassword(string pPassword)
        {
            if (Password == pPassword)
                IsActive = false;
            return IsActive;
        }


        public void DoOnClose()
        {
            if (!IsActive)
                return;
            MainWindowForm lvMwf = new MainWindowForm(Password, ListTitlesToBlocks);
            lvMwf.ShowDialog();
            StartBleepThread();
        }

        private void StartBleepThread()
        {
            if (_bleepThread != null && _bleepThread.IsAlive)
                _bleepThread.Abort();
            _bleepThread = new Thread(ThreadedStartBleeping);
            _bleepThread.Start();
        }


        private void ThreadedStartBleeping()
        {
            while (IsActive)
            {
                try
                {
                    #region bleeps
                    Console.Beep(659, 125);
                    Console.Beep(659, 125);
                    Thread.Sleep(125);
                    Console.Beep(659, 125);
                    #endregion
                }
                catch (Exception ex)
                { Console.WriteLine(ex);}
            }
        }


    }
}
