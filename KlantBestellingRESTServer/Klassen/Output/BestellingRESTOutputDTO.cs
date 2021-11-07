namespace KlantBestellingRESTServer.Klassen.Output
{
    public class BestellingRESTOutputDTO
    {
        #region Properties
        public string Id { get; set; }
        public string KlantId { get; set; }
        public string Product { get; set; }
        public int Aantal { get; set; }
        #endregion

        #region Constructors
        public BestellingRESTOutputDTO(string id, string klantId, string product, int aantal)
        {
            Id = id;
            KlantId = klantId;
            Product = product;
            Aantal = aantal;
        }
        #endregion
    }
}
