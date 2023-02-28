using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Ville
    {
        public int Ville_Id { get; set; }
        public string Ville_Code { get; set; }
        public string Ville_Designation { get; set; }
        public int User_Modif { get; set; }
        public DateTime Date_Modif { get; set; }
    }
}
