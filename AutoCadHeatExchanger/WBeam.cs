namespace AutoCadHeatExchanger
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WBeam
    {
        public int Id { get; set; }

        public string BeamSize { get; set; }

        public double R1 { get; set; }

        public double Height { get; set; }

        public double WidthB { get; set; }

        public double ThicknessA { get; set; }

        public double ThicknessB { get; set; }
    }
}
