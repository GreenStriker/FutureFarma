﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace vms.entity.models
{
    public partial class AdvancedSalary
    {
        public int AdvanceSalaryId { get; set; }
        public int? EmloyId { get; set; }
        public DateTime? DateTaben { get; set; }
        public decimal Amount { get; set; }
        public int? PayrollId { get; set; }
        public string Remarks { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }

        public virtual Employe Emloy { get; set; }
        public virtual Payroll Payroll { get; set; }
    }
}