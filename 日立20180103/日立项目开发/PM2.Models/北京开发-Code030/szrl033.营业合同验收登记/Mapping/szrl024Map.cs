using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Gmail.DDD.DataContext;

namespace PM2.Models.Code030.szrl033Model
{
    //szrl024
    public class szrl024Map : EntityConfigurationBase<szrl024>
    {
        public szrl024Map()
        {
            //Primary Key
            this.HasKey(t => t.rl02401);


            //Properties
            this.Property(t => t.rl02401).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl02402).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl02403).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl02404);
            this.Property(t => t.rl02405);
            this.Property(t => t.rl02406).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl02407).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl02408);


            // Table & Column Mappings
            this.ToTable("szrl024");
            this.Property(t => t.rl02401).HasColumnName("rl02401");
            this.Property(t => t.rl02402).HasColumnName("rl02402");
            this.Property(t => t.rl02403).HasColumnName("rl02403");
            this.Property(t => t.rl02404).HasColumnName("rl02404");
            this.Property(t => t.rl02405).HasColumnName("rl02405");
            this.Property(t => t.rl02406).HasColumnName("rl02406");
            this.Property(t => t.rl02407).HasColumnName("rl02407");
            this.Property(t => t.rl02408).HasColumnName("rl02408");


        }
    }
}