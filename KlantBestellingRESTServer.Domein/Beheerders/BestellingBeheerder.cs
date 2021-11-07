using KlantBestellingRESTServer.Domein.Exceptions;
using KlantBestellingRESTServer.Domein.Interfaces;
using KlantBestellingRESTServer.Domein.Klassen;
using System;
using System.Collections.Generic;

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

        public bool HeeftBestellingenKlant(int id)
        {
            try
            {
                return _repo.HeeftBestellingenKlant(id);
            }
            catch (Exception ex)
            {
                throw new BestellingBeheerderException("HeeftBestellingenKlant - error", ex);
            }
        }

        public bool BestaatBestelling(int id)
        {
            try
            {
                return _repo.BestaatBestelling(id);
            }
            catch (Exception ex)
            {
                throw new BestellingBeheerderException("Bestelling bestaat niet.", ex);
            }
        }

        public Bestelling BestellingUpdaten(Bestelling bestelling)
        {
            if (bestelling == null)
            {
                throw new BestellingBeheerderException("Bestelling is null.");
            }
            if (!_repo.BestaatBestelling(bestelling.Id))
            {
                throw new BestellingBeheerderException("Bestelling bestaat niet.");
            }
            Bestelling bestellingDb = BestellingWeergeven(bestelling.Id);
            if (bestellingDb == bestelling)
            {
                throw new BestellingBeheerderException("Er zijn geen verschillen met het origineel.");
            }
            _repo.BestellingUpdaten(bestelling);
            return bestelling;
        }
        #endregion
    }
}
