import { IObjectWithState } from '../../../common/iobjectwithstate';
import { ObjectState } from '../../../common/enums';
import { RoomTypeViewModel } from '../../viewmodel/policiesviewmodel/roomtypeviewmodel';

 export class ChildAndExtraBedPolicyViewModel implements IObjectWithState {
    id: number;
    isChildrenAllowed: boolean;
    minChildAge: number;
    maxChildAge: number;
    isExtraCotAllowed: boolean;
    minInfantAge: number;
    maxInfantAge: number;
    cotPrice: number;
    isExtraBedAllowed: boolean;
    hotelId: number;
    cotPriceTypeId: number;
    maxChildAndExtraBedPerRoomList: RoomTypeViewModel[];
    objectState: ObjectState;
}