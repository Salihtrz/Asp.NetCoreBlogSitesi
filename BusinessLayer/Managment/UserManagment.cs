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
    public class UserManagment : IUsersServices<User>
    {
        EfUserRepo UserRepo;

        public UserManagment(EfUserRepo UserRepo)
        {
            this.UserRepo = UserRepo;
        }
        public void add(User user)
        {
            UserRepo.add(user); 
        }

       
        public List<User> getAllList()
        {
            return UserRepo.getAllList();
        }

		public User getCategoryById(int id)
		{
			return UserRepo.getCategoryById(id);

		}

		public void remove(User user)
        {
            UserRepo.remove(user);
        }

        public void update(User user)
        {
            UserRepo.update(user);
        }
    }
}
