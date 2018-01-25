using Gmail.DDD.DataContext;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace PM2.Models.Code019.Mapping
{
    public class sdpk007Map : EntityConfigurationBase<sdpk007>
    {
        public sdpk007Map()
        {
            // Primary Key
            this.HasKey(t => new { t.pk00701, t.pk00702 });

            // Properties
            this.Property(t => t.pk00701)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.pk00702)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("sdpk007");
            this.Property(t => t.pk00701).HasColumnName("pk00701");
            this.Property(t => t.pk00702).HasColumnName("pk00702");

            this.HasRequired(x => x.sdpk008)
                .WithMany(y => y.sdpk007s)
                .HasForeignKey(x => x.pk00701)
                .WillCascadeOnDelete(true);

        }
    }
}
