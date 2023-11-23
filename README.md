# FiltroConsultas

# Juan David Serrano Valencia

# Consultas

# Devuelve un listados con todos los pagos que se realizaron en el año 2008 mediante paypal .Ordene eñ resultado de mayor a menor

```
c#

public async Task<IEnumerable<object>> PagosPaypal()
        {
            var result = from p in _context.Pags
                         where p.FechaPago.Year == 2008 && p.FormaPago == "Paypal"
                         orderby p.Total descending
                         select p;
            return await result.ToListAsync();

    }

    [HttpGet("{PagosPaypal}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> PagosPaypal()
    {
        var pagos = await _unitOfWork.Pagos.PagosPaypal();

        return Ok(pagos);
    }

```
