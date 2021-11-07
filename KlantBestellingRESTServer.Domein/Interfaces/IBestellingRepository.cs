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
        Bestelling BestellingWeergeven(int id);
        bool BestaatBestelling(int bestellingId);
        void BestellingVerwijderen(int bestellingId);
        Bestelling BestellingToevoegen(Bestelling bestelling);
    }
}
