﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductionManager.DbModel.Models
{
    [Table("ScrapReason", Schema = "Production")]
    public partial class ScrapReason
    {
        public ScrapReason()
        {
            WorkOrder = new HashSet<WorkOrder>();
        }

        [Column("ScrapReasonID")]
        public short ScrapReasonId { get; set; }
        [Required]
        [Column(TypeName = "Name")]
        [StringLength(4000)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("ScrapReason")]
        public ICollection<WorkOrder> WorkOrder { get; set; }
    }
}
