using EFLayer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IIletisimsServices<Iletisim>
    {
        void add(Iletisim iletisim);
        void remove(int id);
        void update(Iletisim iletisim);
        List<Iletisim> getAllList();
		Iletisim getCategoryById(int id);

	}
}
