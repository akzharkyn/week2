using Example3.Models;
using System;

namespace Example3
{ 
    class Program
    {
     
        static void Main(string[] args)
        {
           
            Game.inGame = true;

            Game.LoadLevel(1); //perehod dlya kajdogo urovnya
            Game.Init(); //

            Console.SetWindowSize(48, 48); // размер экрана консоли
            
            while (Game.inGame) // poka my igraem
            {
                Game.Redraw();

                ConsoleKeyInfo pressedKey = Console.ReadKey();

                switch (pressedKey.Key) //esli ya najala klaviw
                {
                    case ConsoleKey.UpArrow:
                        Game.snake.Move(0,-1);
                        break;
                    case ConsoleKey.DownArrow:
                        Game.snake.Move(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        Game.snake.Move(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        Game.snake.Move(1, 0);
                        break;
                    case ConsoleKey.Escape:
                        Game.inGame = false;  //vyhodim iz igry
                        break;
                    case ConsoleKey.F2:
                        Game.Save();  //saving of game at the end
                        break;
                    case ConsoleKey.F3:
                        Game.Resume();
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
