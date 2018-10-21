using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace AutoCadHeatExchanger.Geometry
{
    public class GeometryManager
    {
        private Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
        private Database db = Application.DocumentManager.MdiActiveDocument.Database;

        public List<LineClass> Lines { get; set; }
        public List<RectangleClass> Rectangles { get; set; }
        public List<CircleClass> Circles { get; set; }
        public PointManager Points { get; set; }

        public Point Origin = new Point("Origin", 0, 0, 0);

        public GeometryManager()
        {
            Lines = new List<LineClass>();
            Points = new PointManager();
            Rectangles = new List<RectangleClass>();
            Circles = new List<CircleClass>();
        }

        public LineClass DrawLine(string name, double x1, double y1, double x2, double y2)
        {
            Point pointOne = new Point($"{name} Point One", x1, y1, 0);

            Point pointTwo = new Point($"{name} Point Two", x2, y2, 0);

            return DrawLine(name, pointOne, pointTwo);
        }

        public LineClass DrawLine(string name, Point pointOne, Point pointTwo)
        {
            LineClass newline = new LineClass(name, pointOne, pointTwo);

            Points.AddPoint(pointOne);
            Points.AddPoint(pointTwo);

            Lines.Add(newline);

            using (Application.DocumentManager.MdiActiveDocument.LockDocument())
            {
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    BlockTableRecord space = (BlockTableRecord)trans.GetObject(db.CurrentSpaceId, OpenMode.ForWrite);

                    Line line = new Line();

                    line.StartPoint = new Point3d(pointOne.X, pointOne.Y, 0);
                    line.EndPoint = new Point3d(pointTwo.X, pointTwo.Y, 0);

                    space.AppendEntity(line);

                    trans.AddNewlyCreatedDBObject(line, true);

                    trans.Commit();
                }
            }

            return newline;
        }

        public RectangleClass DrawRectangle(string name, double xDist, double yDist, Point startPoint, bool maybe)
        {
            RectangleClass rect = new RectangleClass(name, xDist, yDist, startPoint);

            DrawLine($"{name} Line One", rect.StartPoint, rect.PointTwo);
            DrawLine($"{name} Line Two", rect.PointTwo, rect.PointThree);
            DrawLine($"{name} Line Three", rect.PointThree, rect.PointFour);
            DrawLine($"{name} Line Four", rect.PointFour, rect.StartPoint);

            return rect;
        }

        public RectangleClass DrawRectangle(string name, double xDist, double yDist, Point startPoint)
        {
            RectangleClass rect = new RectangleClass(name, xDist, yDist, startPoint);

            using (Application.DocumentManager.MdiActiveDocument.LockDocument())
            {
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    BlockTableRecord space = (BlockTableRecord)trans.GetObject(db.CurrentSpaceId, OpenMode.ForWrite);

                    Point3dCollection points = new Point3dCollection();

                    points.Add(new Point3d(rect.StartPoint.X, rect.StartPoint.Y, 0));
                    points.Add(new Point3d(rect.PointTwo.X, rect.PointTwo.Y, 0));
                    points.Add(new Point3d(rect.PointThree.X, rect.PointThree.Y, 0));
                    points.Add(new Point3d(rect.PointFour.X, rect.PointFour.Y, 0));
                    
                    Polyline2d polyline2D = new Polyline2d(Poly2dType.SimplePoly, points, 0, true, 0, 0, null);

                    space.AppendEntity(polyline2D);

                    trans.AddNewlyCreatedDBObject(polyline2D, true);

                    trans.Commit();
                }
            }

            return rect;
        }

        public void DrawRectangle(RectangleClass rect, Point startPoint)
        {
            using (Application.DocumentManager.MdiActiveDocument.LockDocument())
            {
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    BlockTableRecord space = (BlockTableRecord)trans.GetObject(db.CurrentSpaceId, OpenMode.ForWrite);

                    Point3dCollection points = new Point3dCollection();

                    points.Add(new Point3d(rect.StartPoint.X, rect.StartPoint.Y, 0));
                    points.Add(new Point3d(rect.PointTwo.X, rect.PointTwo.Y, 0));
                    points.Add(new Point3d(rect.PointThree.X, rect.PointThree.Y, 0));
                    points.Add(new Point3d(rect.PointFour.X, rect.PointFour.Y, 0));

                    Polyline2d polyline2D = new Polyline2d(Poly2dType.SimplePoly, points, 0, true, 0, 0, null);

                    space.AppendEntity(polyline2D);

                    trans.AddNewlyCreatedDBObject(polyline2D, true);

                    trans.Commit();
                }
            }
        }

        public CircleClass DrawCircle(string name, double x, double y, double radius)
        {
            Point centerPoint = new Point($"{name} Center Point", x, y);

            return DrawCircle(name, centerPoint, radius);
        }

        public CircleClass DrawCircle(string name, Point centerPoint, double radius)
        {
            Points.AddPoint(centerPoint);

            CircleClass circ = new CircleClass(name, centerPoint, radius);

            Circles.Add(circ);

            using (Application.DocumentManager.MdiActiveDocument.LockDocument())
            {
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    BlockTableRecord space = (BlockTableRecord)trans.GetObject(db.CurrentSpaceId, OpenMode.ForWrite);

                    Circle circle = new Circle();

                    circle.Center = new Point3d(centerPoint.X, centerPoint.Y, 0);
                    circle.Radius = radius;

                    space.AppendEntity(circle);

                    trans.AddNewlyCreatedDBObject(circle, true);

                    trans.Commit();
                }
            }

            return circ;
        }
    }
}
