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

        talla?: string;
        color?: string;  
        genero?: string; 

        existencia?: number ;
        existenciaMinima?: number ;
        existenciaMaxima?: number ;

        imagenes?: string[]
}



