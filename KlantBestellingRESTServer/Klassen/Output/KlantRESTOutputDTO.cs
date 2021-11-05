using System.Collections.Generic;

namespace KlantBestellingRESTServer.Klassen.Output
{
    public class KlantRESTOutputDTO
    {
        #region Properties
        public string Id { get; set; }
        public string Naam { get; set; }
        public string Adres { get; set; }
        public List<string> Bestellingen { get; set; }
        #endregion

        #region Constructors
        public KlantRESTOutputDTO(string id, string naam, string adres, List<string> bestellingen)
        {
            Id = id;
            Naam = naam;
            Adres = adres;
            Bestellingen = bestellingen;
        }
        #endregion
    }
}
