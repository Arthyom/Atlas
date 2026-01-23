import { IBaseDto } from "../../Base/IBaseDto";

export interface IDtoEnPeShippingPackageSize extends IBaseDto{
  type: string;
  depth: string;
  width: string;
  height: string;
  weight: string;
  description: string;
}