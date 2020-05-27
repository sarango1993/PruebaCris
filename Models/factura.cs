using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaCris.Models
{
    public class factura
    {

        public int ID { get; set; }

        public string Nombre { get; set; }

        public int Saldo { get; set; }

        public string direccion { get; set; }

        public int Cantidad { get; set; }
    }
}
