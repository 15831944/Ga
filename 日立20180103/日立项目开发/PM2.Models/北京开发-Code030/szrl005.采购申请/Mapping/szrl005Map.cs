using Gmail.DDD.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030.Mapping
{
    public class szrl005Map : EntityConfigurationBase<szrl005>
    {
        public szrl005Map()
        {
            //Primary Key
            this.HasKey(t => t.rl00530);

            //Properties
            this.Property(t => t.rl00501)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl00502)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl00503)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl00504)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl00505)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl00506)
            .IsRequired()
            .HasMaxLength(5);

            this.Property(t => t.rl00507)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl00508)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl00509)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl00510)
            .IsRequired()
            .HasMaxLength(20);

            this.Property(t => t.rl00511)
            .IsRequired()
            .HasMaxLength(20);

            this.Property(t => t.rl00512)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl00513)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl00514)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl00515)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl00516);
            this.Property(t => t.rl00517)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl00518)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl00519);
            this.Property(t => t.rl00520)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl00521)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl00522)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl00523)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl00524)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl00525)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl00526)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl00527);
            this.Property(t => t.rl00528);
            this.Property(t => t.rl00529)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl00530)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl00531)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl00532)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl00533)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl00534);
            this.Property(t => t.rl00535)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl00536);
            this.Property(t => t.rl00537);
            this.Property(t => t.rl00538)
            .IsRequired()
            .HasMaxLength(200);

            this.Property(t => t.rl00539)
            .IsRequired()
            .HasMaxLength(200);

            this.Property(t => t.rl00540)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl00541);
            this.Property(t => t.rl00542);
            this.Property(t => t.rl00543);
            this.Property(t => t.rl00544);
            this.Property(t => t.rl00545);
            this.Property(t => t.rl00546);
            this.Property(t => t.rl00547);
            this.Property(t => t.rl00548);
            this.Property(t => t.rl00549);
            this.Property(t => t.rl00550);
            this.Property(t => t.rl00551)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(t => t.rl00552)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(t => t.rl00553)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(t => t.rl00554)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(t => t.rl00555)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(t => t.rl00556)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(t => t.rl00557)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(t => t.rl00558)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(t => t.rl00559)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(t => t.rl00560)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl00561)
            .IsRequired()
            .HasPrecision(18, 9);

            // Table & Column Mappings
            this.ToTable("szrl005");
            this.Property(t => t.rl00501).HasColumnName("rl00501");
            this.Property(t => t.rl00502).HasColumnName("rl00502");
            this.Property(t => t.rl00503).HasColumnName("rl00503");
            this.Property(t => t.rl00504).HasColumnName("rl00504");
            this.Property(t => t.rl00505).HasColumnName("rl00505");
            this.Property(t => t.rl00506).HasColumnName("rl00506");
            this.Property(t => t.rl00507).HasColumnName("rl00507");
            this.Property(t => t.rl00508).HasColumnName("rl00508");
            this.Property(t => t.rl00509).HasColumnName("rl00509");
            this.Property(t => t.rl00510).HasColumnName("rl00510");
            this.Property(t => t.rl00511).HasColumnName("rl00511");
            this.Property(t => t.rl00512).HasColumnName("rl00512");
            this.Property(t => t.rl00513).HasColumnName("rl00513");
            this.Property(t => t.rl00514).HasColumnName("rl00514");
            this.Property(t => t.rl00515).HasColumnName("rl00515");
            this.Property(t => t.rl00516).HasColumnName("rl00516");
            this.Property(t => t.rl00517).HasColumnName("rl00517");
            this.Property(t => t.rl00518).HasColumnName("rl00518");
            this.Property(t => t.rl00519).HasColumnName("rl00519");
            this.Property(t => t.rl00520).HasColumnName("rl00520");
            this.Property(t => t.rl00521).HasColumnName("rl00521");
            this.Property(t => t.rl00522).HasColumnName("rl00522");
            this.Property(t => t.rl00523).HasColumnName("rl00523");
            this.Property(t => t.rl00524).HasColumnName("rl00524");
            this.Property(t => t.rl00525).HasColumnName("rl00525");
            this.Property(t => t.rl00526).HasColumnName("rl00526");
            this.Property(t => t.rl00527).HasColumnName("rl00527");
            this.Property(t => t.rl00528).HasColumnName("rl00528");
            this.Property(t => t.rl00529).HasColumnName("rl00529");
            this.Property(t => t.rl00530).HasColumnName("rl00530");
            this.Property(t => t.rl00531).HasColumnName("rl00531");
            this.Property(t => t.rl00532).HasColumnName("rl00532");
            this.Property(t => t.rl00533).HasColumnName("rl00533");
            this.Property(t => t.rl00534).HasColumnName("rl00534");
            this.Property(t => t.rl00535).HasColumnName("rl00535");
            this.Property(t => t.rl00536).HasColumnName("rl00536");
            this.Property(t => t.rl00537).HasColumnName("rl00537");
            this.Property(t => t.rl00538).HasColumnName("rl00538");
            this.Property(t => t.rl00539).HasColumnName("rl00539");
            this.Property(t => t.rl00540).HasColumnName("rl00540");
            this.Property(t => t.rl00541).HasColumnName("rl00541");
            this.Property(t => t.rl00542).HasColumnName("rl00542");
            this.Property(t => t.rl00543).HasColumnName("rl00543");
            this.Property(t => t.rl00544).HasColumnName("rl00544");
            this.Property(t => t.rl00545).HasColumnName("rl00545");
            this.Property(t => t.rl00546).HasColumnName("rl00546");
            this.Property(t => t.rl00547).HasColumnName("rl00547");
            this.Property(t => t.rl00548).HasColumnName("rl00548");
            this.Property(t => t.rl00549).HasColumnName("rl00549");
            this.Property(t => t.rl00550).HasColumnName("rl00550");
            this.Property(t => t.rl00551).HasColumnName("rl00551");
            this.Property(t => t.rl00552).HasColumnName("rl00552");
            this.Property(t => t.rl00553).HasColumnName("rl00553");
            this.Property(t => t.rl00554).HasColumnName("rl00554");
            this.Property(t => t.rl00555).HasColumnName("rl00555");
            this.Property(t => t.rl00556).HasColumnName("rl00556");
            this.Property(t => t.rl00557).HasColumnName("rl00557");
            this.Property(t => t.rl00558).HasColumnName("rl00558");
            this.Property(t => t.rl00559).HasColumnName("rl00559");
            this.Property(t => t.rl00560).HasColumnName("rl00560");
            this.Property(t => t.rl00561).HasColumnName("rl00561");
        }
    }
}
