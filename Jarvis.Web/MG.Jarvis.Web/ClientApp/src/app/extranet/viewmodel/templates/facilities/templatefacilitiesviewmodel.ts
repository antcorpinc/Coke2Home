import { FacilityGroupViewModel } from '../../facilitiesservicesviewmodel/facilitygroupviewmodel';
import { ObjectState } from '../../../../common/enums';

export class TemplateFacilitiesViewModel {
   id: number;
   hotelFacilityFields: FacilityGroupViewModel[];
   objectState: ObjectState;
}
