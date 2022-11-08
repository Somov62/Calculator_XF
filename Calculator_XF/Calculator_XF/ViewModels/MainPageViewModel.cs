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
                new ExpressionModel() { Expression = "5", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "6", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "7", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "8", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "9", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "10", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "11", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "12", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "13", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "14", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "15", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "16", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "17", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "18", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "19", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "20", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "21", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "22", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "23", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "24", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "25", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "26", Result = "4", IsSelected = false },
                new ExpressionModel() { Expression = "27", Result = "4", IsSelected = false }
            };
        }

        public ObservableCollection<ExpressionModel> Expressions { get; }



        public ExpressionModel CurrentExpression => Expressions.FirstOrDefault();

        private void SetSymbol(object symbol)
        {
            CurrentExpression.Expression += symbol.ToString();
            CurrentExpression.OnPropertyChanged("Expression");
        }
    }

    internal class ExpressionModel : ObservableObject
    {
        public string Expression { get; set; }
        public string Result { get; set; }
        public bool IsSelected { get; set; }
    }
}

