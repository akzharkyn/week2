using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Example3.Models
{
    public class Drawer
    {
        public ConsoleColor color; //class cveta
        public char sign;
        public List<Point> body = new List<Point>(); //sozdaem list dlya pointa(to4ek)
        public void Draw()
        {
            Console.ForegroundColor = color;

            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y); //koordinaty to4ki(zmeiki) v na4ale igry
                Console.Write(sign);
            }
        }

        public Drawer() //konstructor
        {

        }

        public void Save()  //v proframm est save, instrukcii chtoby soxranit 
        {
            string fileName = "";

            switch (sign)   //esli ya najmu opredelennyi znak to otkroetsya tot fail kotoromu sootvetstvuet fail xml
            {
                case '#':
                    fileName = "wall.xml";
                    break;
                case '$':
                    fileName = "food.xml";
                    break;
                case 'o':
                    fileName = "snake.xml";
                    break;
            }
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write); //filename stanovitsya odnim iz trex
            XmlSerializer xs = new XmlSerializer(GetType()); //from code to text  //gettype uznat tip newego faila
            xs.Serialize(fs, this);
            fs.Close();
        }

        public void Resume()  //vozobnovit igru
        {
            string fileName = "";

            switch (sign)
            {
                case '#':
                    fileName = "wall.xml";
                    break;
                case '$':
                    fileName = "food.xml";
                    break;
                case 'o':
                    fileName = "snake.xml";
                    break;
            }
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(GetType());


            
            switch (sign)
            {
                case '#':
                    Game.wall.body.Clear();
                    Game.wall = xs.Deserialize(fs) as Wall; //obratnyi process serialize
                    break;
                case '$':
                    Game.food.body.Clear();
                    Game.food = xs.Deserialize(fs) as Food;
                    break;
                case 'o':
                    Game.snake.body.Clear();

                    Game.snake = xs.Deserialize(fs) as Snake;
                    break;
            }
           
            fs.Close();


        }
    }

}
