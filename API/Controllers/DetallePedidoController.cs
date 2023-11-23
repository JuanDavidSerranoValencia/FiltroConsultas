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
public class DetallePedidoController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DetallePedidoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DetallePedido>>> Get()
        {
            var pedidos = await _unitOfWork.DetallePedidos.GetAllAsync();
            return _mapper.Map<List<DetallePedido>>(pedidos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetallePedidoDto>> Get(int id)
        {
            var DetallePedido = await _unitOfWork.DetallePedidos.GetByIdAsync(id);
            if(DetallePedido == null)
            {
                return NotFound();
            }
            return _mapper.Map<DetallePedidoDto>(DetallePedido);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DetallePedido>> Post(DetallePedidoDto DetallePedidoDto)
        {
            var DetallePedido = _mapper.Map<DetallePedido>(DetallePedidoDto);
            this._unitOfWork.DetallePedidos.Add(DetallePedido);
            await _unitOfWork.SaveAsync();
            if(DetallePedido == null)
            {
                return BadRequest();
            }
            DetallePedidoDto.Id = DetallePedido.Id;
            return CreatedAtAction(nameof(Post), new {id = DetallePedidoDto.Id}, DetallePedidoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetallePedidoDto>> Put(int id, [FromBody] DetallePedidoDto DetallePedidoDto)
        {
            if(DetallePedidoDto == null)
            {
                return NotFound();
            }
            var pedidos = _mapper.Map<DetallePedido>(DetallePedidoDto);
            _unitOfWork.DetallePedidos.Update(pedidos);
            await _unitOfWork.SaveAsync();
            return DetallePedidoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var DetallePedido = await _unitOfWork.DetallePedidos.GetByIdAsync(id);
            if(DetallePedido == null)
            {
                return NotFound();
            }
            _unitOfWork.DetallePedidos.Delete(DetallePedido);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
