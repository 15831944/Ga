using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Gmail.DDD.DataContext;

namespace PM2.Models.Code030.szrl033Model
{
    //szrl022
    public class szrl022Map : EntityConfigurationBase<szrl022>
    {
        public szrl022Map()
        {
            //Primary Key
            this.HasKey(t => t.rl02201);


            //Properties
            this.Property(t => t.rl02201).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl02202).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl02203);
            this.Property(t => t.rl02204);
            this.Property(t => t.rl02205);
            this.Property(t => t.rl02206).IsRequired().HasMaxLength(500);
            this.Property(t => t.rl02207).IsRequired().HasMaxLength(500);
            this.Property(t => t.rl02208);
            this.Property(t => t.rl02209).IsRequired().HasMaxLength(100);
            this.Property(t => t.rl02210).IsRequired().HasMaxLength(10);
            this.Property(t => t.rl02211).IsRequired().HasMaxLength(100);
            this.Property(t => t.rl02212).IsRequired().HasMaxLength(10);
            this.Property(t => t.rl02213);
            this.Property(t => t.rl02214).IsRequired().HasMaxLength(100);
            this.Property(t => t.rl02215).IsRequired().HasMaxLength(10);
            this.Property(t => t.rl02216);


            // Table & Column Mappings
            this.ToTable("szrl022");
            this.Property(t => t.rl02201).HasColumnName("rl02201");
            this.Property(t => t.rl02202).HasColumnName("rl02202");
            this.Property(t => t.rl02203).HasColumnName("rl02203");
            this.Property(t => t.rl02204).HasColumnName("rl02204");
            this.Property(t => t.rl02205).HasColumnName("rl02205");
            this.Property(t => t.rl02206).HasColumnName("rl02206");
            this.Property(t => t.rl02207).HasColumnName("rl02207");
            this.Property(t => t.rl02208).HasColumnName("rl02208");
            this.Property(t => t.rl02209).HasColumnName("rl02209");
            this.Property(t => t.rl02210).HasColumnName("rl02210");
            this.Property(t => t.rl02211).HasColumnName("rl02211");
            this.Property(t => t.rl02212).HasColumnName("rl02212");
            this.Property(t => t.rl02213).HasColumnName("rl02213");
            this.Property(t => t.rl02214).HasColumnName("rl02214");
            this.Property(t => t.rl02215).HasColumnName("rl02215");
            this.Property(t => t.rl02216).HasColumnName("rl02216");


        }
    }
}