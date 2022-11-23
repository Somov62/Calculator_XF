using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLib
{
    public static class Calculator
    {
        private static readonly IReadOnlyDictionary<char, int> _operatorsRate = new Dictionary<char, int>()
        {
            {'(', 1 }, {'+', 2 }, {'-', 2 }, {'×', 3 }, {'÷', 3 },
            {'^', 4 }, {'q', 5 }, {'s', 5 }, {'c', 5 }, {'t', 5 }
        };

        public static double SolveExpression(string expression)
        {
            expression = PrepareExpression(expression);
            string postfixNotation = ConvertToPostfixNotation(expression);
            return SolvePostfixNotation(postfixNotation);
        }

        private static string PrepareExpression(string expression)
        {
            expression = expression
                .Replace(" ", "")
                .Replace(".", ",")
                .Replace("*", "×")
                .Replace("/", "÷")
                .Replace("/", "÷")
                .Replace("/", "÷")
                .Replace("/", "÷")
                .Replace("/", "÷")
                .Replace("sin", "s")
                .Replace("cos", "c")
                .Replace("tan", "t")
                .Replace("sqrt", "q")
                .Replace("√", "q")
                .Replace("(-", "(0-");
            return expression;
        }
        
        private static string ConvertToPostfixNotation(string expression)
        {
            StringBuilder rpnString = new StringBuilder(expression.Length);
            Stack<char> operators = new Stack<char>();

            foreach (var item in expression)
            {
                if (char.IsDigit(item) || item == ',' || item == 'e' || item == 'π')
                {
                    rpnString.Append(item);
                    continue;
                }

                if (rpnString.Length > 0 && rpnString[rpnString.Length - 1] != ' ')
                    rpnString.Append(' ');

                if (item == '(' || operators.Count == 0)
                {
                    operators.Push(item);
                    continue;
                }

                if (item == ')')
                {
                    while (operators.Peek() != '(')
                    {
                        rpnString.Append(operators.Pop());
                        rpnString.Append(' ');
                    }
                    operators.Pop();
                    if (operators.Count > 0)
                    {
                        if (char.IsLetter(operators.Peek()))
                        {
                            rpnString.Append(operators.Pop());
                            rpnString.Append(' ');
                        }
                    }
                    continue;
                }

                if (!_operatorsRate.TryGetValue(item, out _)) throw new FormatException();

                if (_operatorsRate[operators.Peek()] < _operatorsRate[item])
                {
                    operators.Push(item);
                    continue;
                }

                while (_operatorsRate[operators.Peek()] >= _operatorsRate[item])
                {
                    rpnString.Append(operators.Pop());
                    rpnString.Append(' ');

                    if (operators.Count == 0) break;
                }

                operators.Push(item);
            }

            if (operators.Count > 0)
            {
                if (rpnString.Length > 0 && rpnString[rpnString.Length - 1] != ' ')
                    rpnString.Append(' ');
                rpnString.Append(string.Join(" ", operators.ToArray()));
            }

            return rpnString.ToString().Trim();
        }

        private static double SolvePostfixNotation(string expression)
        {
            Stack<double> numbers = new Stack<double>();

            foreach (var item in expression.Split(' '))
            {
                if (item == "π")
                {
                    numbers.Push(Math.PI);
                    continue;
                }

                if (item == "e")
                {
                    numbers.Push(Math.E);
                    continue;
                }
                if (double.TryParse(item, out double number))
                {
                    numbers.Push(number);
                    continue;
                }

                double fArg = numbers.Pop();
                double sArg = 0;
                if (!char.IsLetter(item[0]))
                {
                    if (numbers.Count == 0) return fArg;
                    sArg = numbers.Pop();
                }

                switch (item)
                {
                    case "+":
                        numbers.Push(sArg + fArg);
                        break;
                    case "-":
                        numbers.Push(sArg - fArg);
                        break;
                    case "×":
                        numbers.Push(sArg * fArg);
                        break;
                    case "÷":
                        if (fArg == 0) throw new DivideByZeroException();
                        numbers.Push(sArg / fArg);
                        break;
                    case "^":
                        numbers.Push(Math.Pow(sArg, fArg));
                        break;
                    case "s":
                        numbers.Push(Math.Sin(fArg));
                        break;
                    case "c":
                        numbers.Push(Math.Cos(fArg));
                        break;
                    case "t":
                        numbers.Push(Math.Tan(fArg));
                        break;
                    case "q":
                        numbers.Push(Math.Sqrt(fArg));
                        break;
                }
            }
            return numbers.Pop();
        }

    }
}
