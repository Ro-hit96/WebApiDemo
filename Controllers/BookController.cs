using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;
using WebApiDemo.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookServices services;
        public BookController(IBookServices services)
        {
            this.services = services;
        }
        // GET: api-->Book-->Getbooks
        [HttpGet]
        [Route("GetBooks")]
        public IActionResult Get()
        {
            try
            {
                var model = services.GetBooks();
                return new ObjectResult(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

        // GET api-->Book-->getbookbyid-->1
        [HttpGet]
        [Route("GetBookById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var model = services.GetBookById(id);
                if (model != null)
                    return new ObjectResult(model);
                else
                    return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/Book-->Add Book
        [HttpPost]
        [Route("AddBook")]
        public IActionResult Post([FromBody] Book book)//from body of http
        {
            try
            {
                int result = services.AddBook(book);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }

        // PUT api/Book/UpdateBook
        [HttpPut]
        [Route("UpdateBook")]
        public IActionResult Put([FromBody] Book book)
        {
            try
            {
                int result = services.UpdateBook(book);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

            // DELETE api/<BookController>/5
            [HttpDelete]
            [Route("DeleteBook/{id}")]
            public IActionResult Delete(int id)
            {
            try
            {
                
                    int result = services.DeleteBook(id);
                    if (result >= 1)
                    {
                        return StatusCode(StatusCodes.Status200OK);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status400BadRequest);
                    }

                
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}

