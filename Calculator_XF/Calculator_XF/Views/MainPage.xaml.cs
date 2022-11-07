using Calculator_XF.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator_XF.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
        }

        private async void ContentPage_Appearing(object sender, System.EventArgs e)
        {
            var element = (scrollviewerContentContainer as StackLayout).Children.Last() as Element;
            await Task.Delay(1000);
            scrollviewer.ScrollToAsync(element, ScrollToPosition.End, true);
        }
    }
}
