using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Offres
    {
        public int IdOffre { get; set; }
        public string OffreDesignation { get; set; }
        public string LieuOffre { get; set; }
        public int PostesVancants { get; set; }
        public int TypeEmploi { get; set; }
        public string TypeEmploi_Designation { get; set; }
        public string NbAnsExp { get; set; }
        public int NiveauEtude { get; set; }
        public string NiveauEtude_Designation { get; set; }
        public string DescriptionEmploi { get; set; }
        public string ExigenceEmploi { get; set; }
        public DateTime DateExpiration { get; set; }
        public DateTime DateModif { get; set; }
    }

    
}
