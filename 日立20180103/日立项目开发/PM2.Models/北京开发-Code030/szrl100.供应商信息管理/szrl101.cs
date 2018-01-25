using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using PM2.Code;
using Gmail.DDD.Entity;

namespace PM2.Models.Code030.szrl100Model
{
	 	//szrl101
		public class szrl101 : Enttity
	{
   		     
      	/// <summary>
		/// rl10101
        /// </summary>        
        [EasyTextbox]       
         public string rl10101{ get; set; }
		/// <summary>
		/// rl10102
        /// </summary>        
        [EasyTextbox]       
         public string rl10102 { get; set; }
		/// <summary>
		/// rl10103
        /// </summary>        
        [EasyTextbox]       
         public string rl10103{ get; set; }

        public DateTime rl10104 { get; set; }

        public string rl10105 { get; set; }
		   
    
        //public virtual szrl100 szrl100 { get; set; }
	}
}

