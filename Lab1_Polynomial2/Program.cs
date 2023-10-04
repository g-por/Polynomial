using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Polynomial2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Polynomial first = new Polynomial(new int[] {4, 5, 6 }, new int[] {3, 2, 1 });
            Polynomial second = new Polynomial(new int[] { 3, 4, 5, 6 }, new int[] {4, 3, 2, 1 });
            var result = first.SumPol(second);
            first.Coefs = result.Coefs;
            Console.WriteLine(result.Coefs);
            Console.ReadKey();
        }
    }
}
