using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Polynomial2
{
    public class Node
    {
        private int power;
        private double coef;
        private Node pointerNext;
        //private int size;

        public int Power { get; set; }
        public double Coef { get; set; }
        public Node PointerNext { get; set; }
        //public int Size { get; set; }
        public Node() { }

        public Node(double coef, int power)
        {
            this.Power = power;
            this.Coef = coef;
            this.PointerNext = null;
            //Size++;
        }

        public Node(double coef, Node pointerNext)
        {
            this.Coef = coef;
            this.PointerNext = pointerNext;
            //Size++;
        }

        public Node(Node copy)
        {
            this.Coef = copy.coef;
            this.PointerNext = copy.pointerNext;
            //this.Size = copy.size;
            //Size++;

        }


    }
}
