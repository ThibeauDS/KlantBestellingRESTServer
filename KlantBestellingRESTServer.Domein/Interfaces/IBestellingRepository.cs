using KlantBestellingRESTServer.Domein.Klassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlantBestellingRESTServer.Domein.Interfaces
{
    public interface IBestellingRepository
    {
        IEnumerable<Bestelling> GeefBestellingenKlant(int id);
    }
}
