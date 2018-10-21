using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoCadHeatExchanger.AutocadOptions;
using AutoCadHeatExchanger.Geometry;
using AutoCadHeatExchanger.Models.HModel.Columns;
using AutoCadHeatExchanger.Models.HModel.Parts;

namespace AutoCadHeatExchanger.Models.HModel
{
    public class StubColumn : ColumnBaseClass
    {
        private GeometryManager geometry;

        public Point KneeBraceRight { get; set; }
        public Point KneeBraceLeft { get; set; }
 
        public double SplicePlateThicknes { get; set; }

        public double KneeBraceLocation { get; set; }

        public KneeBraceClipEnum BraceLocation { get; set; }

        public KneeBraceClipBrace RightKneeBraceClip { get; set; }

        public KneeBraceClipBrace LeftKneeBraceClip { get; set; }

        public KneeBrace LeftKneeBrace { get; set; }

        public KneeBrace RightKneeBrace { get; set; }

        public PlenumKneeBrace PlenumLeftBrace { get; set; }

        public PlenumKneeBrace PlenumRightBrace { get; set; }

        public double KneeBraceLength { get; set; }
               
        public StubColumn(string name, Point startPoint, double length, double width, double kneeBraceLength, KneeBraceClipEnum braceLocation, ViewOrientationEnum viewOrientationEnum)
        {
            geometry = new GeometryManager();

            Name = name;
            StartPoint = startPoint;
            Length = length;
            Width = width;

            BasePlateThickness = .5;
            SplicePlateThicknes = .5;
            ColumnLength = Length - BasePlateThickness - SplicePlateThicknes;
            KneeBraceLocation = ColumnLength * (2f / 3f) - 3;
            BraceLocation = braceLocation;
            KneeBraceLength = kneeBraceLength;

            switch (viewOrientationEnum)
            {
                case ViewOrientationEnum.Front:
                    LoadFrontView();
                    break;
                case ViewOrientationEnum.Top:
                    LoadTopView();
                    break;
                case ViewOrientationEnum.Left:
                    LoadLeftView();
                    break;
                default:
                    LoadFrontView();
                    break;
            }

           
        }

        private void LoadFrontView()
        {
            BottomRightPoint = new Point("Bottom Right Point", StartPoint.X + Width, StartPoint.Y);
            TopRightPoint = new Point("Top Right Point", BottomRightPoint.X, BottomRightPoint.Y + Length);
            TopLeftPoint = new Point("Top Left Point", StartPoint.X, TopRightPoint.Y);
            BottomCenterPoint = new Point("Bottom Center Point", (StartPoint.X + Width) / 2, StartPoint.Y);
            KneeBraceLeft = new Point("Knee Brace Left", StartPoint.X, StartPoint.Y + KneeBraceLocation);
            KneeBraceRight = new Point("Knee Brace Right", BottomRightPoint.X, StartPoint.Y + KneeBraceLocation);

            Points = new List<Point>
            {
                StartPoint,
                BottomRightPoint,
                TopRightPoint,
                TopLeftPoint
            };
        }

        private void LoadTopView()
        {
            
        }

        private void LoadLeftView()
        {
            
        }
        public void DrawFrontView()
        {
            LayerManager.SetLayerCurrent("StubColumn");

            var basePlate = geometry.DrawRectangle("Base Plate", Width, BasePlateThickness, StartPoint);
            var column = geometry.DrawRectangle("Column", Width, ColumnLength, basePlate.PointFour);
            var splicePlate = geometry.DrawRectangle("Splice Plate", Width, SplicePlateThicknes, column.PointFour);
            

            switch (BraceLocation)
            {
                case KneeBraceClipEnum.None:
                    break;
                case KneeBraceClipEnum.Left:
                    LeftKneeBraceClip = new KneeBraceClipBrace("Knee Brace", KneeBraceLeft, HorizontalOrientationEnum.Left);
                    
                    LeftKneeBraceClip.DrawFrontView();

                    LeftKneeBrace = new KneeBrace("Left Knee Brace", LeftKneeBraceClip.CenterPoint, KneeBraceLength, HorizontalOrientationEnum.Left);
                    LeftKneeBrace.DrawFrontView();

                    PlenumLeftBrace = new PlenumKneeBrace("Plenum Left Brace", LeftKneeBrace.EndPoint, HorizontalOrientationEnum.Left);
                    PlenumLeftBrace.DrawFrontView();

                    break;
                case KneeBraceClipEnum.Right:
                    RightKneeBraceClip = new KneeBraceClipBrace("Knee Brace", KneeBraceRight, HorizontalOrientationEnum.Right);
                    RightKneeBraceClip.DrawFrontView();

                    RightKneeBrace = new KneeBrace("Right Knee Brace", RightKneeBraceClip.CenterPoint, KneeBraceLength, HorizontalOrientationEnum.Right);
                    RightKneeBrace.DrawFrontView();

                    PlenumRightBrace = new PlenumKneeBrace("Plenum Right Brace", RightKneeBrace.EndPoint, HorizontalOrientationEnum.Right);
                    PlenumRightBrace.DrawFrontView();
                    break;
                case KneeBraceClipEnum.Both:
                    LeftKneeBraceClip = new KneeBraceClipBrace("Knee Brace", KneeBraceLeft, HorizontalOrientationEnum.Left);
                    LeftKneeBraceClip.DrawFrontView();

                    RightKneeBraceClip = new KneeBraceClipBrace("Knee Brace", KneeBraceRight, HorizontalOrientationEnum.Right);
                    RightKneeBraceClip.DrawFrontView();

                    LeftKneeBrace = new KneeBrace("Left Knee Brace", LeftKneeBraceClip.CenterPoint, KneeBraceLength, HorizontalOrientationEnum.Left);
                    LeftKneeBrace.DrawFrontView();

                    RightKneeBrace = new KneeBrace("Right Knee Brace", RightKneeBraceClip.CenterPoint, KneeBraceLength, HorizontalOrientationEnum.Right);
                    RightKneeBrace.DrawFrontView();

                    PlenumLeftBrace = new PlenumKneeBrace("Plenum Left Brace", LeftKneeBrace.EndPoint, HorizontalOrientationEnum.Left);
                    PlenumLeftBrace.DrawFrontView();

                    PlenumRightBrace = new PlenumKneeBrace("Plenum Right Brace", RightKneeBrace.EndPoint, HorizontalOrientationEnum.Right);
                    PlenumRightBrace.DrawFrontView();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }   
    }
}
