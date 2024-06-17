 using System;
 using System.Collections.Generic;

namespace cuentamovimiento.Dtos
{

    public class ReporteDto
    {
        public string NumeroCuenta { get; set; }
        public decimal Saldo { get; set; }
        public List<MovimientoDto> Movimientos { get; set; }
    }
}
