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
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            // Save changed to configuration json file
            Hide();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Hide();
        }
    }
}
