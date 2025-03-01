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
    public class GonderiManagement : IGonderisServices<Gonderiler>
    {
        EfGonderiRepo GonderiRepo;
        public GonderiManagement(EfGonderiRepo GonderiRepo)
        {
            this.GonderiRepo = GonderiRepo;
        }
        public void add(Gonderiler gonderiler)
        {
            GonderiRepo.add(gonderiler);
        }

        public List<Gonderiler> getAllList()
        {
            return GonderiRepo.getAllList();
        }

        public List<Gonderiler> getAllListWithKategori()
        {
            return GonderiRepo.getAllListWithKategori();
        }
        public Gonderiler getCategoryById(int id)
		{
			return GonderiRepo.getCategoryById(id);

		}
		public void remove(Gonderiler gonderiler)
        {
            GonderiRepo.remove(gonderiler);
        }
        public DateTime GetMevcutTarih()
        {
            return DateTime.Now;
        }
        public List<Gonderiler> SgetGonderiByKategoriId(int id)
        {
            var liste = GonderiRepo.getGonderiByKategoriId((int)id);
            return GonderiRepo.getGonderiByKategoriId((int)id);
        }
        public void update(Gonderiler gonderiler)
        {
            GonderiRepo.update(gonderiler);
        }
    }
}
