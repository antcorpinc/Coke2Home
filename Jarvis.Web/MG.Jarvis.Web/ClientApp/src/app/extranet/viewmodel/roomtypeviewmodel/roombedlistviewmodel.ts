import { IObjectWithState } from '../../../common/iobjectwithstate';
import { ObjectState } from '../../../common/enums';
export class RoomBedListViewModel  implements IObjectWithState {
  objectState: ObjectState;
  id: number;
  bedId: number;
  noOfBeds: number;
}
