import { IBaseDto } from "@/Models/DTOs/Base/IBaseDto";

export interface IDtoUsuarioResponse {
  zipCode: string;
  nombre: string;
  email: string;
  country: string;
  state: string;
  countryCode: string;
  stateCode: string;
  references: string;
  phone: string;
  interiorNumber: number;
  outdoorNumber: number;
  neighborhood: string;
  company: string;
  rol:string;
}