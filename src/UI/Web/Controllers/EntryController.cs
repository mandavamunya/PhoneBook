using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly IEntryService _entryService;
        private readonly IEntryRepository _entryRepository;

        public EntryController(IEntryService entryService, IEntryRepository entryRepository)
        {
            _entryService = entryService;
            _entryRepository = entryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Entry>> Index()
        {
            return await _entryRepository.GetEntriesAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntryById([FromRoute]int id)
        {
            var entry = await _entryService.GetEntryById(id);
            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }

        [HttpGet("EntriesByPhoneBookId/{id}")]
        public async Task<IEnumerable<Entry>> GetEntryByPhoneBookId([FromRoute]int id)
        {
            return await _entryRepository.GetEntriesByPhoneBookId(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddEntry([FromBody] Entry entry)
        {
            return Ok(await _entryService.AddEntryAsync(entry));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEntry([FromBody] Entry entry)
        {
            return Ok(await _entryService.SetEntryAsync(entry));
        }

        [HttpGet("EntryByName/{name}")]
        public async Task<IActionResult> GetEntryByName([FromRoute]string name)
        {
            var entry = await _entryRepository.GetEntryByName(name);
            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }

        [HttpGet("EntryByPhoneNumber/{phoneNumber}")]
        public async Task<IActionResult> GetEntryByPhoneNumber([FromRoute]string phoneNumber)
        {
            var entry = await _entryRepository.GetEntryByPhoneNumber(phoneNumber);
            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntry([FromRoute] int id)
        {
            var entry = await _entryService.GetEntryById(id);

            if (entry == null)
                return NotFound();

            return Ok(await _entryService.DeleteEntryAsync(entry)); 
        }

    }
}