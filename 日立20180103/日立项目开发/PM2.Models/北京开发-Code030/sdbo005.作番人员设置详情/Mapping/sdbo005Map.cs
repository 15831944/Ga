using Gmail.DDD.DataContext;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM2.Models.Code030.Mapping
{
    public class sdbo005Map : EntityConfigurationBase<sdbo005>
    {
        public sdbo005Map()
        {
            //Primary Key
            this.HasKey(t => t.bo00501);

            //Properties
            this.Property(t => t.bo00501)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.bo00502)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.bo00503)
            .IsRequired()
            .HasMaxLength(400);

            this.Property(t => t.bo00504)
            .IsRequired()
            .HasMaxLength(400);

            this.Property(t => t.bo00505);
            this.Property(t => t.bo00506)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.bo00507);
            // Table & Column Mappings
            this.ToTable("sdbo005");
            this.Property(t => t.bo00501).HasColumnName("bo00501");
            this.Property(t => t.bo00502).HasColumnName("bo00502");
            this.Property(t => t.bo00503).HasColumnName("bo00503");
            this.Property(t => t.bo00504).HasColumnName("bo00504");
            this.Property(t => t.bo00505).HasColumnName("bo00505");
            this.Property(t => t.bo00506).HasColumnName("bo00506");
            this.Property(t => t.bo00507).HasColumnName("bo00507");
        }
    }
}
