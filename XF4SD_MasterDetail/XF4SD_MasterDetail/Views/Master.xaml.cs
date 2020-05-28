using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF4SD_MasterDetail.Models;

namespace XF4SD_MasterDetail.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : CollectionView
    {
        public Master()
        {
            InitializeComponent();

            ItemsSource = Enumerable.Range(1, 100)
                .Select(x => new MasterDetailsItem(x))
                .ToList();
        }
    }
}