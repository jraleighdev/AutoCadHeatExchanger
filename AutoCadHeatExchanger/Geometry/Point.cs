using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCadHeatExchanger.Geometry
{
    public class Point
    {
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point()
        {
            
        }

        public Point(string name, double x, double y, double z = 0)
        {
            Name = name;
            X = x;
            Y = y;
            Z = z;
        }
    }
}
