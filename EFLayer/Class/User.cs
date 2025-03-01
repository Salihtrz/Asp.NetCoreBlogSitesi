using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLayer.Class
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [DisplayName("Adı")]
        public string? Name { get; set; }
        [DisplayName("Soyadı")]
        public String? SurName { get; set; }
        [DisplayName("Kullanıcı Adı")]
        public string? UserAdi { get; set; }
        [DisplayName("Parola")]
        public string? Password { get; set; }
        [DisplayName("Yetki")]
        public int RoleId { get; set; }
    }
}