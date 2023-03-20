using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes_2.algorithms
{
    internal class Map
    {
        protected string[,] map;

        public Map(string[,] map)
        {
            this.map = new string[map.GetLength(0) + 2, map.GetLength(1) + 2];
            for (int i = 0; i < map.GetLength(0) + 2; i++)
            {
                for (int j = 0; j < map.GetLength(1) + 2; j++)
                {
                    if (i == 0 || i == map.GetLength(0) + 1)
                    {
                        this.map[i, j] = "X";
                    }
                    else
                    {
                        if (j == 0 || j == map.GetLength(1) + 1)
                        {
                            this.map[i, j] = "X";
                        }
                        else
                        {
                            this.map[i, j] = map[i - 1, j - 1];
                        }
                    }
                }
            }
            showMap();
        }

        public string[,] getMap()
        {
            return this.map;
        }

        public void showMap()
        {
            for (int i = 0; i < this.map.GetLength(0); i++)
            {
                for (int j = 0; j < this.map.GetLength(1); j++)
                {
                    Console.Write(String.Format(this.map[i, j] + " "));
                }
                Console.WriteLine();
            }
        }

        public int[] getStartingPoint()
        {
            int[] startPoint = new int[2] { -1, -1 };
            for (int i = 0; i < this.map.GetLength(0); i++)
            {
                for (int j = 0; j < this.map.GetLength(1); j++)
                {
                    if (this.map[i, j] == "K")
                    {
                        ;
                        startPoint[0] = i;
                        startPoint[1] = j;
                        return startPoint;
                    }
                }
            }

            return startPoint;
        }

        public int getTreasureAmount()
        {
            int treasureCount = 0;
            for (int i = 0; i < this.map.GetLength(0); i++)
            {
                for (int j = 0; j < this.map.GetLength(1); j++)
                {
                    if (this.map[i, j] == "T")
                    {
                        ;
                        treasureCount++;
                    }
                }
            }

            return treasureCount;
        }
    }
}
