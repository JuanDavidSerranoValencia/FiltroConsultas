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
    public class PedidoRepository : GenericRepository<Pedido>, IPedido
    {
        public ApiFiltroContext _context { get; set; }
        public PedidoRepository(ApiFiltroContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<object>> NumeroPedidos()
        {
            var result = from p in _context.Pedids
                         group p by p.Estado into g
                         select new { Estado = g.Key, CantidadPedidos = g.Count() };
            return await result.OrderByDescending(r => r.CantidadPedidos).ToListAsync();
        }
    }
}
