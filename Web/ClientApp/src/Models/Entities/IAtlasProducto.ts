export default interface IAtlasProducto{
    
        id: number;
        nombre: string;
        descripcion: string;
        precioUnitario: number;
        precioMayore: number;
        categoriaId: number;
        talla?: string;
        color?: string;  
        genero?: string; 
        existencia?: number ;
        existenciaMinima?: number ;
        existenciaMaxima?: number ;
}


export  interface IAtlasDtoProducto{
    
        id: number;
        nombre: string;
        descripcion: string;
        precioUnitario: number;
        precioMayoreo: number;
        categoria: string;

        selected: boolean;

        talla?: string;
        color?: string;  
        genero?: string; 

        categoriaColor? : string

        existencia?: number ;
        existenciaMinima?: number ;
        existenciaMaxima?: number ;

        imagenes?: string[];

        cantidad: number;
}

export interface IAtlasDtoContainer<T>{

        mainType: T;
}

export  interface IAtlasDtoBarCodeProducto{
    
        id: number;
        nombre: string
}


