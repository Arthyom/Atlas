export enum StatesEnvioEnum{
    capturado       = 'Capturado' ,   //- package's measurement captured
    proveedor       = 'Proveedor' ,   // - package's shipping company captured
    guia            = 'GuiaEnvio' , // - package's shipping guide generated
    guiaCancelada   = 'GuiaCancelada',//- package's shipping guide canceled
    pickup          = 'EsperandoPickUp',  // - waiting for pickup
    enviado         = 'Enviado',// - package sent
    recibido        = 'Recibido'// - package recivied
}