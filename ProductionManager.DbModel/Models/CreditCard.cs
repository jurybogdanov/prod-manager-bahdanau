﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductionManager.DbModel.Models
{
    [Table("CreditCard", Schema = "Sales")]
    public partial class CreditCard
    {
        public CreditCard()
        {
            PersonCreditCard = new HashSet<PersonCreditCard>();
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
        }

        [Column("CreditCardID")]
        public int CreditCardId { get; set; }
        [Required]
        [StringLength(50)]
        public string CardType { get; set; }
        [Required]
        [StringLength(25)]
        public string CardNumber { get; set; }
        public byte ExpMonth { get; set; }
        public short ExpYear { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("CreditCard")]
        public ICollection<PersonCreditCard> PersonCreditCard { get; set; }
        [InverseProperty("CreditCard")]
        public ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
    }
}
