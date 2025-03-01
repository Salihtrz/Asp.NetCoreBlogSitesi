using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLayer.Class
{
    public class Kategories
    {
        [Key]
        public int kategoriId { get; set; }
        [DisplayName("Kategori Adı")]

        public string? kategoryName { get; set; }

        public IEnumerable<Gonderiler>? Gonderiler { get; set; }
    }
}
