
using Xamarin.Forms;
using Xamarin.Forms.DualScreen;
using Xamarin.Forms.Xaml;
using XF4SD_MasterDetail.Models;

namespace XF4SD_MasterDetail.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        bool IsSpanned => DualScreenInfo.Current.SpanMode != TwoPaneViewMode.SinglePane;

        public DetailsPage()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (IsSpanned)
            {
                ((MasterDetailsItem)BindingContext).IsShowActionBar = true;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DualScreenInfo.Current.PropertyChanged += OnFormsWindowPropertyChanged;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            DualScreenInfo.Current.PropertyChanged -= OnFormsWindowPropertyChanged;
        }

        async void OnFormsWindowPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(DualScreenInfo.Current.SpanMode) || e.PropertyName == nameof(DualScreenInfo.Current.IsLandscape))
            {
                if (IsSpanned)
                    await Navigation.PopAsync();
            }
        }

        private void OnDeleteClicked(object sender, System.EventArgs e)
        {
            string title = ((MasterDetailsItem)BindingContext).Title;
            MasterDetail.Current.OnDeleteClicked(title);
        }

        private void OnSaveClicked(object sender, System.EventArgs e)
        {
            string title = ((MasterDetailsItem)BindingContext).Title;
            MasterDetail.Current.OnDeleteClicked(title);
        }
    }
}