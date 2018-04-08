import { ObjectState } from '../../../common/enums';
import { IObjectWithState } from '../../../common/iobjectwithstate';
import { CancellationPolicyClausesViewModel } from './cancellationpolicyclausesviewmodel';

export class CancellationPolicyViewModel implements IObjectWithState {
  cancellationPolicyId: number;
  cancellationPolicyTypeId: number;
  isNoShowCharges: boolean;
  noShowCancellationChargesId: number;
  isActive: boolean;
  isDeleted: boolean;
  name: string;
  hotelId: number;
  cancellationPolicyClausesViewModelList:  CancellationPolicyClausesViewModel[];
  objectState: ObjectState;
}
