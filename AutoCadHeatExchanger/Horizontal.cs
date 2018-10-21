namespace AutoCadHeatExchanger
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Horizontal
    {
        public int Id { get; set; }

        public int FanQty { get; set; }

        public double PlenumDepth { get; set; }

        public double DriveClearance { get; set; }

        public double DistanceUnderFan { get; set; }

        public double TopColumnHeight { get; set; }

        public double StubColumnHeight { get; set; }

        public int ColumnSize { get; set; }

        public int AngleSize { get; set; }

        public double Width { get; set; }

        public double Length { get; set; }

        public double WTC { get; set; }

        public double CTC { get; set; }

        public int JobId { get; set; }
    }
}
