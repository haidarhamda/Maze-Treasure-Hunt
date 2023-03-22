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
            String[,] maze = this.map.getMap();
            int[] startingPoint = this.map.getStartingPoint();
            int nTreasure = this.map.getTreasureAmount();
            Queue<List<int[]>> nodeQueue = new Queue<List<int[]>>();
            List<List<int[]>> solution = new List<List<int[]>>();
            List<List<int[]>> route = new List<List<int[]>>();
            List<int[]> visited = new List<int[]>();

            bool solved;
            int currentTreasure = 0;
            List<int[]> temp = new List<int[]>();
            List<int[]> currentTop = new List<int[]>();
            int[] currentNode;

            nodeQueue.Enqueue(new List<int[]> { startingPoint });

            while (nodeQueue.Count > 0 && currentTreasure != nTreasure)
            {
                currentTop = nodeQueue.Dequeue();
                currentNode = currentTop[currentTop.Count - 1];
                temp = currentTop.ToList();

                visited.Add(currentNode);
                route.Add(currentTop);

                if (maze[currentNode[0], currentNode[1]] == "T")
                {
                    solution.Add(currentTop);
                    currentTreasure++;
                }

                for (int i = 0; i < 4; i++)
                {
                    int[] nextNode = getNextNode(currentNode, i);
                    if (maze[nextNode[0], nextNode[1]] != "X" && !isVisited(visited, nextNode))
                    {
                        temp.Add(nextNode);
                        nodeQueue.Enqueue(new List<int[]>(temp));
                        temp.RemoveAt(temp.Count - 1);
                    }
                }
                temp.Clear();
            }
            if (!route.Contains(currentTop))
            {
                route.Add(currentTop);
            }
            if (currentTreasure != nTreasure)
            {
                solved = false;
            }
            else solved = true;

            return new Tuple<List<int[]>, List<int[]>, bool>(optimizedRoute(solution), optimizedRoute(route), solved);
        }
    }
}
