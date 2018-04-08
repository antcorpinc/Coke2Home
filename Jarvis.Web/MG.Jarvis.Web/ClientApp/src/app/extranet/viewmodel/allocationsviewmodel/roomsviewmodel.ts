import { ObjectState } from '../../../common/enums';
import { RateCategoryViewModel } from './ratecategoryviewmodel';

export class RoomsViewModel {
  roomId: number;
  roomName: string;
  objectState: ObjectState;
  roomSold: RoomSoldViewModel[];
  rateCategory: RateCategoryViewModel[];
}

export class RoomSoldViewModel {
  date:string;
  roomSold: number;
}
