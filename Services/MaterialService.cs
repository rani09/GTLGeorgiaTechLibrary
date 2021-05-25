using Autofac;
using DataAccess;
using GTLCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MaterialService
    {
        static IContainer _container;
        static MaterialService()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<MaterialRepository>().As<IMaterialRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int materialId)
        {
            return _container.Resolve<IMaterialRepository>().Delete(materialId);
        }
        public static List<Material> GetAll()
        {
            return _container.Resolve<IMaterialRepository>().GetAll();
        }
        public static Material Save(Material material, EntityState state)
        {
            if (state == EntityState.Added)
                material.id = _container.Resolve<IMaterialRepository>().Insert(material);
            else
                _container.Resolve<IMaterialRepository>().Update(material);
            return material;
        }
        public static Material GitById(int materialId)
        {
            return _container.Resolve<IMaterialRepository>().GetById(materialId);
        }
    }
}
