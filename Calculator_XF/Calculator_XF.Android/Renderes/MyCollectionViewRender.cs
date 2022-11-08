using Android.Content;
using Android.Views;
using Calculator_XF.Controls;
using Calculator_XF.Droid.Renderes;
using System;
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
    }
}