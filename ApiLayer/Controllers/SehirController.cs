using BusinessLayer.Abstract;
using DataAccesLayer.Context;
using Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SehirController : ControllerBase
    {
        private readonly SqlDbContext _context;
        private readonly ISehirManager sehirManager;

        public SehirController(SqlDbContext context, ISehirManager sehirManager)
        {
            _context = context;
            this.sehirManager = sehirManager;
        }

        // GET: api/Sehir
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sehir>>> GetSehirler()
        {
            var result = await sehirManager.FindAllIncludeAsync(null, p => p.Ulke);

            if (result == null)
            {
                return NotFound();
            }
            var sonuc = await result.ToListAsync();
            return sonuc;
        }

        // GET: api/Sehir/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sehir>> GetSehir(int id)
        {
            if (_context.Sehirler == null)
            {
                return NotFound();
            }
            var sehir = await _context.Sehirler.FindAsync(id);

            if (sehir == null)
            {
                return NotFound();
            }

            return sehir;
        }

        // PUT: api/Sehir/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Sehir sehir)
        {
            if (id != sehir.Id)
            {
                return BadRequest();
            }

            _context.Entry(sehir).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SehirExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sehir
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sehir>> Post(Sehir sehir)
        {

            var result = await sehirManager.CreateAsync(sehir);

            if (result >= 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();

            }

            //if (_context.Sehirler == null)
            //{
            //    return Problem("Entity set 'SqlDbContext.Sehirler'  is null.");
            //}
            //_context.Sehirler.Add(sehir);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetSehir", new { id = sehir.Id }, sehir);
        }

        // DELETE: api/Sehir/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Sehirler == null)
            {
                return NotFound();
            }
            var sehir = await _context.Sehirler.FindAsync(id);
            if (sehir == null)
            {
                return NotFound();
            }

            _context.Sehirler.Remove(sehir);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SehirExists(int id)
        {
            return (_context.Sehirler?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
