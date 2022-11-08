using System;
using Calculator_XF.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Calculator_XF.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
            scrollviewer.OnNestingOverScrolled += Scrollviewer_OnNestingOverScrolled;
        }
        private bool _scrollPosition;
        private void Scrollviewer_OnNestingOverScrolled(Controls.MyScrollView.OverScrolledEventArgs args)
        {
            if (args.ScrollDimension) return;

            if (_scrollPosition) return;

            ScrollToKeyboard();
        }

        private void ScrollToKeyboard(bool animate = true)
        {
            var element = scrollviewerContentContainer.Children.Last() as Element;
            scrollviewer.ScrollToAsync(element, ScrollToPosition.End, animate);
            _scrollPosition = true;
        }

        private async void ScrollToExpressions(bool animate = true)
        {
            await Task.Delay(10);
            var element = scrollviewerContentContainer.Children.First() as Element;
            scrollviewer.ScrollToAsync(element, ScrollToPosition.End, animate);
            _scrollPosition = false;
        }

        private async void ContentPage_Appearing(object sender, System.EventArgs e)
        {
            expressionsCollection.HeightRequest = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density - 75;
            await Task.Delay(500);
            ScrollToKeyboard(false);
        }

        private double _previewScrollPosition;

        private void scrollviewer_Scrolled(object sender, ScrolledEventArgs e)
        {
            if (e.ScrollY < _previewScrollPosition)
            {
                if (_scrollPosition) ScrollToExpressions(false);
                _scrollPosition = false;
            }
            _previewScrollPosition = e.ScrollY;
        }

    }
}
