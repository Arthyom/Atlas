import { IAtlasCustomControl } from './IAtlasCustomControl';
export interface IAtlasCustomFormConfig{
    validationSchema?: any,
    initialValues?: any,
    properties?:  IAtlasCustomControl[],
    title: string,
    resource: string,

    formSchema:  IAtlasFormSchema[],
    sectionTitle?: string
}


export interface IAtlasFormSchema{
    schema: any,
    config?: IAtlasCustomControl,
}