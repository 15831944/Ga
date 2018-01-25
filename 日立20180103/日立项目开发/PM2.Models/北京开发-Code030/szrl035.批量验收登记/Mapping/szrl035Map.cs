using Gmail.DDD.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030.Mapping
{
    public class szrl035Map : EntityConfigurationBase<szrl035>
    {
        public szrl035Map()
        {
            //Primary Key
            this.HasKey(t => t.rl03501);

            //Properties
            this.Property(t => t.rl03501)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl03502)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl03503)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl03504)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl03505)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl03506)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl03507)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl03508);
            this.Property(t => t.rl03509)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl03510)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl03511)
           .IsRequired()
           .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("szrl035");
            this.Property(t => t.rl03501).HasColumnName("rl03501");
            this.Property(t => t.rl03502).HasColumnName("rl03502");
            this.Property(t => t.rl03503).HasColumnName("rl03503");
            this.Property(t => t.rl03504).HasColumnName("rl03504");
            this.Property(t => t.rl03505).HasColumnName("rl03505");
            this.Property(t => t.rl03506).HasColumnName("rl03506");
            this.Property(t => t.rl03507).HasColumnName("rl03507");
            this.Property(t => t.rl03508).HasColumnName("rl03508");
            this.Property(t => t.rl03509).HasColumnName("rl03509");
            this.Property(t => t.rl03510).HasColumnName("rl03510");
            this.Property(t => t.rl03511).HasColumnName("rl03511");
        }
    }
}