using Xunit;
using KlantBestellingRESTServer.Domein.Klassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlantBestellingRESTServer.Domein.Exceptions;

namespace KlantBestellingRESTServer.Domein.Klassen.Tests
{
    public class BestellingTests
    {
        #region Properties
        private readonly Klant _klant;
        private readonly Product _product;
        private readonly Bestelling _bestelling;
        #endregion

        #region Constructors
        public BestellingTests()
        {
            _klant = new(1, "Thibeau De Smet", "Sleistraat 26A 9550 Herzele");
            _product = new(1, "Duvel");
            _bestelling = new(1, _product, 2, _klant);
        }
        #endregion

        [Theory()]
        [InlineData(0)]
        public void ZetIdTest(int id)
        {
            Assert.Throws<BestellingException>(() => _bestelling.ZetId(id));
        }

        [Theory()]
        [InlineData(null)]
        public void ZetProductTest(Product product)
        {
            Assert.Throws<BestellingException>(() => _bestelling.ZetProduct(product));
        }

        [Theory()]
        [InlineData(1)]
        public void ZetAantalTest(int aantal)
        {
            Assert.Throws<BestellingException>(() => _bestelling.ZetAantal(aantal));
        }

        [Theory()]
        [InlineData(null)]
        public void ZetKlantTest(Klant klant)
        {
            Assert.Throws<BestellingException>(() => _bestelling.ZetKlant(klant));
        }
    }
}