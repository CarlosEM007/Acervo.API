using Acervo.Application.DTOs;
using Acervo.Application.Service;
using Acervo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CartItemController : ControllerBase
{
    private readonly CartItemService _service;
    public CartItemController(CartItemService service) => _service = service;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await _service.GetById(id);
        return result.Succeeded ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCartItem()
    {
        var result = await _service.GetAllCartItem();
        return result.Succeeded ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] CreateCartItemDto dto)
    {
        var entity = new CartItem(dto.CartId, dto.BookId, dto.UnitPrice, dto.Quantity);
        var result = await _service.Insert(entity);
        return result.Succeeded ? Ok() : BadRequest(result.Error);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCartItemDto dto)
    {
        var found = await _service.GetById(dto.Id);
        if (!found.Succeeded) return NotFound(found.Error);

        found.Value.UpdateQuantity(dto.Quantity);
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
