using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3.Models
{
    public class Snake : Drawer //nasleduem
    {
        Point head = new Point(); //daem x y koordinaty
        public void Eat() { }
        public Snake()
        {
            color = ConsoleColor.Yellow;
            sign = 'o';
        }

        public void Move(int dx, int dy) //koordinaty dvijeniya
        {

           

            for (int i = body.Count - 1; i > 0; --i)  //body count posl tochka
            {
                body[i].x = body[i - 1].x; //poslednyaya tochka stanovitsya vmesto predposlednei
                body[i].y = body[i - 1].y;  //y there
            }

            if (body[0].x + dx < 0) dx = dx + 48; //4toby snake ne vihodil iz consoli po x +
            if (body[0].y + dy < 0) dy = dy + 48; // po y -
            if (body[0].x + dx > 48) dx = dx - 48;
            if (body[0].y + dy > 48) dy = dy - 48;

            body[0].x = body[0].x + dx; // dx move body[0].x eto golova
            body[0].y = body[0].y + dy;

            //проверка, можем ли скушать
            if (Game.snake.body[0].x == Game.food.body[0].x && Game.snake.body[0].y == Game.food.body[0].y)  //esli koord golovy  budet ravna s koord edy 
            {
                //добавил к змейке новую точку. прирост
                Game.snake.body.Add(new Point { x = Game.food.body[0].x, y = Game.food.body[0].y });
                // переместил еду на новую позицию 
                int fx = 0, fy = 0; //kuda stavit edu
                bool area = false;
                while (!area)
                {
                    fx = new Random().Next(0, 35); // vremennye koord edi v kakoi to randomnoi plowadi
                    fy = new Random().Next(0, 35);
                    area = true;

                    for (int i = 0; i < Game.wall.body.Count; ++i)  //probegaemsya po all wall
                    {
                        if (fx == Game.wall.body[i].x && fy == Game.wall.body[i].y) //eda poyavlyaetsya na novyh koordinatah
                        {
                            area = false;
                            break;


                            //Game.food.body[0].x = new Random().Next(0, 49);
                            //Game.food.body[0].y = new Random().Next(0, 49);
                        }


                    }
                    for (int j = 0; j < Game.snake.body.Count; ++j)    //obwee kolichestvo tochek - count
                    {
                        if (fx == Game.snake.body[j].x &&
                            fy == Game.snake.body[j].y)    //
                        {
                            area = false;
                            break;
                        }
                    }
                }
                    Game.food.body[0].x = fx; //eda poyavlyaetsya v takoi koordinate
                    Game.food.body[0].y = fy;

                    Game.foodEat++; //posle togo kak pokuwal koli4estvo uveli4ivaetsya
                if (Game.foodEat % 4 == 0) //dlya urovnya esli s'el 4 edy prinimaet v game
                {
                    Console.Clear(); //4toby fit ubralsya
                    Game.wall.body.Clear();
                    Game.food.body.Clear();
                    Game.LoadLevel((Game.foodEat / 4) + 1);  // perehodit na sled uroven
                    Game.Init();
                }
                    }

                    //проверка, есть ли столкновение со стеной
                    for (int i = 0; i < Game.wall.body.Count; ++i)
                    {
                        if (Game.snake.body[0].x == Game.wall.body[i].x && Game.snake.body[0].y == Game.wall.body[i].y)
                        {
                            Console.Clear();
                            Console.SetCursorPosition(35, 15);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Game Over!");
                            Game.inGame = false; //igra zakan4ivaetsya
                        }
                    } 
                }
            }
        }
    

    


