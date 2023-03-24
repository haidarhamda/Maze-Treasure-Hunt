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

        public Tuple<List<int[]>, List<int[]>, List<int[]>> tspWithBfs()
        {
            return tsproblem("Bfs");
        }

        public Tuple<List<int[]>, List<int[]>, List<int[]>> tspWithDfs()
        {
            return tsproblem("Dfs");
        }

        public Tuple<List<int[]>, List<int[]>, List<int[]>> tsproblem(string mode)
        {
            Tuple<List<int[]>, List<int[]>> searchResult;

            if (string.Compare(mode, "Bfs") == 0)
            {
                Bfs bfs = new Bfs(this.map);
                Tuple<List<int[]>, List<int[]>, List<int[]>> bfsResult = bfs.bfsearch();
                searchResult = new Tuple<List<int[]>, List<int[]>>(bfsResult.Item1, bfsResult.Item2);
            }
            else
            {
                Dfs dfs = new Dfs(this.map);
                Tuple<List<int[]>, List<int[]>, List<int[]>> dfsResult = dfs.dfsearch();
                searchResult = new Tuple<List<int[]>, List<int[]>>(dfsResult.Item1, dfsResult.Item2);
            }

            List<int[]> visited = searchResult.Item2.ToList();

            Tuple<List<int[]>, List<int[]>> routeBack = getRouteBack(searchResult.Item1[searchResult.Item1.Count-1],visited);
            List<int[]> tspSolution = new List<int[]>(searchResult.Item1);
            List<int[]> tspSearching = new List<int[]>(searchResult.Item2);
            routeBack.Item1.RemoveAt(0);
            routeBack.Item2.RemoveAt(0);
            tspSolution.AddRange(routeBack.Item1);
            tspSearching.AddRange(routeBack.Item2);

            return new Tuple<List<int[]>, List<int[]>, List<int[]>>(tspSolution, tspSearching, visited);
        }

        public Tuple<List<int[]>, List<int[]>> getRouteBack(int[] current, List<int[]> visited)
        {
            String[,] maze = this.map.getMap();
            int[] start = this.map.getStartingPoint();
            int[] direction = heuristicDirection(start, current);

            Stack<List<int[]>> nodeStack = new Stack<List<int[]>>();
            List<List<int[]>> solution = new List<List<int[]>>();
            List<List<int[]>> searchingRoute = new List<List<int[]>>();

            bool back = false;
            List<int[]> temp = new List<int[]>();
            List<int[]> currentTop = new List<int[]>();
            List<int[]> visitedNow = new List<int[]>();
            int[] currentNode;

            nodeStack.Push(new List<int[]> { current });
            Array.Reverse(direction);

            while (nodeStack.Count > 0 && !back)
            {
                currentTop = nodeStack.Pop();
                currentNode = currentTop[currentTop.Count - 1];
                temp = currentTop.ToList();

                if (maze[currentNode[0], currentNode[1]] == "K")
                {
                    solution.Add(currentTop);
                    back = true;
                }
                visitedNow.Add(currentNode);

                if (!isBranched(maze, visited, currentNode))
                {
                    searchingRoute.Add(currentTop);
                }

                

                Queue<int[]> tempUnvisited = new Queue<int[]>();
                Queue<int[]> tempVisited = new Queue<int[]>();
                foreach (int i in direction)
                {
                    int[] nextNode = getNextNode(currentNode, i);
                    if (maze[nextNode[0], nextNode[1]] != "X" && !isVisited(visitedNow, nextNode))
                    {
                        if (!isVisited(visited, nextNode))
                        {
                            tempUnvisited.Enqueue(nextNode);
                        }
                        else
                        {
                            tempVisited.Enqueue(nextNode);
                        }
                    }
                }
                foreach (int[] nextVisited in tempVisited)
                {
                    temp.Add(nextVisited);
                    nodeStack.Push(new List<int[]>(temp));
                    temp.RemoveAt(temp.Count - 1);
                }
                foreach (int[] nextUnvisited in tempUnvisited)
                {
                    temp.Add(nextUnvisited);
                    nodeStack.Push(new List<int[]>(temp));
                    temp.RemoveAt(temp.Count - 1);
                }
                temp.Clear();
            }
            if (!searchingRoute.Contains(currentTop))
            {
                searchingRoute.Add(currentTop);
            }

            return new Tuple<List<int[]>, List<int[]>>(createRoute(solution), createRoute(searchingRoute));
        }
    }
}
