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
    public class DetallePedidoRepository : GenericRepository<DetallePedido> , IDetallePedido 
    { 
        public ApiFiltroContext _context { get; set; } 
        public DetallePedidoRepository(ApiFiltroContext context) : base(context) 
        { 
            _context = context; 
        } 
    } 
} 
