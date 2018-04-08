import { IObjectWithState } from '../../../common/iobjectwithstate';
import { ObjectState } from '../../../common/enums';

export class CuisineViewModel implements IObjectWithState {
    objectState: ObjectState;
    id: number;
    cusine: string;
    isSelected: boolean;
}
