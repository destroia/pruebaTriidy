using Data.Interface;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.AccesData
{
    public class CityData : ICityData
    {
        readonly contextDBTriidy DB;
        public CityData(contextDBTriidy db)
        {
            DB = db;
        }
        public async Task<bool> Create(City contry)
        {
            try
            {
                await DB.Cities.AddAsync(contry);
                await DB.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                City city = await DB.Cities.FindAsync(id);
                if (city != null)
                {
                    DB.Cities.Remove(city);
                    await DB.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async  Task<List<City>> GetByIdContry(int idContry)
        {
            return await DB.Cities.Where(x => x.ContryId == idContry).ToListAsync();
        }

        public async Task<bool> Update(City contry)
        {
            try
            {
                DB.Cities.Update(contry);
                await DB.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
