using Calculator_XF.MVVM.Core;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

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
                new ExpressionModel() { Expression = "1", Result = "4", IsSelected = true },
                new ExpressionModel() { Expression = "2", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "3", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "4", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "5", Result = "4", IsSelected = false }
            };
        }

        public ObservableCollection<ExpressionModel> Expressions { get; }



        public ExpressionModel CurrentExpression => Expressions.FirstOrDefault();

        private void SetSymbol(object symbol)
        {
            CurrentExpression.Expression += symbol.ToString();
            CurrentExpression.OnPropertyChanged("Expression");
        }

        public bool IsResultMode { get; set; } = false;
    }

    internal class ExpressionModel : ObservableObject
    {
        public string Expression { get; set; }
        public string Result { get; set; }
        public bool IsSelected { get; set; }
    }
}

