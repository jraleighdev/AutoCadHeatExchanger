namespace AutoCadHeatExchanger
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TafBearing
    {
        public int Id { get; set; }

        public double BearingSize { get; set; }

        public double CenterOfBearing { get; set; }

        public double DistanceBetweenHoles { get; set; }
    }
}
