using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoCadHeatExchanger.Geometry;
using AutoCadHeatExchanger.Helpers;
using AutoCadHeatExchanger.Models.HModel.FanRing;
using AutoCadHeatExchanger.Models.HModel.Plenum;

namespace AutoCadHeatExchanger.Models.HModel
{
    public class HmodelBuildClass
    {
        private Horizontal horizontal;

        //General Properties
        public string JobNumber { get; set; }
        public int NumberOfFans { get; set; }
        public double TubeLength { get; set; }
        public double PlenumDepth { get; set; }
        public double DriveClearance { get; set; }
        public double DistanceUnderFan { get; set; }
        public WBeam Column { get; set; }
        public double FanDiameter { get; set; }
        public double BasePlateThickness => .5;
        public double SplicePlateThickness => .5;
        public double Height => PlenumDepth + DistanceUnderFan;
        public double TopColumnHeight => PlenumDepth + DriveClearance;
        public double TopColumnBeamLength => TopColumnHeight - SplicePlateThickness;
        public double StubColumnHeight => Height - TopColumnHeight;
        public double StubColumnBeamLength => StubColumnHeight - BasePlateThickness - SplicePlateThickness;
        public double Width => 180;
        public double Length => 710;

        public int NumberOfCenterColumns => NumberOfFans > 1 ? NumberOfFans - 1 : 0;
        public double ColumnWidth => 6;
        public double CTC => MyMath.Round((Length - ColumnWidth) / NumberOfFans, 16);
        public double WTC => MyMath.Round(Width - ColumnWidth, 16);

        private double KneeBraceLocation => StubColumnHeight * (2f / 3f);

        public double KneeBraceSidePanelLocation;

        public double BraceADim => BraceBDim * Math.Tan(MyMath.ConvertDegreeValue(30));

        public double BraceBDim => DistanceUnderFan - KneeBraceLocation - 2.731f;

        public double BraceCDim => BraceBDim / Math.Cos(MyMath.ConvertDegreeValue(30));

        public double BraceLength => BraceBDim + 4;
        
        //Stub Columns
        public StubColumn FrontRightStubColumn { get; set; }
        public List<StubColumn> CenterStubColumns { get; set; }
        public StubColumn BackRightStubColumn { get; set; }

        //Top Columns
        public TopColumn FrontRightTopColumn { get; set; }
        public List<TopColumn> CenterTopColumn { get; set; }
        public TopColumn BackRightTopColumn { get; set; }

        //Side Panel
        public List<SidePanel> SidePanels { get; set; }

        //Fan Ring
        public List<FanRingClass> FanRings { get; set; }

        //Points of H Model Structure
        public Point StartPoint { get; set; }
        public Point BottomRightPoint { get; set; }
        public Point TopRightPoint { get; set; }
        public Point TopLeftPoint { get; set; }
        public Point BottomCenterPoint { get; set; }
        public List<Point> ColumnCenterPoints { get; set; }


        public HmodelBuildClass()
        {
            CenterStubColumns = new List<StubColumn>();
            CenterTopColumn = new List<TopColumn>();
            ColumnCenterPoints = new List<Point>();
            SidePanels = new List<SidePanel>();
            FanRings = new List<FanRingClass>();
        }

        public void LoadFrontViewLoadParameters()
        {
            StartPoint = new Point("Origin", 0, 0);
            BottomRightPoint = new Point("Bottom Right", Length, 0);
            BottomCenterPoint = new Point("Bottom Center", Length / 2, 0);
            TopRightPoint = new Point("Top Right", Length, Height);
            TopLeftPoint = new Point("Top Left", 0, Height);

            //Layout Columns

            //Front right columns
            FrontRightStubColumn = new StubColumn("Front Right", StartPoint, StubColumnHeight, 6, BraceCDim, KneeBraceClipEnum.Right, ViewOrientationEnum.Front);
            FrontRightTopColumn = new TopColumn("Front Right", FrontRightStubColumn.TopLeftPoint, TopColumnHeight, 6);

            //Center Columns
            if (NumberOfFans > 1)
            {
                for (int i = 1; i <= NumberOfCenterColumns; i++)
                {
                    Point columnCenterPoint = new Point($"Column Center {i}", (StartPoint.X + FrontRightStubColumn.Width / 2) + CTC * i, 0);
                    ColumnCenterPoints.Add(columnCenterPoint);

                    Point columStartPoint = new Point("Column Start Point", columnCenterPoint.X - FrontRightStubColumn.Width / 2, 0);
                    StubColumn centerStubColumn = new StubColumn($"Center Column {i}", columStartPoint, StubColumnHeight, 6, BraceCDim, KneeBraceClipEnum.Both, ViewOrientationEnum.Front);
                    CenterStubColumns.Add(centerStubColumn);

                    TopColumn centerTopColumn = new TopColumn($"Center Column {i}", centerStubColumn.TopLeftPoint, TopColumnHeight, 6);
                    CenterTopColumn.Add(centerTopColumn);
                }
            }

            //Back right Colums
            BackRightStubColumn = new StubColumn("Back Right", new Point("Bottom Right", BottomRightPoint.X - FrontRightStubColumn.Width, 0), StubColumnHeight, 6, BraceCDim, KneeBraceClipEnum.Left, ViewOrientationEnum.Front);
            BackRightTopColumn = new TopColumn("Back Right", BackRightStubColumn.TopLeftPoint, TopColumnHeight, 6);

            //Layout plenum
            double plenumLength = CTC - ColumnWidth;

            double plenumStartY = Height - PlenumDepth;

            Point point = new Point("Side panel point", FrontRightTopColumn.TopRightPoint.X, plenumStartY);
            SidePanels.Add(new SidePanel("Side Panel", point, plenumLength, PlenumDepth));

            foreach (var col in CenterTopColumn)
            {
                Point centerColPoint = new Point("Side panel point", col.TopRightPoint.X, plenumStartY);
                SidePanels.Add(new SidePanel("Side Panel", centerColPoint, plenumLength, PlenumDepth));
            }

            foreach (var panel in SidePanels)
            {
                FanRings.Add(new FanRingClass("Fan Ring", panel.BottomCenterPoint, FanDiameter));
            }
        }

        public void Draw()
        {
            //Load parameters from database
            //Do not put in constructor autocad times out
            Load();

            //Draw Front view
            DrawFrontView();

        }

        private void DrawFrontView()
        {
            //Load Front View Parameters
            LoadFrontViewLoadParameters();

            FrontRightStubColumn.DrawFrontView();
            FrontRightTopColumn.DrawFrontView();

            CenterStubColumns.ForEach(x => x.DrawFrontView());
            CenterTopColumn.ForEach(x => x.DrawFrontView());

            BackRightStubColumn.DrawFrontView();
            BackRightTopColumn.DrawFrontView();

            //Draw Plenum
            SidePanels.ForEach(x => x.DrawFrontView());

            //Draw Fan Ring
            FanRings.ForEach(x => x.DrawFrontView());
            

        }

        private void Load()
        {
            

            NumberOfFans = 3;
            TubeLength = 720;
            PlenumDepth = 30;
            DriveClearance = 30;
            DistanceUnderFan = 80;
            FanDiameter = 156;

        }
    }
}
