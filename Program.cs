using AlgoAndDataStructure.Stack;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AlgoAndDataStructure
{
    internal class Program
    {
        private async static Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Node Chain
            //Node first = new Node { Value = 3 };
            //Node middle = new Node { Value = 5 };
            //Node last = new Node { Value = 7 };
            //first.Next = middle;
            //middle.Next = last;
            //PrintList(first);
            var ll = new List<int>();

            Tuple<int, string> person =
                                    new Tuple<int, string>(1, "");
            //person.
            // var res = PostFixCalculator.PostfixCalc(new string[] { "4", "5", "6", "+", "*", "1", "-" });
            var res = PostFixCalculator.PostfixCalc(new string[] { "4", "5", "+" });
            Console.WriteLine(res);
            Console.Read();
            var ddd = new List<string> { "bose" };
        }

        private static void PrintList(Node node)
        {
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
        }
    }
}