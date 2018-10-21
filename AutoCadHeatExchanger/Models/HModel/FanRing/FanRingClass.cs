using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoCadHeatExchanger.AutocadOptions;
using AutoCadHeatExchanger.Geometry;

namespace AutoCadHeatExchanger.Models.HModel.FanRing
{
    public class FanRingClass
    {
        private GeometryManager geometry;

        public string Name { get; set; }

        public Point BottomLeftPoint { get; set; }

        public Point BottomCenterPoint { get; set; }

        public Point TopLeftPoint { get; set; }

        public Point TopRightPoint { get; set; }

        public Point BottomRightPoint { get; set; }

        public Point CenterPoint { get; set; }

        public Point BottomFlangePoint { get; set; }

        public Point TopFlangePoint { get; set; }

        public Point RingStartPoint { get; set; }

        public List<Point> Points { get; set; }

        

        public double FanDiameter { get; set; }
        public double FlangeLength { get; set; }
        public double RingLength { get; set; }
        public double Depth { get; set; }

        public FanRingClass(string name, Point centerPoint, double fanDiameter)
        {
            geometry = new GeometryManager();

            Name = name;
            CenterPoint = centerPoint;
            FanDiameter = fanDiameter;
            RingLength = fanDiameter + 1;
            FlangeLength = RingLength + 2;
            Depth = 14;

            //Set overall points
            BottomLeftPoint = new Point("Start Point", CenterPoint.X - FlangeLength/2, centerPoint.Y - Depth);
            BottomRightPoint = new Point("Bottom Right Point", BottomLeftPoint.X + FlangeLength, BottomLeftPoint.Y);
            TopRightPoint = new Point("Top Right Point", BottomRightPoint.X, centerPoint.Y);
            TopLeftPoint = new Point("Top Left Point", BottomLeftPoint.X, TopRightPoint.Y);
            BottomCenterPoint = new Point("Bottom Center Point", centerPoint.X, BottomLeftPoint.Y);

            //set piece points
            BottomFlangePoint = BottomLeftPoint;
            RingStartPoint = new Point("Ring Start Point", BottomLeftPoint.X + 1, BottomLeftPoint.Y + .1344);
            TopFlangePoint = new Point("Top Flange Point", BottomFlangePoint.X, BottomFlangePoint.Y + Depth - .1344);

            Points = new List<Point>
            {
                BottomLeftPoint,
                BottomRightPoint,
                TopRightPoint,
                TopLeftPoint
            };
        }

        public void DrawFrontView()
        {
            LayerManager.SetLayerCurrent("FanRing");

            var bottomFlange = geometry.DrawRectangle("Bottom Flange", FlangeLength, .1344, BottomLeftPoint);
            var centerRing = geometry.DrawRectangle("Ring", RingLength, Depth - .1344 * 2, RingStartPoint);
            var topFlange = geometry.DrawRectangle("Top Flange", FlangeLength, .1344, TopFlangePoint);
        }
    }
}
