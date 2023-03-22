using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes_2.algorithms
{
    public partial class Tsp : Solver
    {
        public Tsp(Map map) : base(map) { }

        public Tuple<List<int[]>, List<int[]>> tsproblem()
        {
            Bfs bfs = new Bfs(this.map);
            Tuple<List<int[]>, List<int[]>, bool> bfsResult = bfs.bfsearch();

            Dfs dfs = new Dfs(this.map);
            Tuple<List<int[]>, List<int[]>, bool> dfsResult = dfs.dfsearch();

            Tuple<List<int[]>, List<int[]>> searchResult;

            if (bfsResult.Item1.Count < dfsResult.Item1.Count)
            {
                searchResult = new Tuple<List<int[]>, List<int[]>>(bfsResult.Item1, bfsResult.Item2);
            }
            else
            {
                searchResult = new Tuple<List<int[]>, List<int[]>>(dfsResult.Item1, dfsResult.Item2);
            }

            Tuple<List<int[]>, List<int[]>> routeBack = getRouteBack(searchResult.Item1[searchResult.Item1.Count-1]);
            List<int[]> tspSolution = new List<int[]>(searchResult.Item1);
            List<int[]> tspSearching = new List<int[]>(searchResult.Item2);
            routeBack.Item1.RemoveAt(0);
            routeBack.Item2.RemoveAt(0);
            tspSolution.AddRange(routeBack.Item1);
            tspSearching.AddRange(routeBack.Item2);

            return new Tuple<List<int[]>, List<int[]>>(tspSolution, tspSearching);
        }

        public Tuple<List<int[]>, List<int[]>> getRouteBack(int[] current)
        {
            String[,] maze = this.map.getMap();
            int[] start = this.map.getStartingPoint();
            int[] direction = heuristicDirection(start, current);

            Stack<List<int[]>> nodeStack = new Stack<List<int[]>>();
            List<List<int[]>> solution = new List<List<int[]>>();
            List<List<int[]>> searchingRoute = new List<List<int[]>>();
            List<int[]> visited = new List<int[]>();

            bool back = false;
            List<int[]> temp = new List<int[]>();
            List<int[]> currentTop = new List<int[]>();
            int[] currentNode;

            nodeStack.Push(new List<int[]> { current });
            direction.Reverse();

            while (nodeStack.Count > 0 && !back)
            {
                currentTop = nodeStack.Pop();
                currentNode = currentTop[currentTop.Count - 1];
                temp = currentTop.ToList();

                visited.Add(currentNode);

                if (!isBranched(maze, visited, currentNode))
                {
                    searchingRoute.Add(currentTop);
                }

                if (maze[currentNode[0], currentNode[1]] == "K")
                {
                    solution.Add(currentTop);
                    back = true;
                }

                foreach (int i in direction)
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

            return new Tuple<List<int[]>, List<int[]>>(optimizedRoute(solution), optimizedRoute(searchingRoute));
        }

        public int[] heuristicDirection(int[] startPoint, int[] currentPoint)
        {
            int[] result;
            if (startPoint[0] < currentPoint[0])
            {
                if (startPoint[1] < currentPoint[1])
                {
                    result = new int[4] { 0, 1, 2, 3 };
                }
                else result = new int[4] {2, 1, 0, 3};
            }
            else
            {
                if (startPoint[1] < currentPoint[1])
                {
                    result = new int[4] { 0, 3, 2, 1 };
                }
                else result = new int[4] { 2, 3, 0, 1 };
            }

            return result;
        }
    }
}
