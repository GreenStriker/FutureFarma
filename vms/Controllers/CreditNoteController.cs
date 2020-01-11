using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Inventory.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using vms.entity.viewModels;
using vms.repository.dbo.StoredProcedure;
using vms.service.dbo;
using vms.service.dbo.StoredProdecure;
using vms.utility.StaticData;

namespace Inventory.Controllers
{
    public class CreditNoteController : ControllerBase
    {
        private readonly ISaleService _service;
        private readonly ISaleDetailService _saleDetail;
        private readonly IProductService _prodService;
        private readonly IConfiguration _configuration;
        private readonly IProductLogService _logService;
        private readonly IStoreProcedureService _spService;
        public CreditNoteController(
            IStoreProcedureService spService,
            ControllerBaseParamModel controllerBaseParamModel,
            ISaleService service,
            ISaleDetailService saleDetail,
            IProductService prodService,
            IProductLogService logService

        ) : base(controllerBaseParamModel)
        {
            _spService = spService;
            _logService = logService;
            _service = service;
            _configuration = Configuration;
            _saleDetail = saleDetail;
            _prodService = prodService;

        }



        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreditNote(int id)
        {
            var createdBy = _session.UserId;
            var BranchId = _session.BranchId;
            var sale = await _service.GetById(id);
            var salesDetails = await _saleDetail.Query().Where(c=>c.Sale.SalesId==id).SelectAsync(CancellationToken.None);
         
            var vm = new VmSalesDetail { SalesDetails = salesDetails, Sale = sale };

            return View(vm);
        }
        public async System.Threading.Tasks.Task<JsonResult> CreditNoteSave(vmCreditNote vm)
        {
            var createdBy = _session.UserId;
            var organizationId = _session.BranchId;
            bool status = false;

            if (vm.CreditNoteDetails.Count > 0)
            {
                vm.CreatedBy = createdBy;
                vm.CreatedTime = DateTime.Now;

                status = await _spService.InsertCredit(vm);
            }
            TempData[ControllerStaticData.MESSAGE] = ControllerStaticData.SUCCESS_CLASSNAME;
            return Json(status);
        }
    }
}