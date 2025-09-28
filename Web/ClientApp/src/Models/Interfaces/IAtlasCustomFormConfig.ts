import { IAtlasCustomControl } from './IAtlasCustomControl';
import { string } from 'yup';
export interface IAtlasCustomFormConfig{
    validationSchema?: any,
    initialValues?: any,
    properties?:  IAtlasCustomControl[],
    title: string,
    resource: string,

    formSchema:  IAtlasFormSchema[],
    sectionTitle?: string,
    customClassTitle?: string,
    customClassContainer?: string,
    customClassDivider?:string

}


export interface IAtlasFormSchema{
    schema: any,
    config?: IAtlasCustomControl,
}