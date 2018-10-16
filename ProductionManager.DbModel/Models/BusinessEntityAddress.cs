﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductionManager.DbModel.Models
{
    [Table("BusinessEntityAddress", Schema = "Person")]
    public partial class BusinessEntityAddress
    {
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Column("AddressID")]
        public int AddressId { get; set; }
        [Column("AddressTypeID")]
        public int AddressTypeId { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("AddressId")]
        [InverseProperty("BusinessEntityAddress")]
        public Address Address { get; set; }
        [ForeignKey("AddressTypeId")]
        [InverseProperty("BusinessEntityAddress")]
        public AddressType AddressType { get; set; }
        [ForeignKey("BusinessEntityId")]
        [InverseProperty("BusinessEntityAddress")]
        public BusinessEntity BusinessEntity { get; set; }
    }
}
