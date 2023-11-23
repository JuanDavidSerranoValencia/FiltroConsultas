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
public class EmpleadoController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EmpleadoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Empleado>>> Get()
    {
        var entidades = await _unitOfWork.Empleados.GetAllAsync();
        return _mapper.Map<List<Empleado>>(entidades);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmpleadoDto>> Get(int id)
    {
        var Empleado = await _unitOfWork.Empleados.GetByIdAsync(id);
        if (Empleado == null)
        {
            return NotFound();
        }
        return _mapper.Map<EmpleadoDto>(Empleado);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Empleado>> Post(EmpleadoDto EmpleadoDto)
    {
        var Empleado = _mapper.Map<Empleado>(EmpleadoDto);
        this._unitOfWork.Empleados.Add(Empleado);
        await _unitOfWork.SaveAsync();
        if (Empleado == null)
        {
            return BadRequest();
        }
        EmpleadoDto.Id = Empleado.Id;
        return CreatedAtAction(nameof(Post), new { id = EmpleadoDto.Id }, EmpleadoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmpleadoDto>> Put(int id, [FromBody] EmpleadoDto EmpleadoDto)
    {
        if (EmpleadoDto == null)
        {
            return NotFound();
        }
        var entidades = _mapper.Map<Empleado>(EmpleadoDto);
        _unitOfWork.Empleados.Update(entidades);
        await _unitOfWork.SaveAsync();
        return EmpleadoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Empleado = await _unitOfWork.Empleados.GetByIdAsync(id);
        if (Empleado == null)
        {
            return NotFound();
        }
        _unitOfWork.Empleados.Delete(Empleado);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("{JefeDeJefes}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> JefeDeJefes()
    {
        var empleados = await _unitOfWork.Empleados.JefeDeJefes();

        return Ok(empleados);
    }
}
