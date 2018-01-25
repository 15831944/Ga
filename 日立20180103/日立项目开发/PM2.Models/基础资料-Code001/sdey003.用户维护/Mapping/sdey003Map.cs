using Gmail.DDD.DataContext;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace PM2.Models.Code001.Mapping
{
    public class sdey003Map : EntityConfigurationBase<sdey003>
    {
        public sdey003Map()
        {
            // Primary Key
            this.HasKey(t => new { t.ey00301 });

            // Properties
            this.Property(t => t.ey00301)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ey00302)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ey00303)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ey00305)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.ey00307)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.ey00309)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.ey00310)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.ey00311)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.ey00312)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.ey00313)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ey00315)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ey00318)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.ey00320)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.ey00321)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("sdey003");
            this.Property(t => t.ey00301).HasColumnName("ey00301");
            this.Property(t => t.ey00302).HasColumnName("ey00302");
            this.Property(t => t.ey00303).HasColumnName("ey00303");
            this.Property(t => t.ey00304).HasColumnName("ey00304");
            this.Property(t => t.ey00305).HasColumnName("ey00305");
            this.Property(t => t.ey00306).HasColumnName("ey00306");
            this.Property(t => t.ey00307).HasColumnName("ey00307");
            this.Property(t => t.ey00308).HasColumnName("ey00308");
            this.Property(t => t.ey00309).HasColumnName("ey00309");
            this.Property(t => t.ey00310).HasColumnName("ey00310");
            this.Property(t => t.ey00311).HasColumnName("ey00311");
            this.Property(t => t.ey00312).HasColumnName("ey00312");
            this.Property(t => t.ey00313).HasColumnName("ey00313");
            this.Property(t => t.ey00314).HasColumnName("ey00314");
            this.Property(t => t.ey00315).HasColumnName("ey00315");
            this.Property(t => t.ey00316).HasColumnName("ey00316");
            this.Property(t => t.ey00317).HasColumnName("ey00317");
            this.Property(t => t.ey00318).HasColumnName("ey00318");
            this.Property(t => t.ey00319).HasColumnName("ey00319");
            this.Property(t => t.ey00320).HasColumnName("ey00320");
            this.Property(t => t.ey00321).HasColumnName("ey00321");

        }
    }
}
