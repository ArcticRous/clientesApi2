using Microsoft.AspNetCore.Mvc;
using ClienteApi2.Data;
using ClienteApi2.Models;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ClienteApi2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtener usuarios")]
        [SwaggerResponse(200, "Lista de usuarios obtenida correctamente")]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtener usuario por ID")]
        [SwaggerResponse(200, "Usuario encontrado")]
        [SwaggerResponse(404, "Usuario no encontrado")]
        public async Task<IActionResult> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Agregar usuarios")]
        [SwaggerResponse(201, "Usuario creado exitosamente")]
        [SwaggerResponse(400, "Datos inválidos")]
        public async Task<IActionResult> CreateCliente([FromBody] CrearClienteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cliente = new Cliente
            {
                Nombre = dto.Nombre,
                CorreoElectronico = dto.CorreoElectronico,
                Telefono = dto.Telefono
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Actualizar usuario existente")]
        [SwaggerResponse(204, "Usuario actualizado correctamente")]
        [SwaggerResponse(404, "Usuario no encontrado")]
        [SwaggerResponse(400, "Datos inválidos")]
        public async Task<IActionResult> UpdateCliente(int id, [FromBody] CrearClienteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _context.Clientes.FindAsync(id);
            if (existing == null) return NotFound();

            existing.Nombre = dto.Nombre;
            existing.CorreoElectronico = dto.CorreoElectronico;
            existing.Telefono = dto.Telefono;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Eliminar usuario")]
        [SwaggerResponse(204, "Usuario eliminado correctamente")]
        [SwaggerResponse(404, "Usuario no encontrado")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return NotFound();

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

    public class CrearClienteDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "El nombre solo debe contener letras")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "Correo electrónico no válido")]
        public string CorreoElectronico { get; set; } = null!;

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "El teléfono debe contener exactamente 10 dígitos")]
        public string Telefono { get; set; } = null!;
    }
}
