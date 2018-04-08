import { HotelBrandViewModel } from '../../../common/viewmodels/hotelbrandviewmodel';
import { HotelChainViewModel } from '../../../common/viewmodels/hotelchainviewmodel';

export class MgHotelViewModel {
  id: string;
  profilePictureUri: string;
  firstName: string;
  hotelName: string;
  lastName: string;
  userName: string;
  designationId: number;
  roleId: number;
  userType: number;
  hotelChainId?: number;
  hotelBrandIds?: number[];
 // employeeId: number;
  email: string;
  // applications: ApplicationRoleViewModel[];
  activationDate: string;
  disabled: boolean;
}
