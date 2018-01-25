using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Gmail.DDD.DataContext;
using PM2.Models.Code030.szrl100Model;

namespace PM2.Models.Code030.szrl100Model
{
    //szrl102
    public class szrl104Map : EntityConfigurationBase<szrl104>
    {
        public szrl104Map()
        {
            //Primary Key
            this.HasKey(t => t.rl10401);

            //Properties
            this.Property(t => t.rl10401);
            this.Property(t => t.rl10402).IsRequired()
            .HasMaxLength(10);




            // Table & Column Mappings
            this.ToTable("szrl104");
            this.Property(t => t.rl10401).HasColumnName("rl10401");
            this.Property(t => t.rl10402).HasColumnName("rl10402");
        }
    }
}