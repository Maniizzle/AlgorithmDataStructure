using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoAndDataStructure.Stack
{
    public class PostFixCalculator
    {
        public static int PostfixCalc(string[] tokens)
        {
            Stack.Stack<int> values = new Stack<int>();
            foreach (var token in tokens)
            {
                var stat = int.TryParse(token, out int result);
                if (stat)
                {
                    values.Push(result);
                }
                else
                {
                    int rsv = values.Pop();
                    int lsv = values.Pop();

                    switch (token.Trim())
                    {
                        case "+":
                            values.Push(lsv + rsv);
                            break;

                        case "-":
                            values.Push(lsv - rsv);
                            break;

                        case "*":
                            values.Push(lsv * rsv);
                            break;

                        case "/":
                            values.Push(lsv / rsv);
                            break;

                        case "%":
                            values.Push(lsv % rsv);
                            break;

                        default:
                            throw new InvalidOperationException("Invalid token");
                    }
                }
            }
            return values.Pop();
        }
    }
}