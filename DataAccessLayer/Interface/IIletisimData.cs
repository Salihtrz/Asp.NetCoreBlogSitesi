using EFLayer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IIletisimData<Iletisim>
    {
        void add( Iletisim iletisim);
        void remove(int  id);   
        void update (Iletisim iletisim); 
        List <Iletisim> getAllList();
		Iletisim getCategoryById(int id);


	}
}
