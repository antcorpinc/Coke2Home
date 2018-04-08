import { IObjectWithState } from '../../../common/iobjectwithstate';
import { ObjectState } from '../../../common/enums';

export class RoomTypeViewModel implements IObjectWithState {
    roomId: number;
    roomName: string;
    noOfGuest: number;
    bedCount: number;
    maxChildren: number;
    extraBedCount: number;
    objectState: ObjectState;
}