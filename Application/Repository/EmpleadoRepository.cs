using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
    {
        public ApiFiltroContext _context { get; set; }
        public EmpleadoRepository(ApiFiltroContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> JefeDeJefes()
        {
            var result = from e in _context.Empleads
                         join j in _context.Empleads on e.CodigoJefe equals j.CodigoEmpleado
                         join m in _context.Empleads on j.CodigoJefe equals m.CodigoEmpleado
                         select new { Empleado = e.Nombre + " " + e.Apellido1 + " " + e.Apellido2, Jefe = j.Nombre + " " + j.Apellido1 + " " + j.Apellido2, JefeDelJefe = m.Nombre + " " + m.Apellido1 + " " + m.Apellido2 };
            return await result.ToListAsync();
        }
    }
}
