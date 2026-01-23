export interface IDtoEnPeDireccion {
  company: string;
  street: string;
  interiorNumber?: string | null; // nullable in C#
  outdoorNumber: string;
  zipCode: string;
  neighborhood: string;
  city: string;
  state: string;
  stateCode: string;
  countryCode: string;
  countryName: string;
  references: string;
  name: string;
  email: string;
  phone: string;
}
