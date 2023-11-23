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
    public class ClienteRepository : GenericRepository<Cliente>, ICliente
    {
        public ApiFiltroContext _context { get; set; }
        public ClienteRepository(ApiFiltroContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> NombreClientesPagos()
        {
            var noPagos = from c in _context.Clients
                          join p in _context.Pags on c.CodigoCliente equals p.CodigoCliente
                          join e in _context.Empleads on c.CodigoEmpleadoRepVentas equals e.CodigoEmpleado
                          join o in _context.Oficins on e.CodigoOficina equals o.CodigoOficina
                          select new { c.NombreCliente, e.Nombre, e.Apellido1, e.Apellido2, o.Ciudad };
            return await noPagos.ToListAsync();
        }

        public async Task<List<object>> ClientesSinPago()
        {
            var clientesSinPago = await _context.Clients
                .Where(c => !_context.Pags.Any(p => p.CodigoCliente == c.CodigoCliente))
                .Select(c => c.NombreCliente)
                .ToListAsync();

            return clientesSinPago.Cast<object>().ToList();
        }

        public async Task<List<object>> ClienteRepresentante()
        {
            var representante = await _context.Clients
                .Join(_context.Empleads, c => c.CodigoEmpleadoRepVentas, e => e.CodigoEmpleado, (cliente, empleado) => new
                {
                    cliente.NombreCliente,
                    Empleado = $"{empleado.Nombre} {empleado.Apellido1}",
                    CiudadOficina = empleado.CodigoOficinaNavigation.Ciudad
                })
                .ToListAsync<object>();

            return representante;
        }

  /*       public async Task<List<object>> ClienteInfoRepresentante()
{
    var result = await _context.Clients
        .GroupJoin(_context.Pags, c => c.CodigoCliente, p => p.CodigoCliente, (cliente, pagos) => new
        {
            cliente.CodigoCliente,
            cliente.NombreCliente,
            pagos.FirstOrDefault()?.empleado.Nombre,
            pagos.FirstOrDefault()?.Empleado.Apellido1,
            pagos.FirstOrDefault()?.Empleado.Apellido2,
            pagos.FirstOrDefault()?.Empleado.Oficina.Telefono
        })
        .Where(c => c.CodigoCliente != null && c.Nombre == null)
        .Distinct()
        .ToListAsync<object>();

    return result;
} */

    }
}
