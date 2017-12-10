using AdventOfCode2017.Helpers;
using AdventOfCode2017.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public static class DaySevenRecursiveCircus
    {
        /// <summary>
        /// Gets the name of the bottom program.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static string GetBottomProgramName(string fileName, out int correctedWeight)
        {
            string filePath = ReadFromTextFile.GetFilePath(fileName);

            string[] fileContent = ReadFromTextFile.GetAllLines(filePath);

            return GetBottomProgramName(fileContent, out correctedWeight);
        }

        /// <summary>
        /// Gets the name of the bottom program.
        /// </summary>
        /// <param name="nodeData">The node data.</param>
        /// <returns></returns>
        public static string GetBottomProgramName(string[] nodeData, out int correctedWeight)
        {
            correctedWeight = 0;

            Node bottomNode = new Node();
            List<Node> nodeList = GetAllNode(nodeData);

            List<Node> parentNodes = nodeList.Where(n => n.HasChild).Select(n => n).ToList();

            // Get the bottom program
            foreach (Node node in parentNodes)
            {
                Node parent = parentNodes.Where(n => n.ChildNames.Contains(node.Name)).Select(n => n).FirstOrDefault();

                //Build node tree
                if (parent == null)
                {
                    bottomNode = node;
                    break;
                }
            }

            bottomNode = BuildChildNode(bottomNode.Name, nodeList);

            Dictionary<string, int> nodeWithOverallWeight = new Dictionary<string, int>();
            foreach (Node node in bottomNode.ChildNodes)
            {
                int sum = 0;
                int totalWeight = GetChildWeight(node, ref sum);
                nodeWithOverallWeight.Add(node.Name, totalWeight + node.Weight);
            }

            int actualValue = nodeWithOverallWeight.Values.ToList().GroupBy(x => x).Select(g => new { Value = g.Key, Count = g.Count() }).Where(v => v.Count > 1).Select(c => c.Value).FirstOrDefault();
            int mismatchedValue = nodeWithOverallWeight.Values.ToList().GroupBy(x => x).Select(g => new { Value = g.Key, Count = g.Count() }).Where(v => v.Count == 1).Select(c => c.Value).FirstOrDefault();

            Node unbalancedParentNode = bottomNode.ChildNodes.Where(n => n.Name == nodeWithOverallWeight.Where(m => m.Value == mismatchedValue).Select(o => o.Key).FirstOrDefault()).FirstOrDefault();

            Node unbalancedNode = new Node();

            GetNodeCausingUnbalance(unbalancedParentNode, ref unbalancedNode);

            correctedWeight = unbalancedNode.Weight - (mismatchedValue - actualValue);

            return bottomNode.Name;
        }

        /// <summary>
        /// Gets the node causing unbalance.
        /// </summary>
        /// <param name="unbalancedParentNode">The unbalanced parent node.</param>
        /// <param name="unbalancedNode">The unbalanced node.</param>
        private static void GetNodeCausingUnbalance(Node unbalancedParentNode, ref Node unbalancedNode)
        {
            Node returnNode = new Node();
            foreach (Node node in unbalancedParentNode.ChildNodes)
            {
                List<Node> nodeList = unbalancedParentNode.ChildNodes.Where(n => n.TotalChildWeight + n.Weight == node.TotalChildWeight + node.Weight).ToList();
                if (nodeList.Count() == unbalancedParentNode.ChildNodes.Count())
                {
                    unbalancedNode = unbalancedParentNode;
                }
                else if (nodeList.Count() == 1)
                {
                    GetNodeCausingUnbalance(node, ref unbalancedNode);
                }
                else
                {
                    GetNodeCausingUnbalance(unbalancedParentNode.ChildNodes.Where(n => n.TotalChildWeight + n.Weight != node.TotalChildWeight + node.Weight).FirstOrDefault(), ref unbalancedNode);
                }
            }
        }

        /// <summary>
        /// Gets the child weight.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        private static int GetChildWeight(Node node, ref int sum)
        {
            if (node.HasChild)
            {
                foreach (Node nod in node.ChildNodes)
                {
                    sum += nod.Weight;
                    GetChildWeight(nod, ref sum);
                }
            }

            return sum;
        }

        /// <summary>
        /// Builds the child node.
        /// </summary>
        /// <param name="nodeName">Name of the node.</param>
        /// <param name="nodeList">The node list.</param>
        /// <returns></returns>
        private static Node BuildChildNode(string nodeName, List<Node> nodeList)
        {
            Node node = nodeList.Where(n => n.Name == nodeName).Select(n => n).FirstOrDefault();
            if (node.HasChild)
            {
                foreach (string name in node.ChildNames)
                {
                    node.ChildNodes.Add(BuildChildNode(name, nodeList));
                    int sum = 0;
                    node.TotalChildWeight = GetChildWeight(node, ref sum);
                }
            }

            return node;
        }

        /// <summary>
        /// Gets all node.
        /// </summary>
        /// <param name="nodeData">The node data.</param>
        /// <returns></returns>
        private static List<Node> GetAllNode(string[] nodeData)
        {
            List<Node> nodeList = new List<Node>();

            foreach (string st in nodeData)
            {
                // Get weight
                int weight = int.Parse(Regex.Match(st, @"\d+").Value);

                // Get node name
                string[] data = DataHelper.GetDataAsStringArray(st);
                string name = data[0];

                bool hasChilds = data.Length > 2;

                List<string> childNames = new List<string>();
                if (hasChilds)
                {
                    childNames = GetChildNames(data);
                }

                nodeList.Add(new Node { Name = name, Weight = weight, HasChild = hasChilds, ChildNames = childNames, ChildNodes = new List<Node>() });
            }

            return nodeList;
        }

        /// <summary>
        /// Gets the child names.
        /// </summary>
        /// <param name="st">The st.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private static List<string> GetChildNames(string[] st)
        {
            List<string> childs = new List<string>();
            for (int i = 3; i < st.Length; i++)
            {
                childs.Add(st[i].Trim(new char[] { ',' }));
            }

            return childs;
        }
    }
}
