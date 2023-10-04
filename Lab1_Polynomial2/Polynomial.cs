using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Polynomial2
{
    public class Polynomial : IPolynomial
    {
        public Node head;
        private int size;
        private int[] coefs;
        private int[] powers;

        public int[] Coefs { get { return coefs; } set { coefs = value; } }
        public int[] Powers  { get { return powers; } set { powers = value; } }
        public int Size { get { return size; } set { size = value; } }

        public Polynomial()
        {
            head = null;
        }

        public Polynomial(int[] coefs, int[] powers)
        {
            for (int i = 0; i < coefs.Length; i++)
            {
                if (head == null)
                {
                    AddNode(coefs[i], powers[i]);
                    this.Coefs = coefs;

                }
                else
                {
                    Node current = head;
                    while (current.PointerNext != null)
                    {
                        current = current.PointerNext;
                    }
                    AddNode(coefs[i], powers[i]);
                }
            }
        }

        public Polynomial(Polynomial p)//Object(B); Object == B;
        {
            if (p == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                Node current = p.head;
                while (current != null)
                {
                    AddNode(current.Coef, current.Power);
                    current = current.PointerNext;
                }
            }
        }

        public void AddNode(double coef, int power)
        {
            Node newNode = new Node(coef, power);

            if (head == null)
            {
                head = newNode;
                Size = 1;
            }
            else
            {
                Node current = head;
                while (current.PointerNext != null)
                {
                    current = current.PointerNext;
                }
                current.PointerNext = newNode;
                Size++;
            }
        }
        public static void Bubble_Sort(int[] anArray)
        {
            for (int i = 0; i < anArray.Length; i++)
            {
                for (int j = 0; j < anArray.Length - 1 - i; j++)
                {
                    if (anArray[j] > anArray[j + 1])
                    {
                        Swap(ref anArray[j], ref anArray[j + 1]);
                    }
                }
            }
        }
        public static void Swap(ref int aFirstArg, ref int aSecondArg)
        {
            int tmpParam = aFirstArg;
            aFirstArg = aSecondArg;
            aSecondArg = tmpParam;
        }

        public double CalcPol(double value)
        {
            double res = 0;
            Node current = head;

            while (current != null)
            {
                res += current.Coef * (double)Math.Pow(value, current.Power);
                current = current.PointerNext;
            }

            return res;
        }

        public Polynomial MultNum(double number)
        {
            Node current = head;
            while (current != null)
            {
                current.Coef *= number;
                current = current.PointerNext;
            }
            return this;
        }

        public Polynomial SubNum(double number)
        {
            Node current = head;
            var result = new Polynomial(this);

            while (current != null)
            { 
                if (this.head.Power == 0)
                {
                    current.Coef = this.head.Coef - number;
                    break;
                }

                current = current.PointerNext;
            }

            if (current == null)
            {
                current.Coef = -number;
                AddNode(current.Coef, 0);
            }
            return result;
        }
        public Polynomial SumNum(double number)
        {
            Node current = head;
            var result = new Polynomial(this);

            while (current != null)
            {
                if (this.head.Power == 0)
                {
                    current.Coef = this.head.Coef + number;
                    break;
                }

                current = current.PointerNext;
            }

            if (current == null)
            {
                current.Coef = number;
                AddNode(current.Coef, 0);
            }
            return result;
        }
        public Polynomial SubPol(Polynomial p) {
            if (p == null)
            {
                throw new NullReferenceException();
            }
            else
            {

                var result = new Polynomial();
                Node currentThisNode = this.head;
                Node currentSubNode = p.head;

                while (currentThisNode != null)
                {
                    if (currentSubNode != null && currentThisNode.Power == currentSubNode.Power)
                    {
                        result.AddNode(currentThisNode.Coef - currentSubNode.Coef, currentThisNode.Power);
                        currentSubNode = currentSubNode.PointerNext;
                    }
                    else
                    {
                        result.AddNode(currentThisNode.Coef, currentThisNode.Power);
                    }

                    currentThisNode = currentThisNode.PointerNext;
                }

                while (currentSubNode != null)
                {
                    result.AddNode(-currentSubNode.Coef, currentSubNode.Power);
                    currentSubNode = currentSubNode.PointerNext;
                }

                return result;
            }
        }
        public Polynomial SumPol(Polynomial p)
        {
            if (p == null)
            {
                throw new NullReferenceException();
            }
            else { 
                var result = new Polynomial();
                Node currentThisNode = this.head;
                Node currentAddNode = p.head;

                while (currentThisNode != null || currentAddNode != null)
                {
                    if (currentThisNode != null && currentAddNode != null && currentThisNode.Power == currentAddNode.Power)
                    {
                        result.AddNode(currentThisNode.Coef + currentAddNode.Coef, currentThisNode.Power);
                        currentThisNode = currentThisNode.PointerNext;
                        currentAddNode = currentAddNode.PointerNext;
                    }
                    else if (currentThisNode != null && (currentAddNode == null || currentThisNode.Power < currentAddNode.Power))
                    {
                        result.AddNode(currentThisNode.Coef, currentThisNode.Power);
                        currentThisNode = currentThisNode.PointerNext;
                    }
                    else if (currentAddNode != null)
                    {
                        result.AddNode(currentAddNode.Coef, currentAddNode.Power);
                        currentAddNode = currentAddNode.PointerNext;
                    }
                }

                return result;
            }
        }

        public Polynomial Multi(Polynomial polynom)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string result = null;
            int dim = 0;
            foreach (double coef in Coefs)
            {
                result += coef.ToString() + "x^" + dim.ToString() + " + ";
                dim++;
            }
            result = result.Remove(result.Length - 3, 3);
            return result;
        }

        public override bool Equals(object obj)
        {
            return obj is Polynomial p1 && p1.Size == Size && p1.Coefs.SequenceEqual(Coefs);

        }

        public override int GetHashCode()
        {
            int hashCode = -1837172754;
            hashCode = hashCode * -1521134295 + Size.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<int[]>.Default.GetHashCode(Coefs);
            return hashCode;
        }
    }
}
