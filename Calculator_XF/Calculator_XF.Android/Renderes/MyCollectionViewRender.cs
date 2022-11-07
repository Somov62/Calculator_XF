using Android.Content;
using Android.Views;
using Calculator_XF.Controls;
using Calculator_XF.Droid.Renderes;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyCollectionView), typeof(MyCollectionViewRender))]


namespace Calculator_XF.Droid.Renderes
{
    public class MyCollectionViewRender : CollectionViewRenderer
    {
        public MyCollectionViewRender(Context context) : base(context)
        {

        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            return base.OnTouchEvent(e);
        }
        protected override void OnScrollChanged(int l, int t, int oldl, int oldt)
        {
            base.OnScrollChanged(l, t, oldl, oldt);
        }

        public override void ScrollBy(int x, int y)
        {
            base.ScrollBy(x, y);
        }

        public override void ScrollTo(int x, int y)
        {
            base.ScrollTo(x, y);
        }

        protected override void ScrollTo(ScrollToRequestEventArgs args)
        {
            base.ScrollTo(args);
        }

        public override void ScrollToPosition(int position)
        {
            base.ScrollToPosition(position);
        }

        public override void ComputeScroll()
        {
            base.ComputeScroll();
        }

        public override void NestedScrollBy(int x, int y)
        {
            base.NestedScrollBy(x, y);
        }
        public override void OnScrolled(int dx, int dy)
        {
            base.OnScrolled(dx, dy);
        }

        public override bool HasNestedScrollingParent => true;
    }
}