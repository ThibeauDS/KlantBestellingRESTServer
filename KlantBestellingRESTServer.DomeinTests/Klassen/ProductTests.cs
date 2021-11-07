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
    public class ProductTests
    {
        #region Properties
        private readonly Product _product;
        #endregion

        #region Constructors
        public ProductTests()
        {
            _product = new(1, "Westmalle");
        }
        #endregion

        [Theory()]
        [InlineData(0)]
        public void ZetIdTest(int id)
        {
            Assert.Throws<ProductException>(() => _product.ZetId(id));
        }

        [Theory()]
        [InlineData(null)]
        public void ZetNaamTest(string naam)
        {
            Assert.Throws<ProductException>(() => _product.ZetNaam(naam));
        }

        [Theory()]
        [InlineData("")]
        public void ZetNaamTest2(string naam)
        {
            Assert.Throws<ProductException>(() => _product.ZetNaam(naam));
        }
    }
}