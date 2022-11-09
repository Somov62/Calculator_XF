using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Calculator_XF.Controls
{
    public class MyButton : Button
    {
        #region Padding    

        public new static BindableProperty PaddingProperty = BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MyButton), default(Thickness), defaultBindingMode: BindingMode.OneWay);

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        #endregion Padding
    }
}
