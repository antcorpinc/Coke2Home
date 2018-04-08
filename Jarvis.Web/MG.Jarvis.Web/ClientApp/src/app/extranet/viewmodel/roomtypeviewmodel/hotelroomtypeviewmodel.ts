import { IObjectWithState } from '../../../common/iobjectwithstate';
import { ObjectState } from '../../../common/enums';
import { RoomBedOptionsViewModel } from './roombedoptionsviewmodel';

export class HotelRoomTypeViewModel implements IObjectWithState {
        objectState: ObjectState;
        roomId: Number;
        isActive: boolean;
        hotelId: number;
        roomTypeId: number;
        name: string;
        size: number;
        sizeMeasureId: number;
        noOfRooms: number;
        noOfDoubleRooms?: number;
        noOfTwinRooms?: number;
        isSmoking: boolean;
        isFreeSale: boolean;
        description: string;
        roomBedOptions: RoomBedOptionsViewModel;
}
