using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Tubes_2.algorithms
{
    public partial class Dfs : Solver
    {
        public Dfs(Map map) : base(map) { }
        public Tuple<List<int[]>, List<int[]>, bool> dfsearch()
        {
            String[,] maze = this.map.getMap();
            int[] startingPoint = this.map.getStartingPoint();
            int nTreasure = this.map.getTreasureAmount();
            Stack<List<int[]>> nodeStack = new Stack<List<int[]>>();
            List<List<int[]>> solution = new List<List<int[]>>();
            List<List<int[]>> searchingRoute = new List<List<int[]>>();
            List<int[]> visited = new List<int[]>();

            bool solved;
            int treasureGet = 0;
            List<int[]> temp = new List<int[]>();
            List<int[]> currentTop = new List<int[]>();
            int[] currentNode;

            nodeStack.Push(new List<int[]> { startingPoint });

            while (nodeStack.Count > 0 && treasureGet != nTreasure)
            {
                currentTop = nodeStack.Pop();
                currentNode = currentTop[currentTop.Count - 1];
                temp = currentTop.ToList();
                if (maze[currentNode[0], currentNode[1]] == "T" && !isVisited(visited, currentNode))
                {
                    solution.Add(currentTop);
                    treasureGet++;
                }
                visited.Add(currentNode);

                if (!isBranched(maze, visited, currentNode))
                {
                    searchingRoute.Add(currentTop);
                }

                

                for (int i = 0; i < 4; i++)
                {
                    int[] nextNode = getNextNode(currentNode, i);
                    if (maze[nextNode[0], nextNode[1]] != "X" && !isVisited(visited, nextNode))
                    {
                        temp.Add(nextNode);
                        nodeStack.Push(new List<int[]>(temp));
                        temp.RemoveAt(temp.Count - 1);
                    }
                }
                temp.Clear();
            }
            if (!searchingRoute.Contains(currentTop))
            {
                searchingRoute.Add(currentTop);
            }
            if (treasureGet != nTreasure)
            {
                solved = false;
            }
            else solved = true;

            return new Tuple<List<int[]>, List<int[]>, bool>(createRoute(solution), createRoute(searchingRoute), solved);
        }
    }
}

