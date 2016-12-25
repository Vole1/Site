using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyRoughSite1.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Display(Name = "Клиент")]
        public string Name { get; set; }
        [Display(Name = "Телефон")]
        public string Telephohe { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; }
    }
}