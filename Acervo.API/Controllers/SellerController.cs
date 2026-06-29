using Acervo.Application.DTOs;
using Acervo.Application.Service;
using Acervo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SellerController : ControllerBase
{
    private readonly SellerService _service;
    public SellerController(SellerService service) => _service = service;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await _service.GetById(id);
        return result.Succeeded ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSeller()
    {
        var result = await _service.GetAllSeller();
        return result.Succeeded ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] CreateSellerDto dto)
    {
        var entity = new Seller(dto.Name, dto.Email, dto.Document, dto.Phone);
        var result = await _service.Insert(entity);
        return result.Succeeded ? Ok() : BadRequest(result.Error);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSellerDto dto)
    {
        var found = await _service.GetById(dto.Id);
        if (!found.Succeeded) return NotFound(found.Error);

        found.Value.Update(dto.Name, dto.Email, dto.Phone);
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
