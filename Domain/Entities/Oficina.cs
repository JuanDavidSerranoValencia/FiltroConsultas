using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Oficina : BaseEntity
    {
        public string CodigoOficina { get; set; } = null!;

        public string Ciudad { get; set; } = null!;

        public string Pais { get; set; } = null!;

        public string Region { get; set; }

        public string CodigoPostal { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string LineaDireccion1 { get; set; } = null!;

        public string LineaDireccion2 { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
    }
}
