using Gmail.DDD.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030.szrl033Model
{
    class rlvw_ConTreeMap : EntityConfigurationBase<rlvw_ConTree>
    {
        public rlvw_ConTreeMap()
        {
            //Primary Key
            this.HasKey(t => t.ID);


            //Properties
            this.Property(t => t.ID);
            this.Property(t => t.Name);
            this.Property(t => t.HLever);
            this.Property(t => t.iLever);
            this.Property(t => t.rl01827);
            this.Property(t => t.ConName);
            this.Property(t => t.ConCode);
            this.Property(t => t.ConAmt);
            this.Property(t => t.PayTerm);
            this.Property(t => t.CanAdd);

            this.ToTable("rlvw_ConTree");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.HLever).HasColumnName("HLever");
            this.Property(t => t.iLever).HasColumnName("iLever");
            this.Property(t => t.rl01827).HasColumnName("rl01827");
            this.Property(t => t.ConName).HasColumnName("ConName");
            this.Property(t => t.ConCode).HasColumnName("ConCode");
            this.Property(t => t.ConAmt).HasColumnName("ConAmt");
            this.Property(t => t.PayTerm).HasColumnName("PayTerm");
            this.Property(t => t.CanAdd).HasColumnName("CanAdd");
        }
    }
}
