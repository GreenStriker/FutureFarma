﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace vms.entity.models
{
    public partial class ProductGruop
    {
        public ProductGruop()
        {
            Products = new HashSet<Product>();
        }

        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public string Description { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public bool? IsAtive { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}