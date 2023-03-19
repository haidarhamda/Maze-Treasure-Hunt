using Tubes2;

namespace DefaultNamespace;


enum Move
{
    Left,Up,Right,Down
}
public class Bfs
{
    private Map map;

    public Bfs(Map map)
    {
        this.map = map;
    }
    public List<string> bfsearch()
    {
        List<string> route = new List<string>();
        List<int[]> visited = new List<int[]>();
        Queue<int[]> nodeQueue = new Queue<int[]>();
        visited.Add(this.map.getStartingPoint());
        nodeQueue.Enqueue(map.getStartingPoint());
        int totalTreasure = map.getTreasureAmount();
        int currentTreasure = 0;
        int[] nextNode;
        while (nodeQueue.Count > 0 && currentTreasure<totalTreasure)
        {
            int[] currentNode = nodeQueue.Dequeue();
            // Console.WriteLine("CurrentNode: "+currentNode[0]+" "+currentNode[1]);
            // Console.WriteLine(nodeQueue.Count);
            for (int i = 0; i < 4; i++)
            {
                nextNode = getNextNode(currentNode,i);
                if (map.getMap()[nextNode[0],nextNode[1]]!="X" && !isVisited(visited,nextNode))
                {
                    nodeQueue.Enqueue(nextNode);
                    visited.Add(nextNode);
                    // Console.WriteLine("NextNode: "+nextNode[0]+" "+nextNode[1]);
                    if (map.getMap()[nextNode[0],nextNode[1]]=="T")
                    {
                        currentTreasure++;
                    }

                    switch (i)
                    {
                        case (int) Move.Left: route.Add("L"); break;
                        case (int) Move.Up: route.Add("U"); break;
                        case (int) Move.Right: route.Add("R"); break;
                        case (int) Move.Down: route.Add("D"); break;
                    }
                }
            }
        }
        return route;
    }

    bool isVisited(List<int[]> visited, int[] node)
    {
        for (int i = 0; i < visited.Count; i++)
        {
            if (visited.ElementAt(i)[0]==node[0]&&visited.ElementAt(i)[1]==node[1])
            {
                return true;
            }
        }

        return false;
    }

    int[] getNextNode(int[] currentNode, int i)
    {
        int[] nextNode = new int[2];
        switch (i)
        {
            case 0: nextNode[0] = currentNode[0];
                nextNode[1] = currentNode[1] - 1;
                break;
            case 1: nextNode[0] = currentNode[0]-1;
                nextNode[1] = currentNode[1];
                break;
            case 2: nextNode[0] = currentNode[0];
                nextNode[1] = currentNode[1] + 1;
                break;
            case 3: nextNode[0] = currentNode[0]+1;
                nextNode[1] = currentNode[1];
                break;
        }

        return nextNode;
    }
}