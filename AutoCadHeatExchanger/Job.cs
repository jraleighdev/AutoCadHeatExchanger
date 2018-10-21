namespace AutoCadHeatExchanger
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Job
    {
        public int Id { get; set; }

        public int JobNumber { get; set; }

        public int ModelType { get; set; }

        public int CoilQty { get; set; }

        public double FanSize { get; set; }

        public double TubeLength { get; set; }
    }
}
