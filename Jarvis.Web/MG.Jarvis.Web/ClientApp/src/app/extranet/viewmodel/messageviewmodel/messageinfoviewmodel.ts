import { IObjectWithState } from '../../../common/iobjectwithstate';
import { ObjectState } from '../../../common/enums';

export class MessageInfoViewModel implements IObjectWithState {
  objectState: ObjectState;
  hotelId: number;
  messageId: number;
  isActive: boolean;
  messageTypeId: number;
  lastModifiedBy: string;
  messageTitle: string;
  startDate: string;
  endDate: string;
  messageDescription: string;
}
