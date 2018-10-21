using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoCadHeatExchanger.AutocadOptions;
using AutoCadHeatExchanger.Geometry;
using AutoCadHeatExchanger.Helpers;

namespace AutoCadHeatExchanger.Models.HModel.Parts
{
    public class KneeBrace
    {
        public string Name { get; set; }

        public Point StartPoint { get; set; }

        public Point EndPoint { get; set; }

        public Point BottomCenterPoint { get; set; }

        public Point TopLeftPoint { get; set; }

        public Point TopRightPoint { get; set; }

        public Point BottomRightPoint { get; set; }

        public Point BottomLeftPoint { get; set; }

        public List<Point> Points { get; set; }

        //column propetries
        public double Length { get; set; }
        public double Width { get; set; }

        public double KneeBraceAngle => 60;

        private GeometryManager geometry;

        public KneeBrace(string name, Point startPoint, double distanceBetweenPoints, HorizontalOrientationEnum horizontalOrientation)
        {
            geometry = new GeometryManager();

            Name = name;

            Length = distanceBetweenPoints + 4;
            Width = 3;

            StartPoint = startPoint;

            if (horizontalOrientation == HorizontalOrientationEnum.Left)
            {
                EndPoint = MyMath.FindPointAtAngle(startPoint, distanceBetweenPoints, TriangleSide.C, 90 - KneeBraceAngle, HorizontalOrientationEnum.Left, VerticalOrientationEnum.Up);
                BottomCenterPoint = MyMath.FindPointAtAngle(startPoint, 2, TriangleSide.C, 90 - KneeBraceAngle, HorizontalOrientationEnum.Right, VerticalOrientationEnum.Down);
                BottomLeftPoint = MyMath.FindPointAtAngle(BottomCenterPoint, 1.5, TriangleSide.B, 90 - KneeBraceAngle, HorizontalOrientationEnum.Left, VerticalOrientationEnum.Down);
                BottomRightPoint = MyMath.FindPointAtAngle(BottomLeftPoint, 3, TriangleSide.C, KneeBraceAngle, HorizontalOrientationEnum.Right, VerticalOrientationEnum.Up);
                TopRightPoint = MyMath.FindPointAtAngle(BottomRightPoint, Length, TriangleSide.C, 90 - KneeBraceAngle, HorizontalOrientationEnum.Left, VerticalOrientationEnum.Up);
                TopLeftPoint = MyMath.FindPointAtAngle(TopRightPoint, 3, TriangleSide.C, KneeBraceAngle, HorizontalOrientationEnum.Left, VerticalOrientationEnum.Down);
            }
            else
            {
                EndPoint = MyMath.FindPointAtAngle(startPoint, distanceBetweenPoints, TriangleSide.C, 90 - KneeBraceAngle, HorizontalOrientationEnum.Right, VerticalOrientationEnum.Up);
                BottomCenterPoint = MyMath.FindPointAtAngle(startPoint, 2, TriangleSide.C, 90 - KneeBraceAngle, HorizontalOrientationEnum.Left, VerticalOrientationEnum.Down);
                BottomLeftPoint = MyMath.FindPointAtAngle(BottomCenterPoint, 1.5, TriangleSide.B, 90 - KneeBraceAngle, HorizontalOrientationEnum.Left, VerticalOrientationEnum.Up);
                BottomRightPoint = MyMath.FindPointAtAngle(BottomLeftPoint, 3, TriangleSide.C, KneeBraceAngle, HorizontalOrientationEnum.Right, VerticalOrientationEnum.Down);
                TopRightPoint = MyMath.FindPointAtAngle(BottomRightPoint, Length, TriangleSide.C, 90 - KneeBraceAngle, HorizontalOrientationEnum.Right, VerticalOrientationEnum.Up);
                TopLeftPoint = MyMath.FindPointAtAngle(TopRightPoint, 3, TriangleSide.C, KneeBraceAngle, HorizontalOrientationEnum.Left, VerticalOrientationEnum.Up);
            }

           
            
            Points = new List<Point>
            {
                startPoint,
                BottomRightPoint,
                TopRightPoint,
                TopLeftPoint
            };
        }

        public void DrawFrontView()
        {
            LayerManager.SetLayerCurrent("SidePanel");

            RectangleClass rect = new RectangleClass("Knee Brace", BottomLeftPoint, BottomRightPoint, TopRightPoint, TopLeftPoint);

            geometry.DrawRectangle(rect, BottomLeftPoint);
        }
    }
}
