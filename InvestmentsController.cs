using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MIP_API.Data;
using MIP_API.Models;

namespace MIP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentsController : ControllerBase
    {
        private readonly MIPDbContext _context;

        public InvestmentsController(MIPDbContext context)
        {
            _context = context;
        }

        // ✅ GET: api/Investments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Investment>>> GetInvestments()
        {
            return await _context.Investments.Include(i => i.User).ToListAsync();
        }

        // ✅ GET: api/Investments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Investment>> GetInvestment(int id)
        {
            var investment = await _context.Investments.Include(i => i.User)
                                .FirstOrDefaultAsync(i => i.InvestmentId == id);

            if (investment == null)
            {
                return NotFound();
            }

            return investment;
        }

        // ✅ POST: api/Investments
        [HttpPost]
        public async Task<ActionResult<Investment>> PostInvestment(Investment investment)
        {
            _context.Investments.Add(investment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInvestment), new { id = investment.InvestmentId }, investment);
        }

        // ✅ PUT: api/Investments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvestment(int id, Investment investment)
        {
            if (id != investment.InvestmentId)
            {
                return BadRequest();
            }

            _context.Entry(investment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Investments.Any(e => e.InvestmentId == id))
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

        // ✅ DELETE: api/Investments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvestment(int id)
        {
            var investment = await _context.Investments.FindAsync(id);
            if (investment == null)
            {
                return NotFound();
            }

            _context.Investments.Remove(investment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

