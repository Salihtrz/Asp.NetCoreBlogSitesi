using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLayer.Class
{
    public class Gonderiler
    {
        [Key]
        public int GonderiId { get; set; }
        [DisplayName("Gönderi Adı")]
        public string? GonderiName { get; set; }
        [DisplayName("Başlık")]
        public string? GonderiBaslik { get; set; }
        [DisplayName("İçerik")]
        public string? GonderiIcerik { get; set; }
        [DisplayName("Resimler")]
        public string? GonderiResim { get; set; }
        [DisplayName("Kategori Id")]
        public int? kategoriId { get; set; }
		[DisplayName("Gönderi Tarihi")]
		public DateTime? gonderiTarihi { get; set; }
        public Kategories? Kategories { get; set; }
    }
}