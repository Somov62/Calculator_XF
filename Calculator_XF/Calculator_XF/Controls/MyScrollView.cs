using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator_XF.Controls
{
    public class MyScrollView : ScrollView
    {
        public MyScrollView() : base()
        {
            MessagingCenter.Subscribe<object>(this, "PositiveOverScrolled", PositiveOverScrolled);
            MessagingCenter.Subscribe<object>(this, "NegativeOverScrolled", NegativeOverScrolled);
        }

        public delegate void OverScrolledEventHandler(OverScrolledEventArgs args);

        public event OverScrolledEventHandler OnNestingOverScrolled;

        public class OverScrolledEventArgs
        {
            public object Sender { get; set; }

            public bool ScrollDimension{ get; set; }
        }

        private bool _isTouchEnabled = true;

        public bool IsTouchEnabled
        {
            get => _isTouchEnabled;
            set
            {
                _isTouchEnabled = value;
                DependencyService.Get<Interfaces.ICustomScrollView>().SetTouchEnabled(value);
            }
        }



        private void PositiveOverScrolled(object _)
        {
            OnNestingOverScrolled?.Invoke(new OverScrolledEventArgs() { Sender = this, ScrollDimension = true });
        }

        private void NegativeOverScrolled(object _)
        {
            OnNestingOverScrolled?.Invoke(new OverScrolledEventArgs() { Sender = this, ScrollDimension = false });
        }

        public new async void ScrollToAsync(Element element, ScrollToPosition position, bool animated)
        {
            
            System.Diagnostics.Debug.WriteLine("SCROLL INVOKE");
            if (!_isTouchEnabled)
            {
                SendScrollFinished();
                return;
            }
            _isTouchEnabled = false;
            await base.ScrollToAsync(element, position, animated);
            _isTouchEnabled = true;
        }
    }
}
