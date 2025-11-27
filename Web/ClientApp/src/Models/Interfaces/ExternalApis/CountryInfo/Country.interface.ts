export interface IDtoExtApiCountryResponse {
  error: boolean;
  msg: string;
  data: IDtoExtApiCountry[];
}

export interface IDtoExtApiCountry {
  name?: string;
  iso3?: string;
  iso2?: string;
  states?: IDtoExtApiState[];
  currency?:string;
}

export interface IDtoExtApiState {
  name: string;
  state_code: string | null;
}

export interface State {
  name: string;
  state_code: null;
}