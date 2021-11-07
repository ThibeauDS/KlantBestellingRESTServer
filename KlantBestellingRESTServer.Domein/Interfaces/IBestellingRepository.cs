using KlantBestellingRESTServer.Domein.Klassen;
using System.Collections.Generic;

namespace KlantBestellingRESTServer.Domein.Interfaces
{
    public interface IBestellingRepository
    {
        IEnumerable<Bestelling> GeefBestellingenKlant(int id);
        Bestelling BestellingWeergeven(int id);
        bool BestaatBestelling(int bestellingId);
        void BestellingVerwijderen(int bestellingId);
        Bestelling BestellingToevoegen(Bestelling bestelling);
        void BestellingUpdaten(Bestelling bestelling);
        bool HeeftBestellingenKlant(int id);
    }
}
