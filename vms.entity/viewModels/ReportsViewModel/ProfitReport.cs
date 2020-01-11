using System;
using System.Collections.Generic;
using System.Text;
using vms.entity.StoredProcedureModel;
namespace vms.entity.viewModels.ReportsViewModel
{
    public class ProfitReport
    {


        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }

        public SpProfit profit { get; set; }

    }

}