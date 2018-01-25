using Gmail.DDD.DataContext;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace PM2.Models.Code001.Mapping
{
    public class sdpj003Map : EntityConfigurationBase<sdpj003>
    {
        public sdpj003Map()
        {
            // Primary Key
            this.HasKey(t => t.pj00301);

            // Properties
            this.Property(t => t.pj00301)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.pj00302)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.pj00303)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.pj00304)
                .IsRequired()
                .HasMaxLength(80);

            this.Property(t => t.pj00305)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.pj00306)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.pj00307)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.pj00308)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.pj00309)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.pj00311)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.pj00312)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("sdpj003");
            this.Property(t => t.pj00301).HasColumnName("pj00301");
            this.Property(t => t.pj00302).HasColumnName("pj00302");
            this.Property(t => t.pj00303).HasColumnName("pj00303");
            this.Property(t => t.pj00304).HasColumnName("pj00304");
            this.Property(t => t.pj00305).HasColumnName("pj00305");
            this.Property(t => t.pj00306).HasColumnName("pj00306");
            this.Property(t => t.pj00307).HasColumnName("pj00307");
            this.Property(t => t.pj00308).HasColumnName("pj00308");
            this.Property(t => t.pj00309).HasColumnName("pj00309");
            this.Property(t => t.pj00310).HasColumnName("pj00310");
            this.Property(t => t.pj00311).HasColumnName("pj00311");
            this.Property(t => t.pj00312).HasColumnName("pj00312");

            this.HasRequired(x => x.Parent)
                .WithMany(y => y.Children)
                .HasForeignKey(x => x.pj00303);

            this.HasRequired(x => x.sdpj025)
                .WithMany(y => y.sdpj003s)
                .HasForeignKey(x => x.pj00311);

        }
    }
}
