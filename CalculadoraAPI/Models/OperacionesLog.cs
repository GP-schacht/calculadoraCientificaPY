using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculadoraAPI.Models
{
    public class OperacionesLog
    {
        
 public int Id { get; set; }
    public string Operacion { get; set; }
    public string TipoOperacion { get; set; }
    public DateTime FechaRegistro { get; set; }

    }
}