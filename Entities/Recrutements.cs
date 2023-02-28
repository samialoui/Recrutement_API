using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public  class Recrutements
    {
        public int RecrutementId { get; set; }
        public string Poste_Recru { get; set; }
        public int CondidatId { get; set; }
        public int CollaborateurId { get; set; }
        public DateTime DateMofid { get; set; }
    }
}
