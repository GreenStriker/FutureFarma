using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using vms.entity.viewModels;
using vms.service.dbo;
using vms.service.dbo.StoredProdecure;
using vms.utility.StaticData;

namespace Inventory.Controllers
{
    public class DebitNoteController : ControllerBase
    {
        private readonly IPurchaseService _service;
        private readonly IPurchaseDetailService _purchaseDetail;
        private readonly IProductService _prodService;
        private readonly IConfiguration _configuration;
        private readonly IProductLogService _logService;
        private readonly IStoreProcedureService _spService;
        public DebitNoteController(
            IStoreProcedureService spService,
            ControllerBaseParamModel controllerBaseParamModel,
            IPurchaseService service,
            IPurchaseDetailService purchaseDetail,
            IProductService prodService,
            IProductLogService logService

        ) : base(controllerBaseParamModel)
        {
            _spService = spService;
            _logService = logService;
            _service = service;
            _configuration = Configuration;
            _purchaseDetail = purchaseDetail;
            _prodService = prodService;

        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> DebitNote(int id)
        {
            var purchase = await _service.GetById(id);
            var vm = new VmPurchaseDetail { PurchaseDetails = purchase.PurchaseDetails, Purchase = purchase };
            return View(vm);
        }

        [HttpPost]

        public async System.Threading.Tasks.Task<JsonResult> DebitNoteSave(vmDebitNote vm)
        {
            var createdBy = _session.UserId;
            var organizationId = _session.BranchId;
            bool status = false;

            if (vm.DebitNoteDetails.Count > 0)
            {
                vm.CreatedBy = createdBy;
                vm.CreatedTime = DateTime.Now;

                status = await _spService.InsertDebit(vm);
            }
            TempData[ControllerStaticData.MESSAGE] = ControllerStaticData.SUCCESS_CLASSNAME;
            return Json(status);
        }
    }
}