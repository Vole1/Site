using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyRoughSite1.Models
{
    public class VacantRegister
    {
        [HiddenInput(DisplayValue = false)]
        public int VacantRegisterId { get; set; }
        [Display(Name = "Дата и время")]
        public string DateTime { get; set; }
        public int? OrderId { get; set; }
        public int MasseurId { get; set; }
        [Display(Name = "Продолжительность сеанса")]
        public string Duration { get; set; }

        
        public virtual Order Order {get; set; }
        public virtual Masseur Masseur { get; set; }
    }
}