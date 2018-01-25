using Gmail.DDD.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030.Mapping
{
    public class szrl018Map : EntityConfigurationBase<szrl018>
    {
        public szrl018Map()
        {
            // Primary Key
            this.HasKey(t => new { t.rl01801, t.rl01802, t.rl01803, t.rl01804, t.rl01805, t.rl01806, t.rl01807, t.rl01808, t.rl01809, t.rl01810, t.rl01811, t.rl01812, t.rl01813, t.rl01814, t.rl01815, t.rl01816, t.rl01817, t.rl01818, t.rl01819, t.rl01820, t.rl01821, t.rl01822, t.rl01823, t.rl01824, t.rl01825, t.rl01826, t.rl01827, t.rl01828, t.rl01829, t.rl01830, t.rl01831, t.rl01832, t.rl01833, t.rl01834, t.rl01835 });

            // Properties
            this.Property(t => t.rl01801)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.rl01802)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.rl01803)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.rl01804)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.rl01805)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.rl01806)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.rl01807)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.rl01808)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.rl01809)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.rl01810)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.rl01811)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.rl01812)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.rl01820)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.rl01822)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.rl01828)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.rl01829)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.rl01830)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.rl01831)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.rl01833)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.rl01834)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("szrl018");
            this.Property(t => t.rl01801).HasColumnName("rl01801");
            this.Property(t => t.rl01802).HasColumnName("rl01802");
            this.Property(t => t.rl01803).HasColumnName("rl01803");
            this.Property(t => t.rl01804).HasColumnName("rl01804");
            this.Property(t => t.rl01805).HasColumnName("rl01805");
            this.Property(t => t.rl01806).HasColumnName("rl01806");
            this.Property(t => t.rl01807).HasColumnName("rl01807");
            this.Property(t => t.rl01808).HasColumnName("rl01808");
            this.Property(t => t.rl01809).HasColumnName("rl01809");
            this.Property(t => t.rl01810).HasColumnName("rl01810");
            this.Property(t => t.rl01811).HasColumnName("rl01811");
            this.Property(t => t.rl01812).HasColumnName("rl01812");
            this.Property(t => t.rl01813).HasColumnName("rl01813");
            this.Property(t => t.rl01814).HasColumnName("rl01814");
            this.Property(t => t.rl01815).HasColumnName("rl01815");
            this.Property(t => t.rl01816).HasColumnName("rl01816");
            this.Property(t => t.rl01817).HasColumnName("rl01817");
            this.Property(t => t.rl01818).HasColumnName("rl01818");
            this.Property(t => t.rl01819).HasColumnName("rl01819");
            this.Property(t => t.rl01820).HasColumnName("rl01820");
            this.Property(t => t.rl01821).HasColumnName("rl01821");
            this.Property(t => t.rl01822).HasColumnName("rl01822");
            this.Property(t => t.rl01823).HasColumnName("rl01823");
            this.Property(t => t.rl01824).HasColumnName("rl01824");
            this.Property(t => t.rl01825).HasColumnName("rl01825");
            this.Property(t => t.rl01826).HasColumnName("rl01826");
            this.Property(t => t.rl01827).HasColumnName("rl01827");
            this.Property(t => t.rl01828).HasColumnName("rl01828");
            this.Property(t => t.rl01829).HasColumnName("rl01829");
            this.Property(t => t.rl01830).HasColumnName("rl01830");
            this.Property(t => t.rl01831).HasColumnName("rl01831");
            this.Property(t => t.rl01832).HasColumnName("rl01832");
            this.Property(t => t.rl01833).HasColumnName("rl01833");
            this.Property(t => t.rl01834).HasColumnName("rl01834");
            this.Property(t => t.rl01835).HasColumnName("rl01835");
        }
    }
}
