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
    public async Task<IActionResult> Insert([FromBody] CartItem entity)
    {
        var result = await _service.Insert(entity);
        return result.Succeeded ? Ok() : BadRequest(result.Error);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CartItem entity)
    {
        var result = await _service.Update(entity);
        return result.Succeeded ? Ok() : BadRequest(result.Error);
    }

    [HttpDelete]
    public IActionResult Delete([FromBody] CartItem entity)
    {
        var result = _service.Delete(entity);
        return result.Succeeded ? Ok() : NotFound(result.Error);
    }
}
