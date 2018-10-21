namespace AutoCadHeatExchanger
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SBeam
    {
        public int Id { get; set; }

        public string BeamSize { get; set; }

        public double Height { get; set; }

        public double WebThickness { get; set; }

        public double FlangeRadius { get; set; }

        public double WebRadius { get; set; }

        public double FlangeAngle { get; set; }

        public double Width { get; set; }

        public double Inclination { get; set; }

        public double FlangeThickness { get; set; }
    }
}
