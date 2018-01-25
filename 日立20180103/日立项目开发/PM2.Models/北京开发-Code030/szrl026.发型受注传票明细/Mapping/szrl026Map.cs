using Gmail.DDD.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030.Mapping
{
    public class szrl026Map: EntityConfigurationBase<szrl026>
    {
        public szrl026Map()
        {
            //Primary Key
            this.HasKey(t => t.rl02601);

            //Properties
            this.Property(t => t.rl02601)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl02602)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl02603)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl02604);
            this.Property(t => t.rl02605)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl02606)
            .IsRequired()
            .HasMaxLength(20);

            this.Property(t => t.rl02607);
            // Table & Column Mappings
            this.ToTable("szrl026");
            this.Property(t => t.rl02601).HasColumnName("rl02601");
            this.Property(t => t.rl02602).HasColumnName("rl02602");
            this.Property(t => t.rl02603).HasColumnName("rl02603");
            this.Property(t => t.rl02604).HasColumnName("rl02604");
            this.Property(t => t.rl02605).HasColumnName("rl02605");
            this.Property(t => t.rl02606).HasColumnName("rl02606");
            this.Property(t => t.rl02607).HasColumnName("rl02607");
        }
    }
}
