using KlantBestellingRESTServer.Domein.Exceptions;
using KlantBestellingRESTServer.Domein.Interfaces;
using KlantBestellingRESTServer.Domein.Klassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                _repo.KlantToevoegen(klant);
                return klant;
            }
            catch (Exception ex)
            {
                throw new KlantBeheerderException("KlantToevoegen - error", ex);
            }

        }

        public void KlantVerwijderen(Klant klant)
        {
            if (!_repo.BestaatKlant(klant.Id))
            {
                throw new KlantBeheerderException("Klant bestaat niet.");
            }
            _repo.KlantVerwijderen(klant);
        }

        public void KlantUpdaten(Klant klant)
        {
            if (!_repo.BestaatKlant(klant.Id))
            {
                throw new KlantBeheerderException("Klant bestaat niet.");
            }
            _repo.KlantUpdaten(klant);
        }

        public Klant KlantWeergeven(int id)
        {
            try
            {
                return _repo.KlantWeergeven(id);
            }
            catch (Exception ex)
            {
                throw new KlantBeheerderException("Klant bestaat niet.", ex);
            }
        }
        #endregion
    }
}
