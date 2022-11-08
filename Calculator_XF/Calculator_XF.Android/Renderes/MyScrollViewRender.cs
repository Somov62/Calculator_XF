using Android.Content;
using Android.Views;
using Calculator_XF.Droid.Renderes;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Calculator_XF.Controls.MyScrollView), typeof(MyScrollViewRender))]


namespace Calculator_XF.Droid.Renderes
{
    public class MyScrollViewRender : ScrollViewRenderer
    {
        public MyScrollViewRender(Context context) : base(context)
        {
        }

        public bool IsScrollEnabled { get; set; } = true;

        public override bool OnTouchEvent(MotionEvent e)
        {
            return base.OnTouchEvent(e);
        }
        protected override void OnScrollChanged(int l, int t, int oldl, int oldt)
        {
            if (IsScrollEnabled)
                base.OnScrollChanged(l, t, oldl, oldt);
        }

        private int _isPositiveOverscroll;
        private int _isNegativeOverscroll;

        public override void ScrollBy(int x, int y)
        {
            if (y > 0)
            {
                if (_isPositiveOverscroll == 3)
                {
                    MessagingCenter.Send<object>(this, "PositiveOverScrolled");
                    _isPositiveOverscroll = -1;
                }
                _isPositiveOverscroll++;
            }

            if (y < 0)
            {
                if (_isNegativeOverscroll == 3)
                {
                    MessagingCenter.Send<object>(this, "NegativeOverScrolled");
                    _isNegativeOverscroll = -1;
                }
                _isNegativeOverscroll++;
            }

            if (y == 0)
            {
                _isPositiveOverscroll = 0;
                _isNegativeOverscroll = 0;
            }

            System.Diagnostics.Debug.WriteLine("Scroll on " + y);
        }

        public override void ScrollTo(int x, int y)
        {
            base.ScrollTo(x, y);
        }

        public void SetScrollEnabled(bool value) => IsScrollEnabled = value;

        public bool GetScrollEnabled() => IsScrollEnabled;

    }
}