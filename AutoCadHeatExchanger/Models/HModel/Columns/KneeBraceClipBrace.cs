using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoCadHeatExchanger.AutocadOptions;
using AutoCadHeatExchanger.Geometry;
using AutoCadHeatExchanger.Helpers;

namespace AutoCadHeatExchanger.Models.HModel.Columns
{
    public class KneeBraceClipBrace
    {
        private GeometryManager geometry;

        public string Name { get; set; }

        public Point BottomLeftPoint { get; set; }

        public Point BottomCenterPoint { get; set; }

        public Point TopLeftPoint { get; set; }

        public Point TopRightPoint { get; set; }

        public Point BottomRightPoint { get; set; }

        public Point CenterPoint { get; set; }

        public Point SecondHolePoint { get; set; }

        public List<Point> Points { get; set; }

        public double Width => 6;

        public double Height => 6;

        public KneeBraceClipBrace(string name, Point startpoint, HorizontalOrientationEnum horizontalOrientation)
        {
            geometry = new GeometryManager();

            Name = name;

            if (horizontalOrientation == HorizontalOrientationEnum.Right)
            {
                BottomLeftPoint = startpoint;
                BottomRightPoint = new Point("Bottom Right Point", BottomLeftPoint.X + Width, BottomLeftPoint.Y);
                TopRightPoint = new Point("Top Right Point", BottomRightPoint.X, BottomLeftPoint.Y + Height);
                TopLeftPoint = new Point("Top Left Point", BottomLeftPoint.X, TopRightPoint.Y);
                CenterPoint = new Point("Center Point", BottomLeftPoint.X + Width /2, BottomLeftPoint.Y + Height / 2);
                SecondHolePoint = MyMath.FindPointAtAngle(CenterPoint, 2, TriangleSide.C, 30, horizontalOrientation, VerticalOrientationEnum.Up);
            }
            else
            {
                BottomRightPoint = startpoint;
                BottomLeftPoint = new Point("Bottom Right Point", BottomRightPoint.X - Width, BottomRightPoint.Y);
                TopRightPoint = new Point("Top Right Point", BottomRightPoint.X, BottomLeftPoint.Y + Height);
                TopLeftPoint = new Point("Top Left Point", BottomLeftPoint.X, TopRightPoint.Y);
                CenterPoint = new Point("Center Point", BottomLeftPoint.X + Width / 2, BottomLeftPoint.Y + Height / 2);
                SecondHolePoint = MyMath.FindPointAtAngle(CenterPoint, 2, TriangleSide.C, 30, horizontalOrientation, VerticalOrientationEnum.Up);

            }


            Points = new List<Point>
            {
                BottomLeftPoint,
                BottomRightPoint,
                TopRightPoint,
                TopLeftPoint,
                CenterPoint,
                SecondHolePoint
            };
        }

        public void DrawFrontView()
        {
            LayerManager.SetLayerCurrent("KneeBraceClip");

            var perimeter = geometry.DrawRectangle("Perimeter", Width, Height, BottomLeftPoint);
            var centerHole = geometry.DrawCircle("Center Hole", CenterPoint, .625 / 2);
            var secondHole = geometry.DrawCircle("Second Hole", SecondHolePoint, .625 / 2);
        }
    }
}
