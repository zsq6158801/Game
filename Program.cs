using System;
 
namespace Day18_2048
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            #region 开局
            GameCore game = new GameCore();
            game.RandomNumber();
            game.RandomNumber();
            PrintScore(game.Map);
            #endregion
            string directionTapIn;
            for (game.CountMove = 0; game.CountMove >=0;)
            {
                directionTapIn = Console.ReadLine();
                Console.Clear();

                switch (directionTapIn)
                {
                    case "w":
                        game.Move(DirectionEnum.Up);
                        break;
                    case "s":
                        game.Move(DirectionEnum.Down);
                        break;
                    case "a":
                        game.Move(DirectionEnum.Left);
                        break;
                    case "d":
                        game.Move(DirectionEnum.Right);
                        break;
                    default:
                            Console.WriteLine("错误指令。");
                        break;
                }
                    if(game.IsChange)
                {
                    game.RandomNumber();
                    PrintScore(game.Map);
                    Console.WriteLine("已移动" + game.CountMove + "步");
                    Console.WriteLine("输入方向键“wasd”后回车移动");
                }
                else
                {
                    PrintScore(game.Map);
                    Console.WriteLine("无法移动！");
                }
                
            }
            Console.ReadLine();
        }

       private  static  void PrintScore(int[,] Map)
        {
            for (int r = 0; r < Map.GetLength(0); r++)
            {
                for (int c = 0; c < Map.GetLength(1); c++)
                {
                    Console.Write(Map[r , c] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
