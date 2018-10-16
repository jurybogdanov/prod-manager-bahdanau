﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductionManager.DbModel.Models
{
    [Table("CountryRegionCurrency", Schema = "Sales")]
    public partial class CountryRegionCurrency
    {
        [StringLength(3)]
        public string CountryRegionCode { get; set; }
        [Column(TypeName = "nchar(3)")]
        public string CurrencyCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("CountryRegionCode")]
        [InverseProperty("CountryRegionCurrency")]
        public CountryRegion CountryRegionCodeNavigation { get; set; }
        [ForeignKey("CurrencyCode")]
        [InverseProperty("CountryRegionCurrency")]
        public Currency CurrencyCodeNavigation { get; set; }
    }
}
