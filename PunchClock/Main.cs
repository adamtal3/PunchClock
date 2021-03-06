﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using PunchClock.Infra;
using PunchClock.Properties;

namespace PunchClock
{
    public partial class Main : MaterialForm
    {
        private bool _isClockRunning = false;
        private readonly Timer _timer;
        private readonly TimeCounter _timeCounter;

        public Main()
        {
            InitializeComponent();

            // Material
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            // Notify icon
            niNotifyIcon.ContextMenu = new ContextMenu(new[] {
                new MenuItem("Show", (sender, args) => { this.niNotifyIcon_MouseDoubleClick(sender, null); }),
                new MenuItem("-"), 
                new MenuItem("Exit", (sender, args) => { this.Close(); })
            });

            // Scroll Lock handler
            ScrollLockInterceptor.ScrollLockChange += ScrollLockInterceptorOnScrollLockChange;

            _timer = new Timer { Interval = 10000 };
            _timer.Tick += (sender, args) => ScrollLockInterceptor.InvokeScrollLockChange();
            _timer.Start();

            _timeCounter = new TimeCounter();
        }

        private void ScrollLockInterceptorOnScrollLockChange(object sender, ScrollLockChangeEventArgs e)
        {
            if (e.IsOn != _isClockRunning)
            {
                _isClockRunning = e.IsOn;
                if (e.IsOn)
                {
                    this.Icon = niNotifyIcon.Icon = Resources.clockOn;
                    var result = _timeCounter.PunchIn();
                    Notify($"Punch in at {result.ToTimeString()}");
                }
                else
                {
                    this.Icon = niNotifyIcon.Icon = Resources.clockOff;
                    var result = _timeCounter.PunchOut();
                    Notify($"Punch out - total time: {result.ToTimeString()}");
                }
            }
        }

        private void Notify(string text)
        {
            var toast = new Toast() { Content = text };
            toast.ShowDialog();
        }

        #region Event Handlers

        private void Main_Load(object sender, EventArgs e)
        {
            // Start minimized
            HideSoon();
        }

        private async Task HideSoon()
        {
            await Task.Delay(500);
            _dontShowStillRunning = true;
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save changed to configuration json file
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private bool _dontShowStillRunning = false;
        private void Main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                niNotifyIcon.Visible = true;
                if (!_dontShowStillRunning)
                    Notify(string.Join(",", Enumerable.Range(1, 15).Select(x => "Punch clock is still running")));
                this.Hide();
                InvokeScrollLockChangeSoon();
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                niNotifyIcon.Visible = false;
            }
            _dontShowStillRunning = false;
        }

        private async Task InvokeScrollLockChangeSoon()
        {
            await Task.Delay(1000);
            ScrollLockInterceptor.InvokeScrollLockChange();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure you want to close?", "Exit Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
                e.Cancel = true;
            else
            {
                _timer.Stop();
                ScrollLockInterceptor.ScrollLockChange -= ScrollLockInterceptorOnScrollLockChange;
            }
        }

        private void niNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        #endregion
    }
}
