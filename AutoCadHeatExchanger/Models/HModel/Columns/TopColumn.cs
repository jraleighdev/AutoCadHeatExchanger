using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoCadHeatExchanger.AutocadOptions;
using AutoCadHeatExchanger.Geometry;
using AutoCadHeatExchanger.Models.HModel.Columns;

namespace AutoCadHeatExchanger.Models.HModel
{
    public class TopColumn : ColumnBaseClass
    {
        private GeometryManager geometry;

        public TopColumn(string name, Point startPoint, double length, double width)
        {
            geometry = new GeometryManager();

            Name = name;
            StartPoint = startPoint;
            Length = length;
            Width = width;

            BasePlateThickness = .5;
            
            ColumnLength = Length - BasePlateThickness;

            BottomRightPoint = new Point("Bottom Right Point", startPoint.X + Width, startPoint.Y);
            TopRightPoint = new Point("Top Right Point", BottomRightPoint.X, BottomRightPoint.Y + length);
            TopLeftPoint = new Point("Top Left Point", startPoint.X, TopRightPoint.Y);
            BottomCenterPoint = new Point("Bottom Center Point", (startPoint.X + Width) / 2, startPoint.Y);

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
            LayerManager.SetLayerCurrent("TopColumn");

            var basePlate = geometry.DrawRectangle("Base Plate", Width, BasePlateThickness, StartPoint);
            var column = geometry.DrawRectangle("Column", Width, ColumnLength, basePlate.PointFour);
        }
    }
}
