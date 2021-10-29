using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using secondAPI.Repositories;

namespace secondAPI.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase {

        private readonly IBookRepository _bookrepository;

        public BookController(IBookRepository bookrepository){
            _bookrepository = bookrepository;
        }

        [HttpPost("post")]
        public async Task<Book> Post([FromBody] Book book){
            return await _bookrepository.Post(book);
        }


        [HttpGet]
        public async Task<IEnumerable<Book>> Get(){
           return await _bookrepository.Get();
        }


        [HttpGet("{number}")]
        public async Task<Book> NumGet(int number){
            return await _bookrepository.Get(number);
            
        }

        [HttpDelete("delete/{number}")]
        public async Task Del(int number){

            await _bookrepository.Delete(number);
            
        }


        [HttpPut("change/{number}")]
        public async Task Put(int number, [FromBody] Book book){
            await _bookrepository.Change(number, book);
        }



    }

}
