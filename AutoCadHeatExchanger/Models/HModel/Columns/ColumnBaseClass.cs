using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoCadHeatExchanger.Geometry;

namespace AutoCadHeatExchanger.Models.HModel.Columns
{
    public class ColumnBaseClass 
    {
        
        public string Name { get; set; }

        public Point StartPoint { get; set; }

        public Point BottomCenterPoint { get; set; }

        public Point TopLeftPoint { get; set; }

        public Point TopRightPoint { get; set; }

        public Point BottomRightPoint { get; set; }

        public List<Point> Points { get; set; }

        //column propetries
        public double Length { get; set; }
        public double Width { get; set; }
        public double BasePlateThickness { get; set; }
        public double ColumnLength { get; set; }
    }
}
