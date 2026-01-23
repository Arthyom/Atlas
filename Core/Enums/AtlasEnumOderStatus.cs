using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Enums
{
    public enum AtlasEnumOderStatus
    {
        OrdenCreada = 1 ,

        
        PagoConfirmado = 2 ,
        PagoEnEspera = 3,
        PagoRechazado = 4,

        OrdenEnPreparacion = 5,
        OrdenEnviada = 6,
        OrdenRecivida = 7,
        OrdenCancelada = 8


    }
}

