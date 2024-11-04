using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Get() => Ok(await _produtoRepository.GetAllAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(string id)
    {
        var produto = await _produtoRepository.GetByIdAsync(id);
        if (produto == null) return NotFound();
        return Ok(produto);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create(Produto produto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        await _produtoRepository.CreateAsync(produto);
        return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(string id, Produto produto)
    {
        var existingProduto = await _produtoRepository.GetByIdAsync(id);
        if (existingProduto == null) return NotFound();

        produto.Id = id;
        await _produtoRepository.UpdateAsync(id, produto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(string id)
    {
        var produto = await _produtoRepository.GetByIdAsync(id);
        if (produto == null) return NotFound();

        await _produtoRepository.DeleteAsync(id);
        return NoContent();
    }
}
