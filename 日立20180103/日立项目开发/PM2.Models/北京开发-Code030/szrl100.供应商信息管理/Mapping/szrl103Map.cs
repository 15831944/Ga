using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Gmail.DDD.DataContext;
using PM2.Models.Code030.szrl100Model;

namespace PM2.Models.Code030.szrl100Model
{
    //szrl102
    public class szrl103Map : EntityConfigurationBase<szrl103>
    {
        public szrl103Map()
        {
            //Primary Key
            this.HasKey(t => t.rl10301);

            //Properties
            this.Property(t => t.rl10301).HasMaxLength(50);
            this.Property(t => t.rl10302).HasMaxLength(50);

            this.Property(t => t.rl10303)
            .IsRequired()
            .HasMaxLength(200);

            this.Property(t => t.rl10304);
            this.Property(t => t.rl10305).IsRequired().HasMaxLength(40);


            //this.HasRequired(t => t.szrl100).WithMany(x => x.szrl103s).HasForeignKey(t => t.rl10302);

            // Table & Column Mappings
            this.ToTable("szrl103");
            this.Property(t => t.rl10301).HasColumnName("rl10301");
            this.Property(t => t.rl10302).HasColumnName("rl10302");
            this.Property(t => t.rl10303).HasColumnName("rl10303");
            this.Property(t => t.rl10304).HasColumnName("rl10304");
            this.Property(t => t.rl10305).HasColumnName("rl10305");
        }
    }
}