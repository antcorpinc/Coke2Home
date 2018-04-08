import { ObjectState } from '../../../../common/enums';
import { AmenitiesTypeViewModel } from './amenitiestypeviewmodel';

export class AmenitiesGroupViewModel {
    facilityGroupName: string;
    roomFacilityTypes: AmenitiesTypeViewModel[];
    id: number;
    facilityGroupId: number;
    code: number;
    isSelected: boolean;
    isConfigurable: boolean;
    objectState: ObjectState;
    status: number;
}
