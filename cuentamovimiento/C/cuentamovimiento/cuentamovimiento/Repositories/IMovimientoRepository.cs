using cuentamovimiento.Entities;

namespace cuentamovimiento.Repositories
{
    public interface IMovimientoRepository
    {
        Task<Movimiento> CreateMovimientoAsync(Movimiento movimiento);
        Task<IEnumerable<Movimiento>> GetMovimientosByCuentaAsync(string numeroCuenta);
        Task<IEnumerable<Movimiento>> GetMovimientosByCuentaAndDateRangeAsync(string numeroCuenta, DateTime startDate, DateTime endDate);
        
    }
}
