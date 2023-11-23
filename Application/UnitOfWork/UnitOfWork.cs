
using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;
namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiFiltroContext _context;
    private ICliente _clientes { get; set; }
    private IDetallePedido _detallePedidos { get; set; }
    private IEmpleado _empleados { get; set; }
    private IGamaProducto _gamaProductos { get; set; }
    private IOficina _oficinas { get; set; }
    private IPago _pagos { get; set; }
    private IPedido _pedidos { get; set; }
    private IProducto _productos { get; set; }



    public ICliente Clientes
    {
        get
        {
            if (_clientes == null)
            {
                _clientes = new ClienteRepository(_context);
            }
            return _clientes;
        }
    }

    public IDetallePedido DetallePedidos
    {
        get
        {
            if (_detallePedidos == null)
            {
                _detallePedidos = new DetallePedidoRepository(_context);
            }
            return _detallePedidos;
        }
    }


    public IEmpleado Empleados
    {
        get
        {
            if (_empleados == null)
            {
                _empleados = new EmpleadoRepository(_context);
            }
            return _empleados;
        }
    }

    
       public IGamaProducto GamaProductos
    {
        get
        {
            if (_gamaProductos == null)
            {
                _gamaProductos = new GamaProductoRepository(_context);
            }
            return _gamaProductos;
        }
    }

      public IOficina Oficinas
    {
        get
        {
            if (_oficinas == null)
            {
                _oficinas = new OficinaRepository(_context);
            }
            return _oficinas;
        }
    }

       public IPago Pagos
    {
        get
        {
            if (_pagos == null)
            {
                _pagos = new PagoRepository(_context);
            }
            return _pagos;
        }
    }

       public IPedido Pedidos
    {
        get
        {
            if (_pedidos == null)
            {
                _pedidos = new PedidoRepository(_context);
            }
            return _pedidos;
        }
    }

        public IProducto Productos
    {
        get
        {
            if (_productos == null)
            {
                _productos = new ProductoRepository(_context);
            }
            return _productos;
        }
    }
    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
    public UnitOfWork(ApiFiltroContext context)
    {
        _context = context;
    }
}
