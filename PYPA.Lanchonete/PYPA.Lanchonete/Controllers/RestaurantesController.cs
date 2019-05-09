
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
        CardápioFactory cardápioFactory;

        public RestaurantesController(RestauranteService restauranteService, CardápioFactory cardápioFactory)
        {
            RestauranteService = restauranteService;
            this.cardápioFactory = cardápioFactory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(RestauranteService.PegarRestaurante());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CardapioModel request)
        {
            var cardápio = cardápioFactory.Create(request.Lanches.ToList<ILanche>());
            RestauranteService.CriarRestaurantePadrão(cardápio);
            return Ok();
        }

       
    }
}
