using EFLayer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IHakkimdasServices<Hakkimda>
    {
        void add(Hakkimda hakkimda);
        void remove(int id);
        void update(Hakkimda hakkimda);
        List<Hakkimda> getAllList();
		Hakkimda getCategoryById(int id);

	}
}
