using KlantBestellingRESTServer.Domein.Exceptions;
using KlantBestellingRESTServer.Domein.Interfaces;
using KlantBestellingRESTServer.Domein.Klassen;
using System;

namespace KlantBestellingRESTServer.Domein.Beheerders
{
    public class KlantBeheerder
    {
        #region Properties
        private readonly IKlantRepository _repo;
        #endregion

        #region Constructors
        public KlantBeheerder(IKlantRepository repo)
        {
            _repo = repo;
        }
        #endregion

        #region Methods
        public Klant KlantToevoegen(Klant klant)
        {
            try
            {
                if (klant == null)
                {
                    throw new KlantBeheerderException("Klant is null.");
                }
                if (_repo.BestaatKlant(klant.Id))
                {
                    throw new KlantBeheerderException("Klant bestaat al.");
                }
                return _repo.KlantToevoegen(klant);
            }
            catch (Exception ex)
            {
                throw new KlantBeheerderException("KlantToevoegen - error", ex);
            }

        }

        public void KlantVerwijderen(int id)
        {
            if (!_repo.BestaatKlant(id))
            {
                throw new KlantBeheerderException("Klant bestaat niet.");
            }
            _repo.KlantVerwijderen(id);
        }

        public Klant KlantUpdaten(Klant klant)
        {
            if (klant == null)
            {
                throw new KlantBeheerderException("Klant is null.");
            }
            if (!_repo.BestaatKlant(klant.Id))
            {
                throw new KlantBeheerderException("Klant bestaat niet.");
            }
            Klant klantDb = KlantWeergeven(klant.Id);
            if (klantDb == klant)
            {
                throw new KlantBeheerderException("Er zijn geen verschillen met het origineel.");
            }
            _repo.KlantUpdaten(klant);
            return klant;
        }

        public Klant KlantWeergeven(int id)
        {
            if (!_repo.BestaatKlant(id))
            {
                throw new KlantBeheerderException("Klant bestaat niet.");
            }
            return _repo.KlantWeergeven(id);
        }

        public bool BestaatKlant(int id)
        {
            try
            {
                return _repo.BestaatKlant(id);
            }
            catch (Exception ex)
            {
                throw new KlantBeheerderException("Klant bestaat niet.", ex);
            }
        }
        #endregion
    }
}
