using ComputerStockApi.Daos;
using ComputerStockApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerStockController : ControllerBase
    {
        public readonly ComputerStockContext _context;

        public ComputerStockController(ComputerStockContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ComputerDao> GetComputers()
        {
            var request = _context.Set<ComputerDao>().ToList();

            return request;
        }

        [HttpPost]
        public async Task<IActionResult> AddComputer(ComputerDao computer)
        {
            var Ncomputer = new ComputerDao()
            {
                Id = computer.Id,
                Name = computer.Name,
                Brand = computer.Brand,
                StateId = computer.StateId,
                Comment = computer.Comment,
                ProcessorId = computer.ProcessorId,
                Ram = computer.Ram,
                TypeId = computer.TypeId,
            };

            await _context.Computers.AddAsync(Ncomputer);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
