import { ApplicationRoleViewModel } from './applicationroleviewmodel';
import { DepartmentViewModel } from './departmentviewmodel';

export class MgUsersListViewModel {
    id: string;
    profilePictureUri: string;
    firstName: string;
    lastName: string;
    userName: string;
    employeeId: number;
    email: string;
    departments: DepartmentViewModel[];
    userApplicationRole: ApplicationRoleViewModel[];
    activationDate: string;
    deActivationDate: string;
    isActive: boolean;
  }
