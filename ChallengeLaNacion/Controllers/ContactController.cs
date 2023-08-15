using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChallengeLaNacion.Models;
using ChallengeLaNacion.Business.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ChallengeLaNacion.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("all")]
        [SwaggerOperation("Obtiene todos los contactos.")]
        public async Task<ActionResult> Index()
        {
            try
            {
                var contacts = await _contactService.GetAll();
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation("Obtiene los detalles de un contacto por ID.")]
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var contact = await _contactService.Find(id);
                if (contact == null)
                {
                    return NotFound("No se encontraron resultados para la búsqueda.");
                }
                return Ok(contact);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpPost("create")]
        [SwaggerOperation("Crea un nuevo contacto.")]
        public async Task<ActionResult> Create(Contact contact)
        {
            try
            {
                await _contactService.CreateContact(contact);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpPut("update/{id}")]
        [SwaggerOperation("Actualiza los detalles de un contacto.")]
        public async Task<ActionResult> Edit(int id, Contact contact)
        {
            try
            {
                contact.Id = id;

                await _contactService.UpdateContact(contact);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpDelete("delete/{id}")]
        [SwaggerOperation("Elimina un contacto por ID.")]
        public async Task<ActionResult> Delete(int id)
        {

            try
            {
                var contact = await _contactService.Find(id);
                if (contact == null)
                {
                    return NotFound("No se encontraron resultados para la búsqueda.");
                }

                await _contactService.DeleteContact(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpGet("find-by-email-or-phone")]
        [SwaggerOperation("Busca un registro por correo electrónico o número de teléfono.")]
        public async Task<ActionResult> SearchByEmailOrPhone(string searchValue)
        {
            try
            {
                var key = "EmailOrPhone";
                var result = await _contactService.SearchContactsBy(key, searchValue);

                if (!result.Any())
                {
                    return NotFound("No se encontraron resultados para la búsqueda.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpGet("find-by-state-or-city")]
        [SwaggerOperation("Busca registros por estado o ciudad.")]
        public async Task<ActionResult> SearchByStateOrCity(string searchValue)
        {
            try
            {
                var key = "Address";
                var result = await _contactService.SearchContactsBy(key, searchValue);

                if (!result.Any())
                {
                    return NotFound("No se encontraron resultados para la búsqueda.");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }
    }
}
