using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface ICityData
    {
        Task<bool> Create(City contry);
        Task<bool> Update(City contry);
        Task<List<City>> GetByIdContry(int idContry);
        Task<bool> Delete(int id);
    }
}
