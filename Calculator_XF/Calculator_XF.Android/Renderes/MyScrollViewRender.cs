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

        public bool IsScrollEnabled { get; set; }

        public override bool OnTouchEvent(MotionEvent e)
        {
            return base.OnTouchEvent(e);
        }
        protected override void OnScrollChanged(int l, int t, int oldl, int oldt)
        {
            //if (IsScrollEnabled)
                base.OnScrollChanged(l, t, oldl, oldt);
        }

        public override void ScrollBy(int x, int y)
        {
            System.Diagnostics.Debug.WriteLine("Scroll on " + y);
            if (IsScrollEnabled)
                base.ScrollBy(x, y);
        }

        public override void ScrollTo(int x, int y)
        {
            base.ScrollTo(x, y);
        }

        public void SetScrollEnabled(bool value) => IsScrollEnabled = value;

        public bool GetScrollEnabled() => IsScrollEnabled;

    }
}