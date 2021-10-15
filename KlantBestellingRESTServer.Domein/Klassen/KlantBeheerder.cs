using KlantBestellingRESTServer.Domein.Exceptions;
using KlantBestellingRESTServer.Domein.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlantBestellingRESTServer.Domein.Klassen
{
    public class KlantBeheerder
    {
        #region Properties
        private IKlantRepository _repo;
        #endregion

        #region Constructors
        public KlantBeheerder(IKlantRepository klantRepository)
        {
            _repo = klantRepository;
        }
        #endregion

        #region Methods
        public void KlantToevoegen(Klant klant)
        {
            try
            {
                if (_repo.BestaatKlant(klant))
                {
                    throw new KlantBeheerderException("Klant bestaat al.");
                }
                _repo.KlantToevoegen(klant);
            }
            catch (Exception ex)
            {
                throw new KlantBeheerderException(ex.Message);
            }
        }

        public void KlantVerwijderen(Klant klant)
        {
            try
            {
                if (_repo.BestaatKlant(klant))
                {
                    _repo.KlantVerwijderen(klant);
                }
                else
                {
                    throw new KlantBeheerderException("Klant bestaat niet.");
                }
            }
            catch (Exception ex)
            {
                throw new KlantBeheerderException(ex.Message);
            }
        }

        public void KlantUpdaten(Klant klant)
        {
            try
            {
                if (_repo.BestaatKlant(klant))
                {
                    _repo.KlantUpdaten(klant);
                }
                else
                {
                    throw new KlantBeheerderException("Klant kan niet worden bijgewerkt.");
                }
            }
            catch (Exception ex)
            {
                throw new KlantBeheerderException(ex.Message);
            }
        }

        public void KlantWeergeven(Klant klant)
        {
            try
            {
                if (_repo.BestaatKlant(klant))
                {
                    _repo.KlantWeergeven(klant);
                }
                else
                {
                    throw new KlantBeheerderException("Klant kan niet worden weergegeven.");
                }
            }
            catch (Exception ex)
            {
                throw new KlantBeheerderException(ex.Message);
            }
        }
        #endregion
    }
}
