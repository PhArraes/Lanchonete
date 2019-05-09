
using Microsoft.AspNetCore.Mvc;
using PYPA.Lanchonete.Core;
using PYPA.Lanchonete.Core.Factories;
using PYPA.Lanchonete.Models;
using System.Linq;

namespace PYPA.Lanchonete.Controllers
{
    [Route("api/[controller]")]
    public class RestaurantesController : Controller
    {
        RestauranteService RestauranteService;
        Card�pioFactory card�pioFactory;

        public RestaurantesController(RestauranteService restauranteService, Card�pioFactory card�pioFactory)
        {
            RestauranteService = restauranteService;
            this.card�pioFactory = card�pioFactory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(RestauranteService.PegarRestaurante());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CardapioModel request)
        {
            var card�pio = card�pioFactory.Create(request.Lanches.ToList<ILanche>());
            RestauranteService.CriarRestaurantePadr�o(card�pio);
            return Ok();
        }

       
    }
}
