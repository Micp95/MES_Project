using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MES_Project.Core;


namespace MES_Project.Project_1
{
    class Project_1_main
    {
        public static void MainPr1()
        {
          //  DataController.generateMashToFile("firstEx.txt");
            Mesh myMesh = DataController.LoadMehs("prawilne.txt");

            MathController math = new MathController(myMesh);
            math.StartCalculate();

            int count = 0;
            foreach(Node nd in myMesh.nodes)
            {
                Console.WriteLine("Temperature in {0} node is:\t{1}", count++, nd.t);
            }

            Console.ReadLine();
        }

    }
}
