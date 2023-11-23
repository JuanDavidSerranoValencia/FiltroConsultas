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
    public class ProductoRepository : GenericRepository<Producto>, IProducto
    {
        public ApiFiltroContext _context { get; set; }
        public ProductoRepository(ApiFiltroContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> ProductosPorPedido()
        {
            var result = from p in _context.Products
                         join dp in _context.DetallePedids on p.CodigoProducto equals dp.CodigoProducto into gj
                         from subdp in gj.DefaultIfEmpty()
                         where subdp == null
                         select  new {p.Nombre,p.Descripcion} ;
            return await result.ToListAsync();
        }
    }
}
