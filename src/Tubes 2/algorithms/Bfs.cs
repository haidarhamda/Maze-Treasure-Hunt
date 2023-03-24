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
            Queue<Tuple<int[], List<int[]>>> q = new Queue<Tuple<int[], List<int[]>>>();
            List<int[]> visited = new List<int[]> { startingPoint };
            int totalTreasure = this.map.getTreasureAmount();
            int currentTreasure = 0;
            q.Enqueue(new Tuple<int[], List<int[]>>(startingPoint, new List<int[]>()));
            int[] nextNode = new int[2];
            List<int[]> path = new List<int[]>();
            bool solved = true;
            List<int[]> visited2 = new List<int[]>();
            while (currentTreasure < totalTreasure)
            {

                while (q.Count > 0)
                {
                    Tuple<int[], List<int[]>> t = q.Dequeue();
                    int[] currentNode = t.Item1;
                    Console.Write(currentNode[0].ToString() + " " + currentNode[1].ToString() + " ");

                    path = t.Item2;
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
                                List<int[]> temp = new List<int[]>();
                                //path.Add(currentNode);
                                temp.AddRange(path);
                                temp.Add(currentNode);
                                //temp.Add(currentNode);
                                q.Enqueue(new Tuple<int[], List<int[]>>(nextNode, temp));
                                visited.Add(nextNode);
                            }
                        }
                    }
                }
                visited2.AddRange(visited);
                q.Clear();
                visited.Clear();
                if (currentTreasure < totalTreasure)
                {
                    path.Remove(path.Last());
                }
                q.Enqueue(new Tuple<int[], List<int[]>>(startingPoint, path));
            }
            if (currentTreasure != totalTreasure)
            {
                solved = false;
            }
            return new Tuple<List<int[]>, List<int[]>, bool>(path, visited2, solved);
        }
    }
}
