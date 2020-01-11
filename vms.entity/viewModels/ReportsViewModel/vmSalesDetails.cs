using System;
using System.Collections.Generic;
using System.Text;
using vms.entity.models;

namespace vms.entity.viewModels.ReportsViewModel
{
    public class vmSalesDetails
    {
        public IEnumerable<SalesDetail> Listsale { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public string searchtext { get; set; }
    }
}