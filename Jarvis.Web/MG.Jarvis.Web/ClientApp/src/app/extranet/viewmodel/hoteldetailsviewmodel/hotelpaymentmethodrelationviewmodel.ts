import { ObjectState } from '../../../common/enums';
import { IObjectWithState } from '../../../common/iobjectwithstate';

export class HotelPaymentMethodRelationViewModel implements IObjectWithState {
    objectState: ObjectState;
    hotelPaymentMethodRelationId: number;
    paymentMethodId: number;
    currencyId: number;
    rateTypeId: number;
}
