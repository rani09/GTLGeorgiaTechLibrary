using System.Collections.Generic;

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
