import { AtlasEnumInputType } from "../Enums/AtlasEnumInputType";
import { IAtlasCustomControl } from "../Interfaces/IAtlasCustomControl";

export const atlasCompsUseCustomControlState = () => {
  const confi = (
    state:any,
    typeInput?: AtlasEnumInputType ,
    label? : string,
    additionalData? : any[],
    isRequired? :boolean ,
    isVisible? :boolean,
    genericFunction? : any
  ) => {

    return ({
     error: state.errors[0],
     label: label == null ? state.path : label,
     typeInput,
     additionalData: additionalData != null ? [...additionalData] : [],
     isRequired,
     isVisible,
     genericFunction,
   });
  }
  

  const conf = (
    state:any,
    customControll: IAtlasCustomControl
  ) => {

    const {
      label, 
      typeInput, 
      additionalData, 
      isRequired, 
      isVisible, 
      genericFunction, 
      customClassContainer,
      customClassControl,
      customClassError,
      customClassLable,

    } = customControll;
    
    return ({
     error: state.errors[0],
     label:  label == null ? state.path : label,
     typeInput,
     additionalData: additionalData != null ? [...additionalData] : [],
     isRequired,
     isVisible,
     genericFunction,
      customClassContainer,
      customClassControl,
      customClassError,
      customClassLable,
   });
  }
  
  return {
    conf,
  };
};
