import { IObjectWithState } from '../../../common/iobjectwithstate';
import { ObjectState } from '../../../common/enums';

export class TaxesViewModel {
    objectState: ObjectState;
    taxTypeId: number;
    taxesType: string;
    taxApplicabilityId: number;
    amount: number;
    isIncludedInRates: boolean;
}
