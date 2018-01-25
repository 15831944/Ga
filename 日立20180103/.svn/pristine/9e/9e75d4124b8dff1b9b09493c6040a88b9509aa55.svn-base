using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Gmail.DDD.DataContext;
using PM2.Models.Code030.szrl100Model;

namespace PM2.Models.Code030.szrl100Model
{
    //szrl102
    public class szrl102Map : EntityConfigurationBase<szrl102>
    {
        public szrl102Map()
        {
            //Primary Key
            this.HasKey(t => t.rl10201);

            //Properties
            this.Property(t => t.rl10201).HasMaxLength(50);
            this.Property(t => t.rl10202).HasMaxLength(50);

            this.Property(t => t.rl10203)
            .IsRequired()
            .HasMaxLength(200);

            this.Property(t => t.rl10204);
            this.Property(t => t.rl10205).IsRequired().HasMaxLength(40);

            //this.HasRequired(t => t.szrl100).WithMany(x => x.szrl102s).HasForeignKey(t => t.rl10202);

            // Table & Column Mappings
            this.ToTable("szrl102");
            this.Property(t => t.rl10201).HasColumnName("rl10201");
            this.Property(t => t.rl10202).HasColumnName("rl10202");
            this.Property(t => t.rl10203).HasColumnName("rl10203");
            this.Property(t => t.rl10204).HasColumnName("rl10204");
            this.Property(t => t.rl10205).HasColumnName("rl10205");
        }
    }
}