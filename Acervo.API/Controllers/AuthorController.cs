using Acervo.Application.Service;
using Acervo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly AuthorService _service;
    public AuthorController(AuthorService service) => _service = service;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await _service.GetById(id);
        return result.Succeeded ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAuthor()
    {
        var result = await _service.GetAllAuthor();
        return result.Succeeded ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] Author entity)
    {
        var result = await _service.Insert(entity);
        return result.Succeeded ? Ok() : BadRequest(result.Error);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Author entity)
    {
        var result = await _service.Update(entity);
        return result.Succeeded ? Ok() : BadRequest(result.Error);
    }

    [HttpDelete]
    public IActionResult Delete([FromBody] Author entity)
    {
        var result = _service.Delete(entity);
        return result.Succeeded ? Ok() : NotFound(result.Error);
    }
}
