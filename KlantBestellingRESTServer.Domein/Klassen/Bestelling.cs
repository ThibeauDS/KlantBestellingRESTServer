using KlantBestellingRESTServer.Domein.Enums;
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
        public Bestelling(int id, int product, int aantal, Klant klant) : this(product, aantal, klant)
        {
            ZetId(id);
        }
        public Bestelling(int product, int aantal, Klant klant)
        {
            ZetProduct(product);
            ZetAantal(aantal);
            ZetKlant(klant);
        }
        #endregion

        #region Methods
        public void ZetId(int id)
        {
            if (id <= 0)
            {
                throw new BestellingException("Het ID is ongeldig. Het moet 1 of meer zijn.");
            }
            Id = id;
        }

        public void ZetProduct(int product)
        {
            if (!Enum.IsDefined(typeof(Product), (Product)product))
            {
                throw new BestellingException("Product bestaat niet.");
            }
            Product = (Product)product;
        }

        public void ZetAantal(int aantal)
        {
            if (aantal <= 1)
            {
                throw new BestellingException("Het aantal moet steeds groter zijn dan 1.");
            }
            Aantal = aantal;
        }

        public void ZetKlant(Klant klant)
        {
            if (klant == null)
            {
                throw new BestellingException("Klant is NULL.");
            }
            Klant = klant;
        }
        #endregion
    }
}
