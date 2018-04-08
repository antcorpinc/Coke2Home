import { AmenitiesRoomViewModel } from './amenitiesroomviewmodel';
import { IObjectWithState } from '../../../common/iobjectwithstate';
import { ObjectState } from '../../../common/enums';

export class AmenitiesViewModel implements IObjectWithState {
    objectState: ObjectState;
    facilityGroupId: number;
    facilityTypeId: number;
    id: number;
    isSelected: boolean;
    isActive: boolean;
    name: string;
    facilitiesRoomList: AmenitiesRoomViewModel[];
}
