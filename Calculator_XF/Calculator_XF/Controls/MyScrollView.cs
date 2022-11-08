using System;
using System.Collections.Generic;
using System.Text;
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



        private void PositiveOverScrolled(object _)
        {
            OnNestingOverScrolled?.Invoke(new OverScrolledEventArgs() { Sender = this, ScrollDimension = true });
        }

        private void NegativeOverScrolled(object _)
        {
            OnNestingOverScrolled?.Invoke(new OverScrolledEventArgs() { Sender = this, ScrollDimension = false });
        }
    }
}
