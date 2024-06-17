using cuentamovimiento.Entities;

namespace cuentamovimiento.Repositories
{
    public interface ICuentaRepository
    {
        Task<Cuenta> GetCuentaByNumeroAsync(string numeroCuenta);

        Task<IEnumerable<Cuenta>> GetCuentasByClienteIdAsync(string clienteId);
                     
        Task<Cuenta> CreateCuentaAsync(Cuenta cuenta);

    }
}
