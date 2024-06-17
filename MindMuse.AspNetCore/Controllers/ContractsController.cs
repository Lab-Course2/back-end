using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MindMuse.Application.Contracts.Models.Requests;
using MindMuse.Data.Contracts.Models;
using MindMuse.Data.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindMuse.AspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly MindMuseContext _context;
        public ContractsController(MindMuseContext context)
        {
            _context = context;
        }

        // GET: api/Contracts
        // GET: api/Contracts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contract>>> GetContracts()
        {
            return await _context.Contracts.ToListAsync();
        }

        [HttpGet("employees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees;
        }


        // GET: api/Contracts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contract>> GetContract(int id)
        {
            var contract = await _context.Contracts.FindAsync(id);

            if (contract == null)
            {
                return NotFound();
            }

            return contract;
        }


        [HttpPost("CreateContract")]
        public async Task<ActionResult<Contract>> CreateContract(Contract contract)
        {
            _context.Contracts.Add(contract);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContract), new { id = contract.Id }, contract);
        }


        // DELETE: api/Contracts/DeleteContract/5
        [HttpDelete("DeleteContract/{id}")]
        public async Task<IActionResult> DeleteContract(int id)
        {
            var contract = await _context.Contracts.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }

            _context.Contracts.Remove(contract);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Contracts/byStartDate/2024-06-17
        [HttpGet("byStartDate")]
        public async Task<ActionResult<IEnumerable<Contract>>> GetContractsByStartDate([FromQuery] DateTime startDate)
        {
            var contracts = await _context.Contracts
                .Where(c => c.StartDate.Date == startDate.Date)
                .ToListAsync();

            return contracts;
        }

        // GET: api/Contracts/byEmployee/5
        [HttpGet("byEmployee")]
        public async Task<ActionResult<IEnumerable<Contract>>> GetContractsByEmployee([FromQuery] int employeeId)
        {
            var contracts = await _context.Contracts
                .Where(c => c.EmployeeId == employeeId)
                .ToListAsync();

            return contracts;
        }

        // PUT: api/Contracts/UpdateContractById/5
        [HttpPut("UpdateContractById/{id}")]
        public async Task<IActionResult> UpdateContractById(int id, [FromBody] Contract contract)
        {
            if (id != contract.Id)
            {
                return BadRequest();
            }

            _context.Entry(contract).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractExists(id))
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

        private bool ContractExists(int id)
        {
            return _context.Contracts.Any(e => e.Id == id);
        }
    }
}
