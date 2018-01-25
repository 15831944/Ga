using Gmail.DDD.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030.Mapping
{
    public class szrl084Map : EntityConfigurationBase<szrl084>
    {
        public szrl084Map()
        {
            //Primary Key
            this.HasKey(t => t.rl08401);

            //Properties
            this.Property(t => t.rl08401)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl08402)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl08403)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl08404)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl08405)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl08406)
            .IsRequired()
            .HasPrecision(18, 6);

            this.Property(t => t.rl08407)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl08408)
            .IsRequired()
            .HasPrecision(18, 6);

            this.Property(t => t.rl08409)
            .IsRequired()
            .HasPrecision(18, 6);

            this.Property(t => t.rl08410)
            .IsRequired()
            .HasPrecision(18, 6);

            this.Property(t => t.rl08411)
            .IsRequired()
            .HasPrecision(18, 6);

            this.Property(t => t.rl08412)
            .IsRequired()
            .HasPrecision(18, 6);

            this.Property(t => t.rl08413)
            .IsRequired()
            .HasPrecision(18, 6);

            this.Property(t => t.rl08414)
            .IsRequired()
            .HasPrecision(18, 6);

            this.Property(t => t.rl08415)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl08416)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl08417)
            .IsRequired()
            .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("szrl084");
            this.Property(t => t.rl08401).HasColumnName("rl08401");
            this.Property(t => t.rl08402).HasColumnName("rl08402");
            this.Property(t => t.rl08403).HasColumnName("rl08403");
            this.Property(t => t.rl08404).HasColumnName("rl08404");
            this.Property(t => t.rl08405).HasColumnName("rl08405");
            this.Property(t => t.rl08406).HasColumnName("rl08406");
            this.Property(t => t.rl08407).HasColumnName("rl08407");
            this.Property(t => t.rl08408).HasColumnName("rl08408");
            this.Property(t => t.rl08409).HasColumnName("rl08409");
            this.Property(t => t.rl08410).HasColumnName("rl08410");
            this.Property(t => t.rl08411).HasColumnName("rl08411");
            this.Property(t => t.rl08412).HasColumnName("rl08412");
            this.Property(t => t.rl08413).HasColumnName("rl08413");
            this.Property(t => t.rl08414).HasColumnName("rl08414");
            this.Property(t => t.rl08415).HasColumnName("rl08415");
            this.Property(t => t.rl08416).HasColumnName("rl08416");
            this.Property(t => t.rl08417).HasColumnName("rl08417");
        }
    }
}
