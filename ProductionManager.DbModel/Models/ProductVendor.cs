﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductionManager.DbModel.Models
{
    [Table("ProductVendor", Schema = "Purchasing")]
    public partial class ProductVendor
    {
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        public int AverageLeadTime { get; set; }
        [Column(TypeName = "money")]
        public decimal StandardPrice { get; set; }
        [Column(TypeName = "money")]
        public decimal? LastReceiptCost { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastReceiptDate { get; set; }
        public int MinOrderQty { get; set; }
        public int MaxOrderQty { get; set; }
        public int? OnOrderQty { get; set; }
        [Required]
        [Column(TypeName = "nchar(3)")]
        public string UnitMeasureCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("BusinessEntityId")]
        [InverseProperty("ProductVendor")]
        public Vendor BusinessEntity { get; set; }
        [ForeignKey("ProductId")]
        [InverseProperty("ProductVendor")]
        public Product Product { get; set; }
        [ForeignKey("UnitMeasureCode")]
        [InverseProperty("ProductVendor")]
        public UnitMeasure UnitMeasureCodeNavigation { get; set; }
    }
}
