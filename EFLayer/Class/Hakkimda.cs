using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLayer.Class
{
    public class Hakkimda
    {
        public int hakkimdaId { get; set; }
		[DisplayName("Başlık")]

		public string baslik { get; set; }
		[DisplayName("İçerik")]

		public string icerik { get; set; }
		[DisplayName("Resim Linki")]

		public string resimLinki { get; set; }

    }
}
