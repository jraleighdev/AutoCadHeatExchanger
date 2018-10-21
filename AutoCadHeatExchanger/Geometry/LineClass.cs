using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCadHeatExchanger.Geometry
{
    public class LineClass
    {
        public string Name { get; set; }
        public Point PointOne { get; set; }
        public Point PointTwo { get; set; }

        public bool Horizontal { get; set; }
        public bool Vertical { get; set; }

        public LineClass()
        {
            
        }

        public LineClass(string name, Point pointOne, Point pointTwo)
        {
            Name = name;
            PointOne = pointOne;
            PointTwo = pointTwo;

            if (Math.Abs(pointOne.X - pointTwo.X) < .005)
            {
                Horizontal = true;
            }

            if (Math.Abs(pointOne.Y - pointTwo.Y) < .005)
            {
                Vertical = true;
            }
        }

    }
}
