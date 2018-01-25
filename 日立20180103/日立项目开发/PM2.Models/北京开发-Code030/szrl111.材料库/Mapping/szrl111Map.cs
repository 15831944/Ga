using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Gmail.DDD.DataContext;

namespace PM2.Models.Code030.szrl111Model
{
    //szrl111
    public class szrl111Map : EntityConfigurationBase<szrl111>
    {
        public szrl111Map()
        {
            //Primary Key
            this.HasKey(t => t.rl11101);


            //Properties
            this.Property(t => t.rl11101).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl11102).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl11103).IsRequired().HasMaxLength(100);
            this.Property(t => t.rl11104).IsRequired().HasMaxLength(100);
            this.Property(t => t.rl11105).HasMaxLength(100);
            this.Property(t => t.rl11106).HasMaxLength(100);
            this.Property(t => t.rl11107).HasMaxLength(100);
            this.Property(t => t.rl11108).HasMaxLength(100);
            this.Property(t => t.rl11109).IsRequired().HasMaxLength(100);
            this.Property(t => t.rl11110).HasMaxLength(200);
            this.Property(t => t.rl11111);
            this.Property(t => t.rl11112).IsRequired().HasMaxLength(100);


            // Table & Column Mappings
            this.ToTable("szrl111");
            this.Property(t => t.rl11101).HasColumnName("rl11101");
            this.Property(t => t.rl11102).HasColumnName("rl11102");
            this.Property(t => t.rl11103).HasColumnName("rl11103");
            this.Property(t => t.rl11104).HasColumnName("rl11104");
            this.Property(t => t.rl11105).HasColumnName("rl11105");
            this.Property(t => t.rl11106).HasColumnName("rl11106");
            this.Property(t => t.rl11107).HasColumnName("rl11107");
            this.Property(t => t.rl11108).HasColumnName("rl11108");
            this.Property(t => t.rl11109).HasColumnName("rl11109");
            this.Property(t => t.rl11110).HasColumnName("rl11110");
            this.Property(t => t.rl11111).HasColumnName("rl11111");
            this.Property(t => t.rl11112).HasColumnName("rl11112");


        }
    }
}