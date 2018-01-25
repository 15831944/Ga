using Gmail.DDD.DataContext;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace PM2.Models.Code031.Mapping
{
    public class szrl125Map : EntityConfigurationBase<szrl125>
    {
        public szrl125Map()
        {
            // Primary Key
            this.HasKey(t => t.rl12501);

            // Properties
            this.Property(t => t.rl12501)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.rl12502)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.rl12503)
                .HasPrecision(18, 6);
            this.Property(t => t.rl12504)
                .HasPrecision(18, 6);
            this.Property(t => t.rl12505)
                .HasPrecision(18, 6);
            this.Property(t => t.rl12506)
                .HasPrecision(18, 6);

            // Table & Column Mappings
            this.ToTable("szrl125");
            this.Property(t => t.rl12501).HasColumnName("rl12501");
            this.Property(t => t.rl12502).HasColumnName("rl12502");
            this.Property(t => t.rl12503).HasColumnName("rl12503");
            this.Property(t => t.rl12504).HasColumnName("rl12504");
            this.Property(t => t.rl12505).HasColumnName("rl12505");
            this.Property(t => t.rl12506).HasColumnName("rl12506");
            this.Property(t => t.rl12507).HasColumnName("rl12507");
        }
    }
}
