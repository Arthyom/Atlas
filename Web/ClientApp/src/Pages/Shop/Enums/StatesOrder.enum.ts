export enum EnumStateOrden{

    OrdenCreada = "CREATED",//'CreadoOrden',          //- orden creada
    
    PagoConfirmado = "",//'ConfirmadoOrden',      //- pago de orden confirmado
    PagoEnEspera = "PENDING",//'PagoEnEspera',        //- pago de orden en espera
    PagoRechazado = "",//'PagoRechazado',       //- pago de orden rechazado

    OrdenEnPreparacion = "",//'PreparandoOrden',      //- preparin orden
    OrdenEnviada    = "",///'EnviadaOrden',         //- order sent
    OrdenRecivida   = ""///'RecividaOrden'
}


