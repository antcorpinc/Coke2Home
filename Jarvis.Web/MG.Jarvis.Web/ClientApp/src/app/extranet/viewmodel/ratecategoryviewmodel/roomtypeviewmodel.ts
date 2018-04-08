import { IObjectWithState } from '../../../common/iobjectwithstate';
import { ObjectState } from '../../../common/enums';

export class RoomTypeViewModel implements IObjectWithState {
    id: number;
   roomId: number;
   isSelected: boolean;
   objectState: ObjectState;
}
