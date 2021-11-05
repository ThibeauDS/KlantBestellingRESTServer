using KlantBestellingRESTServer.Domein.Exceptions;
using System;

namespace KlantBestellingRESTServer.Domein.Klassen
{
    public class Bestelling
    {
        #region Properties
        public int Id { get; private set; }
        public Product Product { get; private set; }
        public int Aantal {  get; private set; }
        public Klant Klant {  get; private set; }
        #endregion

        #region Constructors
        public Bestelling(int id, Product product, int aantal, Klant klant)
        {
            ZetId(id);
            ZetProduct(product);
            ZetAantal(aantal);
            ZetKlant(klant);
        }
        public Bestelling(int id, int aantal, Klant klant)
        {
            ZetId(id);
            ZetAantal(aantal);
            ZetKlant(klant);
        }
        public Bestelling(int aantal, Klant klant)
        {
            ZetAantal(aantal);
            ZetKlant(klant);
        }
        #endregion

        #region Methods
        public void ZetId(int id)
        {
            if (id < 0)
            {
                throw new BestellingException("Het ID is ongeldig. Het moet 0 of meer zijn.");
            }
            Id = id;
        }

        public void ZetProduct(Product product)
        {
            Product = product;
        }

        public void ZetAantal(int aantal)
        {
            if (aantal < 1)
            {
                throw new BestellingException("Het aantal moet groter zijn dan 0.");
            }
            Aantal = aantal;
        }

        public void ZetKlant(Klant klant)
        {
            Klant = klant;
        }
        #endregion
    }
}
