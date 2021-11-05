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
        #endregion
    }
}
