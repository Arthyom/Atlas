
export interface ICartDireccion{
    paisId: number;
    estadoId: number;
    municipio: string;
    colonia: string;
    direccion: string;
    direccionPrimaria: string,
    direccionSecundaria:string,
    cp:number;
    exterior:number;
    interior:number;
    entreCalles:string;
    referencias:string;

    last_name:string,
    first_name:string,
    phone:string,
    direccion1: string,
    direccion2:string,
    ciudad: string,
    pais:string,
    paisCodigo: string,
    estado:string,
    estadoCodigo: string;
        paisCode:string;
    paisName:string

}



export interface ICartMetodoPago{
    metodoPagoId: number;
    titular: string;
    numero: number;
    cvv: number;
    vencimiento: string;
}

export interface ICartPropietario{
    nombre: string;
    apellidoM: string;
    apellidoP: string;
    telefono: string;
    email: string;
}