using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface ICitiesData
    {
        Task<bool> Create(Contry contry);
        Task<bool> Update(Contry contry);
        Task<List<Contry>> Get();
        Task<bool> Delete(int id);
    }
}
