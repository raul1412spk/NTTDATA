using cuentamovimiento.Dtos;
using cuentamovimiento.Services;
using Microsoft.AspNetCore.Mvc;

namespace cuentamovimiento.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReporteController : ControllerBase
    {
        private readonly CuentaService _cuentaService;
        private readonly MovimientoService _movimientoService;

        public ReporteController(CuentaService cuentaService, MovimientoService movimientoService)
        {
            _cuentaService = cuentaService;
            _movimientoService = movimientoService;
        }

        [HttpGet("reportes")]
        public async Task<IActionResult> GetReporte([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] string clienteId)
        {
            try
            {
                var cuentas = await _cuentaService.GetCuentasByClienteIdAsync(clienteId);
                var reporteDtoList = new List<ReporteDto>();

                foreach (var cuenta in cuentas)
                {
                    var movimientos = await _movimientoService.GetMovimientosByCuentaAndDateRangeAsync(cuenta.NumeroCuenta, startDate, endDate);
                    var movimientosDto = movimientos.Select(m => new MovimientoDto
                    {
                        Fecha = m.Fecha,
                        TipoMovimiento = m.TipoMovimiento,
                        Valor = m.Valor,
                        Saldo = m.Saldo
                    }).ToList();

                    var reporteDto = new ReporteDto
                    {
                        NumeroCuenta = cuenta.NumeroCuenta,
                        Saldo = cuenta.SaldoInicial, 
                        Movimientos = movimientosDto
                    };

                    reporteDtoList.Add(reporteDto);
                }

                return Ok(reporteDtoList);
            }
            catch (Exception )
            {
                return StatusCode(500, "Error al generar reporte");
            }
        }
    }

}
