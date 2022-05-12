using System;
using System.Collections.Generic;
namespace Day18_2048
{
    public class GameCore
    {
        private int[,] map;
        private int[,] mapBefore;
        private int[] getline;
        private List<EmptyBlock> emptyblock;
        private Random random;
        private int count;
        private int i;
        private int r;
        private int c;
        private int countMove;
        private int randomIndex;

        public int[,] Map { get => map; }
        public int CountMove { get => countMove; set => countMove = value; }
        public int[,] MapBefor { get => mapBefore; set => mapBefore = value; }
        public bool IsChange { get; set; }


        public GameCore()
        {
            map = new int[4, 4];
            mapBefore = new int[4, 4];
            getline = new int[4];
            emptyblock = new List<EmptyBlock>(16);
            random = new Random();
            count = 0;
            i = 0;
            r = 0;
            c = 0;
            CountMove = 0;
            randomIndex = 0;
        }

        #region 移动
        private void MoveUp()
        {
            for (c = 0; c < Map.GetLength(1); c++)
            {

                for (r = 0; r < Map.GetLength(0); r++)
                {
                    getline[r] = Map[r, c];
                }
                ReForm();
                for (r = 0; r < Map.GetLength(0); r++)
                {
                    Map[r, c] = getline[r];
                }
            }
        }
        private void MoveDown()
        {
            for (c = 0; c < Map.GetLength(1); c++)
            {

                for (r = Map.GetLength(0) - 1; r >= 0; r--)
                {
                    getline[Map.GetLength(0) - r - 1] = Map[r, c];
                }
                ReForm();
                for (r = Map.GetLength(0) - 1; r >= 0; r--)
                {
                    Map[r, c] = getline[Map.GetLength(0) - r - 1];
                }
            }
        }
        private void MoveLeft()
        {
            for (r = 0; r < Map.GetLength(0); r++)
            {

                for (c = 0; c < Map.GetLength(1); c++)
                {
                    /*
                    00 01 02 03
                    10 11 12 13
                    20 21 22 23
                    30 31 32 33
                    */
                    getline[c] = Map[r, c];
                }
                ReForm();
                for (c = 0; c < Map.GetLength(1); c++)
                {
                    Map[r, c] = getline[c];
                }
            }
        }
        private void MoveRight()
        {
            for (r = 0; r < Map.GetLength(0); r++)
            {

                for (c = Map.GetLength(1) - 1; c >= 0; c--)
                {
                    getline[Map.GetLength(1) - c - 1] = Map[r, c];
                }
                ReForm();
                for (c = Map.GetLength(1) - 1; c >= 0; c--)
                {
                    Map[r, c] = getline[Map.GetLength(1) - c - 1];
                }
            }
        }

        public void Move(DirectionEnum dir)
        {
            IsChange = false;
            Array.Copy(map, mapBefore, map.Length);
            switch (dir)
            {
                case DirectionEnum.Up:
                    MoveUp();
                    break;
                case DirectionEnum.Down:
                    MoveDown();
                    break;
                case DirectionEnum.Left:
                    MoveLeft();
                    break;
                case DirectionEnum.Right:
                    MoveRight();
                    break;
            }
            CountMove++;
            for (r = 0; r < map.GetLength(0); r++)
            {
                for (c = 0; c < map.GetLength(1); c++)
                {
                    if (map[r, c] != mapBefore[r, c])
                    {
                        IsChange = true;
                        return;
                    }
                }
            }
        }


        private void ReForm()
        {
            LineToZero();
            Merge();
            LineToZero();
        }

        private void LineToZero()
        {
            for (count = 0; count < getline.Length;)
            {
                for (i = count; i < getline.Length;)
                {
                    if (getline[count] == 0 && getline[i] != 0)
                    {
                        getline[count] = getline[i];
                        getline[i] = 0;
                        break;
                    }
                    i++;
                }
                count++;
            }
        }
        private void Merge()
        {
            for (count = 1; count < getline.Length; count++)
            {
                if (getline[count - 1] == getline[count])
                {
                    getline[count - 1] = getline[count - 1] + getline[count];
                    getline[count] = 0;
                    break;
                }

            }

        }
        #endregion

        public void RandomNumber()
        {
            for (r = 0; r < Map.GetLength(0); r++)
            {
                for (c = 0; c < Map.GetLength(1); c++)
                {
                    if (Map[r, c] == 0)
                    {
                        emptyblock.Add(new EmptyBlock(r, c));
                    }
                }
            }
            if (emptyblock.Count != 0)
            {
                randomIndex = random.Next(0, emptyblock.Count - 1);
                Map[emptyblock[randomIndex].R, emptyblock[randomIndex].C] = random.Next(0, 10) != 1 ? 4 : 2;
            }

            emptyblock.Clear();
        }
    }
}
