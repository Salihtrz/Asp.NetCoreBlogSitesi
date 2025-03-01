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
    public class DataUserRepostory : IUserData<User>
    {
        IKBlokContex IKBlokContex = new IKBlokContex();
        public void add(User user)
        {
            IKBlokContex.Add(user);
            IKBlokContex.SaveChanges();
        }

        public List<User> getAllList()
        {
            return IKBlokContex.Set<User>()
                 .ToList();
        }

		public User getCategoryById(int id)
		{
			return IKBlokContex.User.Find(id);
		}

		public void remove(User user)
        {
            IKBlokContex.Remove(user);
            IKBlokContex.SaveChanges();
        }

        public void update(User user)
        {
            IKBlokContex.Update(user);
            IKBlokContex.SaveChanges();
        }
    }
}
