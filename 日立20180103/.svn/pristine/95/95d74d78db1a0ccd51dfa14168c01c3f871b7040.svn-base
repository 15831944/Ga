using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Gmail.DDD.DataContext;

namespace PM2.Models.Code030.szrl111Model
{
    //szrl111
    public class sdpa013Map : EntityConfigurationBase<sdpa013>
    {
        public sdpa013Map()
        {
            //Primary Key
            this.HasKey(t => t.pa01301);


            //Properties
            this.Property(t => t.pa01301).IsRequired().HasMaxLength(18);
            this.Property(t => t.pa01302).IsRequired().HasMaxLength(100);
            this.Property(t => t.pa01303).IsRequired().HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("sdpa013");
            this.Property(t => t.pa01301).HasColumnName("pa01301");
            this.Property(t => t.pa01302).HasColumnName("pa01302");
            this.Property(t => t.pa01303).HasColumnName("pa01303");


        }
    }
}