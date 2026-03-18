import { IDtoProducto } from "@/Pages/Producto/DTOs/IDtoProducto"

export const useAtlasComposableUseFilesFetcher = () =>{


    const getFileFrom = (resource: string, mode = 'store', identifier: string) =>{
        return `/${mode}/${resource}/file/${identifier}`
    }

     const getFirstFileForProducto = (  productoLike: IDtoProducto, mode = 'store',) =>{
        if(!productoLike.imagenes) return noFile()
        if(productoLike.imagenes.length == 0) return noFile()
        return `/${mode}/producto/file/${productoLike.imagenes[0]}`
    }

         const getFirstFileForProductoAnonimous = (  productoLike: IDtoProducto, mode = 'store',) =>{
        if(!productoLike.imagenes) return noFile()
        if(productoLike.imagenes.length == 0) return noFile()
        return `/${mode}/productoAnonimous/file/${productoLike.imagenes[0]}`
    }

    const getLastImage = (producto: IDtoProducto) =>{
        const {imagenes} = producto;

        if(!imagenes) return '';

        const len = imagenes.length
        
        return imagenes[len];
    }

    
    const getImageAt = (producto: IDtoProducto, at : number) =>{

        const {imagenes} = producto;
        
        if(!imagenes) return '';
        
        const len = imagenes.length

        console.log('sssss')
        if( at <0 )
            at = len +at
        
        return imagenes[at];
    }

    const noFile = () =>{
        return 'https://www.repro.cam.ac.uk/sites/default/files/images/profile/no-photo.png'
    }

    return {
        getImageAt,
        getLastImage,
        getFileFrom,
        noFile,
        getFirstFileForProductoAnonimous,
        getFirstFileForProducto
    }
}