using EFLayer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
   public interface IGonderisServices<Gonderiler>
    {
        void add(Gonderiler gonderiler);
        void remove(Gonderiler gonderiler);
        void update(Gonderiler gonderiler);
        List<Gonderiler> getAllList();
        List<Gonderiler> getAllListWithKategori();
        Gonderiler getCategoryById(int id);
        List<Gonderiler> SgetGonderiByKategoriId(int id);

    }
}
