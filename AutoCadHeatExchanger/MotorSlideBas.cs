namespace AutoCadHeatExchanger
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MotorSlideBases")]
    public partial class MotorSlideBas
    {
        public int Id { get; set; }

        public string MotorSize { get; set; }

        public double Width { get; set; }

        public double Length { get; set; }

        public double HoleLengthDistance { get; set; }

        public double HoleWidthDistance { get; set; }

        public double HoleDiameter { get; set; }
    }
}
