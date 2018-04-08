import { ObjectState, ContractType } from '../../../../common/enums';
import { HotelDetailsViewModel } from '../../hoteldetailsviewmodel/hoteldetailsviewmodel';

export class ContractHotelDetailsViewModel {
    id: number;
    name: string;
    startDate: String;
    endDate: string;
    objectState: ObjectState;
    hotelId: number;
    contractType: ContractType;
    pdfLink: string;
}
