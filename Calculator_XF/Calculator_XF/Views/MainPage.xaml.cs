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
            var vm = new MainPageViewModel();
            this.BindingContext = vm;
            vm.Expressions.CollectionChanged += Expressions_CollectionChanged;

            scrollView.OnNestingOverScrolled += Scrollviewer_OnNestingOverScrolled;
        }

        private void Expressions_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            expressionsCollection.ScrollTo(0, animate: false);
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
            _scrollPosition = true;
            var element = scrollViewContentContainer.Children.Last() as Element;
            scrollView.ScrollToAsync(element, ScrollToPosition.End, animate);
        }

        private void ScrollToExpressions(bool animate = true)
        {
            _scrollPosition = false;
            var element = scrollViewContentContainer.Children.First() as VisualElement;
            scrollView.ScrollToAsync(element, ScrollToPosition.End, animate);
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

        private bool _isExtensionMenuOpen;
        private void ExtensionMenu_Click(object sender, EventArgs e)
        {
            keyboardGrid.Opacity = 0;
            int length = _isExtensionMenuOpen ? 0 : 1;

            (int, int) grid = (Grid.GetRow(frameE), Grid.GetColumn(frameE));
            Grid.SetRow(frameE, Grid.GetRow(frameExct));
            Grid.SetColumn(frameE, Grid.GetColumn(frameExct));

            Grid.SetRow(frameExct, grid.Item1);
            Grid.SetColumn(frameExct, grid.Item2);

            exctRow.Height = new GridLength(length, GridUnitType.Star);
            exctColumn.Width = new GridLength(length, GridUnitType.Star);
            _isExtensionMenuOpen = !_isExtensionMenuOpen;
            keyboardGrid.FadeTo(1, 350, Easing.CubicInOut);
        }
    }
}
