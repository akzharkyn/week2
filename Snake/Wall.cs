using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3.Models
{
    public class Wall : Drawer //nasleduem vse kachestva ot drawer
    {
        public Wall()
        {
            color = ConsoleColor.White; //daem cvet
            sign = '#'; //i simvol
        }
    }
}
