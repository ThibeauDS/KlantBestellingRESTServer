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
    public class BestellingBeheerder
    {
        #region Properties
        private readonly IBestellingRepository _repo;
        #endregion

        #region Constructors
        public BestellingBeheerder(IBestellingRepository repo)
        {
            _repo = repo;
        }
        #endregion

        #region Methods
        public IEnumerable<Bestelling> GeefBestellingenKlant(int id)
        {
            try
            {
                return _repo.GeefBestellingenKlant(id);
            }
            catch (Exception ex)
            {
                throw new BestellingBeheerderException("GeefBestellingenKlant - error", ex);
            }
        }

        public Bestelling BestellingWeergeven(int id)
        {
            try
            {
                return _repo.BestellingWeergeven(id);
            }
            catch (Exception ex)
            {
                throw new BestellingBeheerderException("BestellingWeergeven - error", ex);
            }
        }

        public void BestellingVerwijderen(int bestellingId)
        {
            try
            {
                if (!_repo.BestaatBestelling(bestellingId))
                {
                    throw new BestellingBeheerderException("Bestelling bestaat niet.");
                }
                _repo.BestellingVerwijderen(bestellingId);
            }
            catch (Exception ex)
            {
                throw new BestellingBeheerderException("BestellingVerwijderen - error", ex);
            }
        }

        public Bestelling BestellingToevoegen(Bestelling bestelling)
        {
            try
            {
                if (bestelling == null)
                {
                    throw new BestellingBeheerderException("Bestelling is NULL.");
                }
                if (_repo.BestaatBestelling(bestelling.Id))
                {
                    throw new BestellingBeheerderException("Bestelling bestaat al.");
                }
                return _repo.BestellingToevoegen(bestelling);
            }
            catch (Exception ex)
            {
                throw new BestellingBeheerderException("BestellingToevoegen - error", ex);
            }
        }
        #endregion
    }
}
