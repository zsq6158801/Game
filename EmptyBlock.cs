using System;
namespace Day18_2048
{
     struct EmptyBlock
    {
       

        public int R { get; set; }
        public int C { get; set; }
        //public int Count { get; set; }

        public EmptyBlock(int row,int column):this()
        {
            this.R = row;
            this.C = column;
        }
    }
}
