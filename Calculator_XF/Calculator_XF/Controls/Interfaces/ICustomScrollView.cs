namespace Calculator_XF.Controls.Interfaces
{
    public interface ICustomScrollView
    {
        void SetScrollEnabled(bool value);
        bool GetScrollEnabled();

        void SetTouchEnabled(bool value);
        bool GetTouchEnabled();
    }
}
