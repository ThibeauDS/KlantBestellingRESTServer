using KlantBestellingRESTServer.Domein.Klassen;

namespace KlantBestellingRESTServer.Domein.Interfaces
{
    public interface IKlantRepository
    {
        bool BestaatKlant(int id);
        Klant KlantToevoegen(Klant klant);
        void KlantVerwijderen(int id);
        void KlantUpdaten(Klant klant);
        Klant KlantWeergeven(int id);
    }
}
