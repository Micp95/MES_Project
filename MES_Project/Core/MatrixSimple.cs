using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES_Project.Core
{
    class MatrixSimple
    {

        public double[,] arr { get; set; }
        public MatrixSimple(int x, int y)
        {
            arr = new double[x, y];
            for( var k=0; k < x; k++)
                for (var p = 0; p < y; p++)
                    arr[k,p] = 0;

        }
        public double getValue(int x,int y)
        {
            return arr[x, y];
        }
        public void setValue(int x, int y, double val)
        {
            arr[x, y] = val;
        }
        public void addValue(int x, int y, double val)
        {
            arr[x, y] += val;
        }
    }
}
