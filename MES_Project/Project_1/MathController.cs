using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MES_Project.Core;
using Accord.Math;

namespace MES_Project.Project_1
{
    class MathController
    {
        public MatrixSimple global { get; }
        public MatrixSimple Gp { get; }
        public MatrixSimple Gt { get; }

        private Mesh myMesh;

        public MathController(Mesh myMesh)
        {
            this.myMesh = myMesh;

            global = new MatrixSimple(this.myMesh.pN, this.myMesh.pN);
            Gp = new MatrixSimple(1, this.myMesh.pN);
            Gt = new MatrixSimple(1, this.myMesh.pN);
        }

        public void StartCalculate()
        {
            CreateMatrixs();
            CalculateTemperatures();
        }

        private void CreateMatrixs()
        {
            foreach ( Element el in myMesh.elements)
            {
                global.addValue(el.idNode1,el.idNode1,el.localMatrix.getValue(0,0));
                global.addValue(el.idNode1, el.idNode2, el.localMatrix.getValue(1, 0));
                global.addValue(el.idNode2, el.idNode1, el.localMatrix.getValue(0, 1));
                global.addValue(el.idNode2, el.idNode2, el.localMatrix.getValue(1, 1));

                Gp.addValue(0, el.idNode1, el.localVector.getValue(0, 0));
                Gp.addValue(0, el.idNode2, el.localVector.getValue(0, 1));
            }

        }


        private void CalculateTemperatures()
        {

            double[,] matrix = global.arr;

            double[,] rightSide = Gp.arr;
           
            rightSide = Matrix.Transpose(rightSide);
            for ( var k =0; k < rightSide.Length;k++)
                rightSide[k, 0] = rightSide[k, 0] * (-1);

            Gt.arr = Matrix.Solve(matrix, rightSide, leastSquares: false);

            for (var k = 0; k < rightSide.Length; k++)
                myMesh.nodes[k].t = Gt.arr[k, 0];

        }

    }
}
