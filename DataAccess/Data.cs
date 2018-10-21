namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Data : DbContext
    {
        public Data()
            : base("name=Data")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
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
