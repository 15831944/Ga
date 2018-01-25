using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Gmail.DDD.DataContext;

namespace PM2.Models.Code030.Szrl105Model
{
    //szrl105
    public class Szrl105Map : EntityConfigurationBase<Szrl105>
    {
        public Szrl105Map()
        {
            this.HasKey(t => t.rl10501);

            //Properties
            this.Property(t => t.rl10501)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(t => t.rl10502)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(t => t.rl10503)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(t => t.rl10504)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(t => t.rl10505)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(t => t.rl10506)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(t => t.rl10507)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(t => t.rl10508)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl10509)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl10510)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl10511)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl10512)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl10513)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl10514)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl10515)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl10516)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl10517)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl10518)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl10519)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10520)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl10521)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10522)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10523)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl10524)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10525)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10526)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10527)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10528)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10529)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10530)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10531)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10532)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10533)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10534)
            .IsRequired()
            .HasMaxLength(20);

            this.Property(t => t.rl10535)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10536)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10537)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10538)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10539);
            this.Property(t => t.rl10540)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10541)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10542)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl10543)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10544)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10545)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10546)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10547)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10548)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10549)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10550)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10551)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10552)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10553)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10554)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10555)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10556)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10557)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl10558)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl10559)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl10560)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl10561)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl10562)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl10563)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl10564)
            .IsRequired()
            .HasMaxLength(200);

            this.Property(t => t.rl10565);
            this.Property(t => t.rl10566);
            this.Property(t => t.rl10567)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl10568)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl10569)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(t => t.rl10570)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(t => t.rl10571);
            this.Property(t => t.rl10572);
            this.Property(t => t.rl10573)
            .IsRequired()
            .HasMaxLength(500);

            this.Property(t => t.rl10574)
            .IsRequired()
            .HasPrecision(18, 9);

            this.Property(t => t.rl10575)
            .IsRequired()
            .HasMaxLength(40);

            this.Property(t => t.rl10576)
            .IsRequired()
            .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("szrl105");
            this.Property(t => t.rl10501).HasColumnName("rl10501");
            this.Property(t => t.rl10502).HasColumnName("rl10502");
            this.Property(t => t.rl10503).HasColumnName("rl10503");
            this.Property(t => t.rl10504).HasColumnName("rl10504");
            this.Property(t => t.rl10505).HasColumnName("rl10505");
            this.Property(t => t.rl10506).HasColumnName("rl10506");
            this.Property(t => t.rl10507).HasColumnName("rl10507");
            this.Property(t => t.rl10508).HasColumnName("rl10508");
            this.Property(t => t.rl10509).HasColumnName("rl10509");
            this.Property(t => t.rl10510).HasColumnName("rl10510");
            this.Property(t => t.rl10511).HasColumnName("rl10511");
            this.Property(t => t.rl10512).HasColumnName("rl10512");
            this.Property(t => t.rl10513).HasColumnName("rl10513");
            this.Property(t => t.rl10514).HasColumnName("rl10514");
            this.Property(t => t.rl10515).HasColumnName("rl10515");
            this.Property(t => t.rl10516).HasColumnName("rl10516");
            this.Property(t => t.rl10517).HasColumnName("rl10517");
            this.Property(t => t.rl10518).HasColumnName("rl10518");
            this.Property(t => t.rl10519).HasColumnName("rl10519");
            this.Property(t => t.rl10520).HasColumnName("rl10520");
            this.Property(t => t.rl10521).HasColumnName("rl10521");
            this.Property(t => t.rl10522).HasColumnName("rl10522");
            this.Property(t => t.rl10523).HasColumnName("rl10523");
            this.Property(t => t.rl10524).HasColumnName("rl10524");
            this.Property(t => t.rl10525).HasColumnName("rl10525");
            this.Property(t => t.rl10526).HasColumnName("rl10526");
            this.Property(t => t.rl10527).HasColumnName("rl10527");
            this.Property(t => t.rl10528).HasColumnName("rl10528");
            this.Property(t => t.rl10529).HasColumnName("rl10529");
            this.Property(t => t.rl10530).HasColumnName("rl10530");
            this.Property(t => t.rl10531).HasColumnName("rl10531");
            this.Property(t => t.rl10532).HasColumnName("rl10532");
            this.Property(t => t.rl10533).HasColumnName("rl10533");
            this.Property(t => t.rl10534).HasColumnName("rl10534");
            this.Property(t => t.rl10535).HasColumnName("rl10535");
            this.Property(t => t.rl10536).HasColumnName("rl10536");
            this.Property(t => t.rl10537).HasColumnName("rl10537");
            this.Property(t => t.rl10538).HasColumnName("rl10538");
            this.Property(t => t.rl10539).HasColumnName("rl10539");
            this.Property(t => t.rl10540).HasColumnName("rl10540");
            this.Property(t => t.rl10541).HasColumnName("rl10541");
            this.Property(t => t.rl10542).HasColumnName("rl10542");
            this.Property(t => t.rl10543).HasColumnName("rl10543");
            this.Property(t => t.rl10544).HasColumnName("rl10544");
            this.Property(t => t.rl10545).HasColumnName("rl10545");
            this.Property(t => t.rl10546).HasColumnName("rl10546");
            this.Property(t => t.rl10547).HasColumnName("rl10547");
            this.Property(t => t.rl10548).HasColumnName("rl10548");
            this.Property(t => t.rl10549).HasColumnName("rl10549");
            this.Property(t => t.rl10550).HasColumnName("rl10550");
            this.Property(t => t.rl10551).HasColumnName("rl10551");
            this.Property(t => t.rl10552).HasColumnName("rl10552");
            this.Property(t => t.rl10553).HasColumnName("rl10553");
            this.Property(t => t.rl10554).HasColumnName("rl10554");
            this.Property(t => t.rl10555).HasColumnName("rl10555");
            this.Property(t => t.rl10556).HasColumnName("rl10556");
            this.Property(t => t.rl10557).HasColumnName("rl10557");
            this.Property(t => t.rl10558).HasColumnName("rl10558");
            this.Property(t => t.rl10559).HasColumnName("rl10559");
            this.Property(t => t.rl10560).HasColumnName("rl10560");
            this.Property(t => t.rl10561).HasColumnName("rl10561");
            this.Property(t => t.rl10562).HasColumnName("rl10562");
            this.Property(t => t.rl10563).HasColumnName("rl10563");
            this.Property(t => t.rl10564).HasColumnName("rl10564");
            this.Property(t => t.rl10565).HasColumnName("rl10565");
            this.Property(t => t.rl10566).HasColumnName("rl10566");
            this.Property(t => t.rl10567).HasColumnName("rl10567");
            this.Property(t => t.rl10568).HasColumnName("rl10568");
            this.Property(t => t.rl10569).HasColumnName("rl10569");
            this.Property(t => t.rl10570).HasColumnName("rl10570");
            this.Property(t => t.rl10571).HasColumnName("rl10571");
            this.Property(t => t.rl10572).HasColumnName("rl10572");
            this.Property(t => t.rl10573).HasColumnName("rl10573");
            this.Property(t => t.rl10574).HasColumnName("rl10574");
            this.Property(t => t.rl10575).HasColumnName("rl10575");
            this.Property(t => t.rl10576).HasColumnName("rl10576");
        }
    }
}