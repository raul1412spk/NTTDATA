using System.ComponentModel.DataAnnotations;

namespace cuentamovimiento.Entities
{

    public class Cuenta
    {
        [Key]
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public string Estado { get; set; }

        public ICollection<Movimiento> Movimientos { get; set; }
    }

}
