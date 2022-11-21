using Calculator_XF.MVVM.Core;

namespace Calculator_XF.Models
{
    internal class ExpressionModel : ObservableObject
    {
        private string _expression;
        public string Expression
        {
            get => _expression;
            set => Set(ref _expression, value, nameof(Expression));
        }

        private string _result;
        public string Result
        {
            get => _result;
            set => Set(ref _result, value, nameof(Result));
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => Set(ref _isSelected, value, nameof(IsSelected));
        }
    }
}
