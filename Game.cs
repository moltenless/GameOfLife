using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    class Game
    {
        public bool[,] Matrix { get; set; }
        //public int Size { get; }
        public int Height { get; }
        public int Width { get; }

        public Game(int height, int width, Point[] initialLayout)
        {
            Matrix = new bool[height, width];
            Height = height;
            Width = width;
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    Matrix[i, j] = initialLayout.Contains(new Point(i, j));
        }

        public void NextLayout()
        {
            bool[,] newMatrix = new bool[Height, Width]; 
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                {
                    int count = GetNeighNum((i, j));
                    if (Matrix[i, j] == true)
                    {
                        if (count == 2 || count == 3)
                            newMatrix[i, j] = true;
                        else if (count <= 1 || count >= 4)
                            newMatrix[i, j] = false;
                    }
                    else if (Matrix[i, j] == false)
                    {
                        if (count == 3)
                            newMatrix[i, j] = true;
                        else
                            newMatrix[i, j] = false;
                    }
                }
            Matrix = newMatrix;
        }

        int GetNeighNum((int x, int y) coord)
        {
            int counter = 0;
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;
                    if (coord.x + i == -1 || coord.x + i == Height ||
                        coord.y + j == -1 || coord.y + j == Width)
                        continue;
                    if (Matrix[coord.x + i, coord.y + j])
                    {
                        counter++;
                    }
                }
            return counter;
        }
    }
}
