using Gmail.DDD.Entity;
using PM2.Code;
using System;
using System.Collections.Generic;

namespace PM2.Models.Code030
{
    public partial class sdbo005 : Enttity
    {
        /// <summary>
        /// Ö÷¼ü
        /// </summary>        
        [Column(ColumnType = ColumnType.PrimaryKey)]
        public string bo00501 { get; set; }
        /// <summary>
        /// bo00502
        /// </summary>        
        [EasyTextbox]
        public string bo00502 { get; set; }
        /// <summary>
        /// bo00503
        /// </summary>        
        [EasyTextbox]
        public string bo00503 { get; set; }
        /// <summary>
        /// bo00504
        /// </summary>        
        [EasyTextbox]
        public string bo00504 { get; set; }
        /// <summary>
        /// bo00505
        /// </summary>        
        [EasyTextbox]
        public int bo00505 { get; set; }
        /// <summary>
        /// bo00506
        /// </summary>        
        [EasyTextbox]
        public string bo00506 { get; set; }
        /// <summary>
        /// bo00507
        /// </summary>        
        [EasyTextbox]
        public int bo00507 { get; set; }
    }
}
