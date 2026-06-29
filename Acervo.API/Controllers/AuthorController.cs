using Acervo.Application.DTOs;
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
    public async Task<IActionResult> Insert([FromBody] CreateAuthorDto dto)
    {
        var entity = new Author(dto.Name, dto.Biography, dto.BirthDate);
        var result = await _service.Insert(entity);
        return result.Succeeded ? Ok() : BadRequest(result.Error);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAuthorDto dto)
    {
        var found = await _service.GetById(dto.Id);
        if (!found.Succeeded) return NotFound(found.Error);

        found.Value.Update(dto.Name, dto.Biography, dto.BirthDate);
        var result = await _service.Update(found.Value);
        return result.Succeeded ? Ok() : BadRequest(result.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var found = await _service.GetById(id);
        if (!found.Succeeded) return NotFound(found.Error);

        var result = _service.Delete(found.Value);
        return result.Succeeded ? Ok() : NotFound(result.Error);
    }
}
