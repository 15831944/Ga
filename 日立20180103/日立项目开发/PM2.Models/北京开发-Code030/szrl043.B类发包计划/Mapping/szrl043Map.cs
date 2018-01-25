using Gmail.DDD.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030.Mapping
{
    public class szrl043Map : EntityConfigurationBase<szrl043>
    {
        public szrl043Map()
        {
            //Primary Key
            this.HasKey(t => t.rl04301);

            //Properties
            this.Property(t => t.rl04301)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl04302)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl04303)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl04304)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl04305)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl04306)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl04307)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl04308);
            this.Property(t => t.rl04309)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl04310)
            .IsRequired()
            .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("szrl043");
            this.Property(t => t.rl04301).HasColumnName("rl04301");
            this.Property(t => t.rl04302).HasColumnName("rl04302");
            this.Property(t => t.rl04303).HasColumnName("rl04303");
            this.Property(t => t.rl04304).HasColumnName("rl04304");
            this.Property(t => t.rl04305).HasColumnName("rl04305");
            this.Property(t => t.rl04306).HasColumnName("rl04306");
            this.Property(t => t.rl04307).HasColumnName("rl04307");
            this.Property(t => t.rl04308).HasColumnName("rl04308");
            this.Property(t => t.rl04309).HasColumnName("rl04309");
            this.Property(t => t.rl04310).HasColumnName("rl04310");
        }
    }
}
