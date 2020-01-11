using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using vms.entity.models;
using vms.entity.viewModels;
using vms.Models;
using vms.service.dbo.StoredProdecure;
using vms.utility;
using Inventory.Utility;
using vms.utility.StaticData;
using X.PagedList;
using System;
using vms.entity.viewModels.ReportsViewModel;
using vms.service.dbo;

namespace Inventory.Controllers
{
    public class RptController : ControllerBase
    {
    
        private readonly IConfiguration _configuration;
        private readonly IReportsService _service;
        private readonly IStoreProcedureService _Storeservice;
        private readonly ISaleDetailService _detailService;
        private readonly IPurchaseDetailService _pdetailService;


        public RptController(
            ControllerBaseParamModel controllerBaseParamModel,
           IReportsService service,
           IStoreProcedureService Storeservice,
           ISaleDetailService detailService,
           IPurchaseDetailService pdetailService



            ) : base(controllerBaseParamModel)
        {

            _service = service;
            _Storeservice = Storeservice;
            _detailService = detailService;
            _pdetailService = pdetailService;
        }



        public async Task<IActionResult> Index()
        {
            

            return View();
        }

        public async Task<IActionResult> Profit()
        {


            var data = await _service.ProfitReport(DateTime.Now.AddMonths(-1), DateTime.Now);




            var model = new ProfitReport();


            model.profit = data;

            model.fromDate = DateTime.Now.AddMonths(-1);
            model.toDate = DateTime.Now;

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Profit(ProfitReport md )
        {


            var data = await _service.ProfitReport(md.fromDate, md.toDate);




            var model = new ProfitReport();


            model.profit = data;

            model.fromDate = md.fromDate;
            model.toDate = md.toDate;

            return View(model);
        }





        public async Task<IActionResult> Stock()
        {


            var data = await _Storeservice.StockList(_session.BranchId);





            return View(data);
        }



        public async Task<IActionResult> salesReport()
        {
            var model = new vmSalesDetails();
            model.FromDate = DateTime.Now.AddMonths(-1);
            model.ToDate = DateTime.Now;
            var getsale = await _detailService.Query().Where(c => c.Sale.BranchId == _session.BranchId && c.Sale.CreatedTime >= model.FromDate && c.Sale.CreatedTime <= model.ToDate)

                .Include(a=>a.Sale).Include(a=>a.Sale.Customer).Include(a => a.Product)

                .OrderByDescending(c => c.SalesDetailId).SelectAsync(CancellationToken.None);

           

          
            model.Listsale = getsale;

            return View(model);

        }


        [HttpPost]
        public async Task<IActionResult> salesReport(vmSalesDetails model)
        {
            
           
            var getsale = await _detailService.Query().Where(c => c.Sale.BranchId == _session.BranchId && c.Sale.CreatedTime >= model.FromDate && c.Sale.CreatedTime <= model.ToDate)

                .Include(a => a.Sale).Include(a => a.Sale.Customer).Include(a => a.Product)

                .OrderByDescending(c => c.SalesDetailId).SelectAsync(CancellationToken.None);

            //string search = model.searchtext;


            if (model.searchtext != null && model.searchtext != "")
            {

                model.searchtext = model.searchtext.ToLower().Trim();
                getsale = getsale.Where(c => c.Product.Name.ToLower().Contains(model.searchtext) );


            }





            //model.searchtext = search;
            model.Listsale = getsale;

            return View(model);

        }

        public async Task<IActionResult> PurchaseReport()
        {
            var model = new vmPurDetails();
            model.FromDate = DateTime.Now.AddMonths(-1);
            model.ToDate = DateTime.Now;
            var getsale = await _pdetailService.Query().Where(c => c.Purchase.BranchId == _session.BranchId && c.Purchase.CreatedTime >= model.FromDate && c.Purchase.CreatedTime <= model.ToDate)

                .Include(a => a.Purchase).Include(a => a.Purchase.Vendor).Include(a => a.Product)

                .OrderByDescending(c => c.PurchaseDetailId).SelectAsync(CancellationToken.None);




            model.Listsale = getsale;

            return View(model);

        }


        [HttpPost]
        public async Task<IActionResult> PurchaseReport(vmPurDetails model)
        {


            var getsale = await _pdetailService.Query().Where(c => c.Purchase.BranchId == _session.BranchId && c.Purchase.CreatedTime >= model.FromDate && c.Purchase.CreatedTime <= model.ToDate)

                .Include(a => a.Purchase).Include(a => a.Purchase.Vendor).Include(a => a.Product)

                .OrderByDescending(c => c.PurchaseDetailId).SelectAsync(CancellationToken.None);


            //string search = model.searchtext;
            if (model.searchtext != null && model.searchtext != "")
            {

                model.searchtext = model.searchtext.ToLower().Trim();
                getsale = getsale.Where(c => c.Product.Name.ToLower().Contains(model.searchtext));


            }


             //model.searchtext = search ;
            model.Listsale = getsale;

            return View(model);

        }


    }
}