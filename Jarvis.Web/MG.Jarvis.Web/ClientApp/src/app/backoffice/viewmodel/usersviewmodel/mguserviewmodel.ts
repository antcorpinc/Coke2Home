import { DepartmentViewModel } from './departmentviewmodel';
import { ApplicationRoleViewModel } from './applicationroleviewmodel';
import {ApplicationRoleIdViewModel} from './applicationroleidviewmodel';

export class MgUserViewModel {
  id: string;
  profilePictureUri: string;
  firstName: string;
  lastName: string;
  userName: string;
  employeeId: number;
  email: string;
   departments: string[];
  userApplicationRole: ApplicationRoleIdViewModel[];
  activationDate: string;
  deActivationDate: string;
  isActive: boolean;
  createdBy: string;
  updatedBy: string;

}
