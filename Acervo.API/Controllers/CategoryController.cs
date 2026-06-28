using Acervo.Application.Service;
using Acervo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly CategoryService _service;
    public CategoryController(CategoryService service) => _service = service;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await _service.GetById(id);
        return result.Succeeded ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategory()
    {
        var result = await _service.GetAllCategory();
        return result.Succeeded ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] Category entity)
    {
        var result = await _service.Insert(entity);
        return result.Succeeded ? Ok() : BadRequest(result.Error);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Category entity)
    {
        var result = await _service.Update(entity);
        return result.Succeeded ? Ok() : BadRequest(result.Error);
    }

    [HttpDelete]
    public IActionResult Delete([FromBody] Category entity)
    {
        var result = _service.Delete(entity);
        return result.Succeeded ? Ok() : NotFound(result.Error);
    }
}
