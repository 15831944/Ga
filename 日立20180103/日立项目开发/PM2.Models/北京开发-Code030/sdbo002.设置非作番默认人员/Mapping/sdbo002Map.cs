using Gmail.DDD.DataContext;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM2.Models.Code030.Mapping
{
    public class sdbo002Map : EntityConfigurationBase<sdbo002>
    {
        public sdbo002Map()
        {
            // Primary Key
            this.HasKey(t => t.bo00201);

            // Properties
            this.Property(t => t.bo00201)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.bo00220)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.bo00202)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.bo00203)
                .HasMaxLength(40);

            this.Property(t => t.bo00204)
                .HasMaxLength(40);

            this.Property(t => t.bo00205)
                .HasMaxLength(40);

            this.Property(t => t.bo00206)
                .HasMaxLength(40);

            this.Property(t => t.bo00207)
                .HasMaxLength(40);

            this.Property(t => t.bo00208)
                .HasMaxLength(40);

            this.Property(t => t.bo00209)
                .HasMaxLength(40);

            this.Property(t => t.bo00210)
                .HasMaxLength(40);

            this.Property(t => t.bo00211)
                .HasMaxLength(40);

            this.Property(t => t.bo00212)
                .HasMaxLength(40);

            this.Property(t => t.bo00213)
                .HasMaxLength(40);

            this.Property(t => t.bo00214)
                .HasMaxLength(40);

            this.Property(t => t.bo00215)
                .HasMaxLength(40);

            this.Property(t => t.bo00216)
                .HasMaxLength(40);

            this.Property(t => t.bo00217)
                .HasMaxLength(40);

            this.Property(t => t.bo00218)
                .HasMaxLength(40);

            this.Property(t => t.bo00219)
                .HasMaxLength(40);


            // Table & Column Mappings
            this.ToTable("sdbo002");
            this.Property(t => t.bo00201).HasColumnName("bo00201");
            this.Property(t => t.bo00220).HasColumnName("bo00220");
            this.Property(t => t.bo00202).HasColumnName("bo00202");
            this.Property(t => t.bo00203).HasColumnName("bo00203");
            this.Property(t => t.bo00204).HasColumnName("bo00204");
            this.Property(t => t.bo00205).HasColumnName("bo00205");
            this.Property(t => t.bo00206).HasColumnName("bo00206");
            this.Property(t => t.bo00207).HasColumnName("bo00207");
            this.Property(t => t.bo00208).HasColumnName("bo00208");
            this.Property(t => t.bo00209).HasColumnName("bo00209");
            this.Property(t => t.bo00210).HasColumnName("bo00210");
            this.Property(t => t.bo00211).HasColumnName("bo00211");
            this.Property(t => t.bo00212).HasColumnName("bo00212");
            this.Property(t => t.bo00213).HasColumnName("bo00213");
            this.Property(t => t.bo00214).HasColumnName("bo00214");
            this.Property(t => t.bo00215).HasColumnName("bo00215");
            this.Property(t => t.bo00216).HasColumnName("bo00216");
            this.Property(t => t.bo00217).HasColumnName("bo00217");
            this.Property(t => t.bo00218).HasColumnName("bo00218");
            this.Property(t => t.bo00219).HasColumnName("bo00219");
        }
    }
}
