import { HotelBrandViewModel } from '../../../common/viewmodels/hotelbrandviewmodel';
import { HotelChainViewModel } from '../../../common/viewmodels/hotelchainviewmodel';

export class HotelUserViewModel {
  id: string;
  profilePictureUri: string;
  brandId: string;
  chainId: string;
  firstName: string;
  hotelId: number[];
  lastName: string;
  userName: string;
  designationId: string;
  extranetRoleId: string;
  email: string;
  activationDate: string;
  deActivationDate: string;
  // disabled: boolean;
  isActive: boolean;
  createdBy: string;
  updatedBy: string;
}
