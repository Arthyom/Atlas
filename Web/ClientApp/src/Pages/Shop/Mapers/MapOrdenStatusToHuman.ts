import { EnumStateOrden } from "../Enums/StatesOrder.enum";

export class MapOrdenStatusToHuman {

    public static mapToTextFromInt( input: EnumStateOrden ) : string{
        switch (input) {
            case EnumStateOrden.OrdenCreada:
                return "Orden Creada";
            case EnumStateOrden.PagoConfirmado:
                return "Orden Confirmada"; 
            case EnumStateOrden.OrdenEnPreparacion:
                return "Orden Preparacion";
            case EnumStateOrden.OrdenEnviada:
                return "Orden Enviada";
            case EnumStateOrden.OrdenRecivida:
                return "Orden Recivida";
            case EnumStateOrden.PagoEnEspera:
                return "Pago  Espera";
            case EnumStateOrden.PagoRechazado:
                return "Pago Rechazado";

            default:
                return "Desconocido";
        } 
    }

    public static mapToColorFromInt( input: EnumStateOrden ) : string{
        switch (input) {
            case EnumStateOrden.OrdenCreada:
                return "badge-primary";
            case EnumStateOrden.PagoConfirmado:
                return "badge-info"; 
            case EnumStateOrden.OrdenEnPreparacion:
                return "badge-primary";
            case EnumStateOrden.OrdenEnviada:
                return "badge-secondary";
            case EnumStateOrden.OrdenRecivida:
                return "badge-accent";
            case EnumStateOrden.PagoEnEspera:
                return "badge-warning";
            case EnumStateOrden.PagoRechazado:
                return "badge-error";

            default:
                return "Desconocido";
        } 
    }
}