using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoCadHeatExchanger.Geometry;

namespace AutoCadHeatExchanger.Helpers
{
    public static class MyMath
    {
        //contant to transfer inches to centimeters and vice versa
        private const double lenCon = 2.54;

        //converts centimeters to inches
        public static double Convertlength(double value)
        {
            return value / lenCon;
        }

        //converts radians to degrees
        public static double ConvertDegreeValue(double value)
        {
            double constant = Math.PI / 180;

            return value * constant;
        }

        //converts inches to centimeters
        public static double SendLength(double value)
        {
            return value * lenCon;
        }

        //rounds a value to the nearest fraction of the factor ex. value = .133 factor 8 return .125
        public static double Round(double value, double factor)
        {
            return Math.Round(value * factor) / factor;
        }

        //fines the number of holes that will fit in the give length
        public static double NumberOfHoles(double length, double offset, double spacing)
        {
            double adjustedLength = length - (offset * 2);

            return Math.Ceiling(adjustedLength / spacing);
        }

        //determines if a value is even or odd using modulus division
        public static bool IsEven(double value)
        {
            return value % 2 == 0;
        }

        public static bool IsEven(int value)
        {
            return value % 2 == 0;
        }

        public static Point FindPointAtAngle(Point startpoint, double distance, TriangleSide providedSide, double angle, HorizontalOrientationEnum horDirection, VerticalOrientationEnum verDirection)
        {
            double startingX = startpoint.X;
            double startingY = startpoint.Y;

            double xmodifier = horDirection == HorizontalOrientationEnum.Left ? -1 : 1;
            double ymodifier = verDirection == VerticalOrientationEnum.Up ? 1 : -1;

            double aDim = 0;
            double bDim = 0;
            double cDim = 0;

            Point point = null;

            switch (providedSide)
            {
                case TriangleSide.C:
                    aDim = (distance * Math.Sin(ConvertDegreeValue(angle))) * xmodifier;
                    bDim = (distance * Math.Cos(ConvertDegreeValue(angle))) * ymodifier;
                    cDim = distance;
                    point = new Point("Found Point", startingX + aDim, bDim + startingY);
                    break;
                case TriangleSide.B:
                    aDim = (distance * Math.Sin(ConvertDegreeValue(angle))) * ymodifier;
                    bDim = (distance * Math.Cos(ConvertDegreeValue(angle))) * xmodifier;
                    cDim = distance;
                    point = new Point("Found Point", startingX + bDim, aDim + startingY);
                    break;


            }




            return point;
        }

        public static double DistanceBetweenTwoPoints(Point startPoint, Point endPoint)
        {
            return Math.Sqrt(Math.Pow(endPoint.X - startPoint.X, 2) + Math.Pow(endPoint.Y - startPoint.Y, 2));
        }

        /// <summary>
        /// Return Center Point from X or Y Cordinates
        /// </summary>
        /// <param name="point1">Give value of a x or y cordinate</param>
        /// <param name="point2">Give value of a x or y cordinate</param>
        /// <returns></returns>
        public static double FindCenterValue(double point1, double point2)
        {
            double difference = Math.Abs(point1 - point2);
            double min = Math.Min(point1, point2);

            return min + difference / 2;
        }

        internal static double Convertlength(object value)
        {
            throw new NotImplementedException();
        }
    }
}
