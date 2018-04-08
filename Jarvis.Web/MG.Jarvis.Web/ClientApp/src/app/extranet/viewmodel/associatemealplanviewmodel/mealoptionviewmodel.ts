import { CuisineViewModel } from './cuisineviewmodel';
import { IObjectWithState } from '../../../common/iobjectwithstate';
import { ObjectState } from '../../../common/enums';

export class MealOptionViewModel implements IObjectWithState {
    objectState: ObjectState;
    currencyId: number;
    price: number;
    cuisineOptions: CuisineViewModel[];
}
