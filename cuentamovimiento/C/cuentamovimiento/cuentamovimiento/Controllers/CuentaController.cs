using cuentamovimiento.Entities;
using cuentamovimiento.Services;
using Microsoft.AspNetCore.Mvc;

namespace cuentamovimiento.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentaController : ControllerBase
    {
        private readonly CuentaService _cuentaService;

        public CuentaController(CuentaService cuentaService)
        {
            _cuentaService = cuentaService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCuenta([FromBody] Cuenta cuenta)
        {
            var createdCuenta = await _cuentaService.CreateCuentaAsync(cuenta);
            return CreatedAtAction(nameof(GetCuentaByNumero), new { numeroCuenta = createdCuenta.NumeroCuenta }, createdCuenta);
        }

        [HttpGet("{numeroCuenta}")]
        public async Task<IActionResult> GetCuentaByNumero(string numeroCuenta)
        {
            var cuenta = await _cuentaService.GetCuentaByNumeroAsync(numeroCuenta);
            return Ok(cuenta);
        }
    }
}
