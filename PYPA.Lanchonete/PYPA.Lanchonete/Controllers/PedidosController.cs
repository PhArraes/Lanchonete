using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PYPA.Lanchonete.Core;
using PYPA.Lanchonete.Core.Factories;
using PYPA.Lanchonete.Models;

namespace PYPA.Lanchonete.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {

        RestauranteService RestauranteService;
        PedidoFactory PedidoFactory;

        public PedidosController(RestauranteService restauranteService, PedidoFactory pedidoFactory)
        {
            RestauranteService = restauranteService;
            PedidoFactory = pedidoFactory;
        }


        // GET: api/Pedidos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(RestauranteService.PegarRestaurante().Pedidos);
        }

        // GET: api/Pedidos/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pedidos
        [HttpPost]
        public void Post([FromBody] NovoPedidoModel request)
        {
            var restaurante = RestauranteService.PegarRestaurante();
            restaurante.NovoPedido(PedidoFactory.Create(restaurante.Cardápio, request.Items));
        }

        // PUT: api/Pedidos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

    }
}
