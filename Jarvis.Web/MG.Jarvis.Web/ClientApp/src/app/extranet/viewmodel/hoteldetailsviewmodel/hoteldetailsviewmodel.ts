import { ContactDetailsViewModel } from './contactdetailsviewmodel';
import { TaxesViewModel } from './taxesviewmodel';
import { IObjectWithState } from '../../../common/iobjectwithstate';
import { ObjectState } from '../../../common/enums';
import { HotelPaymentMethodRelationViewModel } from './hotelpaymentmethodrelationviewmodel';

export class HotelDetailsViewModel implements IObjectWithState {
  objectState: ObjectState;
  hotelId: number;
  hotelCode?: string;
  isActive: boolean;
  hotelName: string;
  hotelChainId?: number;
  hotelBrandId?: number;
  hotelTypeId: number;
  address1: string;
  address2?: string;
  countryId: number;
  cityId: number;
  zipCode: string;
  latitude: number;
  longitude: number;
  location: string;
  starRatingId: number;
  mgPoint?: number;
  shortDescription: string;
  longDescription?: string;
  contactDetails: ContactDetailsViewModel[];
  website?: string;
  reservationEmail?: string;
  reservationContactNo?: string;
  hotelPaymentMethodRelation: HotelPaymentMethodRelationViewModel;
  isExtranetAccess: boolean;
  isChannelManagerConnectivity: boolean;
  channelManagerId?: number;
  taxDetails: TaxesViewModel[];
  checkInFrom: string;
  checkOutTo: string;
}
