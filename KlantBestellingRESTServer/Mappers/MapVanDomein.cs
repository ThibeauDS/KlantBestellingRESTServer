using KlantBestellingRESTServer.Domein.Beheerders;
using KlantBestellingRESTServer.Domein.Klassen;
using KlantBestellingRESTServer.Exceptions;
using KlantBestellingRESTServer.Klassen.Output;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KlantBestellingRESTServer.Mappers
{
    public class MapVanDomein
    {
        #region Methods
        public static KlantRESTOutputDTO MapVanKlantDomein(string url, Klant klant, BestellingBeheerder bestellingBeheerder)
        {
            try
            {
                string klantIdUrl = $"{url}/Klant/{klant.Id}";
                List<string> bestellingen = bestellingBeheerder.GeefBestellingenKlant(klant.Id).Select(x => klantIdUrl + $"/Bestelling/{x.Id}").ToList();
                KlantRESTOutputDTO klantRESTOutputDTO = new(klantIdUrl, klant.Naam, klant.Adres, bestellingen);
                return klantRESTOutputDTO;
            }
            catch (Exception ex)
            {
                throw new MapVanDomeinException("MapVanKlantDomein - error", ex);
            }
        }
        #endregion
    }
}
