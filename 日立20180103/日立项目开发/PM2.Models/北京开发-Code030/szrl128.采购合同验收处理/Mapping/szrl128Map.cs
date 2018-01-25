using Gmail.DDD.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030.Mapping
{
    public class szrl128Map : EntityConfigurationBase<szrl128>
    {
        public szrl128Map()
        {
            //Primary Key
            this.HasKey(t => t.rl12801);

            //Properties
            this.Property(t => t.rl12801)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl12802)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl12803)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl12804);
            this.Property(t => t.rl12805)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl12806)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl12807)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl12808)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl12809);
            this.Property(t => t.rl12810)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl12811)
            .IsRequired()
            .HasMaxLength(10);
            this.Property(t => t.rl12812)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl12813);

            // Table & Column Mappings
            this.ToTable("szrl128");
            this.Property(t => t.rl12801).HasColumnName("rl12801");
            this.Property(t => t.rl12802).HasColumnName("rl12802");
            this.Property(t => t.rl12803).HasColumnName("rl12803");
            this.Property(t => t.rl12804).HasColumnName("rl12804");
            this.Property(t => t.rl12805).HasColumnName("rl12805");
            this.Property(t => t.rl12806).HasColumnName("rl12806");
            this.Property(t => t.rl12807).HasColumnName("rl12807");
            this.Property(t => t.rl12808).HasColumnName("rl12808");
            this.Property(t => t.rl12809).HasColumnName("rl12809");
            this.Property(t => t.rl12810).HasColumnName("rl12810");
            this.Property(t => t.rl12811).HasColumnName("rl12811");
            this.Property(t => t.rl12812).HasColumnName("rl12812");
            this.Property(t => t.rl12813).HasColumnName("rl12813");
        }
    }
}
