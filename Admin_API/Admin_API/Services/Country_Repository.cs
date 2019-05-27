using Admin_API.Models;
using Admin_API.ServiceContract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_API.Services
{
    public class Country_Repository : ICountry_Repository
    {
        private readonly AdminAng5DBContext _context;
        public Country_Repository(AdminAng5DBContext context)
        {
            _context = context;
        }
        public Country_Repository()
        {
            _context = new AdminAng5DBContext();
        }

        public async Task<List<CountryMaster>> GetAll()
        {
            try
            {
                return await _context.CountryMaster.Where(x => x.IsActive).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Insert(CountryMaster countryMaster)
        {
            try
            {
                await _context.CountryMaster.AddAsync(countryMaster);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CountryMaster> GetById(int Id)
        {
            try
            {
                return await _context.CountryMaster.SingleOrDefaultAsync(x => x.CountryId == Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(CountryMaster countryMaster)
        {
            try
            {
                _context.Entry(countryMaster).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var record = await _context.CountryMaster.SingleOrDefaultAsync(m => m.CountryId == id);
                if (record == null)
                    return false;
                _context.Remove(record);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
