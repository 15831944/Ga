using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.DataContext;

namespace PM2.Models.Code030.Mapping
{
    public class szrl116Map : EntityConfigurationBase<szrl116>
    {
        public szrl116Map()
        {

            //Primary Key
            this.HasKey(t => t.rl11601);

            //Properties
            this.Property(t => t.rl11601)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl11602)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl11603)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl11604)
            .IsRequired()
            .HasMaxLength(80);

            this.Property(t => t.rl11605)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl11606)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl11607);
            this.Property(t => t.rl11608)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl11609);
            this.Property(t => t.rl11610);
            this.Property(t => t.rl11611);
            this.Property(t => t.rl11612)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(t => t.rl11613);
            this.Property(t => t.rl11614)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl11615);
            this.Property(t => t.rl11616);
            this.Property(t => t.rl11617);
            this.Property(t => t.rl11618);
            this.Property(t => t.rl11619)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl11620)
            .IsRequired()
            .HasMaxLength(20);

            this.Property(t => t.rl11621)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl11622)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl11623)
            .IsRequired()
            .HasMaxLength(20);

            this.Property(t => t.rl11624)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl11625)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl11626)
            .IsRequired()
            .HasMaxLength(20);

            this.Property(t => t.rl11627)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl11628)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl11629)
            .IsRequired()
            .HasMaxLength(20);

            this.Property(t => t.rl11630)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl11631)
            .IsRequired()
            .HasMaxLength(20);

            this.Property(t => t.rl11632)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl11633)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl11634)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl11635)
            .IsRequired()
            .HasMaxLength(20);
            this.Property(t => t.rl11636);

            this.Property(t => t.rl11637)
            .IsRequired()
            .HasMaxLength(20);
            this.Property(t => t.rl11638)
          .IsRequired()
          .HasMaxLength(40);

            this.Property(t => t.rl11639)
         .IsRequired()
         .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("szrl116");
            this.Property(t => t.rl11601).HasColumnName("rl11601");
            this.Property(t => t.rl11602).HasColumnName("rl11602");
            this.Property(t => t.rl11603).HasColumnName("rl11603");
            this.Property(t => t.rl11604).HasColumnName("rl11604");
            this.Property(t => t.rl11605).HasColumnName("rl11605");
            this.Property(t => t.rl11606).HasColumnName("rl11606");
            this.Property(t => t.rl11607).HasColumnName("rl11607");
            this.Property(t => t.rl11608).HasColumnName("rl11608");
            this.Property(t => t.rl11609).HasColumnName("rl11609");
            this.Property(t => t.rl11610).HasColumnName("rl11610");
            this.Property(t => t.rl11611).HasColumnName("rl11611");
            this.Property(t => t.rl11612).HasColumnName("rl11612");
            this.Property(t => t.rl11613).HasColumnName("rl11613");
            this.Property(t => t.rl11614).HasColumnName("rl11614");
            this.Property(t => t.rl11615).HasColumnName("rl11615");
            this.Property(t => t.rl11616).HasColumnName("rl11616");
            this.Property(t => t.rl11617).HasColumnName("rl11617");
            this.Property(t => t.rl11618).HasColumnName("rl11618");
            this.Property(t => t.rl11619).HasColumnName("rl11619");
            this.Property(t => t.rl11620).HasColumnName("rl11620");
            this.Property(t => t.rl11621).HasColumnName("rl11621");
            this.Property(t => t.rl11622).HasColumnName("rl11622");
            this.Property(t => t.rl11623).HasColumnName("rl11623");
            this.Property(t => t.rl11624).HasColumnName("rl11624");
            this.Property(t => t.rl11625).HasColumnName("rl11625");
            this.Property(t => t.rl11626).HasColumnName("rl11626");
            this.Property(t => t.rl11627).HasColumnName("rl11627");
            this.Property(t => t.rl11628).HasColumnName("rl11628");
            this.Property(t => t.rl11629).HasColumnName("rl11629");
            this.Property(t => t.rl11630).HasColumnName("rl11630");
            this.Property(t => t.rl11631).HasColumnName("rl11631");
            this.Property(t => t.rl11632).HasColumnName("rl11632");
            this.Property(t => t.rl11633).HasColumnName("rl11633");
            this.Property(t => t.rl11634).HasColumnName("rl11634");
            this.Property(t => t.rl11635).HasColumnName("rl11635");
            this.Property(t => t.rl11636).HasColumnName("rl11636");
            this.Property(t => t.rl11637).HasColumnName("rl11637");
            this.Property(t => t.rl11638).HasColumnName("rl11638");
            this.Property(t => t.rl11639).HasColumnName("rl11639");
        }
    }

}
