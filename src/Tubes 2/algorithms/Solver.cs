using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes_2.algorithms
{
    enum Move
    {
        Left, Up, Right, Down
    }

    public static class util
    {
        public static bool visited;

        public static bool isVisited(List<int[]> visited, int[] node)
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
    }

    public class Solver
    {
        public Map map;

        public Solver(Map map)
        {
            this.map = map;
        }

        protected int[] getNextNode(int[] currentNode, int i)
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

        protected bool isVisited(List<int[]> visited, int[] node)
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

        protected bool isBranched(String[,] maze, List<int[]> visited, int[] node)
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

        protected List<int[]> optimizedRoute(List<List<int[]>> route)
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
