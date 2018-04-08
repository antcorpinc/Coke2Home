import { IObjectWithState } from '../../../common/iobjectwithstate';
import { ObjectState } from '../../../common/enums';

export class ContactDetailsViewModel implements IObjectWithState {
    objectState: ObjectState;
    contactId: number;
    isPrimary: boolean;
    contactPerson: string;
    designationId: number;
    emailAddress: string;
    contactNumber: string;
}
