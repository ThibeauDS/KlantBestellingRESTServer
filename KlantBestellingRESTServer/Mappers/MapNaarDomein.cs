using KlantBestellingRESTServer.Domein.Klassen;
using KlantBestellingRESTServer.Exceptions;
using KlantBestellingRESTServer.Klassen.Input;
using System;

namespace KlantBestellingRESTServer.Mappers
{
    public class MapNaarDomein
    {
        #region Methods
        public static Klant MapNaarKlantDomein(KlantRESTInputDTO klantRESTInputDTO)
        {
            try
            {
                Klant klant = new(klantRESTInputDTO.Naam, klantRESTInputDTO.Adres);
                return klant;
            }
            catch (Exception ex)
            {
                throw new MapNaarDomeinException("MapNaarKlantDomein - error", ex);
            }
        }

        public static Bestelling MapNaarBestellingDomein(BestellingRESTInputDTO bestellingRESTInputDTO, Klant klant)
        {
            try
            {
                Bestelling bestelling = new(bestellingRESTInputDTO.Product, bestellingRESTInputDTO.Aantal, klant);
                return bestelling;
            }
            catch (Exception ex)
            {
                throw new MapNaarDomeinException("MapNaarBestellingDomein - error", ex);
            }
        }
        #endregion
    }
}
