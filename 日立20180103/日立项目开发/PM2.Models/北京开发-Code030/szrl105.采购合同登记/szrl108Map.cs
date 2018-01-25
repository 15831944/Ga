using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Gmail.DDD.DataContext;

namespace PM2.Models.Code030.Szrl105Model
{
    //szrl108
    public class szrl108Map : EntityConfigurationBase<szrl108>
    {
        public szrl108Map()
        {
            //Primary Key
            this.HasKey(t => t.rl10801);


            //Properties
            this.Property(t => t.rl10801).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl10802).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl10803).HasMaxLength(100);
            this.Property(t => t.rl10804).HasMaxLength(100);
            this.Property(t => t.rl10805).IsRequired().HasMaxLength(100);
            this.Property(t => t.rl10806);


            // Table & Column Mappings
            this.ToTable("szrl108");
            this.Property(t => t.rl10801).HasColumnName("rl10801");
            this.Property(t => t.rl10802).HasColumnName("rl10802");
            this.Property(t => t.rl10803).HasColumnName("rl10803");
            this.Property(t => t.rl10804).HasColumnName("rl10804");
            this.Property(t => t.rl10805).HasColumnName("rl10805");
            this.Property(t => t.rl10806).HasColumnName("rl10806");


        }
    }
}