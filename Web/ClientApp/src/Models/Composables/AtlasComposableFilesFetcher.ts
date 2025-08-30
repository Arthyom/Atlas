import { IAtlasDtoProducto } from "../Entities/IAtlasProducto"

export const useAtlasComposableUseFilesFetcher = () =>{


    const getFileFrom = (resource: string, mode = 'store', identifier: string) =>{
        return `/${mode}/${resource}/file/${identifier}`
    }

     const getFirstFileForProducto = (  productoLike: IAtlasDtoProducto, mode = 'store',) =>{
        if(!productoLike.imagenes) return noFile()
        if(productoLike.imagenes.length == 0) return noFile()
        return `/${mode}/producto/file/${productoLike.imagenes[0]}`
    }

    const getLastImage = (producto: IAtlasDtoProducto) =>{
        const {imagenes} = producto;

        if(!imagenes) return '';

        const len = imagenes.length
        
        return imagenes[len];
    }

    
    const getImageAt = (producto: IAtlasDtoProducto, at : number) =>{

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
        getFirstFileForProducto
    }
}