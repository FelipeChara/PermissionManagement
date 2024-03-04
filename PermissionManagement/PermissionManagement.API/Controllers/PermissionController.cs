using MediatR;
using Microsoft.AspNetCore.Mvc;
using PermissionManagement.Application.Permissions.Get;
using PermissionManagement.Application.Permissions.Modify;
using PermissionManagement.Application.Permissions.Request;
using PermissionManagement.Domain.Abstractions;

namespace PermissionManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Obtiene permiso por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            Result<PermissionDTO?> query = await _mediator.Send(new GetPermissionByIdQuery(id));

            if (query.IsFailure)
            {
                return BadRequest(query.Error);
            }

            return Ok(query.Value);
        }

        /// <summary>
        /// Obtiene lista de permisos por empleado
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet("employee/{employeeId}")]
        public async Task<IActionResult> GetByEmployee(Guid employeeId)
        {
            Result<List<PermissionDTO>> query = await _mediator.Send(new GetPermissionByEmployeeQuery(employeeId));

            if (query.IsFailure)
            {
                return BadRequest(query.Error);
            }

            return Ok(query.Value);
        }

        /// <summary>
        /// Solicita un permiso 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RequestPermission(RequestPermissionCommand request, CancellationToken cancellationToken)
        {
            Result<Guid> command =  await _mediator.Send(request, cancellationToken);

            if (command.IsFailure)
            {
                return BadRequest(command.Error);
            }

            return CreatedAtAction(nameof(GetById), new { id = command.Value }, command.Value);
        }

        /// <summary>
        /// Edita un permiso
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> ModifyPermission(Guid id, ModifyPermissionCommand request, CancellationToken cancellationToken)
        {
            if(id != request.Id) 
            {
                return BadRequest("Los Ids no coinciden");
            }

            Result<Guid> command = await _mediator.Send(request, cancellationToken);

            if (command.IsFailure)
            {
                return BadRequest(command.Error);
            }

            return NoContent();
        }
    }
}
