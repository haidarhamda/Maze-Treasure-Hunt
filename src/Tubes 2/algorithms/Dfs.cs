using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Tubes_2.algorithms
{
    enum Move
    {
        Left, Up, Right, Down
    }
    internal class Dfs
    {
        private Map map;

        public Dfs(Map map)
        {
            this.map = map;
        }

        public Tuple<List<int[]>, List<int[]>> dfsearch()
        {
            String[,] maze = this.map.GetMap();
            int[] startingPoint = this.map.getStartingPoint();
            int nTreasure = this.map.getTreasureAmount();
            Stack<List<int[]>> nodeStack = new Stack<List<int[]>>();
            List<List<int[]>> solution = new List<List<int[]>>();
            List<List<int[]>> searchingRoute = new List<List<int[]>>();
            List<int[]> visited = new List<int[]>();

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

                visited.Add(currentNode);

                if (!isBranched(maze, visited, currentNode))
                {
                    searchingRoute.Add(currentTop);
                }

                if (maze[currentNode[0], currentNode[1]] == "T")
                {
                    solution.Add(currentTop);
                    treasureGet++;
                }

                for (int i = 3; i > -1; i--)
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

        int[] getNextNode(int[] currentNode, int i)
        {
            int[] nextNode = new int[2];
            switch (i)
            {
                case (int)Move.Left:
                    nextNode[0] = currentNode[0];
                    nextNode[1] = currentNode[1] - 1;
                    break;
                case (int)Move.Up:
                    nextNode[0] = currentNode[0] - 1;
                    nextNode[1] = currentNode[1];
                    break;
                case (int)Move.Right:
                    nextNode[0] = currentNode[0];
                    nextNode[1] = currentNode[1] + 1;
                    break;
                case (int)Move.Down:
                    nextNode[0] = currentNode[0] + 1;
                    nextNode[1] = currentNode[1];
                    break;
            }

            return nextNode;
        }

        public bool isVisited(List<int[]> visited, int[] node)
        {
            foreach (var Node in visited)
            {
                if (Node[0] == node[0] && Node[1] == node[1])
                {
                    return true;
                }
            }

            return false;
        }

        public bool isBranched(String[,] maze, List<int[]> visited, int[] node)
        {
            int branch = 0;
            if (maze[node[0] - 1, node[1]] != "X" && !isVisited(visited, new int[] { node[0] - 1, node[1] }))
            {
                branch++;
            }
            if (maze[node[0] + 1, node[1]] != "X" && !isVisited(visited, new int[] { node[0] + 1, node[1] }))
            {
                branch++;
            }
            if (maze[node[0], node[1] - 1] != "X" && !isVisited(visited, new int[] { node[0], node[1] - 1 }))
            {
                branch++;
            }
            if (maze[node[0], node[1] + 1] != "X" && !isVisited(visited, new int[] { node[0], node[1] + 1 }))
            {
                branch++;
            }

            if (branch > 0)
            {
                return true;
            }
            return false;

        }

        public List<int[]> optimizedRoute(List<List<int[]>> route)
        {
            int nRoute = route.Count;
            int[] tempArr = new int[2];
            List<int[]> result = new List<int[]>(route[0]);
            for (int i = 0; i < nRoute - 1; i++)
            {
                List<int[]> firstTemp = new List<int[]>(route[i]);
                List<int[]> secondTemp = new List<int[]>(route[i + 1]);

                while (firstTemp[0].SequenceEqual(secondTemp[0]) && firstTemp.Count > 1)
                {
                    if (!firstTemp[1].SequenceEqual(secondTemp[1]))
                    {
                        tempArr = firstTemp[0];
                    }
                    firstTemp.RemoveAt(0);
                    secondTemp.RemoveAt(0);
                }

                if (firstTemp.Count > 1)
                {
                    firstTemp.Reverse();
                    firstTemp.RemoveAt(0);
                    result.AddRange(firstTemp);
                    result.Add(tempArr);
                }
                else
                {
                    if (firstTemp[0].SequenceEqual(secondTemp[0]))
                    {
                        firstTemp.RemoveAt(0);
                        secondTemp.RemoveAt(0);
                    }
                    else
                    {
                        firstTemp.Reverse();
                        firstTemp.RemoveAt(0);
                        result.AddRange(firstTemp);
                        result.Add(tempArr);
                    }
                }

                result.AddRange(secondTemp);
            }
            return result;
        }
    }
}

