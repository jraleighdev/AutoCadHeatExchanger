namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NemaMotor
    {
        public int Id { get; set; }

        public string FrameSize { get; set; }

        public double CenterOfShaft { get; set; }

        public double MotorHeight { get; set; }

        public double FrameDiameter { get; set; }

        public double BoltHoleFromCenterOfShaft { get; set; }

        public double ShaftLength { get; set; }

        public double ShaftDiameter { get; set; }

        public double FirstHoleFromShaftEnd { get; set; }

        public double SecondHoleFromFirst { get; set; }

        public double HoleDiameter { get; set; }
    }
}
