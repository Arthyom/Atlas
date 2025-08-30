import { IAtlasKeyValue } from '../Interfaces/IAtlasKeyValue';

export const useAtlasComposableMapKeyValue = () =>{


    const mapToKeyValue = (collection:any[], valueToExtract: string) =>{
        return collection.map<IAtlasKeyValue>( (x)=> ({key: x.id, value :x[valueToExtract]}))
    }


    const expandBasedOnValue = ( collection: IAtlasKeyValue[]) =>{
        const newCollection : IAtlasKeyValue[] = []

        collection.forEach( x => {
            let amount: number =  +x.value
            
            for (let index = 0; index < amount; index++) {
                newCollection.push({key: x.key, value: x.value})
            }
        })

        return newCollection;
    }


    return{
        mapToKeyValue,
        expandBasedOnValue
    }
}