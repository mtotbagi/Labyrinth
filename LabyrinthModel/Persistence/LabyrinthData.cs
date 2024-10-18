using Labyrinth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Labyrinth.Persistence
{
    public class LabyrinthData
    {
        private int[,] values;
        private bool[,] visible;
        private int xPos;
        private int yPos;
        public int Size { get; }

        public LabyrinthData(int[,] _values)
        {
            xPos = 0;
            yPos = 0;
            values = _values;
            Size = values.GetLength(0);
            visible = new bool[Size, Size];

            SetupVisibility();
        }

        public bool Victory { get { return xPos == Size - 1 && yPos == Size - 1; } }

        public int[,] Value { get { return values; } }

        public bool[,] Visible { get { return visible; } }

        public int XPos {  get { return xPos; } set { xPos = value; } }
        public int YPos {  get { return yPos; } set { yPos = value; } }

        public bool IsVisible(int x, int y)
        {
            if (Math.Abs(x - XPos) > 2 || Math.Abs(y - YPos) > 2) return false;
            if (Math.Abs(x - XPos) < 2 && Math.Abs(y - YPos) < 2) return true;
            if (Math.Abs(x - XPos) == 2 && Math.Abs(y - YPos) == 2)
            {
                if (Value[(XPos + x) / 2, (YPos + y) / 2] == 0) return true;
                return false;
            }

            if (Math.Abs(x - XPos) == 2)
            {
                if (Value[(XPos + x) / 2, y] == 0 &&
                Value[(XPos + x) / 2, YPos] == 0) return true;
                return false;
            }

            if (Math.Abs(y - YPos) == 2)
            {
                if (Value[x, (YPos + y) / 2] == 0 &&
                Value[XPos, (YPos + y) / 2] == 0) return true;
                return false;
            }
            return false;
        }

        public void UpdateVisibility()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    visible[i, j] = IsVisible(i,j);
                }
            }
        }

        private void SetupVisibility()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    visible[i,j] = false;
                }
            }
            visible[0,0] = true;
            visible[1,0] = true;
            visible[0,1] = true;
            visible[1,1] = true;
            if(IsVisible(2, 0)) visible[2,0] = true;
            if(IsVisible(2, 1)) visible[2,1] = true;
            if(IsVisible(2, 2)) visible[2,2] = true;
            if(IsVisible(0, 2)) visible[0,2] = true;
            if(IsVisible(1, 2)) visible[1,2] = true;
        }

    }
}
