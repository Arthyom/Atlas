import { AtlasEnumInputType } from "../Enums/AtlasEnumInputType";

export interface IAtlasCustomControl{
    error?: string;
    typeInput?: AtlasEnumInputType;
    modelValue?: string;
    label?: string;
    isRequired?: boolean;
    isVisible?: boolean;
    additionalData?: any[];
    genericFunction?: any;
    icon?: string;
    placeHolder?: string 
}