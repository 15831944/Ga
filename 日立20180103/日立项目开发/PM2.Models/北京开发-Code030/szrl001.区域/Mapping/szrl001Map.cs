using Gmail.DDD.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030.Mapping
{
    public class szrl001Map : EntityConfigurationBase<szrl001>
    {
        public szrl001Map()
        {
            // Primary Key
            this.HasKey(t => t.rl00101);

            // Properties
            this.Property(t => t.rl00101)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.rl00102)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.rl00103)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.rl00104)
                .IsRequired()
                .HasMaxLength(2000);

            // Table & Column Mappings
            this.ToTable("szrl001");
            this.Property(t => t.rl00101).HasColumnName("rl00101");
            this.Property(t => t.rl00102).HasColumnName("rl00102");
            this.Property(t => t.rl00103).HasColumnName("rl00103");
            this.Property(t => t.rl00104).HasColumnName("rl00104");
        }
    }
}
