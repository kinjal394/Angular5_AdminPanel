using Admin_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_API.ServiceContract
{
    interface ICurrency_Repository
    {
        Task<List<CurrencyMaster>> GetAll();
        Task<CurrencyMaster> GetById(int Id);
        Task<List<CurrencyMaster>> GetAllForBase();
        Task Insert(CurrencyMaster currencyMaster);
        Task Update(CurrencyMaster currencyMaster);
        Task<bool> Delete(int id);
    }
}
