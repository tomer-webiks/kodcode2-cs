using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Console.Classes_1
{
    enum Color
    {
        green,
        red,
        yellow
    }
    internal class Car
    {
        private Color _color;
        public Car(Color color)
        {
            this._color = color;
        }
    }
}
