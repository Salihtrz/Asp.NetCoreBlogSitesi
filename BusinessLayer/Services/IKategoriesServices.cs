using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFLayer.Class;

namespace BusinessLayer.Services
{
    public interface IKategoriesServices<Kategories>
    {
        void add(Kategories Kategorİ);
        void remove(Kategories Kategorİ);
        void update(Kategories Kategorİ);
        List<Kategories> getAllList();
        Kategories getCategoryById(int id);
    }
}
