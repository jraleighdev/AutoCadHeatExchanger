namespace AutoCadHeatExchanger
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Coil
    {
        public int Id { get; set; }

        public int CoilNumber { get; set; }

        public double TubeLength { get; set; }

        public double TubePitch { get; set; }

        public string TubeDiameter { get; set; }

        public int TubeFace { get; set; }

        public double WeldOffset { get; set; }

        public double FinHeight { get; set; }

        public int TubeRows { get; set; }

        public int NumberOfPasses { get; set; }

        public double FrontTubeSheetThickness { get; set; }

        public double FrontWrapperThickness { get; set; }

        public double FrontEndPlateThickness { get; set; }

        public double FrontPassPlateThickness { get; set; }

        public double BackTubeSheetThickness { get; set; }

        public double BackWrapperThickness { get; set; }

        public double BackEndPlateThickness { get; set; }

        public double BackPassPlateThickness { get; set; }

        public double FrontHeaderSpan { get; set; }

        public double BackHeaderSpan { get; set; }

        public string BinderType { get; set; }

        public string SupportType { get; set; }

        public double SideFrameThickness { get; set; }

        public string InletSize { get; set; }

        public string OutletSize { get; set; }

        public string InletRating { get; set; }

        public string OutletRating { get; set; }

        public string InletSchedule { get; set; }

        public string OutletSchedule { get; set; }

        public string HeaderType { get; set; }

        public double Split { get; set; }

        public double Slope { get; set; }

        public int CoilCover { get; set; }

        public string NumberOfInlet { get; set; }

        public string FlowType { get; set; }

        public double TubeSheetLength { get; set; }

        public int JobId { get; set; }
    }
}
