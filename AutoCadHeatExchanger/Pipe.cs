namespace AutoCadHeatExchanger
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pipe
    {
        public int Id { get; set; }

        [Required]
        public string Size { get; set; }

        [Required]
        public string Schedule { get; set; }

        public double OD { get; set; }

        public double Thickness { get; set; }
    }
}
