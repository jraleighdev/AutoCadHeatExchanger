using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCadHeatExchanger.Geometry
{
    public class PointManager
    {
        public List<Point> Points { get; set; }

        public PointManager()
        {
            Points = new List<Point>();
        }

        public void AddPoint(string name, double x, double y, double z)
        {
            Points.Add(new Point(name, x, y, z));
        }

        public void AddPoint(Point point)
        {
            Points.Add(point);
        }

        public void AddPoints(List<Point> points)
        {
            Points.AddRange(points);
        }


        public Point GetPoint(string name)
        {
            return Points.FirstOrDefault(x => x.Name == name);
        }

        public IEnumerable<Point> GetPoints(string name)
        {
            return Points.Where(x => x.Name.Contains(name));
        }

        public IEnumerable<Point> GetPointsXaxis(double x, AxisOrientationEnum comparison)
        {
            IEnumerable<Point> temp = null;

            switch (comparison)
            {
                case AxisOrientationEnum.Greater:
                    temp = Points.Where(p => p.X > x);
                    break;
                case AxisOrientationEnum.Less:
                    temp = Points.Where(p => p.X < x);
                    break;
                case AxisOrientationEnum.Same:
                    temp = Points.Where(p => Math.Abs(p.X - x) < .005);
                    break;
            }

            return temp;
        }
    
        public IEnumerable<Point> GetPointsYaxis(double y, AxisOrientationEnum comparison)
        {
            IEnumerable<Point> temp = null;

            switch (comparison)
            {
                case AxisOrientationEnum.Greater:
                    temp = Points.Where(p => p.Y > y);
                    break;
                case AxisOrientationEnum.Less:
                    temp = Points.Where(p => p.Y < y);
                    break;
                case AxisOrientationEnum.Same:
                    temp = Points.Where(p => Math.Abs(p.Y - y) < .005);
                    break;
            }

            return temp;
        }
    }
}
