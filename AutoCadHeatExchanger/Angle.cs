namespace AutoCadHeatExchanger
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Angle
    {
        public int Id { get; set; }

        public double Leg1 { get; set; }

        public double Leg2 { get; set; }

        public double Thickness { get; set; }

        public double Radius1 { get; set; }

        public double Radius2 { get; set; }

        public string AngleSize { get; set; }
    }
}
