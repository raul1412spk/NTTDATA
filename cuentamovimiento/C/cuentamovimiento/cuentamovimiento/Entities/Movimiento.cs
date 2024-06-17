using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cuentamovimiento.Entities
{
    public class Movimiento
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }

        [ForeignKey("Cuenta")]
        public string NumeroCuenta { get; set; }
        public Cuenta Cuenta { get; set; }
    }
}
