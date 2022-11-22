using Calculator_XF.Models;
using CalculatorLib;
using System;
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
            Expressions = new ObservableCollection<ExpressionModel>();
            CreateExpression();
            CurrentExpression.OnPropertyChanged("Expression");
        }

        public ObservableCollection<ExpressionModel> Expressions { get; }
        public ExpressionModel CurrentExpression => Expressions.FirstOrDefault();

        private bool _isResultMode;
        public bool IsResultMode
        {
            get => _isResultMode;
            set => Set(ref _isResultMode, value);

        }

        private void CreateExpression()
        {
            if (CurrentExpression != null)
                CurrentExpression.IsSelected = false;
            ExpressionModel exp = new ExpressionModel() { IsSelected = true };
            Expressions.Insert(0, exp);
        }

        private void SetSymbol(object inputSymbol)
        {
            char symbol = inputSymbol.ToString()[0];

            if (char.IsDigit(symbol) && IsResultMode)
            {
                CreateExpression();
            }

            var exp = CurrentExpression;

            switch (symbol)
            {
                case 'C':
                    exp.Expression = null;
                    break;
                case 'A':
                    Clear();
                    break;

                case '⌫':
                    exp.Expression = exp.Expression?.Substring(0, exp.Expression.Length - 1);
                    if (exp.Expression?.Length == 0) exp.Expression = null;
                    break;

                case '=':
                    IsResultMode = true;
                    return;

                case 'e':
                case 'π':
                    exp.Expression += symbol.ToString();
                    break;
                case 's':
                    exp.Expression += "sin(";
                    break;
                case 'c':
                    exp.Expression += "cos(";
                    break;
                case 't':
                    exp.Expression += "tan(";
                    break; 
                case '√':
                    exp.Expression += "√(";
                    break;
                case '/':
                    if (exp.Expression == null) exp.Expression += "0";

                    exp.Expression += "^(-1)";
                    break;
                default:
                    if (!char.IsDigit(symbol))
                    {
                        if (symbol == '(')
                        {
                            exp.Expression += '(';
                            return;
                        }

                        if (exp.Expression == null) exp.Expression += "0";
                        char[] needZeroSymbols = { '+', '-', '÷', '×', '^' };

                        if (symbol == ',')
                        {
                            if (!char.IsDigit(exp.Expression[exp.Expression.Length - 1])) return;
                            for (int i = exp.Expression.Length - 1; i >= 0; i--)
                            {
                                if (needZeroSymbols.Contains(symbol)) break;
                                if (exp.Expression[i] == ',') return;
                            }
                        }

                        if (!char.IsDigit(exp.Expression[exp.Expression.Length - 1])
                            && needZeroSymbols.Contains(symbol))
                            return;
                    }
                    exp.Expression += symbol.ToString();
                    break;
            }

            IsResultMode = false;
            exp.Result = null;

            if (exp.Expression == null || exp.Expression == "0")
                return;
            var numbers = new char[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', };
            if (exp.Expression.Intersect(numbers).Count() == 0) return;

            string expression = exp.Expression;

            if (exp.Expression.Contains('('))
            {
                int countOpen = exp.Expression.Where(p => p == '(').Count();
                int countClose = exp.Expression.Where(p => p == ')').Count();
                for (int i = countClose; i < countOpen; i++)
                {
                    expression += ')';
                }
            }

            try
            {
                exp.Result = Math.Round(Calculator.SolveExpression(expression), 8).ToString();
            }
            catch (DivideByZeroException)
            {
                exp.Result = "Разделить на ноль нельзя";
            }
            catch (FormatException)
            {
                exp.Result = "Ошибка";
            }
            catch
            {
                exp.Result = "Ошибка";
            }
        }

        private void Clear()
        {
            if (Expressions.Count == 1) return;
            Expressions.Clear();
            CreateExpression();
        }


    }
}

