
export interface ICartDireccion{
    paisId: number;
    estadoId: number;
    municipioId: number;
    coloniaId: number;
    direccion: string;
    cp:number;
    exterior:number;
    interior:number;
    entreCalles:string;
    referencias:string;
}



export interface ICartMetodoPago{
    metodoPagoId: number;
    titular: string;
    numero: number;
    cvv: number;
    vencimiento: string;
}