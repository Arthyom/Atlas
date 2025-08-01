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

    const noFile = () =>{
        return 'https://www.repro.cam.ac.uk/sites/default/files/images/profile/no-photo.png'
    }

    return {
        getFileFrom,
        noFile,
        getFirstFileForProducto
    }
}