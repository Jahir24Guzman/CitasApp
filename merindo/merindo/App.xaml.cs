using merindo.Views;
using Syncfusion.Licensing;
using Xamarin.Forms;

namespace merindo
{
    public partial class App : Application
    {
        public static Database Database { get; private set; }

        public App()
        {
            InitializeComponent();

            SyncfusionLicenseProvider.RegisterLicense("TU_CLAVE_DE_LICENCIA");

            Database = new Database(Constants.DatabasePath);

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}