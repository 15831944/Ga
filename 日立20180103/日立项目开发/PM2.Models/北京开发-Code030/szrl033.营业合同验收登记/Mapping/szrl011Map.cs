using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Gmail.DDD.DataContext;

namespace PM2.Models.Code030
{
    //szrl011
    public class szrl011Map : EntityConfigurationBase<szrl011>
    {
        public szrl011Map()
        {
            //Primary Key
            this.HasKey(t => t.rl01101);


            //Properties
            this.Property(t => t.rl01101).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl01102).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl01103).IsRequired().HasMaxLength(200);
            this.Property(t => t.rl01104).IsRequired().HasMaxLength(200);
            this.Property(t => t.rl01105).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl01106).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl01107);
            this.Property(t => t.rl01108).IsRequired().HasMaxLength(200);
            this.Property(t => t.rl01109);
            this.Property(t => t.rl01110);
            this.Property(t => t.rl01111).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl01112);
            this.Property(t => t.rl01113);
            this.Property(t => t.rl01114);
            this.Property(t => t.rl01115);
            this.Property(t => t.rl01116).IsRequired().HasMaxLength(200);
            this.Property(t => t.rl01117);
            this.Property(t => t.rl01118).IsRequired().HasMaxLength(20);
            this.Property(t => t.rl01119).IsRequired().HasMaxLength(20);
            this.Property(t => t.rl01120);
            this.Property(t => t.rl01121);
            this.Property(t => t.rl01122);
            this.Property(t => t.rl01123);
            this.Property(t => t.rl01124);
            this.Property(t => t.rl01125);
            this.Property(t => t.rl01126).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl01127);
            this.Property(t => t.rl01128);
            this.Property(t => t.rl01129);
            this.Property(t => t.rl01130);
            this.Property(t => t.rl01131);
            this.Property(t => t.rl01132).IsRequired().HasMaxLength(200);
            this.Property(t => t.rl01133);
            this.Property(t => t.rl01134);
            this.Property(t => t.rl01135);
            this.Property(t => t.rl01136).IsRequired().HasMaxLength(200);
            this.Property(t => t.rl01137).IsRequired().HasMaxLength(200);
            this.Property(t => t.rl01138).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl01139).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl01140).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl01141).IsRequired().HasMaxLength(40);
            this.Property(t => t.rl01142).IsRequired().HasMaxLength(20);
            this.Property(t => t.rl01143).IsRequired().HasMaxLength(200);
            this.Property(t => t.rl01144).IsRequired().HasMaxLength(200);
            this.Property(t => t.rl01145);
            this.Property(t => t.rl01146);
            this.Property(t => t.rl01147).IsRequired().HasMaxLength(100);
            this.Property(t => t.rl01148).IsRequired().HasMaxLength(10);
            this.Property(t => t.rl01149).IsRequired().HasMaxLength(100);
            this.Property(t => t.rl01150).IsRequired().HasMaxLength(10);
            this.Property(t => t.rl01151);
            this.Property(t => t.rl01152).IsRequired().HasMaxLength(100);
            this.Property(t => t.rl01153).IsRequired().HasMaxLength(10);
            this.Property(t => t.rl01154).IsRequired().HasMaxLength(200);
            this.Property(t => t.rl01155).IsRequired().HasMaxLength(200);
            this.Property(t => t.rl01156).IsRequired().HasMaxLength(200);
            this.Property(t => t.rl01157);
            this.Property(t => t.rl01158);
            this.Property(t => t.rl01159);
            this.Property(t => t.rl01160);
            this.Property(t => t.rl01161);


            // Table & Column Mappings
            this.ToTable("szrl011");
            this.Property(t => t.rl01101).HasColumnName("rl01101");
            this.Property(t => t.rl01102).HasColumnName("rl01102");
            this.Property(t => t.rl01103).HasColumnName("rl01103");
            this.Property(t => t.rl01104).HasColumnName("rl01104");
            this.Property(t => t.rl01105).HasColumnName("rl01105");
            this.Property(t => t.rl01106).HasColumnName("rl01106");
            this.Property(t => t.rl01107).HasColumnName("rl01107");
            this.Property(t => t.rl01108).HasColumnName("rl01108");
            this.Property(t => t.rl01109).HasColumnName("rl01109");
            this.Property(t => t.rl01110).HasColumnName("rl01110");
            this.Property(t => t.rl01111).HasColumnName("rl01111");
            this.Property(t => t.rl01112).HasColumnName("rl01112");
            this.Property(t => t.rl01113).HasColumnName("rl01113");
            this.Property(t => t.rl01114).HasColumnName("rl01114");
            this.Property(t => t.rl01115).HasColumnName("rl01115");
            this.Property(t => t.rl01116).HasColumnName("rl01116");
            this.Property(t => t.rl01117).HasColumnName("rl01117");
            this.Property(t => t.rl01118).HasColumnName("rl01118");
            this.Property(t => t.rl01119).HasColumnName("rl01119");
            this.Property(t => t.rl01120).HasColumnName("rl01120");
            this.Property(t => t.rl01121).HasColumnName("rl01121");
            this.Property(t => t.rl01122).HasColumnName("rl01122");
            this.Property(t => t.rl01123).HasColumnName("rl01123");
            this.Property(t => t.rl01124).HasColumnName("rl01124");
            this.Property(t => t.rl01125).HasColumnName("rl01125");
            this.Property(t => t.rl01126).HasColumnName("rl01126");
            this.Property(t => t.rl01127).HasColumnName("rl01127");
            this.Property(t => t.rl01128).HasColumnName("rl01128");
            this.Property(t => t.rl01129).HasColumnName("rl01129");
            this.Property(t => t.rl01130).HasColumnName("rl01130");
            this.Property(t => t.rl01131).HasColumnName("rl01131");
            this.Property(t => t.rl01132).HasColumnName("rl01132");
            this.Property(t => t.rl01133).HasColumnName("rl01133");
            this.Property(t => t.rl01134).HasColumnName("rl01134");
            this.Property(t => t.rl01135).HasColumnName("rl01135");
            this.Property(t => t.rl01136).HasColumnName("rl01136");
            this.Property(t => t.rl01137).HasColumnName("rl01137");
            this.Property(t => t.rl01138).HasColumnName("rl01138");
            this.Property(t => t.rl01139).HasColumnName("rl01139");
            this.Property(t => t.rl01140).HasColumnName("rl01140");
            this.Property(t => t.rl01141).HasColumnName("rl01141");
            this.Property(t => t.rl01142).HasColumnName("rl01142");
            this.Property(t => t.rl01143).HasColumnName("rl01143");
            this.Property(t => t.rl01144).HasColumnName("rl01144");
            this.Property(t => t.rl01145).HasColumnName("rl01145");
            this.Property(t => t.rl01146).HasColumnName("rl01146");
            this.Property(t => t.rl01147).HasColumnName("rl01147");
            this.Property(t => t.rl01148).HasColumnName("rl01148");
            this.Property(t => t.rl01149).HasColumnName("rl01149");
            this.Property(t => t.rl01150).HasColumnName("rl01150");
            this.Property(t => t.rl01151).HasColumnName("rl01151");
            this.Property(t => t.rl01152).HasColumnName("rl01152");
            this.Property(t => t.rl01153).HasColumnName("rl01153");
            this.Property(t => t.rl01154).HasColumnName("rl01154");
            this.Property(t => t.rl01155).HasColumnName("rl01155");
            this.Property(t => t.rl01156).HasColumnName("rl01156");
            this.Property(t => t.rl01157).HasColumnName("rl01157");
            this.Property(t => t.rl01158).HasColumnName("rl01158");
            this.Property(t => t.rl01159).HasColumnName("rl01159");
            this.Property(t => t.rl01160).HasColumnName("rl01160");
            this.Property(t => t.rl01161).HasColumnName("rl01161");


        }
    }
}