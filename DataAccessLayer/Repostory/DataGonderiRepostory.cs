using DataAccess.Context;
using DataAccessLayer.Interface;
using EFLayer.Class;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repostory
{
    public class DataGonderiRepostory : IGonderiData<Gonderiler>
    {
        IKBlokContex IKBlokContex = new IKBlokContex();
        public void add(Gonderiler gonderiler)
        {
            IKBlokContex.Add(gonderiler);
            IKBlokContex.SaveChanges();
        }
        public List<Gonderiler> getAllList()
        {
            return IKBlokContex.Set<Gonderiler>()
               .ToList();
        }

        public List<Gonderiler> getAllListWithKategori()
        {
            return IKBlokContex.Set<Gonderiler>()
               .Include(i => i.Kategories)
               .ToList();
        }

        public Gonderiler getCategoryById(int id)
        {
            return IKBlokContex.Gonderis.Find(id);
        }

        public List<Gonderiler> getGonderiByKategoriId(int id)
        {
            var test1 = IKBlokContex.Gonderis.Where(x => x.kategoriId == id).ToList();
            return test1.ToList();
        }

        public void remove(Gonderiler gonderiler)
        {
            IKBlokContex.Remove(gonderiler);
            IKBlokContex.SaveChanges();
        }

        public void update(Gonderiler gonderiler)
        {
            IKBlokContex.Update(gonderiler);
            IKBlokContex.SaveChanges();
        }
    }
}
