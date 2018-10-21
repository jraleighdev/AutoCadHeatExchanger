using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoCadHeatExchanger.AutocadOptions;
using AutoCadHeatExchanger.Geometry;

namespace AutoCadHeatExchanger.Models.HModel.Plenum
{
    public class SidePanel : PlenumBaseClass
    {
        private GeometryManager geometry;

        public SidePanel(string name, Point startPoint, double length, double width)
        {
            geometry = new GeometryManager();

            Name = name;
            StartPoint = startPoint;
            Length = length;
            Width = width;

            BottomRightPoint = new Point("Bottom Right Point", startPoint.X + Width, startPoint.Y);
            TopRightPoint = new Point("Top Right Point", BottomRightPoint.X, BottomRightPoint.Y + length);
            TopLeftPoint = new Point("Top Left Point", startPoint.X, TopRightPoint.Y);
            BottomCenterPoint = new Point("Bottom Center Point", startPoint.X + (Length / 2), startPoint.Y);

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

            var sideView = geometry.DrawRectangle("Side Panel", Length, Width, StartPoint);
        }
    }
}
