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
        private double[] coefs;
        private int[] powers;
        public void CheckAndRemoveZeroCoefficient()
        {
            Node current = head;
            Node previous = null;

            int newCoefsSize = 0;

            while (current != null)
            {
                if (current.Coef == 0)
                {
                    if (previous != null)
                    {
                        previous.PointerNext = current.PointerNext;
                        current = current.PointerNext;
                    }
                    else
                    {
                        head = current.PointerNext;
                        current = head;
                    }
                }
                else
                {
                    newCoefsSize++;
                    previous = current;
                    current = current.PointerNext;
                }
            }

            double[] newCoefs = new double[newCoefsSize];
            int[] newPowers = new int[newCoefsSize];

            current = head;
            int index = 0;

            while (current != null)
            {
                newCoefs[index] = current.Coef;
                newPowers[index] = current.Power;
                index++;

                current = current.PointerNext;
            }

            this.Coefs = newCoefs;
            this.Powers = newPowers;
        }
        public double[] Coefs { get { return coefs; } set { coefs = value; } }
        public int[] Powers  { get { return powers; } set { powers = value; } }
        public int Size { get { return size; } set { size = value; } }

        public Polynomial()
        {
            head = null;
            this.size = 0;
        }

        public Polynomial(double[] coefs, int[] powers)
        {
            for (int i = 0; i < coefs.Length; i++)
            {
                if (head == null)
                {
                    AddNode(coefs[i], powers[i]);
                    this.coefs = coefs;
                    this.powers = powers;

                }
                else
                {
                    Node current = head;
                    while (current.PointerNext != null)
                    {
                        current = current.PointerNext;
                    }
                    this.coefs = coefs;
                    this.powers = powers;
                    AddNode(coefs[i], powers[i]);
                }
            }
        }
        public Polynomial(Polynomial p)
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

            this.powers = p.Powers;
            this.coefs = p.Coefs;
        }

        public void AddNode(double coef, int power)
        {
            Node newNode = new Node(coef, power);
            if (head == null)
            {
                head = newNode;
                this.size = 1;
            }
            else
            {
                Node current = head;
                while (current.PointerNext != null)
                {
                    current = current.PointerNext;
                }
                current.PointerNext = newNode;
                this.size++;
            }
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
            Polynomial resultPolynomial = new Polynomial();

            double[] newCoefs = new double[this.Size];
            int[] newPowers = new int[this.Size];

            Node currentNode = this.head;

            int index = 0;
            while (currentNode != null)
            {
                double newCoef = currentNode.Coef * number;

                resultPolynomial.AddNode(newCoef, currentNode.Power);

                newCoefs[index] = newCoef;
                newPowers[index] = currentNode.Power;

                currentNode = currentNode.PointerNext;
                index++;
            }


            resultPolynomial.Coefs = newCoefs; 
            resultPolynomial.Powers = newPowers; 
            resultPolynomial.CheckAndRemoveZeroCoefficient();
            return resultPolynomial;
        }
        public Polynomial SubNum(double number)
        {
            int indexForConstant = -1;

            for (int i = 0; i < this.powers.Length; i++)
            {
                if (this.powers[i] == 0)
                {
                    this.coefs[i] -= number;
                    indexForConstant = i;
                    break;
                }
            }
            if (indexForConstant == -1)
            {
                Array.Resize(ref this.coefs, this.coefs.Length + 1);
                Array.Resize(ref this.powers, this.powers.Length + 1);

                this.coefs[this.coefs.Length - 1] = -number;
                this.powers[this.powers.Length - 1] = 0;
            }
            else if (this.coefs[indexForConstant] == 0)
            {
                double[] newCoefs = new double[this.coefs.Length - 1];
                int[] newPowers = new int[this.powers.Length - 1];

                for (int i = 0, j = 0; i < this.coefs.Length; i++)
                {
                    if (i != indexForConstant)
                    {
                        newCoefs[j] = this.coefs[i];
                        newPowers[j] = this.powers[i];
                        j++;
                    }
                }

                this.coefs = newCoefs;
                this.powers = newPowers;
            }

            return this;
        }

        public Polynomial SumNum(double number)
        {
            bool constantTermFound = false;
            int newSize = this.Size;

            for (int i = 0; i < this.Size; i++)
            {
                if (this.powers[i] == 0)
                {
                    this.coefs[i] += number;
                    constantTermFound = true;
                    break;
                }
            }

            if (!constantTermFound)
            {
                newSize += 1;

                double[] newCoefs = new double[newSize];
                int[] newPowers = new int[newSize];

                for (int i = 0; i < this.Size; i++)
                {
                    newCoefs[i] = this.coefs[i];
                    newPowers[i] = this.powers[i];
                }

                newCoefs[newSize - 1] = number;
                newPowers[newSize - 1] = 0;

                this.coefs = newCoefs;
                this.powers = newPowers;
            }

            return new Polynomial(this.coefs, this.powers);
        }

        public Polynomial SubPol(Polynomial p)
        {
            if (p == null)
            {
                throw new NullReferenceException();
            }

            var result = new Polynomial();

            Node currentThisNode = this.head;
            Node currentSubNode = p.head;

            while (currentThisNode != null || currentSubNode != null)
            {
                if (currentSubNode == null || (currentThisNode != null && currentThisNode.Power > currentSubNode.Power))
                {
                    result.AddNode(currentThisNode.Coef, currentThisNode.Power);
                    currentThisNode = currentThisNode.PointerNext;
                }
                else if (currentThisNode == null || (currentSubNode != null && currentThisNode.Power < currentSubNode.Power))
                {
                    result.AddNode(-currentSubNode.Coef, currentSubNode.Power);
                    currentSubNode = currentSubNode.PointerNext;
                }
                else
                {
                    double coefDifference = currentThisNode.Coef - currentSubNode.Coef;
                    if (coefDifference != 0)
                    {
                        result.AddNode(coefDifference, currentThisNode.Power);
                    }
                    currentThisNode = currentThisNode.PointerNext;
                    currentSubNode = currentSubNode.PointerNext;
                }
            }

            result.CheckAndRemoveZeroCoefficient();
            return result;
        }

        public Polynomial SumPol(Polynomial p)
        {
            if (p == null)
            {
                throw new NullReferenceException();
            }

            int maxSize = this.size + p.size; // максимальний можливий розмір
            double[] tempCoefs = new double[maxSize];
            int[] tempPowers = new int[maxSize];
            int currentIndex = 0;

            Node currentThisNode = this.head;
            Node currentAddNode = p.head;

            while (currentThisNode != null || currentAddNode != null)
            {
                int thisPower = (currentThisNode != null) ? currentThisNode.Power : int.MinValue;
                int addPower = (currentAddNode != null) ? currentAddNode.Power : int.MinValue;

                if (thisPower == addPower)
                {
                    tempCoefs[currentIndex] = currentThisNode.Coef + currentAddNode.Coef;
                    tempPowers[currentIndex] = thisPower;
                    currentIndex++;

                    currentThisNode = currentThisNode.PointerNext;
                    currentAddNode = currentAddNode.PointerNext;
                }
                else if (thisPower > addPower || currentAddNode == null)
                {
                    tempCoefs[currentIndex] = currentThisNode.Coef;
                    tempPowers[currentIndex] = thisPower;
                    currentIndex++;

                    currentThisNode = currentThisNode.PointerNext;
                }
                else
                {
                    tempCoefs[currentIndex] = currentAddNode.Coef;
                    tempPowers[currentIndex] = addPower;
                    currentIndex++;

                    currentAddNode = currentAddNode.PointerNext;
                }
            }

            Array.Resize(ref tempCoefs, currentIndex);
            Array.Resize(ref tempPowers, currentIndex);

            return new Polynomial(tempCoefs, tempPowers);
        }
        public Polynomial Multi(Polynomial second)
        {
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            double[] newCoefs = new double[this.size + second.size];
            int[] newPowers = new int[this.size + second.size];
            int currentIndex = 0;

            Node currentThisNode = this.head;
            while (currentThisNode != null)
            {
                Node currentSecondNode = second.head;
                while (currentSecondNode != null)
                {
                    double coef = currentThisNode.Coef * currentSecondNode.Coef;
                    int power = currentThisNode.Power + currentSecondNode.Power;

                    if (coef != 0)
                    {
                        int existingIndex = Array.IndexOf(newPowers, power, 0, currentIndex);
                        if (existingIndex != -1)
                        {
                            newCoefs[existingIndex] += coef;
                        }
                        else
                        {
                            newCoefs[currentIndex] = coef;
                            newPowers[currentIndex] = power;
                            currentIndex++;
                        }
                    }

                    currentSecondNode = currentSecondNode.PointerNext;
                }
                currentThisNode = currentThisNode.PointerNext;
            }
            Array.Resize(ref newCoefs, currentIndex);
            Array.Resize(ref newPowers, currentIndex);

            return new Polynomial(newCoefs, newPowers);
        }

        public override string ToString()
        {
            if (head == null || (coefs.Length == 1 && coefs[0] == 0)) return "0";
            if (coefs == null || powers == null) return "Error: Coefficients or Powers not initialized!";

            StringBuilder result = new StringBuilder();
            bool firstTerm = true;

            for (int i = 0; i < coefs.Length; i++)
            {
                if (coefs[i] == 0) continue;

                if (!firstTerm)
                {
                    if (coefs[i] > 0) result.Append(" + ");
                    else if (coefs[i] < 0) result.Append(" - ");
                }
                else
                {
                    firstTerm = false;
                }

                if (powers[i] != 0 && Math.Abs(coefs[i]) != 1) result.Append(Math.Abs(coefs[i]).ToString());
                else if (powers[i] == 0) result.Append(coefs[i].ToString());

                if (powers[i] != 0) result.Append("x^" + powers[i].ToString());
            }

            if (result.Length == 0) return "0";
            return result.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Polynomial))
                return false;
            Node current1 = head;
            Node current2 = ((Polynomial)obj).head;

            while (current1 != null && current2 != null)
            {
                if (current1.Coef != current2.Coef || current1.Power != current2.Power)
                {
                    return false;
                }

                current1 = current1.PointerNext;
                current2 = current2.PointerNext;
            }
            return current1 == null && current2 == null;

        }
        public override int GetHashCode()
        {
            int hashCode = -1837172754;
            hashCode = hashCode * -1521134295 + Size.GetHashCode();
            hashCode = hashCode * -1521134295 + Coefs.Aggregate(0, (acc, val) => acc * -1521134295 + val.GetHashCode());
            return hashCode;
        }
    }
}
