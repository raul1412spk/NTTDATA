using cuentamovimiento.Entities;
using cuentamovimiento.Repositories;

namespace cuentamovimiento.Services
{
    public class CuentaService
    {
        private readonly ICuentaRepository _cuentaRepository;
        public CuentaService(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }

        public async Task<Cuenta> CreateCuentaAsync(Cuenta cuenta)
        {
            return await _cuentaRepository.CreateCuentaAsync(cuenta);
        }
        public async Task<IEnumerable<Cuenta>> GetCuentasByClienteIdAsync(string clienteId)
        {
            return await _cuentaRepository.GetCuentasByClienteIdAsync(clienteId);
        }
        public async Task<Cuenta> GetCuentaByNumeroAsync(string numeroCuenta)
        {
            try
            {
                var cuenta = await _cuentaRepository.GetCuentaByNumeroAsync(numeroCuenta);

                if (cuenta == null)
                {
                    throw new Exception($"Cuenta con número {numeroCuenta} no encontrada.");
                }

                return cuenta;
            }
            catch (Exception ex)
            {
                
                throw new Exception($"Error al buscar cuenta por número {numeroCuenta}. Detalles: {ex.Message}");
            }
        }
    }
}
