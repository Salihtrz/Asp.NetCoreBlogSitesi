using BusinessLayer.Services;
using DataAccessLayer.EntittyFramework;
using EFLayer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managment
{
    public class HakkimdaManagment : IHakkimdasServices<Hakkimda>
    {
        EfHakkimdaRepo hakkimdaRepo;

        public HakkimdaManagment(EfHakkimdaRepo hakkimdaRepo)
        {
            this.hakkimdaRepo = hakkimdaRepo;
        }

        public void add(Hakkimda hakkimda)
        {
            hakkimdaRepo.add(hakkimda);
        }

        public List<Hakkimda> getAllList()
        {
            return hakkimdaRepo.getAllList();   
        }

		public Hakkimda getCategoryById(int id)
		{
			return hakkimdaRepo.getCategoryById(id);
		}

		public void remove(int id)
        {
           hakkimdaRepo.remove(id);
        }

        public void update(Hakkimda hakkimda)
        {
          hakkimdaRepo.update(hakkimda);
        }

		
	}
}
