using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Calculator_XF.Controls;
using Calculator_XF.Droid.Renderes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyButton), typeof(MyButtonRenderer))]
namespace Calculator_XF.Droid.Renderes
{

    public class MyButtonRenderer : ButtonRenderer
    {
        public MyButtonRenderer(Context context) : base(context)
        {
        }


        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            UpdatePadding();
        }

        private void UpdatePadding()
        {
            var element = this.Element as MyButton;
            if (element != null)
            {
                this.Control.SetPadding(
                    (int)element.Padding.Left,
                    (int)element.Padding.Top,
                    (int)element.Padding.Right,
                    (int)element.Padding.Bottom
                );
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == nameof(MyButton.Padding))
            {
                UpdatePadding();
            }
        }
    }
}