using Gmail.DDD.DataContext;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace PM2.Models.Code031.Mapping
{
    public class szrl140Map : EntityConfigurationBase<szrl140>
    {
        public szrl140Map()
        {
            // Primary Key
            this.HasKey(t => t.rl14001);

            // Properties
            this.Property(t => t.rl14001)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.rl14002)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.rl14004)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.rl14006)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.rl14007)
                .HasPrecision(18, 6);

            this.Property(t => t.rl14008)
                .HasPrecision(18, 6);

            this.Property(t => t.rl14009)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.rl14010)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.rl14011)
                .HasPrecision(18, 6);

            this.Property(t => t.rl14012)
                .HasPrecision(18, 6);

            this.Property(t => t.rl14013)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.rl14015)
                .HasPrecision(18, 6);

            this.Property(t => t.rl14016)
                .HasPrecision(18, 6);

            this.Property(t => t.rl14017)
                .HasPrecision(18, 6);

            this.Property(t => t.rl14018)
                .HasPrecision(18, 6);

            this.Property(t => t.rl14019)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.rl14020)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("szrl140");
            this.Property(t => t.rl14001).HasColumnName("rl14001");
            this.Property(t => t.rl14002).HasColumnName("rl14002");
            this.Property(t => t.rl14003).HasColumnName("rl14003");
            this.Property(t => t.rl14004).HasColumnName("rl14004");
            this.Property(t => t.rl14005).HasColumnName("rl14005");
            this.Property(t => t.rl14006).HasColumnName("rl14006");
            this.Property(t => t.rl14007).HasColumnName("rl14007");
            this.Property(t => t.rl14008).HasColumnName("rl14008");
            this.Property(t => t.rl14009).HasColumnName("rl14009");
            this.Property(t => t.rl14010).HasColumnName("rl14010");
            this.Property(t => t.rl14011).HasColumnName("rl14011");
            this.Property(t => t.rl14012).HasColumnName("rl14012");
            this.Property(t => t.rl14013).HasColumnName("rl14013");
            this.Property(t => t.rl14014).HasColumnName("rl14014");
            this.Property(t => t.rl14015).HasColumnName("rl14015");
            this.Property(t => t.rl14016).HasColumnName("rl14016");
            this.Property(t => t.rl14017).HasColumnName("rl14017");
            this.Property(t => t.rl14018).HasColumnName("rl14018");
            this.Property(t => t.rl14019).HasColumnName("rl14019");
            this.Property(t => t.rl14020).HasColumnName("rl14020");
            this.Property(t => t.rl14021).HasColumnName("rl14021");
            this.Property(t => t.rl14022).HasColumnName("rl14022");

            this.HasRequired(x => x.szrl125)
                .WithMany(y => y.szrl140s)
                .HasForeignKey(x => x.rl14002);

        }
    }
}
