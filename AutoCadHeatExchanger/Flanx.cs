namespace AutoCadHeatExchanger
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Flanx
    {
        public int Id { get; set; }

        public int Class { get; set; }

        public double Size { get; set; }

        public double OutSideDiameter { get; set; }

        public double FlangeThickness { get; set; }

        public double PipeDiameter { get; set; }

        public double HubLength { get; set; }

        public double Bore { get; set; }

        public double BoltHoleCircle { get; set; }

        public double BoltHoleDiameter { get; set; }

        public int BoltHoleQty { get; set; }

        public double RaisedFaceDiameter { get; set; }

        public double HubDiameter { get; set; }
    }
}
