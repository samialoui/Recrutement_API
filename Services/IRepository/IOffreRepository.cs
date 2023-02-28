using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepository
{
    public interface IOffreRepository
    {
        public List<Offres> GetAllOffres();
        public void PublierOffre(Offres offre);
        public void ModifierOffre(Offres offre);
        public List<NiveauScolaire> GetAllNiveauScolaire();
        public List<TypeEmploi> GetAllTypeEmploi();
        public List<Pays> GetAllPays();
        public List<Ville> GetAllVille();
    }
}
