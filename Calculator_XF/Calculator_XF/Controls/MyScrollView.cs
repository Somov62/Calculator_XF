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



        private void PositiveOverScrolled(object _)
        {
            OnNestingOverScrolled?.Invoke(new OverScrolledEventArgs() { Sender = this, ScrollDimension = true });
        }

        private void NegativeOverScrolled(object _)
        {
            OnNestingOverScrolled?.Invoke(new OverScrolledEventArgs() { Sender = this, ScrollDimension = false });
        }

        public new Task ScrollToAsync(Element element, ScrollToPosition position, bool animated)
        {
            Point point = this.GetScrollPositionForElement(element as VisualElement, position);

            var animation = new Animation(
                callback: y => base.ScrollToAsync(point.X, y, animated: false),
                start: this.ScrollY,
                end: point.Y);

            uint length = animated ? 250u : 0;
            
            return new Task(() => animation.Commit(
                owner: this,
                name: "Scroll",
                length: length,
                easing: Easing.SinIn));
        }
    }
}
