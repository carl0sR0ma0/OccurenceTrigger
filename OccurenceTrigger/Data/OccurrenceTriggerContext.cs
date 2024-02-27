using Microsoft.EntityFrameworkCore;
using OccurenceTrigger.Models;

namespace OccurenceTrigger.Data
{
    public class OccurrenceTriggerContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Indicator> Indicators { get; set; }
        public DbSet<IndicatorHistoric> IndicatorHistorics { get; set; }
        public DbSet<TriggerConfiguration> TriggerConfigurations { get; set; }
        public DbSet<Occurrence> Occurrences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IndicatorHistoric>()
                .HasKey(ih => new { ih.IndicatorId, ih.Date });

            base.OnModelCreating(modelBuilder);
        }
    }
}
