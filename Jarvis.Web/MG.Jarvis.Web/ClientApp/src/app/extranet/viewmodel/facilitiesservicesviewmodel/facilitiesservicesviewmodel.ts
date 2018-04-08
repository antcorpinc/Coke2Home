import { IObjectWithState } from '../../../common/iobjectwithstate';
import { ObjectState } from '../../../common/enums';

export class FacilitiesServicesViewModel implements IObjectWithState {
   hotelFacilityRelationId: number;
   objectState: ObjectState;
   id: number;
   name: string;
   isSelected: boolean;
   facilityTypeId: number;
   facilityGroupId: number;
}
