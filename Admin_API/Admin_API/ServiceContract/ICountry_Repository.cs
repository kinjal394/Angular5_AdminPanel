using Admin_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_API.ServiceContract
{
    interface ICountry_Repository
    {
        Task<List<CountryMaster>> GetAll();
        Task<CountryMaster> GetById(int Id);
        Task Insert(CountryMaster countryMaster);
        Task Update(CountryMaster countryMaster);
        Task<bool> Delete(int id);
    }
}
