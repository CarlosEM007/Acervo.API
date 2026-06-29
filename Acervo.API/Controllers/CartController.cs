using Acervo.Application.DTOs;
using Acervo.Application.Service;
using Acervo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly CartService _service;
    public CartController(CartService service) => _service = service;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await _service.GetById(id);
        return result.Succeeded ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCart()
    {
        var result = await _service.GetAllCart();
        return result.Succeeded ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] CreateCartDto dto)
    {
        var entity = new Cart(dto.UserId);
        var result = await _service.Insert(entity);
        return result.Succeeded ? Ok() : BadRequest(result.Error);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCartDto dto)
    {
        var found = await _service.GetById(dto.Id);
        if (!found.Succeeded) return NotFound(found.Error);

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
