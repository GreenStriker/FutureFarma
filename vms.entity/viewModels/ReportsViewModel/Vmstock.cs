using System;
using System.Collections.Generic;
using X.PagedList;
using vms.entity.StoredProcedureModel;

namespace vms.entity.viewModels.ReportsViewModel
{
    public class Vmstock 
    {
        public int brachID { get; set; }
    
        
        public List<Spstock> Liststock { get; set; }
        
    }
   
}