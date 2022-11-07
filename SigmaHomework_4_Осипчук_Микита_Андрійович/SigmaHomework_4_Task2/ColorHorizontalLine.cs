using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_4_Task2
{
    internal struct ColorHorizontalLine
    {
        public int FirstPoint { get; set; }
        public int SecondPoint { get; set; }

        private int? _color = default;

        public int? Color { 
            get { return _color;  }
            set
            {
                _color = value;
            }
        }

        public int Lenght { get => SecondPoint - FirstPoint + 1; }

        public ColorHorizontalLine()
        {
            FirstPoint = default;
            SecondPoint =  default;
        }

        public ColorHorizontalLine(int firstPoint, int secondPoint, int color)
        {
            FirstPoint = firstPoint;
            SecondPoint = secondPoint;
            Color = color;
        }

        public override string ToString()
        {
            return $"First point = {FirstPoint}, Second point = {SecondPoint}.\n   Lenght = {Lenght}, Color = {Color}";
        }
    }
}
