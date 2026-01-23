export  interface IDtoProducto{
    
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









