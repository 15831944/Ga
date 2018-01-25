using Gmail.DDD.DataContext;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace PM2.Models.Code031.Mapping
{
    public class szrl127Map : EntityConfigurationBase<szrl127>
    {
        public szrl127Map()
        {
            // Primary Key
            this.HasKey(t => t.rl12701);

            // Properties
            this.Property(t => t.rl12701)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.rl12702)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.rl12704)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.rl12705)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.rl12706)
                .HasPrecision(18, 6);

            this.Property(t => t.rl12707)
                .HasPrecision(18, 6);

            this.Property(t => t.rl12708)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.rl12709)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.rl12710)
                .HasPrecision(18, 6);

            this.Property(t => t.rl12711)
                .HasPrecision(18, 6);

            this.Property(t => t.rl12712)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.rl12714)
                .HasPrecision(18, 6);

            this.Property(t => t.rl12715)
                .HasPrecision(18, 6);

            this.Property(t => t.rl12716)
                .HasPrecision(18, 6);

            this.Property(t => t.rl12717)
                .HasPrecision(18, 6);

            this.Property(t => t.rl12718)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.rl12720)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.rl12721)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("szrl127");
            this.Property(t => t.rl12701).HasColumnName("rl12701");
            this.Property(t => t.rl12702).HasColumnName("rl12702");
            this.Property(t => t.rl12703).HasColumnName("rl12703");
            this.Property(t => t.rl12704).HasColumnName("rl12704");
            this.Property(t => t.rl12705).HasColumnName("rl12705");
            this.Property(t => t.rl12706).HasColumnName("rl12706");
            this.Property(t => t.rl12707).HasColumnName("rl12707");
            this.Property(t => t.rl12708).HasColumnName("rl12708");
            this.Property(t => t.rl12709).HasColumnName("rl12709");
            this.Property(t => t.rl12710).HasColumnName("rl12710");
            this.Property(t => t.rl12711).HasColumnName("rl12711");
            this.Property(t => t.rl12712).HasColumnName("rl12712");
            this.Property(t => t.rl12713).HasColumnName("rl12713");
            this.Property(t => t.rl12714).HasColumnName("rl12714");
            this.Property(t => t.rl12715).HasColumnName("rl12715");
            this.Property(t => t.rl12716).HasColumnName("rl12716");
            this.Property(t => t.rl12717).HasColumnName("rl12717");
            this.Property(t => t.rl12718).HasColumnName("rl12718");
            this.Property(t => t.rl12719).HasColumnName("rl12719");
            this.Property(t => t.rl12720).HasColumnName("rl12720");
            this.Property(t => t.rl12721).HasColumnName("rl12721");
            this.Property(t => t.rl12722).HasColumnName("rl12722");
            
            this.HasRequired(x => x.szrl125)
                .WithMany(y => y.szrl127s)
                .HasForeignKey(x => x.rl12702);

            this.HasRequired(x => x.sdpj004)
                .WithMany()
                .HasForeignKey(x => x.rl12721);

        }
    }
}
