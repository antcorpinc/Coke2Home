import { RoomBedOptionsViewModel } from './roombedoptionsviewmodel';
export interface RoomTypeInfoViewModel {
  isActive: boolean;
  hotelId: number;
  roomTypeId: number;
  roomName: string;
  roomSize: number;
  sizeMeasureId: number;
  noOfRooms: number;
  noOfDoubleRooms: number;
  noOfTwinRooms: number;
  isFreeSale: boolean;
  smoking: number;
  roomDescription: string;
  roomBedOptions: RoomBedOptionsViewModel[] ;
}
