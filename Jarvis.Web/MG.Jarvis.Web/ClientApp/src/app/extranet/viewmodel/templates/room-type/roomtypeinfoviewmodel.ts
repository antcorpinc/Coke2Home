import { ObjectState, EntityState } from '../../../../common/enums';
import { IObjectWithState } from '../../../../common/iobjectwithstate';

export class Roomtypeinfoviewmodel {
  id: number;
  name: string;
  code: string;
  symbol: string;
  isSelected: boolean;
  isConfigurable: boolean;
  status: EntityState;
  objectState: ObjectState;
}
export class TemplateRoomtypeinfoviewmodel implements IObjectWithState {
  roomFields: Roomtypeinfoviewmodel[];
  id: number;
  name: string;
  nameItemId: number;
  isActive: boolean;
  isDeleted: boolean;
  createdBy: null;
  createdDate: string;
  objectState: ObjectState;
  isPublished: boolean;
}
