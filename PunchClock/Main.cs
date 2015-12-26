using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace PunchClock
{
    public partial class Main : MaterialForm
    {
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
                new MenuItem("Show", niNotifyIcon_Click),
                new MenuItem("-"), 
                new MenuItem("Exit", (sender, args) => { this.Close(); })
            });
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            // Save changed to configuration json file
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Main_Resize(object sender, System.EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                niNotifyIcon.Visible = true;
                Notify("Punch clock is still running");
                this.Hide();
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                niNotifyIcon.Visible = false;
            }
        }

        private void Notify(string text)
        {
            niNotifyIcon.BalloonTipText = text;
            niNotifyIcon.ShowBalloonTip(1500);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure you want to close?", "Exit Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
                e.Cancel = true;
        }

        private void niNotifyIcon_Click(object sender, System.EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}
