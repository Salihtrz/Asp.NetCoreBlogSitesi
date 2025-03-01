using DataAccess.Context;
using DataAccessLayer.Interface;
using EFLayer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repostory
{
    public class DataHakkimdaRepostory : IHakkimdaData<Hakkimda>
    {
        IKBlokContex IKBlokContex = new IKBlokContex();
        public void add(Hakkimda hakkimda)
        {
           IKBlokContex.Add(hakkimda);
            IKBlokContex.SaveChanges();
        }

        public List<Hakkimda> getAllList()
        {
            return IKBlokContex.Set<Hakkimda>()
                .ToList();
        }

		public Hakkimda getCategoryById(int id)
		{
            return IKBlokContex.Hakkimdas.Find(id);
		}

		public void remove(int id)
        {
           IKBlokContex.Remove(id);
            IKBlokContex.SaveChanges();
        }

        public void update(Hakkimda hakkimda)
        {
           IKBlokContex.Update(hakkimda);
           IKBlokContex.SaveChanges();
        }
    }
}
