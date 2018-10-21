using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCadHeatExchanger.Geometry
{
    public class CircleClass
    {
        public string Name { get; set; }
        public Point CenterPoint { get; set; }
        public double Radius { get; set; }
        public double Diameter { get; set; }

        public CircleClass()
        {
            
        }

        public CircleClass(string name, Point centerPoint, double radius)
        {
            Name = name;
            CenterPoint = centerPoint;
            Radius = radius;
            Diameter = radius * 2;
        }



    }

}
