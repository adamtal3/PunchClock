using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace PunchClock
{
    public partial class Toast : MaterialForm
    {
        private static int _openedToastsHeight = 0;
        private static readonly object _syncRoot = new object();
         
        public Toast()
        {
            InitializeComponent();

            Location = new Point(Size.Width * (-1), 0);
            lock (_syncRoot)
                _openedToastsHeight += (Height + 10);
        }

        public int Timeout { get; set; } = 3000;
        public string Content { get { return lblLabel.Text; } set { lblLabel.Text = value; } }

        private void Toast_Load(object sender, EventArgs e)
        {
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - Size.Width - 5,
                Screen.PrimaryScreen.WorkingArea.Bottom - _openedToastsHeight);
            HideOnTimeout();
        }

        private async Task HideOnTimeout()
        {
            await Task.Delay(Timeout);
            Close();
            lock (_syncRoot)
                _openedToastsHeight -= (Height + 10);
        }
    }
}
