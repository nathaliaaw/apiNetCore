using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiNet.Models;

namespace apiNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudesHogwartsController : ControllerBase
    {
        private readonly SolicitudContext _context;

        public SolicitudesHogwartsController(SolicitudContext context)
        {
            _context = context;
        }

        // GET: api/SolicitudesHogwarts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SolicitudesHogwarts>>> GetSolicitudesHogwarts()
        {
            return await _context.SolicitudesHogwarts.ToListAsync();
        }

        // GET: api/SolicitudesHogwarts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SolicitudesHogwarts>> GetSolicitudesHogwarts(long id)
        {
            var solicitudesHogwarts = await _context.SolicitudesHogwarts.FindAsync(id);

            if (solicitudesHogwarts == null)
            {
                return NotFound();
            }

            return solicitudesHogwarts;
        }

        // PUT: api/SolicitudesHogwarts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolicitudesHogwarts(long id, SolicitudesHogwarts solicitudesHogwarts)
        {
            if (!NombreCorrectoCasa(solicitudesHogwarts.CasaHogwarts))
            {
                return BadRequest("La casa de Hogwarts ingresada es incorrecta");
            }

            if (id != solicitudesHogwarts.IdSolicitud)
            {
                return BadRequest("El numero de la solicitud no es correcta");
            }

            _context.Entry(solicitudesHogwarts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitudesHogwartsExists(id))
                {
                    return NotFound("La identificación no fue encontrada");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SolicitudesHogwarts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SolicitudesHogwarts>> PostSolicitudesHogwarts(SolicitudesHogwarts solicitudesHogwarts)
        {
            if (NombreCorrectoCasa(solicitudesHogwarts.CasaHogwarts))
            {
                _context.SolicitudesHogwarts.Add(solicitudesHogwarts);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSolicitudesHogwarts", new { id = solicitudesHogwarts.Identificación }, solicitudesHogwarts);
            }
            else
            {
                return BadRequest("La casa de Hogwarts ingresada es incorrecta");
            }
        }

            // DELETE: api/SolicitudesHogwarts/5
            [HttpDelete("{id}")]
        public async Task<ActionResult<SolicitudesHogwarts>> DeleteSolicitudesHogwarts(long id)
        {
            var solicitudesHogwarts = await _context.SolicitudesHogwarts.FindAsync(id);
            if (solicitudesHogwarts == null)
            {
                return NotFound();
            }

            _context.SolicitudesHogwarts.Remove(solicitudesHogwarts);
            await _context.SaveChangesAsync();

            return solicitudesHogwarts;
        }

        private bool SolicitudesHogwartsExists(long id)
        {
            return _context.SolicitudesHogwarts.Any(e => e.IdSolicitud == id);
        }
        public bool NombreCorrectoCasa(string casa)
        {
            if (casa == "Gryffindor" || casa == "Hufflepuff"
               || casa == "Ravenclaw" || casa == "Slytherin")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
