using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Gmail.DDD.DataContext;

namespace PM2.Models.Code030.szrl033Model
{
    //szrl034
    public class szrl034Map : EntityConfigurationBase<szrl034>
    {
        public szrl034Map()
        {
            //Primary Key
            this.HasKey(t => t.rl03401);


            //Properties
            this.Property(t => t.rl03401).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl03402).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl03403).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl03404).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl03405);
            this.Property(t => t.rl03406);
            this.Property(t => t.rl03407).IsRequired().HasMaxLength(20);
            this.Property(t => t.rl03408).IsRequired().HasMaxLength(20);
            this.Property(t => t.rl03409);
            this.Property(t => t.rl03410).IsRequired().HasMaxLength(20);
            this.Property(t => t.rl03411);
            this.Property(t => t.rl03412);
            this.Property(t => t.rl03413).IsRequired().HasMaxLength(40);


            // Table & Column Mappings
            this.ToTable("szrl034");
            this.Property(t => t.rl03401).HasColumnName("rl03401");
            this.Property(t => t.rl03402).HasColumnName("rl03402");
            this.Property(t => t.rl03403).HasColumnName("rl03403");
            this.Property(t => t.rl03404).HasColumnName("rl03404");
            this.Property(t => t.rl03405).HasColumnName("rl03405");
            this.Property(t => t.rl03406).HasColumnName("rl03406");
            this.Property(t => t.rl03407).HasColumnName("rl03407");
            this.Property(t => t.rl03408).HasColumnName("rl03408");
            this.Property(t => t.rl03409).HasColumnName("rl03409");
            this.Property(t => t.rl03410).HasColumnName("rl03410");
            this.Property(t => t.rl03411).HasColumnName("rl03411");
            this.Property(t => t.rl03412).HasColumnName("rl03412");
            this.Property(t => t.rl03413).HasColumnName("rl03413");


        }
    }
}