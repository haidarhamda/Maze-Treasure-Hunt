using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public static bool countDistinct(List<int[]> visited, int[] node)
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

        public bool isBeside(int[] currentnode, int[] nextnode)
        {
            if (currentnode[0] == nextnode[0])
            {
                if (Math.Abs(currentnode[1] - nextnode[1]) == 1)
                {
                    return true;
                }
            }
            else if (currentnode[1] == nextnode[1])
            {
                if (Math.Abs(currentnode[0] - nextnode[0]) == 1)
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

        protected List<int[]> createRoute(List<List<int[]>> route)
        {
            int nRoute = route.Count;
            int[] tempArr = new int[2];
            List<int[]> result = new List<int[]>(route[0]);
            List<int[]> treasureNodes = new List<int[]>();

            for (int j = 0; j < nRoute; j++)
            {

            }
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

        public int[] heuristicDirection(int[] targetPoint, int[] currentPoint)
        {
            int[] result;
            if (targetPoint[0] < currentPoint[0])
            {
                if (targetPoint[1] < currentPoint[1])
                {
                    result = new int[4] { 0, 1, 2, 3 };
                }
                else result = new int[4] { 2, 1, 0, 3 };
            }
            else
            {
                if (targetPoint[1] < currentPoint[1])
                {
                    result = new int[4] { 0, 3, 2, 1 };
                }
                else result = new int[4] { 2, 3, 0, 1 };
            }

            return result;
        }
        protected List<int[]> optimizedSolution(List<List<int[]>> solution)
        {
            List<int[]> treasureNodes = new List<int[]>();
            List<int[]> currentSolution = solution.SelectMany(i => i).Distinct().ToList();

            treasureNodes.Add(currentSolution[0]);
            foreach (List<int[]> node in solution)
            {
                treasureNodes.Add(node[node.Count - 1]);
            }

            List<int[]> newSolution = new List<int[]>();

            int i = 0;
            newSolution.Add(currentSolution[0]);
            while (i < treasureNodes.Count-1)
            {
                int[] direction = heuristicDirection(treasureNodes[i+1], treasureNodes[i]);
                int[] nextNode = treasureNodes[i];
                int[] currentNode = treasureNodes[i];
                
                while (!currentNode.SequenceEqual(treasureNodes[i+1]))
                {
                    if (isBeside(currentNode, treasureNodes[i+1]))
                    {
                        newSolution.Add(treasureNodes[i+1]);
                        currentNode = treasureNodes[i+1];
                    }
                    else
                    {
                        foreach (int j in direction)
                        {
                            nextNode = getNextNode(currentNode, j);
                            if (isVisited(currentSolution, nextNode))
                            {
                                break;
                            }
                        }
                        newSolution.Add(nextNode);
                        currentNode = nextNode;
                    }
                }
                i++;
            }

            return newSolution;
        }
    }
}
