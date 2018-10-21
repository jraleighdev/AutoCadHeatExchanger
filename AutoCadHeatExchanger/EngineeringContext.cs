namespace AutoCadHeatExchanger
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EngineeringContext : DbContext
    {
        public EngineeringContext()
            : base("data source=OWNER-PC\\SQLEXPRESS;initial catalog=EngineeringDataBase;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
            
        }

        public virtual DbSet<Angle> Angles { get; set; }
        public virtual DbSet<Coil> Coils { get; set; }
        public virtual DbSet<Cover> Covers { get; set; }
        public virtual DbSet<Flanx> Flanges { get; set; }
        public virtual DbSet<Horizontal> Horizontals { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<MotorSlideBas> MotorSlideBases { get; set; }
        public virtual DbSet<NemaMotor> NemaMotors { get; set; }
        public virtual DbSet<Pipe> Pipes { get; set; }
        public virtual DbSet<SBeam> SBeams { get; set; }
        public virtual DbSet<TafBearing> TafBearings { get; set; }
        public virtual DbSet<WBeam> WBeams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
