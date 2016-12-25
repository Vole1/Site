using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyRoughSite1.Models
{
    public class MasseurDbInitializer : DropCreateDatabaseAlways<MasseurContext>
    {
        protected override void Seed(MasseurContext context)
        {
            Masseur mass1 = new Masseur() { Id = 56, Name = "Дмитрий", Gender = 'М', Description = "Крутой чел)" };
            Masseur mass2 = new Masseur() { Id = 57, Name = "Анатолий", Gender = 'М', Description = "Очень крутой чел)" };
            Masseur mass3 = new Masseur() { Id = 58, Name = "Елена", Gender = 'Ж', Description = "Самый крутой чел)" };

            context.Masseurs.Add(mass1);
            context.Masseurs.Add(mass2);
            context.Masseurs.Add(mass3);
            context.SaveChanges();

        }
    }
}