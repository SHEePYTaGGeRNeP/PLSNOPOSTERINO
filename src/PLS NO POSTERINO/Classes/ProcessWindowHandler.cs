using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace PLS_NO_POSTERINO.Classes
{
    public class ProcessWindowHandler
    {
        public static readonly ProcessWindowHandler Instance = new ProcessWindowHandler();

        public delegate void AutoModeStartedHandler();
        public event AutoModeStartedHandler OnAutoModeStarted;

        public List<TitlesToBlock> ListTitlesToBlocks { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; private set; }
        public NativeWin32.ProcessWindow FormWindow { get; set; }

        private Thread _bleepThread;

        public System.Windows.Forms.Timer ListeningTimer { get; }
        public System.Windows.Forms.Timer AfkCheckTimer { get; }

        public int AutoModeAfkInMs { get; set; }

        public ProcessWindowHandler()
        {
            ListTitlesToBlocks = new List<TitlesToBlock>();
            ListeningTimer = new System.Windows.Forms.Timer();
            AfkCheckTimer = new System.Windows.Forms.Timer();
            this.Setup();
        }

        private void Setup()
        {
            ListeningTimer.Interval = 100;
            ListeningTimer.Tick += ListeningTimerOnTick;
            AfkCheckTimer.Interval = 1000;
            AfkCheckTimer.Tick += AfkCheckTimerOnTick;
            AutoModeAfkInMs = 5000;
        }

        private void AfkCheckTimerOnTick(object pSender, EventArgs pEventArgs)
        {
            int lvIdleTime = 0;
            NativeWin32.LASTINPUTINFO lvLastInputInfo = new NativeWin32.LASTINPUTINFO();
            lvLastInputInfo.cbSize = Marshal.SizeOf(lvLastInputInfo);
            lvLastInputInfo.dwTime = 0;

            int lvEnvTicks = Environment.TickCount;

            if (NativeWin32.GetLastInputInfo(out lvLastInputInfo))
            {
                int lvLastInputTick = lvLastInputInfo.dwTime;
                lvIdleTime = lvEnvTicks - lvLastInputTick;
            }
            if (lvIdleTime > AutoModeAfkInMs)
            {
                SetActive(true);
                if (OnAutoModeStarted != null)
                    OnAutoModeStarted.Invoke();
                AfkCheckTimer.Stop();
            }
            Console.WriteLine("Inactive for : " + lvIdleTime);
        }

        private void ListeningTimerOnTick(object pSender, EventArgs pEventArgs)
        {
            NativeWin32.ProcessWindow lvCurrentProcessWindow = NativeWin32.GetActiveProcessWindow();
            if (H.TitlesToBlockContainsTitle(ListTitlesToBlocks, lvCurrentProcessWindow.Title))
            {
                NativeWin32.SetForegroundWindow(FormWindow.hWnd.ToInt32());
                if (_bleepThread == null || !_bleepThread.IsAlive)
                    this.StartBleepThread();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pIsActive">FALSE if password is null or empty</param>
        /// <returns></returns>
        public bool SetActive(bool pIsActive)
        {
            if (String.IsNullOrEmpty(Password))
                return false;
            IsActive = pIsActive;
            ListeningTimer.Stop();
            if (IsActive)
            {
                ListeningTimer.Start();
            }
            else
                if (this._bleepThread != null && this._bleepThread.IsAlive)
                    this._bleepThread.Abort();
            return true;
        }

        public void SetAutoModusActive(bool pIsActive)
        {
            if (pIsActive == false)
                AfkCheckTimer.Stop();
            else
                AfkCheckTimer.Start();
        }

        /// <summary>
        /// Returns IsActive
        /// </summary>
        /// <param name="pPassword"></param>
        /// <returns>Returns IsActive</returns>
        public bool CheckPassword(string pPassword)
        {
            if (Password == pPassword)
                this.SetActive(false);
            else
                this.StartBleepThread();
            return IsActive;
        }




        public void StartBleepThread()
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

                    Console.Beep(1500, 500);
                    Console.Beep(200, 250);
                    Console.Beep(3000, 1000);

                    #endregion
                }
                catch (ThreadAbortException)
                {
                }
                catch (Exception lvEx)
                {
                    Console.WriteLine(lvEx);
                }
            }
        }


    }
}
