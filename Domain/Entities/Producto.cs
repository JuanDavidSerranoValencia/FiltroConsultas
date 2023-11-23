using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Producto : BaseEntity
    {
        public string CodigoProducto { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Gama { get; set; } = null!;

        public string Dimensiones { get; set; }

        public string Proveedor { get; set; }

        public string Descripcion { get; set; }

        public short CantidadEnStock { get; set; }

        public decimal PrecioVenta { get; set; }

        public decimal? PrecioProveedor { get; set; }

        public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

        public virtual GamaProducto GamaNavigation { get; set; } = null!;
    }
}
