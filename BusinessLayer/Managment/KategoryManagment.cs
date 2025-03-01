using BusinessLayer.Services;
using DataAccess.Context;
using DataAccessLayer.EntittyFramework;
using EFLayer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managment
{
    public class KategoryManagment : IKategoriesServices<Kategories>
    {
        EfKategoryRepo kategoryRepo;

        public KategoryManagment(EfKategoryRepo kategoryRepo)
        {
            this.kategoryRepo = kategoryRepo;
        }

        public void add(Kategories Kategorİ)
        {
            kategoryRepo.add(Kategorİ);
        }

        public List<Kategories> getAllList()
        {
            return kategoryRepo.getAllList();
        }

        public Kategories getCategoryById(int id)
		{
			return kategoryRepo.getCategoryById(id);
		}

		public void remove(Kategories Kategorİ)
        {
           kategoryRepo.remove(Kategorİ);
        }

        public void update(Kategories Kategorİ)
        {
            kategoryRepo.update(Kategorİ);
        }
    }
}
