using KlantBestellingRESTServer.Domein.Klassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlantBestellingRESTServer.Domein.Interfaces
{
    public interface IKlantRepository
    {
        bool BestaatKlant(Klant klant);
        void KlantToevoegen(Klant klant);
        void KlantVerwijderen(Klant klant);
        void KlantUpdaten(Klant klant);
        void KlantWeergeven(Klant klant);
    }
}
