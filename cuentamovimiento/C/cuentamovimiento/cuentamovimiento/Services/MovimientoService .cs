using cuentamovimiento.Entities;
using cuentamovimiento.Repositories;

namespace cuentamovimiento.Services
{
    public class MovimientoService
    {
        private readonly IMovimientoRepository _movimientoRepository;
        private readonly ICuentaRepository _cuentaRepository;
        public MovimientoService(IMovimientoRepository movimientoRepository, ICuentaRepository cuentaRepository)
        {
            _movimientoRepository = movimientoRepository;
            _cuentaRepository = cuentaRepository;
        }

        public async Task<Movimiento> CreateMovimientoAsync(Movimiento movimiento)
        {
            var cuenta = await _cuentaRepository.GetCuentaByNumeroAsync(movimiento.NumeroCuenta);
            if (cuenta.SaldoInicial + movimiento.Valor < 0)
            {
                throw new Exception("Saldo no disponible");
            }
            cuenta.SaldoInicial += movimiento.Valor;
            movimiento.Saldo = cuenta.SaldoInicial;
            return await _movimientoRepository.CreateMovimientoAsync(movimiento);
        }

        public async Task<IEnumerable<Movimiento>> GetMovimientosByCuentaAndDateRangeAsync(string numeroCuenta, DateTime startDate, DateTime endDate)
        {
            return await _movimientoRepository.GetMovimientosByCuentaAndDateRangeAsync(numeroCuenta, startDate, endDate);
        }
    }
}
