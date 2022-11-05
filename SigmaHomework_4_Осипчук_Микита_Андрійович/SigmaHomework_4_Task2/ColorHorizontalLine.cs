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
        public Point FirstPoint { get; set; }
        public Point SecondPoint { get; set; }

        private int? _color = default;

        public int? Color { 
            get { return _color;  }
            set
            {
                _color = value;
            }
        }

        public int LenghtHorizontal { get => SecondPoint.X - FirstPoint.X + 1; }

        public ColorHorizontalLine()
        {
            FirstPoint = new Point(0, 0);
            SecondPoint = new Point(0, 0);
        }

        public ColorHorizontalLine(Point firstPoint, Point secondPoint, int color)
        {
            FirstPoint = firstPoint;
            SecondPoint = secondPoint;
            Color = color;
        }

        public override string ToString()
        {
            return $"First point = ({FirstPoint}), Second point = ({SecondPoint}).\nLenght = {this.LenghtHorizontal}, Color = {this.Color}";
        }
    }
}
