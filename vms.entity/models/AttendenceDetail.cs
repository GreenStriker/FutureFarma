﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace vms.entity.models
{
    public partial class AttendenceDetail
    {
        public int AttendenceDetailsId { get; set; }
        public int? AttendenceId { get; set; }
        public int? EmployId { get; set; }
        public int? Present { get; set; }
        public int? Late { get; set; }
        public int? TotalAttended { get; set; }

        public virtual Atendence Attendence { get; set; }
        public virtual Employe Employ { get; set; }
    }
}