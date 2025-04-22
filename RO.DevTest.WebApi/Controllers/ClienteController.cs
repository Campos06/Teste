[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly ClienteService _clienteService;

    public ClienteController(ClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var clientes = await _clienteService.ListarClientesAsync();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var cliente = await _clienteService.ObterClienteAsync(id);
        if (cliente == null) return NotFound();
        return Ok(cliente);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ClienteDto dto)
    {
        await _clienteService.AdicionarClienteAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = dto.Nome }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] ClienteDto dto)
    {
        await _clienteService.AtualizarClienteAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _clienteService.RemoverClienteAsync(id);
        return NoContent();
    }
}
