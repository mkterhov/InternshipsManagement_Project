using InternshipsManagmentProject.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InternshipsManagmentProject.Utilities
{
    public class DataBaseInitializer : DropCreateDatabaseAlways<Entities>
    {
        protected override void Seed(Entities context)
        {
            IList<Firm> firms = new List<Firm>();

            IList<string> names = new List<string>() {
"Adolfo Schmieder  ","Bridgette Peed  ","Jenelle Giambrone  ","Judith Jin  ","Dexter Wren  ","Thomasena Mauk  ","Laurinda Worsley  ","Justina Rousseau  ","Elana Lightsey  ","Deana Lafon  ","Lenore Mcnabb  ","Kenda Enders  ","Shemeka Wernick  ","Sulema Ruyle  ","Nathanael Mcelwee  ","Brett Hofer  ","Jettie Horrocks  ","Sydney Ristau  ","Natalya Kogut  ","Jose Harryman  ","Marcelo Gobel  ","Rosemary Kneeland  ","Melonie Grenier  ","Linette Hibbitts  ","Hae Benfer  ","Lorie Lema  ","Hattie Haring  ","Clement Asaro  ","Edmond Asuncion  ","Keith Folkers  ","Dottie Gorden  ","Kristy Ezzell  ","Pamila Messer  ","Elliott Ratti  ","Magen Senter  ","Carlo Rothstein  ","Ladawn Armor  ","Ailene Verner  ","Willis Obey  ","Cyndy Wei  ","Lynne Corning  ","Lashaunda Larsen  ","Golden Cuff  ","Dinorah Le  ","Kellye Pink  ","Marci Gasper  ","Tyron Theriault  ","Min Derrico  ","Felica Legaspi  ","Miranda Hotaling"};

            IList<string> firmNames = new List<string>() {
                "Paula  ", "Vivien  ", "Boyce  ", "Dinah  ", "Kasi  ", "Leo  ", "Charla  ", "Jadwiga  ", "Latrina  ",
                "Fernande  ", "Catalina  ", "Rogelio  ", "Nathanael  ", "Treasa  ", "Elouise  ", "Anika  ", "Stefan  ", "Racquel  ", "Marla  ", "Dania"
            };

            Random random = new Random(120);

            for(int i = 0; i < firmNames.Count; i++)
            {
                string guid = Guid.NewGuid().ToString();
                Firm firm = new Firm();
                firm.FirmId = guid;
                firm.Name = firmNames.ElementAt(i);
                firm.Description = "Pretty Good Company";
                firm.NumberOfEmployees = random.Next();
                
            }

            context.Firms.AddRange(firms);

            base.Seed(context);
        }
    }
}