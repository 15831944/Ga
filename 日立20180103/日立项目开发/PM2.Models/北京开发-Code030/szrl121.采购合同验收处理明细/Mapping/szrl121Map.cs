using Gmail.DDD.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030.Mapping
{
    public class szrl121Map : EntityConfigurationBase<szrl121>
    {
        public szrl121Map()
        {
            //Primary Key
            this.HasKey(t => t.rl12101);

            //Properties
            this.Property(t => t.rl12101)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl12102);

            this.Property(t => t.rl12103)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(t => t.rl12104)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl12105)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl12106)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(t => t.rl12107)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl12108)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl12109)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl12110)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl12111);

            

            this.Property(t => t.rl12122);
            this.Property(t => t.rl12123);

            // Table & Column Mappings
            this.ToTable("szrl121");
            this.Property(t => t.rl12101).HasColumnName("rl12101");
            this.Property(t => t.rl12102).HasColumnName("rl12102");
            this.Property(t => t.rl12103).HasColumnName("rl12103");
            this.Property(t => t.rl12104).HasColumnName("rl12104");
            this.Property(t => t.rl12105).HasColumnName("rl12105");
            this.Property(t => t.rl12106).HasColumnName("rl12106");
            this.Property(t => t.rl12107).HasColumnName("rl12107");
            this.Property(t => t.rl12108).HasColumnName("rl12108");
            this.Property(t => t.rl12109).HasColumnName("rl12109");
            this.Property(t => t.rl12110).HasColumnName("rl12110");
            this.Property(t => t.rl12111).HasColumnName("rl12111");
          
            this.Property(t => t.rl12122).HasColumnName("rl12122");
            this.Property(t => t.rl12123).HasColumnName("rl12123");
        }
    }
}
