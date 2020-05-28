using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF4SD_MasterDetail.Views;

namespace XF4SD_MasterDetail
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MasterDetail());
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
