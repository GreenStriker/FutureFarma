using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;
using vms.entity.models;
namespace vms.entity.StoredProcedureModel
{
    public class SpProfit
    {
        [Key]

        public int id { get; set; }
        public decimal? TotalCredit { get; set; }
        public decimal? TotalReciveable { get; set; }
        public decimal? TotalReciv { get; set; }
        public decimal? TotalPurchasePay { get; set; }
	    public decimal? TotalPayableAmount{ get; set; }
	    public decimal? TotalPay { get; set; }
        public decimal? TotalExpence { get; set; }


    }
}