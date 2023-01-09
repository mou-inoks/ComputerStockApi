using ComputerStockApi.Daos;
using ComputerStockApi.Data;
using ComputerStockApi.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ComputerStockApi.Dtos;
using ComputerStockApi.Quer;

namespace ComputerStockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerStockController : ControllerBase
    {
        private readonly ComputerStockContext _context;
        private readonly IMediator mediator;

        public ComputerStockController(ComputerStockContext context, IMediator mediator )
        {
            _context = context;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComputerDto>>> GetComputers()
        {
            var request = new GetAllComputersQuery();

            var response = await mediator.Send(request);

            return Ok(response);
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComputer(int id)
        {
            var computer =  _context.Computers.FirstOrDefault(x => x.Id == id);

            if (computer == null)
                return NotFound();
            else
            {
                _context.Computers.Remove(computer);
                await _context.SaveChangesAsync();

            }

            return Ok();
        }

        [HttpGet("processors")]
        public IEnumerable<ProcessorDao> GetProcessors()
        {
            var request = _context.Set<ProcessorDao>().ToList();

            return request;
        }

        [HttpGet("processors/{id}")]
        public async Task<IActionResult> GetProcessorsById(int id)
        {
            var processor = _context.Processor.FirstOrDefault(x => x.Id == id);

            return Ok(processor);
        }

        [HttpPost("processors")]
        public async Task<IActionResult> AddProcessor(ProcessorDao processor)
        {
            var NProcessor = new ProcessorDao()
            {
                Name=processor.Name,
                Vitesse=processor.Vitesse,
                Niveau=processor.Niveau,
            };

            await _context.Processor.AddAsync(NProcessor);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("processor/{id}")]
        public async Task<IActionResult> DeleteProcessor(int id)
        {
            var processor = _context.Processor.FirstOrDefault(x => x.Id == id);

            if (processor == null)
                return NotFound();
            else
            {
                _context.Processor.Remove(processor);
                await _context.SaveChangesAsync();

            }

            return Ok();
        }


        [HttpGet("state")]
        public IEnumerable<StateDao> GetStates()
        {
            var request = _context.Set<StateDao>().ToList();

            return request;
        }

        [HttpPost("state")]
        public async Task<IActionResult> AddState(StateDao state)
        {
            var NState = new StateDao()
            {
                 State= state.State
            };

            await _context.State.AddAsync(NState);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("type")]
        public IEnumerable<ComputerTypeDao> GetType()
        {
            var request = _context.Set<ComputerTypeDao>().ToList();

            return request;
        }

        [HttpPost("type")]
        public async Task<IActionResult> addType(ComputerTypeDao type)
        {
            var NType = new ComputerTypeDao()
            {
                Type = type.Type
            };

            await _context.ComputerType.AddAsync(NType);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
