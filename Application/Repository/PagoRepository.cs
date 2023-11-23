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
    public class PagoRepository : GenericRepository<Pago>, IPago
    {
        public ApiFiltroContext _context { get; set; }
        public PagoRepository(ApiFiltroContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> PagosPaypal()
        {
            var result = from p in _context.Pags
                         where p.FechaPago.Year == 2008 && p.FormaPago == "Paypal"
                         orderby p.Total descending
                         select p;
            return await result.ToListAsync();
        }

        public async Task<IEnumerable<object>> FormasDepago()
        {
            var result = (from p in _context.Pags
                          select p.FormaPago).Distinct();
            return await result.ToListAsync();
        }


    }
}
