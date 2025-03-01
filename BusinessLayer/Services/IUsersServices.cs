using EFLayer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IUsersServices<User>
    {
        void add(User user);
        void remove(User user);
        void update(User user);
        List<User> getAllList();
		User getCategoryById(int id);


	}
}
