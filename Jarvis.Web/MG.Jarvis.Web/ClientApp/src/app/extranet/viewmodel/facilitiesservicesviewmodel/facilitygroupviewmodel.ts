import { FacilityTypeViewModel } from './facilitytypeviewmodel';
import { ObjectState } from '../../../common/enums';

export class FacilityGroupViewModel {
    facilityGroupId?: number;
    facilityGroupName?: string;
    hotelFacilityTypes: FacilityTypeViewModel[];

    // variables for template facilities
    isConfigurable: boolean;
    isSelected: boolean;
    id: number;   // Field Id
    objectState: ObjectState;
    status: number;
}
