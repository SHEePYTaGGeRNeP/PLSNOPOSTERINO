using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace PLS_NO_POSTERINO.Classes
{
    using System.Runtime.CompilerServices;

    using PLS_NO_POSTERINO.Properties;

    public class ProcessWindowHandler
    {
        private ProgressBar trackWave = new ProgressBar() { Maximum = int.MaxValue };

        public int WaitForPassword { get; set; } = 5000;
        public bool LockPc { get; set; }
        public static ProcessWindowHandler Instance;

        private readonly System.Media.SoundPlayer _soundPlayer = new System.Media.SoundPlayer(Properties.Resources.Loud_alarm_clock_sound);

        public delegate void AutoModeStartedHandler();
        public event AutoModeStartedHandler OnAutoModeStarted;

        public List<TitlesToBlock> ListTitlesToBlocks { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; private set; }
        public NativeWin32.ProcessWindow FormWindow { get; set; }
        private MainWindowForm _form;
        private Thread _bleepThread;

        public System.Windows.Forms.Timer ListeningTimer { get; private set; }
        public System.Windows.Forms.Timer AfkCheckTimer { get; private set; }

        public int AutoModeAfkInMs { get; set; }
        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);
        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
        [DllImport("user32")]
        public static extern void LockWorkStation();

        public ProcessWindowHandler(MainWindowForm form)
        {
            Instance = this;
            this._form = form;
            this.ListTitlesToBlocks = new List<TitlesToBlock>();
            this.ListeningTimer = new System.Windows.Forms.Timer();
            this.AfkCheckTimer = new System.Windows.Forms.Timer();
            this.Setup();
        }

        private void Setup()
        {
            this.ListeningTimer.Interval = 100;
            this.ListeningTimer.Tick += this.ListeningTimerOnTick;
            this.AfkCheckTimer.Interval = 1000;
            this.AfkCheckTimer.Tick += this.AfkCheckTimerOnTick;
            this.AutoModeAfkInMs = 5000;
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
            if (lvIdleTime > this.AutoModeAfkInMs)
            {
                this.SetActive(true);
                if (this.OnAutoModeStarted != null)
                    this.OnAutoModeStarted.Invoke();
                this.AfkCheckTimer.Stop();
            }
            Console.WriteLine("Inactive for : " + lvIdleTime);
        }

        private void ListeningTimerOnTick(object pSender, EventArgs pEventArgs)
        {
            NativeWin32.ProcessWindow lvCurrentProcessWindow = NativeWin32.GetActiveProcessWindow();
            if (H.TitlesToBlockContainsTitle(this.ListTitlesToBlocks, lvCurrentProcessWindow.Title))
            {
                NativeWin32.SetForegroundWindow(this.FormWindow.hWnd.ToInt32());
                this._form.Show();
                this._form.WindowState = FormWindowState.Normal;
                this._form.ShowInTaskbar = true;
                keybd_event((byte)Keys.VolumeUp, 0, 0, 0); // increase volume
                if (this._bleepThread != null && this._bleepThread.IsAlive) return;
                Thread startBleepAndAlarm = new Thread(this.WaitForAlarm);
                startBleepAndAlarm.Start();
            }
        }

        private void SetVolumeMax()
        {
            for (int i = 0; i < 50; i++)
            {
                Thread.Sleep(50);
                keybd_event((byte)Keys.VolumeUp, 0, 0, 0); // increase volume
            }
        }


        private void WaitForAlarm()
        {
            Thread.Sleep(this.WaitForPassword);
            if (!this.IsActive) return;
            if (this.LockPc)
                LockWorkStation();
            else
            if (this._bleepThread == null || !this._bleepThread.IsAlive)
                this.StartBleepThread();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pIsActive">FALSE if password is null or empty</param>
        /// <returns></returns>
        public bool SetActive(bool pIsActive)
        {
            if (String.IsNullOrEmpty(this.Password))
                return false;
            this.IsActive = pIsActive;
            this.ListeningTimer.Stop();
            if (this.IsActive)
            {
                this.ListeningTimer.Start();
            }
            else
            {
                if (this._bleepThread != null && this._bleepThread.IsAlive)
                    this._bleepThread.Abort();
                this._soundPlayer.Stop();
            }
            return true;
        }



        public void SetAutoModusActive(bool pIsActive)
        {
            if (pIsActive == false)
                this.AfkCheckTimer.Stop();
            else
                this.AfkCheckTimer.Start();
        }

        /// <summary>
        /// Returns IsActive
        /// </summary>
        /// <param name="pPassword"></param>
        /// <returns>Returns IsActive</returns>
        public bool CheckPassword(string pPassword)
        {
            if (this.Password == pPassword)
                this.SetActive(false);
            else
                this.StartBleepThread();
            return this.IsActive;
        }




        public void StartBleepThread()
        {
            if (this._bleepThread != null && this._bleepThread.IsAlive)
                this._bleepThread.Abort();
            this.SetVolumeMax();
            if (!this.IsActive) return;
            this._bleepThread = new Thread(this.ThreadedStartBleeping);
            this._bleepThread.Start();
            this._soundPlayer.PlayLooping();
        }
        private void ThreadedStartBleeping()
        {
            while (this.IsActive)
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
