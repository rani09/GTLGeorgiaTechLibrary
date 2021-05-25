using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTLCore
{
    public interface IMaterialRepository
    {
        List<Material> GetAll();
        int Insert(Material material);
        bool Update(Material material);
        bool Delete(int MaterialId);
        Material GetById(int id);
    }
}
