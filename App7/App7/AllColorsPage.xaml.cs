using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllColorsPage : ContentPage
    {
        public AllColorsPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ColorView.ItemsSource = NamedColor.All;
        }
    }
}