import { Component, OnInit } from '@angular/core';
import { CONSTANTS } from '../../../../common/constants';
import { Router, ActivatedRoute } from '@angular/router';
import { UserDataService } from '../../../common/backoffice-shared/services/user-data.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AgentInfoViewModel } from '../../../viewmodel/usersviewmodel/agentinfoviewmodel';
import { AgencyViewModel } from '../../../viewmodel/usersviewmodel/agencyviewmodel';
import { DesignationViewModel } from '../../../viewmodel/usersviewmodel/designationviewmodel';
import { MgRoleViewModel } from '../../../viewmodel/usersviewmodel/mgrolelistviewmodel';
import { BackofficeLookupService } from '../../../common/backoffice-shared/services/backoffice-lookup';
import { BranchViewModel } from '../../../viewmodel/usersviewmodel/branchviewmodel';
import { Observable } from 'rxjs/Observable';
import {startWith} from 'rxjs/operators/startWith';
import {map} from 'rxjs/operators/map';
import { MatSnackBar } from '@angular/material';


@Component({
  selector: 'app-agent-user-info',
  templateUrl: './agent-user-info.component.html',
  styleUrls: ['./agent-user-info.component.css']
})

export class AgentUserInfoComponent implements OnInit {
  operation: string;
  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  hotelId: number;
  agentId: number;
  agentInfo: AgentInfoViewModel = <AgentInfoViewModel>{};
  agentForm: FormGroup;
  designationList: DesignationViewModel[];
  roleList: MgRoleViewModel[];
  agencyList: AgencyViewModel[] = [];
  branchList: BranchViewModel[] = [];
  selectedStartDate: string;
  public todaysDate = new Date();
  minDate: string;
  filteredOptions: Observable<AgencyViewModel[]>;
  filteredBranchOptions: Observable<BranchViewModel[]>;

  constructor(private router: Router, private activatedRoute: ActivatedRoute,
    public lookupService: BackofficeLookupService,
    private userDataService: UserDataService,
    private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.operation = this.activatedRoute.snapshot.params['operation'];
    this.agentId = this.activatedRoute.snapshot.params['id'];

    this.agentForm = new FormGroup({
      agency: new FormControl('', Validators.required),
      branch: new FormControl('' , Validators.required),
      userName: new FormControl('', Validators.required),
      designationId: new FormControl('', Validators.required),
      email: new FormControl('', Validators.required),
      contactNumber: new FormControl('', Validators.required),
      b2BRoleId: new FormControl('', Validators.required),
      activationDate: new FormControl('', Validators.required),
    });

    this.getDesignations();
    this.getRoles();
    this.getAgencies();

    this.filteredOptions = this.agentForm.controls.agency.valueChanges
    .pipe(
      startWith(''),
      map(val => this.filter(val.toString()))
    );

    this.filteredBranchOptions = this.agentForm.controls.branch.valueChanges
    .pipe(
      startWith(''),
      map(val => this.filterBranch(val.toString()))
    );
  }

  filter(val: string): AgencyViewModel[] {
    if (this.agencyList.length > 0 ) {
    return this.agencyList.filter(option =>
       option.name.toString().toLowerCase().indexOf(val.toString().toLowerCase()) === 0);
    }
  }

  filterBranch(val: string): BranchViewModel[] {
    if (this.branchList.length > 0) {
    return this.branchList.filter(option =>
       option.name.toString().toLowerCase().indexOf(val.toString().toLowerCase()) === 0);
    }
  }

  displayFn(val: AgencyViewModel) {
    return val ? val.name + ' - ' + val.code : val ;
  }

  displayBranchFn(val: BranchViewModel) {
    return val ? val.name : val ;
  }

  getDesignations() {
    this.lookupService.getDesignationByType(CONSTANTS.userType.agentuser).subscribe(designationData =>
      this.designationList = designationData
    );
  }

  getRoles() {
    this.lookupService.getRolesByApplicationName(CONSTANTS.application.b2b).subscribe(data =>
      this.roleList = data
    );
  }

  getAgencies() {
    this.agencyList = this.activatedRoute.snapshot.data['agencies'];
  }

  getBranches(agencyId) {
    this.branchList.splice(0, this.branchList.length);
    // console.log('getBranches - Agency ID: ', agencyId);
    this.agentForm.get('branch').setValue('');
    if (agencyId !== null) {
      this.lookupService.getAgencyBranches(agencyId).subscribe(data =>
        this.branchList = data
      ); }
  }

  saveAgent() {
    const tempAgent = Object.assign({}, this.agentInfo, this.agentForm.value);
    // console.log('tempAgent: ', tempAgent);
    const agent: AgentInfoViewModel = <AgentInfoViewModel>{};
    agent.designationId = tempAgent.designationId;
    agent.agencyId = tempAgent.agency.id;
    agent.branchId = tempAgent.branch.id;
    agent.contactNumber = tempAgent.contactNumber;
    agent.b2BRoleId = tempAgent.b2BRoleId;
    // agent.firstName = tempAgent.firstName;
    // agent.lastName = tempAgent.lastName;
    agent.userName = tempAgent.userName ;
    agent.email = tempAgent.email;
    agent.activationDate = tempAgent.activationDate.toISOString();
    if (tempAgent.activationDate.toISOString() > this.todaysDate.toISOString()) {
      agent.isActive = false;
    } else {
      agent.isActive = true;
    }
    agent.createdBy = 'sa';
    agent.updatedBy = 'sa';
    // console.log('agent save : ', agent);
    this.userDataService.createAgentUser(agent as AgentInfoViewModel)
      .subscribe(data => {
        console.log('createAgentUser Result:' + data);
        if (data.succeeded === true ) {
          this.snackBar.open('Agent Saved Successfully', '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
          this.router.navigate(['/usermgmt/agentusers']);
        } else {
          // TODO: Need to check how we are doing error handling.
          this.snackBar.open('Error occourred while saving Agent. ' + data.errors[0].description ,
          '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar'});
        }
      });
  }

  cancel() {
    window.scrollTo(0, 0);
    this.router.navigate(['/usermgmt/agentusers']);
  }
}
