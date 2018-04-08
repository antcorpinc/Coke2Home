import { IObjectWithState } from '../../../common/iobjectwithstate';
import { ObjectState } from '../../../common/enums';
import { RoomBedListViewModel } from './roombedlistviewmodel';
export class RoomBedOptionsViewModel implements IObjectWithState  {
  constructor() {
    this.roomBedList = new Array<RoomBedListViewModel>();
  }
  objectState: ObjectState;
  occupancyId: number;
  roomBedList: Array<RoomBedListViewModel>;
}
