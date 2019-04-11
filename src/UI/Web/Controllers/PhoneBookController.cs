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
    public class PhoneBookController : ControllerBase
    {
        private readonly IEntryService _entryService;
        private readonly IPhoneBookService _phoneBookService;
        private readonly IPhoneBookRepository _phoneBookRepository;

        public PhoneBookController(
            IEntryService entryService,
            IPhoneBookService phoneBookService,
            IPhoneBookRepository phoneBookRepository)
        {
            _entryService = entryService;
            _phoneBookService = phoneBookService;
            _phoneBookRepository = phoneBookRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<PhoneBook>> Index()
        {
            return await _phoneBookRepository.GetPhoneBooksAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhoneBookById([FromRoute] int id)
        {
            var phoneBook = await _phoneBookService.GetAllPhoneBookItems(id);
            if (phoneBook == null)
            {
                return NotFound();
            }
            return Ok(phoneBook);
        }

        [HttpPost]
        public async Task<IActionResult> AddPhoneBook([FromBody] PhoneBook phoneBook)
        {
            phoneBook = await _phoneBookService.AddPhoneBookAsync(phoneBook);
            return Ok(phoneBook);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePhoneBook([FromBody] PhoneBook phoneBook)
        {
            await _phoneBookService.SetPhoneBookAsync(phoneBook);
            return Ok();
        }

        [HttpGet("PhoneBookByName/{name}")]
        public async Task<IActionResult> GetPhoneBookByName([FromRoute]string name)
        {
            var phoneBook = await _phoneBookRepository.GetPhoneBookByName(name);

            if (phoneBook == null)       
                return NotFound();
           
            return Ok(phoneBook);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoneBook([FromRoute] int id)
        {
            var phoneBook = await _phoneBookService.GetPhoneBookById(id);

            if (phoneBook == null)
                return NotFound();

            return Ok(await _phoneBookService.DeletePhoneBookAsync(phoneBook));
        }
    }
}