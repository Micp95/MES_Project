using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES_Project.Project_1
{
    class Node
    {

        public double t { get; set; }               //temperatura
        public double x { get; }                    //polozenie
        public conditions myConditions { get; }     //warunek

        public int myId;

        public Node(int id, conditions myConditions)
        {
            myId = id;
            this.myConditions = myConditions;
        }

        public enum conditions
        {
            none, heat, convection
        }

    }
}
