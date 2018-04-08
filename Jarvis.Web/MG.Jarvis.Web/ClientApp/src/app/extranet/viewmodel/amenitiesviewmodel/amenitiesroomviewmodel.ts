import { AmenitiesGroupViewModel } from './amenitiesgroupviewmodel';
import { IObjectWithState } from '../../../common/iobjectwithstate';
import { ObjectState } from '../../../common/enums';

export class AmenitiesRoomViewModel implements IObjectWithState {
    objectState: ObjectState;
    roomFacilityRelationId: number;
    roomTypeId: number;
    roomName: string;
    isSelected: boolean;
}
