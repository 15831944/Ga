using Gmail.DDD.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030.Mapping
{
    public class szrl130Map : EntityConfigurationBase<szrl130>
    {
        public szrl130Map()
        {
            //Primary Key
            this.HasKey(t => t.rl13001);

            //Properties
            this.Property(t => t.rl13001)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl13002)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl13003)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl13004);
            this.Property(t => t.rl13005)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl13006)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl13007)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl13008)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl13009);
            this.Property(t => t.rl13010)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl13011)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl13012)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl13013);
            // Table & Column Mappings
            this.ToTable("szrl130");
            this.Property(t => t.rl13001).HasColumnName("rl13001");
            this.Property(t => t.rl13002).HasColumnName("rl13002");
            this.Property(t => t.rl13003).HasColumnName("rl13003");
            this.Property(t => t.rl13004).HasColumnName("rl13004");
            this.Property(t => t.rl13005).HasColumnName("rl13005");
            this.Property(t => t.rl13006).HasColumnName("rl13006");
            this.Property(t => t.rl13007).HasColumnName("rl13007");
            this.Property(t => t.rl13008).HasColumnName("rl13008");
            this.Property(t => t.rl13009).HasColumnName("rl13009");
            this.Property(t => t.rl13010).HasColumnName("rl13010");
            this.Property(t => t.rl13011).HasColumnName("rl13011");
            this.Property(t => t.rl13012).HasColumnName("rl13012");
            this.Property(t => t.rl13013).HasColumnName("rl13013");
        }
    }
}
