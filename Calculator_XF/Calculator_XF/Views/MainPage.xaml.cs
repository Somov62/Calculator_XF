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
            scrollView.OnNestingOverScrolled += Scrollviewer_OnNestingOverScrolled;
        }
        private bool _scrollPosition;
        private void Scrollviewer_OnNestingOverScrolled(Controls.MyScrollView.OverScrolledEventArgs args)
        {
            if (args.ScrollDimension)
            {
                if (!_scrollPosition) return;
                ScrollToExpressions();
                return;
            }

            if (_scrollPosition) return;

            ScrollToKeyboard();
        }

        private void ScrollToKeyboard(bool animate = true)
        {
            var element = scrollViewContentContainer.Children.Last() as Element;
            scrollView.ScrollToAsync(element, ScrollToPosition.End, animate).Start();
            _scrollPosition = true;
        }

        private void ScrollToExpressions(bool animate = true)
        {
            _scrollPosition = false;

            var element = scrollViewContentContainer.Children.First() as VisualElement;
            scrollView.ScrollToAsync(element, ScrollToPosition.End, animate).Start();
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
                if (_scrollPosition) ScrollToExpressions();
                _scrollPosition = false;
            }
            _previewScrollPosition = e.ScrollY;
        }

    }
}
