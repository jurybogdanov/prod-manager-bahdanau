﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductionManager.DbModel.Models
{
    [Table("SalesTerritory", Schema = "Sales")]
    public partial class SalesTerritory
    {
        public SalesTerritory()
        {
            Customer = new HashSet<Customer>();
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
            SalesPerson = new HashSet<SalesPerson>();
            SalesTerritoryHistory = new HashSet<SalesTerritoryHistory>();
            StateProvince = new HashSet<StateProvince>();
        }

        [Key]
        [Column("TerritoryID")]
        public int TerritoryId { get; set; }
        [Required]
        [Column(TypeName = "Name")]
        [StringLength(4000)]
        public string Name { get; set; }
        [Required]
        [StringLength(3)]
        public string CountryRegionCode { get; set; }
        [Required]
        [StringLength(50)]
        public string Group { get; set; }
        [Column("SalesYTD", TypeName = "money")]
        public decimal SalesYtd { get; set; }
        [Column(TypeName = "money")]
        public decimal SalesLastYear { get; set; }
        [Column("CostYTD", TypeName = "money")]
        public decimal CostYtd { get; set; }
        [Column(TypeName = "money")]
        public decimal CostLastYear { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("CountryRegionCode")]
        [InverseProperty("SalesTerritory")]
        public CountryRegion CountryRegionCodeNavigation { get; set; }
        [InverseProperty("Territory")]
        public ICollection<Customer> Customer { get; set; }
        [InverseProperty("Territory")]
        public ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
        [InverseProperty("Territory")]
        public ICollection<SalesPerson> SalesPerson { get; set; }
        [InverseProperty("Territory")]
        public ICollection<SalesTerritoryHistory> SalesTerritoryHistory { get; set; }
        [InverseProperty("Territory")]
        public ICollection<StateProvince> StateProvince { get; set; }
    }
}
