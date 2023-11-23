using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pago : BaseEntity
    {
        public int CodigoCliente { get; set; }

        public string FormaPago { get; set; } = null!;

        public string IdTransaccion { get; set; } = null!;

        public DateOnly FechaPago { get; set; }

        public decimal Total { get; set; }

        public virtual Cliente CodigoClienteNavigation { get; set; } = null!;
    }
}
