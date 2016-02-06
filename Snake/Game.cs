using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3.Models
{
    public class Game
    {
        public static int foodEat = 0; // sna4ala s'edennoe koli4estvo edy 0
        public static bool inGame; // na4at igru
        public static Snake snake = new Snake(); // sozdaem otdelnyi class dlya zmeiki
        public static Wall wall = new Wall(); // dlya wall
        public static Food food = new Food(); // dlya food
        public static void Redraw()
        {
            Console.Clear();
            snake.Draw(); 
            food.Draw();
            wall.Draw();
            Console.SetCursorPosition(24, 15);
            Console.WriteLine(Game.foodEat + "Scores:");

        }

        public static void LoadLevel(int i) //prinimaem ot snake zna4enie loadlevel
        {
            FileStream fs = new FileStream(string.Format(@"C:\Users\ASUS\Documents\visual studio 2015\Projects\lab3\Snake\Levels\LevelWall{0}.txt", i),
                FileMode.Open, FileAccess.Read);  //sozdaem fail dlya novogo risunka

            StreamReader reader = new StreamReader(fs);

            string line;
            int row = -1;
            int col = 0;
            
            while ((line = reader.ReadLine()) != null)
            {
                row++;
                col = -1;
                foreach (char c in line)
                {
                    col++;
                    if (c == '#')
                    {
                        Game.wall.body.Add(new Point { x = col, y = row });
                    }
                }
            }

            fs.Close();
        }

        public static void Resume()
        {
            wall.Resume();
            food.Resume();
            snake.Resume();
        }

        public static void Save()
        {
            wall.Save();
            food.Save();
            snake.Save();
        }

        public static void Init()
        {
            snake.body.Add(new Point { x = 10, y = 10 });
            food.body.Add(new Point { x = 20, y = 10 });
        }
    }

}
