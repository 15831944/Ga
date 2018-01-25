using Gmail.DDD.DataContext;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM2.Models.Code030.Mapping
{
    public class sdbo004Map : EntityConfigurationBase<sdbo004>
    {
        public sdbo004Map()
        {
            //Primary Key
            this.HasKey(t => t.bo00401);

            //Properties
            this.Property(t => t.bo00401)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.bo00402)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.bo00403)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.bo00404)
            .IsRequired()
            .HasMaxLength(400);

            this.Property(t => t.bo00405);
            this.Property(t => t.bo00406)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.bo00407);
            this.Property(t => t.bo00408);
            // Table & Column Mappings
            this.ToTable("sdbo004");
            this.Property(t => t.bo00401).HasColumnName("bo00401");
            this.Property(t => t.bo00402).HasColumnName("bo00402");
            this.Property(t => t.bo00403).HasColumnName("bo00403");
            this.Property(t => t.bo00404).HasColumnName("bo00404");
            this.Property(t => t.bo00405).HasColumnName("bo00405");
            this.Property(t => t.bo00406).HasColumnName("bo00406");
            this.Property(t => t.bo00407).HasColumnName("bo00407");
            this.Property(t => t.bo00408).HasColumnName("bo00408");
        }
    }
}
