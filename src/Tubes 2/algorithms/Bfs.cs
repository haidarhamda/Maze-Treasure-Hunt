using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes_2.algorithms
{
    public partial class Bfs : Solver
    {
        public Bfs(Map map) : base(map) { }

        public Tuple<List<int[]>, List<int[]>, bool> bfsearch()
        {
            int[] startingPoint = this.map.getStartingPoint();
            Queue<Tuple<int[], List<int[]>>> nodeQueue = new Queue<Tuple<int[], List<int[]>>>();
            List<int[]> visited = new List<int[]> { startingPoint };
            int totalTreasure = this.map.getTreasureAmount();
            int currentTreasure = 0;
            nodeQueue.Enqueue(new Tuple<int[], List<int[]>>(startingPoint, new List<int[]>()));
            int[] nextNode = new int[2];
            List<int[]> path = new List<int[]>();
            bool solved = true;
            List<int[]> searchRoute = new List<int[]>();
            while (currentTreasure < totalTreasure)
            {

                while (nodeQueue.Count > 0)
                {
                    Tuple<int[], List<int[]>> temp = nodeQueue.Dequeue();
                    int[] currentNode = temp.Item1;
                    Console.Write(currentNode[0].ToString() + " " + currentNode[1].ToString() + " ");
                    

                    path = temp.Item2;
                    foreach (var node in path)
                    {
                        Console.Write("<" + node[0].ToString() + "," + node[1].ToString() + "> ");
                    }
                    Console.WriteLine();
                    if (this.map.getMap()[currentNode[0], currentNode[1]] == "T")
                    {
                        currentTreasure++;
                        startingPoint = currentNode;
                        this.map.setMap(currentNode, "R");
                        path.Add(currentNode);
                        Console.WriteLine("Treasure Found");
                        break;
                    }
                    else
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            nextNode = getNextNode(currentNode, i);
                            if (!isVisited(visited, nextNode) && map.getMap()[nextNode[0], nextNode[1]] != "X")
                            {
                                List<int[]> tmp = new List<int[]>();
                                //path.Add(currentNode);
                                tmp.AddRange(path);
                                tmp.Add(currentNode);
                                //temp.Add(currentNode);
                                nodeQueue.Enqueue(new Tuple<int[], List<int[]>>(nextNode, tmp));
                                visited.Add(nextNode);
                            }
                        }
                    }
                    if(currentTreasure == totalTreasure)
                    {
                        break;
                    }
                }
                searchRoute.AddRange(visited);
                nodeQueue.Clear();
                visited.Clear();
                if (currentTreasure < totalTreasure)
                {
                    path.Remove(path.Last());
                }
                nodeQueue.Enqueue(new Tuple<int[], List<int[]>>(startingPoint, path));
            }
            if (currentTreasure != totalTreasure)
            {
                solved = false;
            }
            return new Tuple<List<int[]>, List<int[]>, bool>(path, searchRoute, solved);
        }
    }
}
