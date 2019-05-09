using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PYPA.Lanchonete.Core
{
    public class RestauranteService
    {
        List<Restaurante> restaurantes;
        public RestauranteService()
        {
            restaurantes = new List<Restaurante>();

        }

        public Restaurante PegarRestaurante(string nome = "")
        {
            return restaurantes.FirstOrDefault(r => r.Nome == nome);
        }

        public void CriarRestaurantePadrão(Cardápio cardápio)
        {
            if (restaurantes.Any(r => r.Nome == "")) return;
            restaurantes.Add(new Restaurante(4, cardápio));
        }
    }
}
