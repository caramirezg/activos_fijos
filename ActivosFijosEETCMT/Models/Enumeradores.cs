using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivosFijosEETC.Models
{
    public class Enumeradores
    {
        public enum estado_activo
        {
            None,
            activo= 3,
        };

        public enum tipo_adquisicion
        {
            None,
            compra_directa = 1,
        };

   
    }
}