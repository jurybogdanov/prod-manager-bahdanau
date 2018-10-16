﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductionManager.DbModel.Models
{
    [Table("Department", Schema = "HumanResources")]
    public partial class Department
    {
        public Department()
        {
            EmployeeDepartmentHistory = new HashSet<EmployeeDepartmentHistory>();
        }

        [Column("DepartmentID")]
        public short DepartmentId { get; set; }
        [Required]
        [Column(TypeName = "Name")]
        [StringLength(4000)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "Name")]
        [StringLength(4000)]
        public string GroupName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("Department")]
        public ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistory { get; set; }
    }
}
