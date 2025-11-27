import { IAtlasKeyValue } from '../Interfaces/IAtlasKeyValue';

export const useAtlasComposableMapKeyValue = () =>{


    const mapToKeyValue = (collection:any[], valueToExtract: string) =>{
        return collection.map<IAtlasKeyValue>( (x)=> ({key: x.id, value :x[valueToExtract]}))
    }

    const mapToKeyValueWithId = (collection:any[], valueToExtract: string, idToExtract: string) =>{
        return collection.map<IAtlasKeyValue>( (x)=> ({key: x[idToExtract], value :x[valueToExtract]}))
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

    const mapToObjectFromArray = <Tout>(collection: any[], collectionMainPropName: string, collectionValue: any) =>{
       
        const response: any = {};
        collection.forEach( item => {
            if(!!item){
                const name = item[collectionMainPropName]
                if(!!name){
                    const values: any = {}
                    values[collectionValue] = item[collectionValue]
                    response[name] =  {...values}
                }
            }
        });

        return response as Tout;
    }


    return{
        mapToKeyValueWithId,
        mapToKeyValue,
        expandBasedOnValue,
        mapToObjectFromArray
    }
}