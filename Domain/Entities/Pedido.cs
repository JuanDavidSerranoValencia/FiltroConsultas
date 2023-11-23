using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pedido : BaseEntity
    {
        public int CodigoPedido { get; set; }

        public DateOnly FechaPedido { get; set; }

        public DateOnly FechaEsperada { get; set; }

        public DateOnly FechaEntrega { get; set; }

        public string Estado { get; set; } = null!;

        public string Comentarios { get; set; }

        public int CodigoCliente { get; set; }

        public virtual Cliente CodigoClienteNavigation { get; set; } = null!;

        public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();
    }
}
