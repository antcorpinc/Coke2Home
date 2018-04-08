import { ContactDetailsViewModel } from '../hoteldetailsviewmodel/contactdetailsviewmodel';
import { PromoContractsViewModel } from './promocontractsviewmodel';

export class ContractsListViewModel {
    id: number;
    name: string;
    startDate: string;
    endDate: string;
    status: string;
    hotelName: string;
    location: string;
    designation: string;
    contractType: string;
    contactPerson: string;
    contacts: ContactDetailsViewModel;
    promoContracts: PromoContractsViewModel;
    isExpanded: boolean;
  }
