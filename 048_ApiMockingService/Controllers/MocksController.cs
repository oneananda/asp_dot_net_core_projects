using _048_ApiMockingService.Data;
using _048_ApiMockingService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _048_ApiMockingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MocksController : ControllerBase
    {
        private readonly MockDbContext _db;

        public MocksController(MockDbContext db) => _db = db;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MockEndpoint mock)
        {
            _db.Mocks.Add(mock);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = mock.Id }, mock);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _db.Mocks.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var mock = await _db.Mocks.FindAsync(id);
            return mock == null ? NotFound() : Ok(mock);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var mock = await _db.Mocks.FindAsync(id);
            if (mock == null) return NotFound();

            _db.Mocks.Remove(mock);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }

}
