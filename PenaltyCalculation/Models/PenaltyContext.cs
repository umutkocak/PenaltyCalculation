namespace PenaltyCalculation.Models
{
    using System.Data.Entity;

    public partial class PenaltyContext : DbContext
    {
        public PenaltyContext()
            : base("name=PenaltyContext")
        {
        }

        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Holiday> Holiday { get; set; }
        public virtual DbSet<WorkDay> WorkDay { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasMany(e => e.Holiday)
                .WithOptional(e => e.Country)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Country>()
                .HasMany(e => e.WorkDay)
                .WithOptional(e => e.Country)
                .WillCascadeOnDelete();
        }
    }
}
