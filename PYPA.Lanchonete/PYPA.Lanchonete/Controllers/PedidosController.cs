using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PYPA.Lanchonete.Core;
using PYPA.Lanchonete.Core.Factories;
using PYPA.Lanchonete.Core.Interfaces;
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
            var restaurante = RestauranteService.PegarRestaurante();
            return Ok(restaurante == null ? new List<Pedido>(): restaurante.Pedidos);
        }

        // GET: api/Pedidos/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pedidos
        [HttpPost]
        public IActionResult Post([FromBody] NovoPedidoModel request)
        {
            var restaurante = RestauranteService.PegarRestaurante();
            var número = restaurante.PegarPróximoNúmero();
            restaurante.NovoPedido(PedidoFactory.Create(número, restaurante.Cardapio, request.Items.ToList<IItemPedido>()));
            return Ok();
        }

        // PUT: api/Pedidos/5
        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            var restaurante = RestauranteService.PegarRestaurante();
            var pedido = restaurante.Pedidos.FirstOrDefault(p => p.Numero == id);
            if (pedido == null) return BadRequest();
            pedido.EntregarPedido();
            return Ok();
        }

    }
}
