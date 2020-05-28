using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.DualScreen;
using Xamarin.Forms.Xaml;
using XF4SD_MasterDetail.Models;

namespace XF4SD_MasterDetail.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetail : ContentPage
    {
        public static MasterDetail Current { get; private set; }

        bool IsSpanned => DualScreenInfo.Current.SpanMode != TwoPaneViewMode.SinglePane;
        DetailsPage detailsPagePushed;

        public MasterDetail()
        {
            InitializeComponent();
            Current = this;
            detailsPagePushed = new DetailsPage();
        }

        private void OnTitleSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null &&
                e.CurrentSelection.Count > 0)
            {
                SetBindingContext();
                SetupViews();
            }
        }

        private void SetBindingContext()
        {
            var bindingContext = masterPage.SelectedItem ?? ((IList<MasterDetailsItem>)masterPage.ItemsSource)[0];
            detailsPage.BindingContext
                = detailsPagePushed.BindingContext = bindingContext;
        }

        private async void SetupViews()
        {
            if (IsSpanned && !DualScreenInfo.Current.IsLandscape)
                SetBindingContext();

            if (detailsPage.BindingContext != null)
            {
                if (!IsSpanned)
                {
                    if (!Navigation.NavigationStack.Contains(detailsPagePushed))
                    {
                        await Navigation.PushAsync(detailsPagePushed);
                    }
                }
            }
        }

        protected override void OnAppearing()
        {
            if (!IsSpanned)
                masterPage.SelectedItem = null;
            DualScreenInfo.Current.PropertyChanged += OnFormsWindowPropertyChanged;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            DualScreenInfo.Current.PropertyChanged -= OnFormsWindowPropertyChanged;
        }

        void OnFormsWindowPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(DualScreenInfo.Current.SpanMode) || e.PropertyName == nameof(DualScreenInfo.Current.IsLandscape))
            {
                SetupViews();
            }
        }

        public void OnDeleteClicked(string title)
        {
            DisplayAlert("Item Details", $"You are DELETING Title '{title}'", "OK");
        }

        public void OnSaveClicked(string title)
        {
            DisplayAlert("Item Details", $"You are SAVING Title '{title}'", "OK");
        }
    }
}