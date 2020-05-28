using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF4SD_MasterDetail.Models;

namespace XF4SD_MasterDetail.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Details : ContentView
    {
        public Details()
        {
            InitializeComponent();
        }

        private void OnDeleteClicked(object sender, System.EventArgs e)
        {
            string title = ((MasterDetailsItem)BindingContext).Title;
            MasterDetail.Current.OnDeleteClicked(title);
        }

        private void OnSaveClicked(object sender, System.EventArgs e)
        {
            string title = ((MasterDetailsItem)BindingContext).Title;
            MasterDetail.Current.OnSaveClicked(title);
        }
    }
}