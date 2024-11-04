using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteController(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Get() => Ok(await _clienteRepository.GetAllAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(string id)
    {
        var cliente = await _clienteRepository.GetByIdAsync(id);
        if (cliente == null) return NotFound();
        return Ok(cliente);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create(Cliente cliente)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        await _clienteRepository.CreateAsync(cliente);
        return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(string id, Cliente cliente)
    {
        var existingCliente = await _clienteRepository.GetByIdAsync(id);
        if (existingCliente == null) return NotFound();

        cliente.Id = id;
        await _clienteRepository.UpdateAsync(id, cliente);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(string id)
    {
        var cliente = await _clienteRepository.GetByIdAsync(id);
        if (cliente == null) return NotFound();

        await _clienteRepository.DeleteAsync(id);
        return NoContent();
    }
}
