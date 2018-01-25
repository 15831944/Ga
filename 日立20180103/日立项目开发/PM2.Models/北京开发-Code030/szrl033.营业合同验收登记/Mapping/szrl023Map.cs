using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Gmail.DDD.DataContext;

namespace PM2.Models.Code030
{
    //szrl023
    public class szrl023Map : EntityConfigurationBase<szrl023>
    {
        public szrl023Map()
        {
            //Primary Key
            this.HasKey(t => t.rl02301);


            //Properties
            this.Property(t => t.rl02301).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl02302).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl02303);
            this.Property(t => t.rl02304).IsRequired().HasMaxLength(500);


            // Table & Column Mappings
            this.ToTable("szrl023");
            this.Property(t => t.rl02301).HasColumnName("rl02301");
            this.Property(t => t.rl02302).HasColumnName("rl02302");
            this.Property(t => t.rl02303).HasColumnName("rl02303");
            this.Property(t => t.rl02304).HasColumnName("rl02304");


        }
    }
}