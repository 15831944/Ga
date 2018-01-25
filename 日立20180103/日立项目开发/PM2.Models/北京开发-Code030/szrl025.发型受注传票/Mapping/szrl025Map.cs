using Gmail.DDD.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030.Mapping
{
    public class szrl025Map: EntityConfigurationBase<szrl025>
    {
        public szrl025Map()
        {
            //Primary Key
            this.HasKey(t => t.rl02535);

            //Properties
            this.Property(t => t.rl02501)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl02502);

            this.Property(t => t.rl02503)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl02504)
            .IsRequired()
            .HasMaxLength(20);

            this.Property(t => t.rl02505);
            this.Property(t => t.rl02506);
            this.Property(t => t.rl02507)
            .IsRequired()
            .HasMaxLength(200);

            this.Property(t => t.rl02508)
            .IsRequired()
            .HasMaxLength(20);

            this.Property(t => t.rl02509)
            .IsRequired()
            .HasMaxLength(200);

            this.Property(t => t.rl02510)
            .IsRequired()
            .HasMaxLength(200);

            this.Property(t => t.rl02511)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl02512)
            .IsRequired()
            .HasMaxLength(200);

            this.Property(t => t.rl02513)
            .IsRequired()
            .HasMaxLength(200);

            this.Property(t => t.rl02514)
            .IsRequired()
            .HasMaxLength(200);

            this.Property(t => t.rl02515);
            this.Property(t => t.rl02516);
            this.Property(t => t.rl02517);
            this.Property(t => t.rl02518)
            .IsRequired()
            .HasPrecision(18, 6);

            this.Property(t => t.rl02519)
            .IsRequired()
            .HasPrecision(18, 6);

            this.Property(t => t.rl02520)
            .IsRequired()
            .HasPrecision(18, 6);

            this.Property(t => t.rl02521)
            .IsRequired()
            .HasPrecision(18, 6);

            this.Property(t => t.rl02522)
            .IsRequired()
            .HasPrecision(18, 6);

            this.Property(t => t.rl02523)
            .IsRequired()
            .HasPrecision(18, 6);

            this.Property(t => t.rl02524)
            .IsRequired()
            .HasPrecision(18, 6);

            this.Property(t => t.rl02525)
            .IsRequired()
            .HasPrecision(18, 6);

            this.Property(t => t.rl02526)
            .IsRequired()
            .HasPrecision(18, 6);

            this.Property(t => t.rl02527)
            .IsRequired()
            .HasMaxLength(4000);

            this.Property(t => t.rl02528)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl02529)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl02530)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl02531)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl02532);
            this.Property(t => t.rl02533)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl02534)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl02535)
            .IsRequired()
            .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("szrl025");
            this.Property(t => t.rl02501).HasColumnName("rl02501");
            this.Property(t => t.rl02502).HasColumnName("rl02502");
            this.Property(t => t.rl02503).HasColumnName("rl02503");
            this.Property(t => t.rl02504).HasColumnName("rl02504");
            this.Property(t => t.rl02505).HasColumnName("rl02505");
            this.Property(t => t.rl02506).HasColumnName("rl02506");
            this.Property(t => t.rl02507).HasColumnName("rl02507");
            this.Property(t => t.rl02508).HasColumnName("rl02508");
            this.Property(t => t.rl02509).HasColumnName("rl02509");
            this.Property(t => t.rl02510).HasColumnName("rl02510");
            this.Property(t => t.rl02511).HasColumnName("rl02511");
            this.Property(t => t.rl02512).HasColumnName("rl02512");
            this.Property(t => t.rl02513).HasColumnName("rl02513");
            this.Property(t => t.rl02514).HasColumnName("rl02514");
            this.Property(t => t.rl02515).HasColumnName("rl02515");
            this.Property(t => t.rl02516).HasColumnName("rl02516");
            this.Property(t => t.rl02517).HasColumnName("rl02517");
            this.Property(t => t.rl02518).HasColumnName("rl02518");
            this.Property(t => t.rl02519).HasColumnName("rl02519");
            this.Property(t => t.rl02520).HasColumnName("rl02520");
            this.Property(t => t.rl02521).HasColumnName("rl02521");
            this.Property(t => t.rl02522).HasColumnName("rl02522");
            this.Property(t => t.rl02523).HasColumnName("rl02523");
            this.Property(t => t.rl02524).HasColumnName("rl02524");
            this.Property(t => t.rl02525).HasColumnName("rl02525");
            this.Property(t => t.rl02526).HasColumnName("rl02526");
            this.Property(t => t.rl02527).HasColumnName("rl02527");
            this.Property(t => t.rl02528).HasColumnName("rl02528");
            this.Property(t => t.rl02529).HasColumnName("rl02529");
            this.Property(t => t.rl02530).HasColumnName("rl02530");
            this.Property(t => t.rl02531).HasColumnName("rl02531");
            this.Property(t => t.rl02532).HasColumnName("rl02532");
            this.Property(t => t.rl02533).HasColumnName("rl02533");
            this.Property(t => t.rl02534).HasColumnName("rl02534");
            this.Property(t => t.rl02535).HasColumnName("rl02535");
        }
    }
}
