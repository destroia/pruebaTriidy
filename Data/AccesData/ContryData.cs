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
    public class ContryData : ICitiesData
    {
        readonly contextDBTriidy DB;
        public ContryData(contextDBTriidy db)
        {
            DB = db;
        }
        public async  Task<bool> Create(Contry contry)
        {
            try
            {
                await DB.Contries.AddAsync(contry);
                await DB.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async  Task<bool> Delete(int id)
        {
            try
            {
                Contry contry = await DB.Contries.FindAsync(id);
                if (contry != null)
                {
                    List<City> ListCity = await DB.Cities.Where(x => x.ContryId == id).ToListAsync();
                    if (ListCity.Count != 0)
                    {
                        DB.Cities.RemoveRange(ListCity);
                        await DB.SaveChangesAsync();
                    }
                    DB.Contries.Remove(contry);
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

        public async Task<List<Contry>> Get()
        {
            return await DB.Contries.ToListAsync();
        }

        public async Task<bool> Update(Contry contry)
        {
            try
            {
                DB.Contries.Update(contry);
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
