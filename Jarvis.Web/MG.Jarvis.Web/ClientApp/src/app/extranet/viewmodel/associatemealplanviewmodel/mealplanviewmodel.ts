import { MealOptionViewModel } from './mealoptionviewmodel';
import { IObjectWithState } from '../../../common/iobjectwithstate';
import { ObjectState } from '../../../common/enums';

export class MealPlanViewModel  implements IObjectWithState {
    objectState: ObjectState;
    hotelId: number;
    mealId: number;
    mealName: string;
    isSelected: boolean;
    mealPlanOptions: MealOptionViewModel;
}
