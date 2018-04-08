import { ObjectState } from '../../../../common/enums';
import { ContractTermsViewModel } from './contracttermsviemodel';

export class SaveContractTermsViewModel {
   id: number;
   name: string;
   clauseLibraryFields: ContractTermsViewModel[];
   isPublished: boolean;
   objectState: ObjectState;
}
