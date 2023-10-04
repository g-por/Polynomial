using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Polynomial2
{
    internal interface IPolynomial
    {
        Polynomial SumNum(double number);
        Polynomial SumPol(Polynomial p);
        Polynomial SubNum(double number);
        Polynomial SubPol(Polynomial p);
        Polynomial MultNum(double number);
        Polynomial Multi(Polynomial polynom);
        double CalcPol(double value);

    }
}
