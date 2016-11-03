using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MES_Project.Project_1.Node;

namespace MES_Project.Project_1
{
    class DataController
    {

        public static Mesh LoadMehs(string fileName)
        {
            Mesh res = null;
            SimpleMashData simpleTmp = null;
            //JsonConvert.DeserializeObject<Movie>(json);
            using (StreamReader outputFile = new StreamReader(fileName))
            {
                string tmpS =  outputFile.ReadToEnd();
                simpleTmp = JsonConvert.DeserializeObject<SimpleMashData>(tmpS);
            }

            if ( simpleTmp != null)
            {
                List<Node> nodes = new List<Node>();
                List<Element> elements = new List<Element>();

                foreach (SimpleNodeData node in simpleTmp.nodes)
                {
                    nodes.Add(new Node(node.id, node.funkcja));
                }


                foreach (SimpleElementData element in simpleTmp.elements)
                {
                    Node node1 = nodes.Where(n => n.myId == element.idNode1).First();
                    Node node2 = nodes.Where(n => n.myId == element.idNode2).First();
                    elements.Add(new Element(element.s, element.l, element.k, node1, node2, simpleTmp.uklad));
                }

                res = new Mesh() {elements=elements,nodes=nodes,pN=nodes.Count,pE = elements.Count };
            }

            return res;
        }
        public static void generateMashToFile(string fileName)
        {
            SimpleMashData tmp = new SimpleMashData();
            List<SimpleNodeData> nodes = new List<SimpleNodeData>();
            nodes.Add(new SimpleNodeData() {id=1,funkcja= conditions .none});
            List<SimpleElementData> elements = new List<SimpleElementData>();
            elements.Add(new SimpleElementData() { idNode1 = 1, idNode2 =1 });
            tmp.nodes = nodes;
            tmp.elements = elements;
            tmp.uklad = new System(0,0,0);

            string jsonStr = JsonConvert.SerializeObject(tmp);

            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                outputFile.WriteLine(jsonStr);
            }
        }

        class SimpleMashData
        {
            public System uklad { get; set; }

            public List<SimpleNodeData> nodes { get; set; }
            public List<SimpleElementData> elements { get; set; }
        }

        class SimpleNodeData
        {
            public int id { get; set; }

            public conditions funkcja { get; set; }
        }
        class SimpleElementData
        {
            public double s { get; set; }
            public double l { get; set; }
            public double k { get; set; }

            public int idNode1 { get; set; }
            public int idNode2 { get; set; }
        }

    }
}
