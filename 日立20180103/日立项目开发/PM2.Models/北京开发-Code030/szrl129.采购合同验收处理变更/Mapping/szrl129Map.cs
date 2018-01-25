using Gmail.DDD.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030.Mapping
{
    public class szrl129Map : EntityConfigurationBase<szrl129>
    {
        public szrl129Map()
        {
            //Primary Key
            this.HasKey(t => t.rl12901);

            //Properties
            this.Property(t => t.rl12901)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl12902)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl12903)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl12904);
            this.Property(t => t.rl12905)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl12906)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl12907)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl12908)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl12909);
            this.Property(t => t.rl12910)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl12911)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl12912)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl12913);
            // Table & Column Mappings
            this.ToTable("szrl129");
            this.Property(t => t.rl12901).HasColumnName("rl12901");
            this.Property(t => t.rl12902).HasColumnName("rl12902");
            this.Property(t => t.rl12903).HasColumnName("rl12903");
            this.Property(t => t.rl12904).HasColumnName("rl12904");
            this.Property(t => t.rl12905).HasColumnName("rl12905");
            this.Property(t => t.rl12906).HasColumnName("rl12906");
            this.Property(t => t.rl12907).HasColumnName("rl12907");
            this.Property(t => t.rl12908).HasColumnName("rl12908");
            this.Property(t => t.rl12909).HasColumnName("rl12909");
            this.Property(t => t.rl12910).HasColumnName("rl12910");
            this.Property(t => t.rl12911).HasColumnName("rl12911");
            this.Property(t => t.rl12912).HasColumnName("rl12912");
            this.Property(t => t.rl12913).HasColumnName("rl12913");
        }
    }
}
