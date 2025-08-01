import { IAtlasKeyValue } from "../Interfaces/IAtlasKeyValue"

export const useAtlasComposableMapKeyValue = () =>{


    const mapToKeyValue = (collection:any[], valueToExtract: string) =>{
        return collection.map<IAtlasKeyValue>( (x)=> ({key: x.id, value :x[valueToExtract]}))
    }


    return{
        mapToKeyValue
    }
}