using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;
using vms.entity.models;
namespace vms.entity.StoredProcedureModel
{
    public class Spstock
    {
        [Key]

        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal? Purchase { get; set; }
        public decimal? Sold { get; set; }
        public decimal? PurchaseReturn { get; set; }
	    public decimal? SalesRetun { get; set; }
	    public decimal? INStock { get; set; }
       


    }
}