using Calculator_XF.MVVM.Core;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using CalculatorLib;


namespace Calculator_XF.ViewModels
{
    internal class MainPageViewModel : Base.BaseViewModel
    {
        public Command SetSymbolInExpressionCommand { get; set; }

        public MainPageViewModel()
        {
            SetSymbolInExpressionCommand = new Command(execute: (object paramenter) => SetSymbol(paramenter));
            Expressions = new ObservableCollection<ExpressionModel>()
            {
                new ExpressionModel() { Expression = null, Result = null, IsSelected = true },
                new ExpressionModel() { Expression = "2", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "3", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "4", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "5", Result = "4", IsSelected = false }
            };
        }

        public ObservableCollection<ExpressionModel> Expressions { get; }

        public ExpressionModel CurrentExpression => Expressions.FirstOrDefault();

        private void SetSymbol(object inputSymbol)
        {
            char symbol = inputSymbol.ToString()[0];
            IsResultMode = false;
            var exp = CurrentExpression;

            exp.Result = null;

            char[] needZeroSymbols = { '+', '-', '÷', '×', '^' };

            switch (symbol)
            {
                case 'C':
                    exp.Expression = "0";
                    break;
                case '⌫':
                    exp.Expression = exp.Expression?.Substring(0, exp.Expression.Length - 1);
                    if (exp.Expression?.Length == 0) exp.Expression = null;
                    break;
                case '=':
                    IsResultMode = true;
                    break;
                default:
                    if (exp.Expression == null)
                    {
                        exp.Expression = string.Empty;
                        if (needZeroSymbols.Contains(symbol))
                            exp.Expression += "0";
                    }
                    exp.Expression += symbol.ToString();
                    break;

            }

            if (exp.Expression != null || exp.Expression != "0")
                exp.Result = Calculator.SolveExpression(exp.Expression).ToString();

            CurrentExpression.OnPropertyChanged("Expression");
            CurrentExpression.OnPropertyChanged("Result");
            CurrentExpression.OnPropertyChanged("IsSelected");
            base.OnPropertyChanged("IsResultMode");
        }

        public bool IsResultMode { get; set; }
    }

    internal class ExpressionModel : ObservableObject
    {
        public string Expression { get; set; }
        public string Result { get; set; }
        public bool IsSelected { get; set; }
    }
}

