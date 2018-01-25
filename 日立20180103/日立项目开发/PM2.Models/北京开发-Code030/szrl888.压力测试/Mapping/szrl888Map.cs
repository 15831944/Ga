using Gmail.DDD.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030.Mapping
{
    public class szrl888Map: EntityConfigurationBase<szrl888>
    {
        public szrl888Map()
        {
            //Primary Key
            this.HasKey(t => t.rl88801);

            //Properties
            this.Property(t => t.rl88801)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl88802)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl88803)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl88804)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl88805)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl88806)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl88807)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl88808)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl88809)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl88810)
            .IsRequired()
            .HasMaxLength(40);
 

            // Table & Column Mappings
            this.ToTable("szrl888");
            this.Property(t => t.rl88801).HasColumnName("rl88801");
            this.Property(t => t.rl88802).HasColumnName("rl88802");
            this.Property(t => t.rl88803).HasColumnName("rl88803");
            this.Property(t => t.rl88804).HasColumnName("rl88804");
            this.Property(t => t.rl88805).HasColumnName("rl88805");
            this.Property(t => t.rl88806).HasColumnName("rl88806");
            this.Property(t => t.rl88807).HasColumnName("rl88807");
            this.Property(t => t.rl88808).HasColumnName("rl88808");
            this.Property(t => t.rl88809).HasColumnName("rl88809");
            this.Property(t => t.rl88810).HasColumnName("rl88810");
        }
    }
}
