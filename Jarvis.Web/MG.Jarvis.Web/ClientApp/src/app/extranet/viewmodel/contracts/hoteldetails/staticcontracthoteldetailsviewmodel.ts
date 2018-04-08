import { ObjectState, ContractType } from '../../../../common/enums';
import { HotelDetailsViewModel } from '../../hoteldetailsviewmodel/hoteldetailsviewmodel';

export class StaticContractHotelDetailsVieModel {
    templateId: number;
    contractId: number;
    name: string;
    startDate: string;
    endDate: string;
    objectState: ObjectState;
    hotelDetailsViewModel: HotelDetailsViewModel;
    contractType: ContractType;
    isDeleted: boolean;
}
