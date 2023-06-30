using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadDemo
{
     public class MatrixPar
    {
        public readonly int dim;
        public readonly int i;
        public readonly int j;
        public readonly double[,] a;
        public readonly double[,] b;
        public double result;
        public readonly Thread thisThread;
        public MatrixPar(int dim,int i, int j, double[,] a, double[,] b, Thread thisThread)
        {
            this.a = a;
            this.dim = dim;
            this.i = i;
            this.j = j;
            this.b = b;
            this.thisThread = thisThread;   

        }
    }
}
