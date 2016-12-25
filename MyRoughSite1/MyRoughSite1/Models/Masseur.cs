using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyRoughSite1.Models
{
    public class Masseur
    {
        public int Id { get; set; }
        [Display(Name = "Массажист")]
        public string Name { get; set; }
        [Display(Name = "Пол")]
        public char Gender { get; set; }
        [Display(Name = "О себе")]
        public string Description { get; set; }
        

        public virtual ICollection<VacantRegister> VacantRegisters { get; set; }
        [NotMapped]
        public IEnumerable<Order> Orders
        {
            get
            {
                return VacantRegisters.Select(x => x.Order);
            }
        }
    }
}