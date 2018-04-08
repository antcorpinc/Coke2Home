import { ObjectState } from '../../../../common/enums';

export class ContractTermsViewModel {
    clauseLibraryId: number;
    description: string;
    isConfigurable: boolean;
    isSelected: boolean;
    name: string;
    objectState: ObjectState;
    order: number;
    status: number;
    // templateId: number;
}
