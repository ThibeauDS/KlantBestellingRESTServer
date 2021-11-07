using KlantBestellingRESTServer.Domein.Beheerders;
using KlantBestellingRESTServer.Domein.Klassen;
using KlantBestellingRESTServer.Klassen.Input;
using KlantBestellingRESTServer.Klassen.Output;
using KlantBestellingRESTServer.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace KlantBestellingRESTServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlantBestellingController : ControllerBase
    {
        #region Properties
        private string url = "http://localhost:5000";
        private readonly BestellingBeheerder _bestellingBeheerder;
        private readonly KlantBeheerder _klantBeheerder;
        //private readonly ProductBeheerder _productBeheerder;
        #endregion

        #region Constructors
        public KlantBestellingController(BestellingBeheerder bestellingBeheerder, KlantBeheerder klantBeheerder)
        {
            _bestellingBeheerder = bestellingBeheerder;
            _klantBeheerder = klantBeheerder;
            //_productBeheerder = productBeheerder;
        }
        #endregion

        #region Methods
        [HttpGet("{id}")]
        public ActionResult<KlantRESTOutputDTO> GetKlant(int id)
        {
            try
            {
                Klant klant = _klantBeheerder.KlantWeergeven(id);
                return Ok(MapVanDomein.MapVanKlantDomein(url, klant, _bestellingBeheerder));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<KlantRESTOutputDTO> PostKlant([FromBody] KlantRESTInputDTO klantRESTInputDTO)
        {
            try
            {
                Klant klant = _klantBeheerder.KlantToevoegen(MapNaarDomein.MapNaarKlantDomein(klantRESTInputDTO));
                return CreatedAtAction(nameof(GetKlant), new { id = klant.Id }, MapVanDomein.MapVanKlantDomein(url, klant, _bestellingBeheerder));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<KlantRESTOutputDTO> DeleteKlant(int id)
        {
            try
            {
                _klantBeheerder.KlantVerwijderen(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<KlantRESTOutputDTO> PutKlant(int id, [FromBody] KlantRESTInputDTO klantRESTInputDTO)
        {
            try
            {
                if (!_klantBeheerder.BestaatKlant(id) || klantRESTInputDTO == null || string.IsNullOrWhiteSpace(klantRESTInputDTO.Naam) || string.IsNullOrWhiteSpace(klantRESTInputDTO.Adres))
                {
                    return BadRequest();
                }
                Klant klant = MapNaarDomein.MapNaarKlantDomein(klantRESTInputDTO);
                klant.ZetId(id);
                Klant klantDb = _klantBeheerder.KlantUpdaten(klant);
                return CreatedAtAction(nameof(GetKlant), new { id = klantDb.Id }, MapVanDomein.MapVanKlantDomein(url, klantDb, _bestellingBeheerder));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
