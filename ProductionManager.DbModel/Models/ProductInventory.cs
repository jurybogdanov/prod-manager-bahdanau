﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductionManager.DbModel.Models
{
    [Table("ProductInventory", Schema = "Production")]
    public partial class ProductInventory
    {
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Column("LocationID")]
        public short LocationId { get; set; }
        [Required]
        [StringLength(10)]
        public string Shelf { get; set; }
        public byte Bin { get; set; }
        public short Quantity { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("LocationId")]
        [InverseProperty("ProductInventory")]
        public Location Location { get; set; }
        [ForeignKey("ProductId")]
        [InverseProperty("ProductInventory")]
        public Product Product { get; set; }
    }
}
