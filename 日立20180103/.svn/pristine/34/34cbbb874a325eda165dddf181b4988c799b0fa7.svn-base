using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Gmail.DDD.DataContext;
using PM2.Models.Code030.szrl100Model;

namespace PM2.Models.Code030.szrl100Model
{
    //szrl101
    public class szrl101Map : EntityConfigurationBase<szrl101>
    {
        public szrl101Map()
        {
            //Primary Key
            this.HasKey(t => t.rl10101);

            //Properties
            this.Property(t => t.rl10101).HasMaxLength(50);
            this.Property(t => t.rl10102).HasMaxLength(50);
            this.Property(t => t.rl10103)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl10104);
            this.Property(t => t.rl10105).IsRequired().HasMaxLength(40);

            //this.HasRequired(t => t.szrl100).WithMany(x => x.szrl101s).HasForeignKey(t => t.rl10102);


            // Table & Column Mappings
            this.ToTable("szrl101");
            this.Property(t => t.rl10101).HasColumnName("rl10101");
            this.Property(t => t.rl10102).HasColumnName("rl10102");
            this.Property(t => t.rl10103).HasColumnName("rl10103");
            this.Property(t => t.rl10104).HasColumnName("rl10104");
            this.Property(t => t.rl10105).HasColumnName("rl10105");
        }

        
    }
}