using Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UnitOfWork
    {
        private static RecrutementRepository recrutementRepository;
        public static RecrutementRepository RecrutementRepository
        {
            get
            {
                if (recrutementRepository == null)
                {
                    recrutementRepository = new RecrutementRepository();
                }
                return recrutementRepository;
            }
        }

        private static OffreRepository offreRepository;
        public static OffreRepository OffreRepository
        {
            get
            {
                if (offreRepository == null)
                {
                    offreRepository = new OffreRepository();
                }
                return offreRepository;
            }
        }
        private static CollaborateurRepository collaborateurRepository;
        public static CollaborateurRepository CollaborateurRepository
        {
            get
            {
                if (collaborateurRepository == null)
                {
                    collaborateurRepository = new CollaborateurRepository();
                }
                return collaborateurRepository;
            }
        }

        private static CandidatRepository candidatRepository;
        public static CandidatRepository CandidatRepository
        {
            get
            {
                if (candidatRepository == null)
                {
                    candidatRepository = new CandidatRepository();
                }
                return candidatRepository;
            }
        }
    }
}
