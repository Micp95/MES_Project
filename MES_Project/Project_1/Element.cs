using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MES_Project.Core;

namespace MES_Project.Project_1
{
    class Element
    {
        public int idNode1 { get; }    //indeks 1 wezla
        public int idNode2 { get; }    //indekx 2 wezla

        private Node node1;
        private Node node2;

        private double s;       //powierzchnia
        private double l;       //dlugosc
        private double k;       //wspolczynnik oddawania ciepla

        private System system; //parametry ukladu


        public MatrixSimple localMatrix { get; }
        public MatrixSimple localVector { get; }



        public Element(double s, double l, double k,Node node1, Node node2, System system)
        {
            this.s = s;
            this.l = l;
            this.k = k;
            this.node1 = node1;
            this.node2 = node2;
            this.system = system;

            localMatrix = new MatrixSimple(2, 2);
            localVector = new MatrixSimple(1, 2);

            idNode1 = node1.myId-1;
            idNode2 = node2.myId-1;

            InitializeLocals();
        }

        private void InitializeLocals()
        {
            double c = s * k / l;
            localMatrix.setValue(0, 0, c);
            localMatrix.setValue(1, 0, -c);
            localMatrix.setValue(0, 1, -c);
            localMatrix.setValue(1, 1, c);

            if(node1.myConditions == Node.conditions.convection)
            {
                localMatrix.addValue(0, 0, s*system.alfa);
                localVector.addValue(0, 0, (-1) * s * system.alfa * system.tEnv);
            }

            if (node2.myConditions == Node.conditions.convection)
            {
                localMatrix.addValue(1, 1, s * system.alfa);
                localVector.addValue(0, 1, (-1) * s * system.alfa * system.tEnv);
            }

            if (node1.myConditions == Node.conditions.heat)
                localVector.addValue(0, 0, s * system.q);


            if (node2.myConditions == Node.conditions.heat)
                localVector.addValue(0, 1, s * system.q);

        }


    }
}
