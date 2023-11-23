using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class ClienteController : BaseController
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClienteController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClinteDto>>> Get()
    {
        var cliente = await _unitOfWork.Clientes.GetAllAsync();

        return _mapper.Map<List<ClinteDto>>(cliente);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Cliente>> Post(ClinteDto clinteDto)
    {
        var cliente = _mapper.Map<Cliente>(clinteDto);
        this._unitOfWork.Clientes.Add(cliente);
        await _unitOfWork.SaveAsync();
        if (cliente == null)
        {
            return BadRequest();
        }
        clinteDto.CodigoCliente = cliente.CodigoCliente;
        return CreatedAtAction(nameof(Post), new { id = clinteDto.CodigoCliente }, clinteDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClinteDto>> Put(int id, [FromBody] ClinteDto clinteDto)
    {
        if (clinteDto == null)
            return NotFound();
        var cliente = _mapper.Map<Cliente>(clinteDto);
        _unitOfWork.Clientes.Update(cliente);
        await _unitOfWork.SaveAsync();
        return clinteDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }
        _unitOfWork.Clientes.Delete(cliente);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("{NombreClientesPagos}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> NombreClientesPagos()
    {
        var cliente = await _unitOfWork.Clientes.NombreClientesPagos();

        return Ok(cliente);
    }

    [HttpGet("{ClientesSinPago}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ClientesSinPago()
    {
        var cliente = await _unitOfWork.Clientes.ClientesSinPago();

        return Ok(cliente);
    }

    [HttpGet("{ClienteRepresentante}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ClienteRepresentante()
    {
        var cliente = await _unitOfWork.Clientes.ClienteRepresentante();

        return Ok(cliente);
    }
}
