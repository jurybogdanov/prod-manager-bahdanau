﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductionManager.DbModel.Models
{
    [Table("SalesReason", Schema = "Sales")]
    public partial class SalesReason
    {
        public SalesReason()
        {
            SalesOrderHeaderSalesReason = new HashSet<SalesOrderHeaderSalesReason>();
        }

        [Column("SalesReasonID")]
        public int SalesReasonId { get; set; }
        [Required]
        [Column(TypeName = "Name")]
        [StringLength(4000)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "Name")]
        [StringLength(4000)]
        public string ReasonType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("SalesReason")]
        public ICollection<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReason { get; set; }
    }
}
