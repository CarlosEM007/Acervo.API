using Acervo.Application.Service;
using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Acervo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookService _service;

        public BookController(BookService service)
        {
            _service = service;
        }

        public async Task<IActionResult> GetById(long Id)
        {
            try
            {
                Result<Book> Result = await _service.GetById(Id);

                if (Result.Succeeded)
                {
                    return Ok(Result.Value);
                }
                else
                {
                    return NotFound(Result.Error);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> GetAllBook()
        {
            try
            {
                Result<List<Book>> Result = await _service.GetAllBook();

                if (Result.Succeeded)
                {
                    return Ok(Result.Value);
                }
                else
                {
                    return NotFound(Result.Error);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult Delete(Book Entity)
        {
            try
            {
                Result Result = _service.Delete(Entity);

                if (Result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return NotFound(Result.Error);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Insert(Book Entity)
        {
            try
            {
                Result Result = await _service.Insert(Entity);

                if (Result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return NotFound(Result.Error);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Update(Book Entity)
        {
            try
            {
                Result Result = await _service.Update(Entity);

                if (Result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return NotFound(Result.Error);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
