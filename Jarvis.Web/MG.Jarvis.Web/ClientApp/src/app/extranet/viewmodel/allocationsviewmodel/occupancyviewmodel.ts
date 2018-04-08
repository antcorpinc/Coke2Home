import { ObjectState } from '../../../common/enums';
export class OccupancyViewModel {
    occupancyName: string;
    objectState: ObjectState;
    occupancyPrice: OccupancyPrice[];
}
export class OccupancyPrice {
    date: string;
    price: number;
}