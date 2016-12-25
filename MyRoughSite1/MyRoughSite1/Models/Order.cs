using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyRoughSite1.Models
{
    public class Order
    {
        [Key]
        [ForeignKey("VacantRegister")]
        public int VacantRegisterId { get; set; }
        [Display(Name = "Подтверждён")]
        public bool ConfermationFlag { get; set; }
        public int CustomerId { get; set; }

        public VacantRegister VacantRegister { get; set; }
    }
}