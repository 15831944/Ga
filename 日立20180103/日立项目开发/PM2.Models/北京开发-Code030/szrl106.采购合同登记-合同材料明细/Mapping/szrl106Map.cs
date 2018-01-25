using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.DataContext;

namespace PM2.Models.Code030.Mapping
{
    public class szrl106Map : EntityConfigurationBase<szrl106>
    {
        public szrl106Map()
        {
            //Primary Key
            this.HasKey(t => t.rl10601);

            //Properties
            this.Property(t => t.rl10601)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl10602)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl10603)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl10604)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl10605)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl10606)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl10607)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl10608)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl10609)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl10610)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10611)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl10612)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10613)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10614)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10615)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10616)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10617)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl10618)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl10619)
            .IsRequired()
            .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("szrl106");
            this.Property(t => t.rl10601).HasColumnName("rl10601");
            this.Property(t => t.rl10602).HasColumnName("rl10602");
            this.Property(t => t.rl10603).HasColumnName("rl10603");
            this.Property(t => t.rl10604).HasColumnName("rl10604");
            this.Property(t => t.rl10605).HasColumnName("rl10605");
            this.Property(t => t.rl10606).HasColumnName("rl10606");
            this.Property(t => t.rl10607).HasColumnName("rl10607");
            this.Property(t => t.rl10608).HasColumnName("rl10608");
            this.Property(t => t.rl10609).HasColumnName("rl10609");
            this.Property(t => t.rl10610).HasColumnName("rl10610");
            this.Property(t => t.rl10611).HasColumnName("rl10611");
            this.Property(t => t.rl10612).HasColumnName("rl10612");
            this.Property(t => t.rl10613).HasColumnName("rl10613");
            this.Property(t => t.rl10614).HasColumnName("rl10614");
            this.Property(t => t.rl10615).HasColumnName("rl10615");
            this.Property(t => t.rl10616).HasColumnName("rl10616");
            this.Property(t => t.rl10617).HasColumnName("rl10617");
            this.Property(t => t.rl10618).HasColumnName("rl10618");
            this.Property(t => t.rl10619).HasColumnName("rl10619");
        }
    }
}
