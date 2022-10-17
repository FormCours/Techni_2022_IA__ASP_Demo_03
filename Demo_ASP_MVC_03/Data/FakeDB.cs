using Demo_ASP_MVC_03.Data.Entities;
using System.Collections.Immutable;

namespace Demo_ASP_MVC_03.Data
{
    public static class FakeDB
    {
        private static List<PersonRole> _PersonRoles = new List<PersonRole>()
        {
            new PersonRole() { Id = 1, Name = "Etudiant" },
            new PersonRole() { Id = 2, Name = "Formateur" },
            new PersonRole() { Id = 3, Name = "Membre de Technifutur" },
            new PersonRole() { Id = 4, Name = "VIP" }
        };

        private static List<Inscription> _Inscriptions = new List<Inscription>()
        {
            new Inscription()
            {
                Id = 1,
                Email = "della.duck@techni.com",
                Firstname = "Della",
                Lastname = "Duck",
                NbGuest = 0,
                PersonRole = _PersonRoles.First(pr => pr.Id == 3),
                PhoneNumber = null,
                SpamOk = false
            }
        };
        private static int _LastInscriptionId = 1;


        #region PersonRole
        public static IEnumerable<PersonRole> GetPersonRole()
        {
            return _PersonRoles.ToImmutableList();
        }

        public static PersonRole? GetPersonRoleById(int id)
        {
            return _PersonRoles.FirstOrDefault(pr => pr.Id == id);
        }
        #endregion

        #region Inscription
        public static IEnumerable<Inscription> GetInscription()
        {
            return _Inscriptions.ToImmutableList();
        }

        public static Inscription? GetInscriptionById(int id)
        {
            return _Inscriptions.SingleOrDefault(inscription => inscription.Id == id);
        }

        public static int AddInscription(Inscription inscription)
        {
            if (inscription is null)
                throw new ArgumentNullException(nameof(inscription));

            if (inscription.PersonRole is null ||
                _PersonRoles.FirstOrDefault(pr => pr.Id == inscription.PersonRole.Id) is null) 
                throw new ArgumentOutOfRangeException(nameof(inscription.PersonRole));

            _LastInscriptionId++;

            _Inscriptions.Add(new Inscription()
            {
                Id = _LastInscriptionId,
                Email = inscription.Email,
                PhoneNumber = inscription.PhoneNumber,
                SpamOk = inscription.SpamOk,
                Firstname = inscription.Firstname,
                Lastname = inscription.Lastname,
                NbGuest = inscription.NbGuest,
                PersonRole = _PersonRoles.Single(pr => pr.Id == inscription.PersonRole.Id) 
            });

            return _LastInscriptionId;
        }
        #endregion
    }
}
