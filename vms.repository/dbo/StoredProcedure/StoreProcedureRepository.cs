using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using vms.entity.models;
using vms.entity.viewModels;
using vms.entity.StoredProcedureModel;
namespace vms.repository.dbo.StoredProcedure
{
    public interface IStoreProcedureRepository 
    {
        Task<bool> InsertCredit(vmCreditNote vm);
        Task<bool> InsertDebit(vmDebitNote vm);

        Task<List<Spstock>> StockList(int BranchID);

    }
    public class StoreProcedureRepository : IStoreProcedureRepository
    {
        private readonly DbContext _context;

        public StoreProcedureRepository(DbContext context)
        {
            _context = context;
        }
        public async Task<bool> InsertCredit(vmCreditNote vm)
        {
            var creditNoteDetails = Newtonsoft.Json.JsonConvert.SerializeObject(vm.CreditNoteDetails);
            try
            {
                this._context.Database.ExecuteSqlCommand(
                    $"EXEC [dbo].[SpCreditNote]  " +
                    $"@SalesId," +
                    $"@VoucherNo," +
                    $"@ReasonOfReturn," +
                    $"@ReturnDate," +
                    $"@CreatedBy," +
                    $"@CreatedTime," +
                    $"@CreditNoteDetails"
                    , new SqlParameter("@SalesId", (object)vm.SalesId ?? DBNull.Value)
                    , new SqlParameter("@VoucherNo", (object)vm.VoucherNo ?? DBNull.Value)
                    , new SqlParameter("@ReasonOfReturn", (object)vm.ReasonOfReturn ?? DBNull.Value)
                    , new SqlParameter("@ReturnDate", (object)vm.ReturnDate ?? DBNull.Value)
                    , new SqlParameter("@CreatedBy", (object)vm.CreatedBy ?? DBNull.Value)
                    , new SqlParameter("@CreatedTime", (object)vm.CreatedTime ?? DBNull.Value)
                    , new SqlParameter("@CreditNoteDetails", (object)creditNoteDetails ?? DBNull.Value)
                );

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return await Task.FromResult(true);
        }

        public async Task<bool> InsertDebit(vmDebitNote vm)
        {
            var debitNoteDetails = Newtonsoft.Json.JsonConvert.SerializeObject(vm.DebitNoteDetails);
            try
            {
                this._context.Database.ExecuteSqlCommand(
                    $"EXEC [dbo].[spInsertDebitNote]  " +
                    $"@PurchaseId," +
                    $"@VoucherNo," +
                    $"@ReasonOfReturn," +
                    $"@ReturnDate," +
                    $"@CreatedBy," +
                    $"@CreatedTime," +
                    $"@DebitNoteDetails"
                    , new SqlParameter("@PurchaseId", (object)vm.PurchaseId ?? DBNull.Value)
                    , new SqlParameter("@VoucherNo", (object)vm.VoucherNo ?? DBNull.Value)
                    , new SqlParameter("@ReasonOfReturn", (object)vm.ReasonOfReturn ?? DBNull.Value)
                    , new SqlParameter("@ReturnDate", (object)vm.ReturnDate ?? DBNull.Value)
                    , new SqlParameter("@CreatedBy", (object)vm.CreatedBy ?? DBNull.Value)
                    , new SqlParameter("@CreatedTime", (object)vm.CreatedTime ?? DBNull.Value)
                    , new SqlParameter("@DebitNoteDetails", (object)debitNoteDetails ?? DBNull.Value)
                );
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return await Task.FromResult(true);
        }




        public async Task<List<Spstock>> StockList(int BranchID)
        {

            var item = await _context.Set<Spstock>().FromSql("SPStock @brach={0}", BranchID).ToListAsync();
            return item;
        }




    }
}
