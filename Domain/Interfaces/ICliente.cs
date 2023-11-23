using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{ 
    public interface ICliente:IGeneric<Cliente> 
    {
        Task<IEnumerable<object>> NombreClientesPagos();
        Task<List<object>> ClientesSinPago();
        Task<List<object>> ClienteRepresentante();

    }
} 
