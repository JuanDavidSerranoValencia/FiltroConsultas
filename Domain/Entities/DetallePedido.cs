using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DetallePedido : BaseEntity
    {
        public int CodigoPedido { get; set; }

        public string CodigoProducto { get; set; } = null!;

        public int Cantidad { get; set; }

        public decimal PrecioUnidad { get; set; }

        public short NumeroLinea { get; set; }

        public virtual Pedido CodigoPedidoNavigation { get; set; } = null!;

        public virtual Producto CodigoProductoNavigation { get; set; } = null!;
    }
}
