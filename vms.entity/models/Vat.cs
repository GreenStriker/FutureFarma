﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace vms.entity.models
{
    public partial class Vat
    {
        public Vat()
        {
            Products = new HashSet<Product>();
        }

        public int VatId { get; set; }
        public string Name { get; set; }
        public decimal? Percentage { get; set; }
        public DateTime? EfectiveFrom { get; set; }
        public DateTime? EfectiveTo { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}