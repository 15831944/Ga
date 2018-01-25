using Gmail.DDD.DataContext;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace PM2.Models.Code001.Mapping
{
    public class sdpj025Map : EntityConfigurationBase<sdpj025>
    {
        public sdpj025Map()
        {
            // Primary Key
            this.HasKey(t => new { t.pj02501 });

            // Properties
            this.Property(t => t.pj02501)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.pj02502)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.pj02503)
                .IsRequired()
                .HasMaxLength(80);

            this.Property(t => t.pj02504)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.pj02505)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.pj02506)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.pj02507)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.pj02508)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.pj02509)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.pj02510)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.pj02511)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.pj02512)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.pj02513)
                .IsRequired()
                .HasMaxLength(60);

            this.Property(t => t.pj02514)
                .IsRequired()
                .HasMaxLength(80);

            this.Property(t => t.pj02515)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.pj02516)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.pj02517)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("sdpj025");
            this.Property(t => t.pj02501).HasColumnName("pj02501");
            this.Property(t => t.pj02502).HasColumnName("pj02502");
            this.Property(t => t.pj02503).HasColumnName("pj02503");
            this.Property(t => t.pj02504).HasColumnName("pj02504");
            this.Property(t => t.pj02505).HasColumnName("pj02505");
            this.Property(t => t.pj02506).HasColumnName("pj02506");
            this.Property(t => t.pj02507).HasColumnName("pj02507");
            this.Property(t => t.pj02508).HasColumnName("pj02508");
            this.Property(t => t.pj02509).HasColumnName("pj02509");
            this.Property(t => t.pj02510).HasColumnName("pj02510");
            this.Property(t => t.pj02511).HasColumnName("pj02511");
            this.Property(t => t.pj02512).HasColumnName("pj02512");
            this.Property(t => t.pj02513).HasColumnName("pj02513");
            this.Property(t => t.pj02514).HasColumnName("pj02514");
            this.Property(t => t.pj02515).HasColumnName("pj02515");
            this.Property(t => t.pj02516).HasColumnName("pj02516");
            this.Property(t => t.pj02517).HasColumnName("pj02517");
            this.Property(t => t.pj02518).HasColumnName("pj02518");

            this.HasRequired(x => x.Parent)
                .WithMany(y => y.Children)
                .HasForeignKey(x => x.pj02502);

        }
    }
}
