import { IObjectWithState } from '../../../common/iobjectwithstate';
import { ObjectState } from '../../../common/enums';

export class CancellationPolicyClausesViewModel implements IObjectWithState {
    cancellationPolicyClausesId: number;
    daysBeforeArrival: number;
    percentageCharge: number;
    cancellationChargesId: number;
    cancellationPolicyId: number;
    objectState: ObjectState;
}
