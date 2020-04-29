using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GASuccessCalculator.EquationParser
{
    public class Equation
    {
        private string expression;

        private List<string> expressions = new List<string>();

        public Equation(string expression)
        {
            this.expression = expression;

        }

        private static IOperand<T> SplitOnStringExpressions<T>(string expr)
        {
            string brace;
            while ((brace = GetDeepestBrace(expr)) != null)
            {

            }
        }

        private static Operator ParseOperator(string expr, OperandParser parser)
        {
            var regex = new Regex(@"(?x) (\S+?) (\s*) ([+-/]+) (\s*) (\S+?)");
            Match m = regex.Match(expr);

            string first = m.Groups[1].Value;
            string operat = m.Groups[2].Value;
            string second = m.Groups[3].Value;

            var fOp = parser.TryGetOperand(first);
            var sOp = parser.TryGetOperand(second);
            var operatorFunc = GetOperatorFunc(fOp.Value, sOp.Value, operat);

            return new Operator(fOp, sOp, operatorFunc);
        }

        private static Func<dynamic, dynamic, dynamic> GetOperatorFunc(dynamic a, dynamic b, string oper)
        {
            switch (oper)
            {
                case "+":
                    return (x, y) => x + y;
                case "-":
                    return (x, y) => x - y;
                case "*":
                    return (x, y) => x * y;
                case "/":
                    return (x, y) => x / y;
                default: return null;
            }
        }


        private static string GetDeepestBrace(string expr)
        {
            Regex reg = new Regex(@"(?x) \( ([^(]+?) \)");
            Match match = reg.Match(expr);
            if (reg.IsMatch(expr))
            {
                return match.Value;
            }

            return null;
        }


    }

    class OperandParser
    {
        public ValueOperand TryGetOperand(string expr)
        {
            if (int.TryParse(expr, out int intRes))
            {
                return new ValueOperand { Value = intRes };
            }
            if (Double.TryParse(expr, out double doubleRes))
            {
                return new ValueOperand { Value = doubleRes };
            }

            return null;
        }
    }

    interface IOperand
    {
        object Calculate();
    }

    class ValueOperand : IOperand
    {
        public dynamic Value { set; get; }

        public dynamic Calculate()
        {
            return Value;
        }
    }

    class Operator : IOperand
    {
        public IOperand First { set; get; }
        public IOperand Second { set; get; }

        private Func<dynamic, dynamic, dynamic> func;

        public Operator(IOperand first, IOperand second, Func<dynamic, dynamic, dynamic> func)
        {
            First = first;
            Second = second;
            this.func = func;
        }

        public dynamic Calculate()
        {
            return func(First.Calculate(), Second.Calculate());
        }
    }


}
