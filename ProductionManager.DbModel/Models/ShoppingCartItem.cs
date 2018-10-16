﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductionManager.DbModel.Models
{
    [Table("ShoppingCartItem", Schema = "Sales")]
    public partial class ShoppingCartItem
    {
        [Column("ShoppingCartItemID")]
        public int ShoppingCartItemId { get; set; }
        [Required]
        [Column("ShoppingCartID")]
        [StringLength(50)]
        public string ShoppingCartId { get; set; }
        public int Quantity { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("ShoppingCartItem")]
        public Product Product { get; set; }
    }
}
