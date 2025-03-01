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
    public class IletisimManagment : IIletisimsServices<Iletisim>
    {
        EfIletisimRepo iletisimRepo;

        public IletisimManagment(EfIletisimRepo iletisimRepo)
        {
        this.iletisimRepo = iletisimRepo;
         }

        public void add(Iletisim iletisim)
        {
            iletisimRepo.add(iletisim);
        }

        public List<Iletisim> getAllList()
        {
            return iletisimRepo.getAllList();
        }

		public Iletisim getCategoryById(int id)
		{
			return iletisimRepo.getCategoryById(id);
		}

		public void remove(int id)
        {
           iletisimRepo.remove(id);
        }

        public void update(Iletisim iletisim)
        {
            iletisimRepo.update(iletisim);
        }
    }

    
}   
