using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCadHeatExchanger.Geometry
{
    public class RectangleClass
    {
        public string Name { get; set; }
        public double XDistance { get; set; }
        public double YDistance { get; set; }

        public Point StartPoint { get; set; }
        public Point PointTwo { get; set; }
        public Point PointThree { get; set; }
        public Point PointFour { get; set; }

        public List<Point> Points { get; set; }

        public RectangleClass(string name, double xDist, double ydist, Point startPoint)
        {
            
            Name = name;
            XDistance = xDist;
            YDistance = ydist;
            StartPoint = startPoint;

            PointTwo = new Point($"{Name} Point Two", StartPoint.X + XDistance, StartPoint.Y, 0);
            PointThree = new Point($"{Name} Point Three", PointTwo.X, PointTwo.Y + YDistance, 0);
            PointFour = new Point($"{Name} Point Three", StartPoint.X, PointThree.Y, 0);

            Points = new List<Point>
            {
                StartPoint,
                PointTwo,
                PointThree,
                PointFour
            };

        }


        public RectangleClass(string name, Point p1, Point p2, Point p3, Point p4)
        {
            Name = name;
            StartPoint = p1;
            PointTwo = p2;
            PointThree = p3;
            PointFour = p4;

            Points = new List<Point>
            {
                StartPoint,
                PointTwo,
                PointThree,
                PointFour
            };
        }

    }
}
