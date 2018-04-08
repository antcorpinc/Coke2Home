import { ApplicationRoleViewModel } from './applicationroleviewmodel';
import { HotelViewModel } from './hotelviewmodel';

export class HotelUserListViewModel {
    id: string;
    profilePictureUri: string;
    userName: string;
    hotels: HotelViewModel[];
    designation: string;
    email: string;
    userApplicationRole: ApplicationRoleViewModel[];
    activationDate: string;
    deActivationDate: string;
    isActive: boolean;
}

