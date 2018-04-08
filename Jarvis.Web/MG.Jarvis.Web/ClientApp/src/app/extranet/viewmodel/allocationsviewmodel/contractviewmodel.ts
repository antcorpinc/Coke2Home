import { RoomsViewModel } from "./roomsviewmodel";

export class ContractDetailsViewModel {
  hotelId: number;
  isStaticContract: boolean;
  isDynamicContract: boolean;
  contractStartDate: string;
  contractEndDate: string;
  pooledAllotment: number; 
  rooms: RoomsViewModel[];
}
