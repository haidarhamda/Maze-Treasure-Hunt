// See https://aka.ms/new-console-template for more information

using DefaultNamespace;
using Tubes2;

namespace Tes
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            

            try
            {
                // string[] lines = System.IO.File.ReadAllLines(@"/home/suisei/Documents/GitHub/Tubes2_DuelisSejati/src/Tubes2/tes.txt");
                string[] lines = System.IO.File.ReadAllLines(@"../../../tes.txt");
                Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
                string[,] map=new string[lines.GetLength(0),lines.ElementAt(0).Split(" ").Length];
                for (int i = 0; i < lines.GetLength(0); i++)
                {
                    for (int j = 0; j < lines.ElementAt(i).Split(" ").Length; j++)
                    {
                        map[i,j] = lines.ElementAt(i).Split(" ").ElementAt(j);
                    }
                }
                Map Map=new Map(map);
                Map.showMap();
                Bfs bfs = new Bfs(Map);
                Tuple<List<string>,List<int[]>> ret=bfs.bfsearch();
                List<string> route = ret.Item1;
                for (int i = 0; i < route.Count; i++)
                {
                    Console.Write(route.ElementAt(i)+" ");
                }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}