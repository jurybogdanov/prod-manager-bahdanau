﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductionManager.DbModel.Models
{
    [Table("Currency", Schema = "Sales")]
    public partial class Currency
    {
        public Currency()
        {
            CountryRegionCurrency = new HashSet<CountryRegionCurrency>();
            CurrencyRateFromCurrencyCodeNavigation = new HashSet<CurrencyRate>();
            CurrencyRateToCurrencyCodeNavigation = new HashSet<CurrencyRate>();
        }

        [Key]
        [Column(TypeName = "nchar(3)")]
        public string CurrencyCode { get; set; }
        [Required]
        [Column(TypeName = "Name")]
        [StringLength(4000)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("CurrencyCodeNavigation")]
        public ICollection<CountryRegionCurrency> CountryRegionCurrency { get; set; }
        [InverseProperty("FromCurrencyCodeNavigation")]
        public ICollection<CurrencyRate> CurrencyRateFromCurrencyCodeNavigation { get; set; }
        [InverseProperty("ToCurrencyCodeNavigation")]
        public ICollection<CurrencyRate> CurrencyRateToCurrencyCodeNavigation { get; set; }
    }
}
