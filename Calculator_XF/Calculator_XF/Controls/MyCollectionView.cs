using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Calculator_XF.Controls
{
    public class MyCollectionView : CollectionView
    {
        public MyCollectionView()
        {
            MessagingCenter.Instance.Subscribe<object, object>(this, "ScrollDetected", ScrollDetected);
        }

        public delegate void ScrollEvent(object sender, ScrollEventArgs args);

        public event ScrollEvent OnScrollDetected;

        public class ScrollEventArgs
        {
            public int ScrollX { get; set; }
            public int ScrollY { get; set; }
        }

        public void ScrollDetected(object sender, object args)
        {
            OnScrollDetected?.Invoke(this, args as ScrollEventArgs);
        }
    }
}
