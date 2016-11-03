using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES_Project.Project_1
{
    class System
    {
        public double alfa { get; }
        public double tEnv { get; }
        public double q { get; }

        public System( double alfa, double tEnv, double q)
        {
            this.alfa = alfa;
            this.tEnv = tEnv;
            this.q = q;
        }
    }
}
