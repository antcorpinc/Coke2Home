webpackJsonp(["user-mgmt.module"],{

/***/ "../../../../../src/app/backoffice/common/backoffice-shared/services/application-resolver.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ApplicationResolverService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__backoffice_lookup__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/backoffice-lookup.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var ApplicationResolverService = (function () {
    function ApplicationResolverService(backofficeLookupService) {
        this.backofficeLookupService = backofficeLookupService;
    }
    ApplicationResolverService.prototype.resolve = function (route, state) {
        return this.backofficeLookupService.getApplications();
    };
    ApplicationResolverService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__backoffice_lookup__["a" /* BackofficeLookupService */]])
    ], ApplicationResolverService);
    return ApplicationResolverService;
}());



/***/ }),

/***/ "../../../../../src/app/backoffice/common/backoffice-shared/services/department-resolver.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return DepartmentResolverService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__backoffice_lookup__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/backoffice-lookup.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var DepartmentResolverService = (function () {
    function DepartmentResolverService(backOfficeLookupService) {
        this.backOfficeLookupService = backOfficeLookupService;
    }
    DepartmentResolverService.prototype.resolve = function (route, state) {
        return this.backOfficeLookupService.getDepartments();
    };
    DepartmentResolverService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__backoffice_lookup__["a" /* BackofficeLookupService */]])
    ], DepartmentResolverService);
    return DepartmentResolverService;
}());



/***/ }),

/***/ "../../../../../src/app/backoffice/common/backoffice-shared/services/designation-resolver.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return DesignationResolverService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__backoffice_lookup__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/backoffice-lookup.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__common_constants__ = __webpack_require__("../../../../../src/app/common/constants.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var DesignationResolverService = (function () {
    function DesignationResolverService(backofficeLookupService) {
        this.backofficeLookupService = backofficeLookupService;
        this.type = __WEBPACK_IMPORTED_MODULE_2__common_constants__["a" /* CONSTANTS */].userType.hoteluser;
    }
    DesignationResolverService.prototype.resolve = function (route, state) {
        return this.backofficeLookupService.getDesignationByType(this.type);
    };
    DesignationResolverService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__backoffice_lookup__["a" /* BackofficeLookupService */]])
    ], DesignationResolverService);
    return DesignationResolverService;
}());



/***/ }),

/***/ "../../../../../src/app/backoffice/common/backoffice-shared/services/hotel-resolver.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return HotelResolverService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__backoffice_lookup__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/backoffice-lookup.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var HotelResolverService = (function () {
    function HotelResolverService(backOfficeLookUpService) {
        this.backOfficeLookUpService = backOfficeLookUpService;
    }
    HotelResolverService.prototype.resolve = function (route, state) {
        return this.backOfficeLookUpService.getIndividualHotels();
    };
    HotelResolverService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__backoffice_lookup__["a" /* BackofficeLookupService */]])
    ], HotelResolverService);
    return HotelResolverService;
}());



/***/ }),

/***/ "../../../../../src/app/backoffice/common/backoffice-shared/services/role-resolver.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return RoleResolverService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__backoffice_lookup__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/backoffice-lookup.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__common_constants__ = __webpack_require__("../../../../../src/app/common/constants.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var RoleResolverService = (function () {
    function RoleResolverService(backofficeLookupService) {
        this.backofficeLookupService = backofficeLookupService;
        this.applicationName = __WEBPACK_IMPORTED_MODULE_2__common_constants__["a" /* CONSTANTS */].application.extranet;
    }
    RoleResolverService.prototype.resolve = function (route, state) {
        return this.backofficeLookupService.getRolesByApplicationName(this.applicationName);
    };
    RoleResolverService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__backoffice_lookup__["a" /* BackofficeLookupService */]])
    ], RoleResolverService);
    return RoleResolverService;
}());



/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/agent-user/agent-user-info/agent-user-info.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/agent-user/agent-user-info/agent-user-info.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"container-fluid pt-4\">\n  <div class=\"customBreadcrumb mb-4\">\n    <span>Agents </span>\n    <span>&gt; Create New Agent</span>\n    <span class=\"mandatoryInfo\">Indicates Mandatory Fields</span>\n  </div>\n  <h1 class=\"mainHeading mb-2\">Create New Agent</h1>\n\n  <form [formGroup]=\"agentForm\" (ngSubmit)=\"saveAgent()\">\n\n    <div class=\"row\">\n      <div class=\"form-group col-md-4 col-lg-3 mb-0\">\n        <mat-form-field>\n          <input type=\"text\" matInput placeholder=\"Search by Agency Name/Code\" formControlName=\"agency\" [matAutocomplete]=\"auto\">\n          <mat-autocomplete #auto=\"matAutocomplete\" [displayWith]=\"displayFn\">\n            <mat-option *ngFor=\"let agency of filteredOptions | async\" [value]=\"agency\" (onSelectionChange)=\"getBranches(agency.id)\">\n              {{ agency.name }} - {{agency.code}}\n            </mat-option>\n          </mat-autocomplete>\n        </mat-form-field>\n      </div>\n\n      <div class=\"form-group col-md-4 col-lg-3 mb-0 \">\n        <mat-form-field>\n          <input matInput placeholder=\"Search by Branch Name\" name=\"branch\" formControlName=\"branch\" [matAutocomplete]=\"autoBranch\">\n          <mat-autocomplete #autoBranch=\"matAutocomplete\" [displayWith]=\"displayBranchFn\">\n            <mat-option *ngFor=\"let branch of filteredBranchOptions | async\" [value]=\"branch\">\n              {{ branch.name }}\n            </mat-option>\n          </mat-autocomplete>\n        </mat-form-field>\n      </div>\n    </div>\n\n    <div class=\"row\">\n      <div class=\"col-md-2\">\n        <mat-icon class=\"userImage\">account_circle</mat-icon>\n        <button class=\"deletePhoto\" mat-raised-button title=\"Delete Image\">\n          <i class=\"fa fa-times-thin\"></i>\n        </button>\n        <div class=\"image-upload\">\n          <label for=\"file-input\">\n            <img src=\"assets/uploadPhoto.png\" title=\"Upload Image\" />\n          </label>\n          <input id=\"file-input\" type=\"file\" />\n        </div>\n      </div>\n    </div>\n\n    <div class=\"row\">\n      <div class=\"form-group col-md-4 col-lg-3\">\n        <mat-form-field class=\"example-full-width\">\n          <input matInput placeholder=\"User Name\" id=\"userName\" formControlName=\"userName\" required />\n        </mat-form-field>\n      </div>\n      <div class=\"form-group col-md-4 col-lg-3\">\n        <mat-form-field>\n          <mat-select placeholder=\"Designation\" formControlName=\"designationId\" required>\n            <mat-option [value]=\"null\">Select</mat-option>\n            <mat-option *ngFor=\"let designation of designationList\" [value]=\"designation.designationId\">{{designation.title}}</mat-option>\n          </mat-select>\n        </mat-form-field>\n      </div>\n\n      <div class=\"form-group col-md-4 col-lg-3\">\n        <mat-form-field class=\"example-full-width\">\n          <input matInput placeholder=\"Email ID\" id=\"emailID\" formControlName=\"email\" pattern=\"\\w+@\\w+\\.\\w+(,\\s*\\w+@\\w+\\.\\w+)*\" required\n          />\n        </mat-form-field>\n      </div>\n    </div>\n\n    <div class=\"row\">\n      <div class=\"pt-1 form-group col-md-4 col-lg-3\">\n        <mat-form-field class=\"example-full-width\">\n          <input matInput placeholder=\"Contact Number\" id=\"contactNumber\" formControlName=\"contactNumber\" required\n          pattern=\"[0-9+-]+(,\\s*[0-9+-]+)*\" type=\"tel\" maxlength=\"15\"/>\n        </mat-form-field>\n      </div>\n\n      <div class=\"pt-1 form-group col-md-4 col-lg-3\">\n        <mat-form-field>\n          <mat-select placeholder=\"Role\" formControlName=\"b2BRoleId\" required>\n            <mat-option [value]=\"null\">Select</mat-option>\n            <mat-option *ngFor=\"let role of roleList\" [value]=\"role.id\">{{role.name}}</mat-option>\n          </mat-select>\n        </mat-form-field>\n      </div>\n    </div>\n\n    <div class=\"row\">\n      <div class=\"col-md-3\">\n        <mat-form-field class=\"example-full-width\">\n          <input matInput [matDatepicker]=\"activationDate\" placeholder=\"Activation Date\" formControlName=\"activationDate\" [min]=\"todaysDate\"\n            require>\n          <mat-datepicker-toggle matSuffix [for]=\"activationDate\"></mat-datepicker-toggle>\n          <mat-datepicker #activationDate></mat-datepicker>\n        </mat-form-field>\n      </div>\n    </div>\n\n    <div class=\"row\">\n      <div class=\"col-md-12 controlButtons mt-5 mb-4\">\n        <button title=\"Save\" type=\"submit\" class=\"genericButton activeButton mat-primary mr-2\" [disabled]=\"!agentForm.valid\" mat-raised-button>Save</button>\n        <button title=\"Cancel\" type=\"submit\" class=\"genericButton defaultButton\" mat-raised-button (click)=\"cancel()\">Cancel</button>\n      </div>\n    </div>\n  </form>\n\n</div>\n"

/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/agent-user/agent-user-info/agent-user-info.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AgentUserInfoComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__common_constants__ = __webpack_require__("../../../../../src/app/common/constants.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__common_backoffice_shared_services_user_data_service__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/user-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__angular_forms__ = __webpack_require__("../../../forms/esm5/forms.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__common_backoffice_shared_services_backoffice_lookup__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/backoffice-lookup.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6_rxjs_operators_startWith__ = __webpack_require__("../../../../rxjs/_esm5/operators/startWith.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7_rxjs_operators_map__ = __webpack_require__("../../../../rxjs/_esm5/operators/map.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__angular_material__ = __webpack_require__("../../../material/esm5/material.es5.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};









var AgentUserInfoComponent = (function () {
    function AgentUserInfoComponent(router, activatedRoute, lookupService, userDataService, snackBar) {
        this.router = router;
        this.activatedRoute = activatedRoute;
        this.lookupService = lookupService;
        this.userDataService = userDataService;
        this.snackBar = snackBar;
        this.edit = __WEBPACK_IMPORTED_MODULE_1__common_constants__["a" /* CONSTANTS */].operation.edit;
        this.create = __WEBPACK_IMPORTED_MODULE_1__common_constants__["a" /* CONSTANTS */].operation.create;
        this.agentInfo = {};
        this.agencyList = [];
        this.branchList = [];
        this.todaysDate = new Date();
    }
    AgentUserInfoComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.operation = this.activatedRoute.snapshot.params['operation'];
        this.agentId = this.activatedRoute.snapshot.params['id'];
        this.agentForm = new __WEBPACK_IMPORTED_MODULE_4__angular_forms__["FormGroup"]({
            agency: new __WEBPACK_IMPORTED_MODULE_4__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_4__angular_forms__["Validators"].required),
            branch: new __WEBPACK_IMPORTED_MODULE_4__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_4__angular_forms__["Validators"].required),
            userName: new __WEBPACK_IMPORTED_MODULE_4__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_4__angular_forms__["Validators"].required),
            designationId: new __WEBPACK_IMPORTED_MODULE_4__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_4__angular_forms__["Validators"].required),
            email: new __WEBPACK_IMPORTED_MODULE_4__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_4__angular_forms__["Validators"].required),
            contactNumber: new __WEBPACK_IMPORTED_MODULE_4__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_4__angular_forms__["Validators"].required),
            b2BRoleId: new __WEBPACK_IMPORTED_MODULE_4__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_4__angular_forms__["Validators"].required),
            activationDate: new __WEBPACK_IMPORTED_MODULE_4__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_4__angular_forms__["Validators"].required),
        });
        this.getDesignations();
        this.getRoles();
        this.getAgencies();
        this.filteredOptions = this.agentForm.controls.agency.valueChanges
            .pipe(Object(__WEBPACK_IMPORTED_MODULE_6_rxjs_operators_startWith__["a" /* startWith */])(''), Object(__WEBPACK_IMPORTED_MODULE_7_rxjs_operators_map__["a" /* map */])(function (val) { return _this.filter(val.toString()); }));
        this.filteredBranchOptions = this.agentForm.controls.branch.valueChanges
            .pipe(Object(__WEBPACK_IMPORTED_MODULE_6_rxjs_operators_startWith__["a" /* startWith */])(''), Object(__WEBPACK_IMPORTED_MODULE_7_rxjs_operators_map__["a" /* map */])(function (val) { return _this.filterBranch(val.toString()); }));
    };
    AgentUserInfoComponent.prototype.filter = function (val) {
        if (this.agencyList.length > 0) {
            return this.agencyList.filter(function (option) {
                return option.name.toString().toLowerCase().indexOf(val.toString().toLowerCase()) === 0;
            });
        }
    };
    AgentUserInfoComponent.prototype.filterBranch = function (val) {
        if (this.branchList.length > 0) {
            return this.branchList.filter(function (option) {
                return option.name.toString().toLowerCase().indexOf(val.toString().toLowerCase()) === 0;
            });
        }
    };
    AgentUserInfoComponent.prototype.displayFn = function (val) {
        return val ? val.name + ' - ' + val.code : val;
    };
    AgentUserInfoComponent.prototype.displayBranchFn = function (val) {
        return val ? val.name : val;
    };
    AgentUserInfoComponent.prototype.getDesignations = function () {
        var _this = this;
        this.lookupService.getDesignationByType(__WEBPACK_IMPORTED_MODULE_1__common_constants__["a" /* CONSTANTS */].userType.agentuser).subscribe(function (designationData) {
            return _this.designationList = designationData;
        });
    };
    AgentUserInfoComponent.prototype.getRoles = function () {
        var _this = this;
        this.lookupService.getRolesByApplicationName(__WEBPACK_IMPORTED_MODULE_1__common_constants__["a" /* CONSTANTS */].application.b2b).subscribe(function (data) {
            return _this.roleList = data;
        });
    };
    AgentUserInfoComponent.prototype.getAgencies = function () {
        this.agencyList = this.activatedRoute.snapshot.data['agencies'];
    };
    AgentUserInfoComponent.prototype.getBranches = function (agencyId) {
        var _this = this;
        this.branchList.splice(0, this.branchList.length);
        // console.log('getBranches - Agency ID: ', agencyId);
        this.agentForm.get('branch').setValue('');
        if (agencyId !== null) {
            this.lookupService.getAgencyBranches(agencyId).subscribe(function (data) {
                return _this.branchList = data;
            });
        }
    };
    AgentUserInfoComponent.prototype.saveAgent = function () {
        var _this = this;
        var tempAgent = Object.assign({}, this.agentInfo, this.agentForm.value);
        // console.log('tempAgent: ', tempAgent);
        var agent = {};
        agent.designationId = tempAgent.designationId;
        agent.agencyId = tempAgent.agency.id;
        agent.branchId = tempAgent.branch.id;
        agent.contactNumber = tempAgent.contactNumber;
        agent.b2BRoleId = tempAgent.b2BRoleId;
        // agent.firstName = tempAgent.firstName;
        // agent.lastName = tempAgent.lastName;
        agent.userName = tempAgent.userName;
        agent.email = tempAgent.email;
        agent.activationDate = tempAgent.activationDate.toISOString();
        if (tempAgent.activationDate.toISOString() > this.todaysDate.toISOString()) {
            agent.isActive = false;
        }
        else {
            agent.isActive = true;
        }
        agent.createdBy = 'sa';
        agent.updatedBy = 'sa';
        // console.log('agent save : ', agent);
        this.userDataService.createAgentUser(agent)
            .subscribe(function (data) {
            console.log('createAgentUser Result:' + data);
            if (data.succeeded === true) {
                _this.snackBar.open('Agent Saved Successfully', '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar' });
                _this.router.navigate(['/usermgmt/agentusers']);
            }
            else {
                // TODO: Need to check how we are doing error handling.
                _this.snackBar.open('Error occourred while saving Agent. ' + data.errors[0].description, '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar' });
            }
        });
    };
    AgentUserInfoComponent.prototype.cancel = function () {
        window.scrollTo(0, 0);
        this.router.navigate(['/usermgmt/agentusers']);
    };
    AgentUserInfoComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-agent-user-info',
            template: __webpack_require__("../../../../../src/app/backoffice/user-mgmt/agent-user/agent-user-info/agent-user-info.component.html"),
            styles: [__webpack_require__("../../../../../src/app/backoffice/user-mgmt/agent-user/agent-user-info/agent-user-info.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_2__angular_router__["Router"], __WEBPACK_IMPORTED_MODULE_2__angular_router__["ActivatedRoute"],
            __WEBPACK_IMPORTED_MODULE_5__common_backoffice_shared_services_backoffice_lookup__["a" /* BackofficeLookupService */],
            __WEBPACK_IMPORTED_MODULE_3__common_backoffice_shared_services_user_data_service__["a" /* UserDataService */],
            __WEBPACK_IMPORTED_MODULE_8__angular_material__["F" /* MatSnackBar */]])
    ], AgentUserInfoComponent);
    return AgentUserInfoComponent;
}());



/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/agent-user/agent-user-list/agent-user-list.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ".usernameTH{\r\n    width: 15%;\r\n}\r\n.agencyTH{\r\n    width: 14%;\r\n    padding-left: 0;\r\n    padding-right: 0;\r\n}\r\n.branchTH{\r\n    width:10%;\r\n    padding-left: 0;\r\n    padding-right: 0;\r\n}\r\n.designationTH{\r\n    width:10%;\r\n}\r\n.emailTH{\r\n    width:13%;\r\n}\r\n.userApplicationRoleTH{\r\n    width:10%;\r\n}\r\n.activationTH{\r\n    width: 11%;\r\n    padding-left: 0;\r\n    padding-right: 0;\r\n}\r\n.userStatusTH{\r\n    width: 8%;\r\n    padding-left: 5px;\r\n    padding-right: 0;\r\n}\r\n.userActionTH{\r\n    width:9%;\r\n}", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/agent-user/agent-user-list/agent-user-list.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"container-fluid pt-4\">\n  <h1 class=\"mainHeading pb-2 mb-4 mt-2\">Agents</h1>\n<form [formGroup]=\"searchUsers\" (ngSubmit)=\"findUsers(searchUsers.get('searchText').value,searchUsers.get('startDate').value,searchUsers.get('endDate').value)\"\nclass=\"w-100\">\n\n  <div class=\"blueBackground pt-1 pb-1 pl-0 pr-2 alignItemCenter\">\n    <div class=\"row formSections borderBottomNone p-0 m-1\">\n     \n    <div class=\"col-md-2 d-flex pr-0\">\n      <label class=\"optionsList mb-0 alignItemCenter pr-3\">From:</label>\n            <mat-form-field>\n              <mat-datepicker-toggle matSuffix [for]=\"sdate\">\n                  <mat-icon matDatepickerToggleIcon>\n                      <i class=\"fa fa-calendar\" aria-hidden=\"true\"></i>\n                    </mat-icon>\n              </mat-datepicker-toggle>\n              <input matInput [matDatepicker]=\"sdate\" placeholder=\"DD-MMM-YY\" formControlName=\"startDate\">\n              <mat-datepicker #sdate></mat-datepicker>\n            </mat-form-field>\n          </div>\n\n          <div class=\"col-md-2 d-flex pr-2 pl-4\">\n          <label class=\"optionsList mb-0 alignItemCenter pr-3\">To:</label>\n                  <mat-form-field>\n                    <input matInput [matDatepicker]=\"enddate\" placeholder=\"DD-MMM-YY\" formControlName=\"endDate\" [min]=\"searchUsers.get('startDate').value\">\n                    <mat-datepicker-toggle matSuffix [for]=\"enddate\">\n                        <mat-icon matDatepickerToggleIcon>\n                            <i class=\"fa fa-calendar\" aria-hidden=\"true\"></i>\n                          </mat-icon>\n                    </mat-datepicker-toggle>\n                    <mat-datepicker #enddate></mat-datepicker>\n                  </mat-form-field>  \n          </div>\n\n          <div class=\"col-md-7 pl-4 pr-4\">\r\n            <mat-form-field>\r\n              <input matInput placeholder=\"Search by User Name, Agency Name, Agency Code, Branch Name, Email Id, Designation, Roles, Activation date \" formControlName=\"searchText\" (keydown.backspace)=\"checkIsInputCleared()\">\r\n            </mat-form-field>\r\n          </div>\n\n          <div class=\"col-md-1 alignItemCenter pl-1 controlButtons\">\r\n            <button title=\"Search\" type=\"submit\" class=\"genericButton genericSmallButton activeButton mat-primary mt-1\" mat-raised-button>Search</button>\r\n          </div>\n\n        </div>\n      </div>\n</form>\n<div class=\"row\">\n    <div class=\"col-md-12 pt-4 mt-2 pb-3 mb-1 controlButtons\">\n    <button title=\"Create New Agent\" type=\"submit\" class=\"pt-2 pb-2 genericButton genericSmallButton defaultButton createNew\" mat-raised-button\n      (click)=\"createAgent()\">\n      <i class=\"fa fa-plus-circle\" aria-hidden=\"true\"></i><span>Create New Agent</span></button>\n    </div>\n</div>\n<mat-table #table [dataSource]= '!isSearch ? dataSource: filteredData' matSort (matSortChange)=\"sortData($event)\" matSortActive=\"activationDate\" matSortDirection=\"desc\" class=\"flexNone genericTable\">\n  <ng-container matColumnDef=\"userName\">\n    <mat-header-cell class=\"usernameTH alignItemCenter\" *matHeaderCellDef mat-sort-header> User Name </mat-header-cell>\n      <mat-cell class =\"usernameTH\" *matCellDef=\"let element\"><div class=\"d-flex\"><mat-icon  class=\"userIcon alignItemCenter\">account_circle</mat-icon><span class=\"d-flex pl-4 alignItemCenter\">{{element.userName}}</span></div></mat-cell>\n    </ng-container>\n\n    <ng-container matColumnDef=\"agencyName\" >\n      <mat-header-cell class =\"agencyTH text-center\" *matHeaderCellDef mat-sort-header> Agency Name - Code </mat-header-cell>\n      <mat-cell class =\"agencyTH\" *matCellDef=\"let element\"> {{element.agencyName}}-{{element.agencyCode}} </mat-cell>\n    </ng-container>\n\n    <ng-container matColumnDef=\"branchName\">\n      <mat-header-cell class =\"branchTH text-center\" *matHeaderCellDef mat-sort-header > Branch Name </mat-header-cell>\n      <mat-cell class =\"branchTH\" *matCellDef=\"let element\"> {{element.branchName}} </mat-cell>\n    </ng-container>\n\n    <ng-container matColumnDef=\"designation\" >\n      <mat-header-cell class =\"designationTH text-center\" *matHeaderCellDef mat-sort-header > Designation </mat-header-cell>\n      <mat-cell class =\"designationTH\" *matCellDef=\"let element\"> {{element.designation}} </mat-cell>\n    </ng-container>\n\n    <ng-container matColumnDef=\"email\">\n      <mat-header-cell class =\"emailTH text-center\"  *matHeaderCellDef mat-sort-header > Email ID </mat-header-cell>\n      <mat-cell class =\"emailTH\" *matCellDef=\"let element\"> {{element.email}} </mat-cell>\n    </ng-container>\n\n    <ng-container matColumnDef=\"userApplicationRole\">\n      <mat-header-cell class =\"userApplicationRoleTH\"  *matHeaderCellDef mat-sort-header >  Role\n        </mat-header-cell>\n      <mat-cell class =\"userApplicationRoleTH\" *matCellDef=\"let element\">\n          <ng-container *ngFor=\"let c of element.userApplicationRole\">\n                    <span class=\"d-block\"> {{c.roleName}}</span>\n            </ng-container>\n         </mat-cell>\n    </ng-container>\n\n\n    <ng-container matColumnDef=\"activationDate\">\n        <mat-header-cell class =\"activationTH text-center\"  *matHeaderCellDef mat-sort-header >\n    <span class=\"text-center\"><span class=\"d-block\">Activation/</span>Inactivation Date</span></mat-header-cell>\n        <mat-cell class =\"activationTH\" *matCellDef=\"let element\"><span class=\"d-block\">{{element.activationDate | date : \"dd-MMM-yy\"}}/</span>\n          <ng-container *ngIf=\"!element.isActive\">\n            {{element.deActivationDate | date : \"dd-MMM-yy\"}}\n            </ng-container>\n        </mat-cell>\n      </ng-container>\n\n    <ng-container matColumnDef=\"isActive\">\n        <mat-header-cell class=\"userStatusTH noOutlineOnFocus\"  *matHeaderCellDef mat-sort-header> Status </mat-header-cell>\n        <mat-cell class=\"userStatusTH\" *matCellDef=\"let element\">\n          <ng-container *ngIf=\" element.isActive == true\">\n            <i class=\"fa fa-circle active_status\" aria-hidden=\"true\"></i>Active</ng-container>\n          <ng-container *ngIf=\"!element.isActive\">\n            <i class=\"fa fa-circle inactive_status\" aria-hidden=\"true\"></i>InActive\n           </ng-container>\n        </mat-cell>\n      </ng-container>\n\n      <ng-container  matColumnDef=\"actions\" class=\"text-center\">\n        <mat-header-cell class=\"userActionTH noOutlineOnFocus\"  *matHeaderCellDef> </mat-header-cell>\n        <mat-cell class=\"userActionTH\" *matCellDef=\"let element\">\n          <mat-select placeholder=\"Actions\" name=\"Actions\" [(ngModel)]=\"actions\">\n              <ng-container *ngIf=\"element.isActive== true \">\n                   <mat-option value=\"{{element.id}}:edit\" #edit (click)=\"GoUserUpdate(edit.value)\">Edit</mat-option>\n              </ng-container>\n            <mat-option value=\"{{element.id}}:delete\" #delete (click)=\"GoUserDelete(delete.value)\">Delete</mat-option>\n          </mat-select>\n        </mat-cell>\n      </ng-container>\n\n<mat-header-row *matHeaderRowDef=\"displayedColumns\"></mat-header-row>\n<mat-row *matRowDef=\"let row; columns: displayedColumns;\"></mat-row>\n\n</mat-table>\n<mat-paginator #paginator class=\"genericPagination\" [pageSize]=\"10\" [pageSizeOptions]=\"[5, 10, 20]\"></mat-paginator>\n\n</div>\n"

/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/agent-user/agent-user-list/agent-user-list.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export DatePickerDateAdapter */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AgentUserListComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__common_constants__ = __webpack_require__("../../../../../src/app/common/constants.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_material__ = __webpack_require__("../../../material/esm5/material.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__angular_common__ = __webpack_require__("../../../common/esm5/common.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__common_backoffice_shared_dialogs_dialogs_service__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/dialogs/dialogs.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__angular_forms__ = __webpack_require__("../../../forms/esm5/forms.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__common_backoffice_shared_services_user_data_service__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/user-data.service.ts");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








var DATE_FORMATS = {
    parse: {
        dateInput: { month: 'short', year: 'numeric', day: 'numeric' }
    },
    display: {
        dateInput: 'input',
        monthYearLabel: { year: 'numeric', month: 'short' },
        dateA11yLabel: { year: 'numeric', month: 'long', day: 'numeric' },
        monthYearA11yLabel: { year: 'numeric', month: 'long' },
    }
};
var DatePickerDateAdapter = (function (_super) {
    __extends(DatePickerDateAdapter, _super);
    function DatePickerDateAdapter() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    DatePickerDateAdapter.prototype.format = function (date, displayFormat) {
        date.setMinutes((date.getTimezoneOffset() * -1));
        if (displayFormat === 'input') {
            var day = date.getDate();
            var month = date.toLocaleString('en-us', { month: 'long' });
            var year = date.getFullYear();
            return this._to2digit(day) + '-' + month.substring(0, 3) + '-' + year % 100;
        }
        else {
            return date.toDateString();
        }
    };
    DatePickerDateAdapter.prototype._to2digit = function (n) {
        return ('00' + n).slice(-2);
    };
    return DatePickerDateAdapter;
}(__WEBPACK_IMPORTED_MODULE_3__angular_material__["P" /* NativeDateAdapter */]));

var AgentUserListComponent = (function () {
    function AgentUserListComponent(agentUserDataService, dialogsService, router, activatedRoute, datepipe) {
        this.agentUserDataService = agentUserDataService;
        this.dialogsService = dialogsService;
        this.router = router;
        this.activatedRoute = activatedRoute;
        this.datepipe = datepipe;
        this.edit = __WEBPACK_IMPORTED_MODULE_2__common_constants__["a" /* CONSTANTS */].operation.edit;
        this.create = __WEBPACK_IMPORTED_MODULE_2__common_constants__["a" /* CONSTANTS */].operation.create;
        this.read = __WEBPACK_IMPORTED_MODULE_2__common_constants__["a" /* CONSTANTS */].operation.read;
        this.displayedColumns = ['userName', 'agencyName', 'branchName', 'designation', 'email', 'userApplicationRole',
            'activationDate', 'isActive', 'actions'];
    }
    AgentUserListComponent.prototype.ngOnInit = function () {
        this.getAgentUserList();
        this.isSearch = false;
        this.searchUsers = new __WEBPACK_IMPORTED_MODULE_6__angular_forms__["FormGroup"]({
            startDate: new __WEBPACK_IMPORTED_MODULE_6__angular_forms__["FormControl"](),
            endDate: new __WEBPACK_IMPORTED_MODULE_6__angular_forms__["FormControl"](),
            searchText: new __WEBPACK_IMPORTED_MODULE_6__angular_forms__["FormControl"]()
        });
    };
    AgentUserListComponent.prototype.findUsers = function (filterValue, filterFrom, filterTo) {
        var _this = this;
        if (filterFrom !== null || filterTo !== null || (filterValue !== null && filterValue.length >= 3)) {
            this.isSearch = true;
        }
        if (filterFrom !== null) {
            filterFrom = this.datepipe.transform(filterFrom, 'yyyy-MM-dd');
        }
        if (filterTo !== null) {
            filterTo = this.datepipe.transform(filterTo, 'yyyy-MM-dd');
        }
        if (filterValue !== null) {
            filterValue = filterValue.trim();
            filterValue = filterValue.toLowerCase();
        }
        this.filteredData = new __WEBPACK_IMPORTED_MODULE_3__angular_material__["K" /* MatTableDataSource */](this.agentUserList.filter(function (user) {
            var searchActivationDate = _this.datepipe.transform(user.activationDate, 'dd-MMM-yy hh:mm a');
            var activationDate = _this.datepipe.transform(user.activationDate, 'yyyy-MM-dd');
            if (filterValue !== null && (filterFrom === null && filterTo === null)) {
                return _this.filterUser(user, filterValue) ||
                    searchActivationDate.toLowerCase().includes(filterValue);
            }
            else if (filterFrom !== null && (filterTo === null && filterValue === null)) {
                return activationDate >= filterFrom;
            }
            else if (filterTo !== null && (filterFrom === null && filterValue === null)) {
                return activationDate <= filterTo;
            }
            else if (filterValue === null && (filterFrom !== null && filterTo !== null)) {
                return filterFrom <= activationDate && activationDate <= filterTo;
            }
            else if (filterFrom === null && (filterValue !== null && filterTo !== null)) {
                return (_this.filterUser(user, filterValue) ||
                    searchActivationDate.toLowerCase().includes(filterValue)) && activationDate <= filterTo;
            }
            else if (filterTo === null && (filterFrom !== null && filterValue !== null)) {
                return (_this.filterUser(user, filterValue) ||
                    searchActivationDate.toLowerCase().includes(filterValue)) &&
                    activationDate >= filterFrom;
            }
            else if (filterFrom !== null && filterTo !== null && filterValue !== null) {
                return (_this.filterUser(user, filterValue) ||
                    searchActivationDate.toLowerCase().includes(filterValue)) &&
                    (filterFrom <= activationDate && activationDate <= filterTo);
            }
        }));
        this.filteredData.paginator = this.paginator;
        this.filteredData.sort = this.sort;
    };
    AgentUserListComponent.prototype.filterUser = function (agentUser, filterValue) {
        this.isAppRoleData = false;
        this.isDesignationData = false;
        for (var i = 0; i < agentUser.userApplicationRole.length; i++) {
            if (agentUser.userApplicationRole[i].roleName.toLowerCase().includes(filterValue)) {
                this.isAppRoleData = true;
                break;
            }
        }
        return agentUser.userName.toLowerCase().includes(filterValue) ||
            agentUser.email.toLowerCase().includes(filterValue) ||
            // agentUser.designation.toLowerCase().includes(filterValue) ||
            // agentUser.branchName.toLowerCase().includes(filterValue) ||
            // agentUser.agencyName.toLowerCase().includes(filterValue) ||
            // agentUser.agencyCode.toLowerCase().includes(filterValue) ||
            this.isAppRoleData || this.isDesignationData;
    };
    AgentUserListComponent.prototype.checkIsInputCleared = function () {
        if (this.searchUsers.get('searchText').value.length === 1) {
            this.filteredData = new __WEBPACK_IMPORTED_MODULE_3__angular_material__["K" /* MatTableDataSource */](this.agentUserList);
        }
    };
    AgentUserListComponent.prototype.sortData = function (sort) {
        var data = this.agentUserList.slice();
        if (!sort.active || sort.direction === '') {
            this.dataSource.data = data.sort(function (a, b) {
                var isAsc = sort.direction === 'desc';
                return compare(a.activationDate, b.activationDate, isAsc);
            });
            return;
        }
        else {
            if (this.isSearch) {
                this.filteredData.data = this.filteredData.data.sort(function (a, b) {
                    var isAsc = sort.direction === 'asc';
                    switch (sort.active) {
                        case 'userName': return compare(a.userName.toLowerCase(), b.userName.toLowerCase(), isAsc);
                        case 'email': return compare(a.email, b.email, isAsc);
                        case 'designation': return compare(+a.designation, +b.designation, isAsc);
                        case 'branchName': return compare(a.branchName, b.branchName, isAsc);
                        case 'agencyName': return compare(a.agencyName, b.agencyName, isAsc);
                        case 'userApplicationRole':
                            return compare((a.userApplicationRole.length === 0) ? '' :
                                a.userApplicationRole[0].roleName, (b.userApplicationRole.length === 0) ? '' :
                                b.userApplicationRole[0].roleName, isAsc);
                        case 'activationDate': return compare(a.activationDate, b.activationDate, isAsc);
                        case 'isActive': return compare(a.isActive, b.isActive, isAsc);
                        default: return 0;
                    }
                });
                this.filteredData.paginator = this.paginator;
            }
            this.dataSource.data = data.sort(function (a, b) {
                var isAsc = sort.direction === 'asc';
                switch (sort.active) {
                    case 'userName': return compare(a.userName.toLowerCase(), b.userName.toLowerCase(), isAsc);
                    case 'email': return compare(a.email, b.email, isAsc);
                    case 'designation': return compare(+a.designation, +b.designation, isAsc);
                    case 'branchName': return compare(a.branchName, b.branchName, isAsc);
                    case 'agencyName': return compare(a.agencyName, b.agencyName, isAsc);
                    case 'agencyCode': return compare(a.agencyCode, b.agencyCode, isAsc);
                    case 'userApplicationRole':
                        return compare((a.userApplicationRole.length === 0) ? '' :
                            a.userApplicationRole[0].roleName, (b.userApplicationRole.length === 0) ? '' :
                            b.userApplicationRole[0].roleName, isAsc);
                    case 'activationDate': return compare(a.activationDate, b.activationDate, isAsc);
                    case 'isActive': return compare(a.isActive, b.isActive, isAsc);
                    default: return 0;
                }
            });
            this.dataSource.paginator = this.paginator;
        }
    };
    AgentUserListComponent.prototype.createAgent = function () {
        this.router.navigate(['../agentusers', 0, this.create], { relativeTo: this.activatedRoute });
    };
    AgentUserListComponent.prototype.getAgentUserList = function () {
        var _this = this;
        this.agentUserDataService.getAgentUsers().subscribe(function (agentUsersList) {
            _this.agentUserList = agentUsersList;
            _this.dataSource = new __WEBPACK_IMPORTED_MODULE_3__angular_material__["K" /* MatTableDataSource */](_this.agentUserList);
            _this.dataSource.paginator = _this.paginator;
            // this.dataSource.sort = this.sort;
        });
    };
    AgentUserListComponent.prototype.deleteAgentUser = function (agentUserId) {
        var _this = this;
        this.agentUserDataService.deleteAgentUser(agentUserId).subscribe(function (isDeleted) {
            _this.isDeleted = isDeleted;
        });
    };
    AgentUserListComponent.prototype.GoUserDelete = function (value) {
        var _this = this;
        var val = value.split(':');
        var agentUserId = val[0];
        this.dialogsService
            .confirm('Confirm', 'Are you sure you want to delete this user?').subscribe(function (res) {
            _this.result = res;
            if (_this.result) {
                // this.deleteAgentUser(agentUserId);
                _this.getAgentUserList();
            }
            else {
                _this.actions = null;
            }
        });
    };
    AgentUserListComponent.prototype.GoUserUpdate = function (value) {
        var val = value.split(':');
        var agentUserId = val[0];
        this.operation = val[1];
        this.router.navigate(['../agentusers', agentUserId, this.operation.trim().toLowerCase()], { relativeTo: this.activatedRoute });
    };
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["ViewChild"])(__WEBPACK_IMPORTED_MODULE_3__angular_material__["v" /* MatPaginator */]),
        __metadata("design:type", __WEBPACK_IMPORTED_MODULE_3__angular_material__["v" /* MatPaginator */])
    ], AgentUserListComponent.prototype, "paginator", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["ViewChild"])(__WEBPACK_IMPORTED_MODULE_3__angular_material__["H" /* MatSort */]),
        __metadata("design:type", __WEBPACK_IMPORTED_MODULE_3__angular_material__["H" /* MatSort */])
    ], AgentUserListComponent.prototype, "sort", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Object)
    ], AgentUserListComponent.prototype, "_dateValue", void 0);
    AgentUserListComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-agent-user-list',
            template: __webpack_require__("../../../../../src/app/backoffice/user-mgmt/agent-user/agent-user-list/agent-user-list.component.html"),
            styles: [__webpack_require__("../../../../../src/app/backoffice/user-mgmt/agent-user/agent-user-list/agent-user-list.component.css")],
            providers: [__WEBPACK_IMPORTED_MODULE_4__angular_common__["DatePipe"], __WEBPACK_IMPORTED_MODULE_5__common_backoffice_shared_dialogs_dialogs_service__["a" /* DialogsService */],
                { provide: __WEBPACK_IMPORTED_MODULE_3__angular_material__["a" /* DateAdapter */], useClass: DatePickerDateAdapter },
                { provide: __WEBPACK_IMPORTED_MODULE_3__angular_material__["b" /* MAT_DATE_FORMATS */], useValue: DATE_FORMATS },
            ]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_7__common_backoffice_shared_services_user_data_service__["a" /* UserDataService */],
            __WEBPACK_IMPORTED_MODULE_5__common_backoffice_shared_dialogs_dialogs_service__["a" /* DialogsService */],
            __WEBPACK_IMPORTED_MODULE_1__angular_router__["Router"],
            __WEBPACK_IMPORTED_MODULE_1__angular_router__["ActivatedRoute"],
            __WEBPACK_IMPORTED_MODULE_4__angular_common__["DatePipe"]])
    ], AgentUserListComponent);
    return AgentUserListComponent;
}());

function compare(a, b, isAsc) {
    return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}


/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/hotel-user/hotel-type/hotel-type.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/hotel-user/hotel-type/hotel-type.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"container-fluid pt-4\">\r\n  <div class=\"customBreadcrumb mb-4\"><span>Hotel/Supplier </span><span>&gt;  Create New Hotel/Supplier User </span><span class=\"mandatoryInfo\">Indicates Mandatory Fields</span></div>\r\n  <h1 class=\"mainHeading mb-2\">Create New Hotel/Supplier User</h1>\r\n  <form #mgHotelForm=\"ngForm\">\r\n    <div class=\"row customeRow\">\r\n      <div class=\"form-group col-md-5 pt-4 mt-2\">\r\n        <div>\r\n          <label>Type</label>\r\n          <mat-radio-group class=\"d-flex\">\r\n            <mat-radio-button value=\"1\" [routerLink]=\"['hoteluserinfo',0,create]\" routerLinkActive=\"active\">Hotel Chain</mat-radio-button>\r\n            <mat-radio-button value=\"2\" [routerLink]=\"['individual',0,create]\" routerLinkActive=\"active\">Individual Hotels</mat-radio-button>\r\n            <mat-radio-button value=\"3\" [routerLink]=\"['supplieruser',0,create]\" routerLinkActive=\"active\">Supplier</mat-radio-button>\r\n          </mat-radio-group>\r\n        </div>\r\n      </div>\r\n    </div>\r\n  </form>\r\n</div>\r\n\r\n<div>\r\n  <div class=\"body-style\">\r\n    <router-outlet></router-outlet>\r\n  </div>\r\n</div>\r\n\r\n\r\n<!-- <div>\r\n  <app-hotel-type-nav-menu [hotelType] = \"hoteltype\"></app-hotel-type-nav-menu>\r\n</div>\r\n<div >\r\n  <div class=\"body-style\">\r\n    <router-outlet></router-outlet>\r\n  </div>\r\n</div> -->\r\n"

/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/hotel-user/hotel-type/hotel-type.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return HotelTypeComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__common_constants__ = __webpack_require__("../../../../../src/app/common/constants.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var HotelTypeComponent = (function () {
    function HotelTypeComponent(router, activatedRoute) {
        this.router = router;
        this.activatedRoute = activatedRoute;
        this.edit = __WEBPACK_IMPORTED_MODULE_2__common_constants__["a" /* CONSTANTS */].operation.edit;
        this.create = __WEBPACK_IMPORTED_MODULE_2__common_constants__["a" /* CONSTANTS */].operation.create;
        this.read = __WEBPACK_IMPORTED_MODULE_2__common_constants__["a" /* CONSTANTS */].operation.read;
    }
    HotelTypeComponent.prototype.ngOnInit = function () {
    };
    HotelTypeComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-hotel-type',
            template: __webpack_require__("../../../../../src/app/backoffice/user-mgmt/hotel-user/hotel-type/hotel-type.component.html"),
            styles: [__webpack_require__("../../../../../src/app/backoffice/user-mgmt/hotel-user/hotel-type/hotel-type.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_router__["Router"],
            __WEBPACK_IMPORTED_MODULE_1__angular_router__["ActivatedRoute"]])
    ], HotelTypeComponent);
    return HotelTypeComponent;
}());



/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/hotel-user/hotel-user-info/hotel-user-info.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/hotel-user/hotel-user-info/hotel-user-info.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"container-fluid pt-1\">\r\n\r\n  <form [formGroup]=\"hotelUserForm\" (ngSubmit)=\"saveHotelUserDetails()\">\r\n    <div class=\"row customeRow alignItemCenter pb-1\">\r\n      <div class=\"form-group col-md-4 col-lg-3 mb-0\">\r\n        <mat-form-field>\r\n          <mat-select placeholder=\"Chain\" name=\"Chain\" formControlName=\"chainId\" (change)=\"getHotelBrands(hotelUserForm.get('chainId').value);\" required>\r\n            <mat-option [value]=\"null\"> Select </mat-option>\r\n            <mat-option *ngFor=\"let hotelchain of HotelchainList\" [value]=\"hotelchain.hotelChainId\">{{hotelchain.hotelChainName}}</mat-option>\r\n          </mat-select>\r\n        </mat-form-field>\r\n      </div>\r\n      <div class=\"form-group col-md-4 col-lg-3 mb-0\">\r\n        <mat-form-field>\r\n          <mat-select placeholder=\"Brand\" name=\"Brand\" formControlName=\"brandIds\" (change)=\"getHotels(hotelUserForm.get('brandIds').value);\" multiple required>\r\n            <mat-option [value]=\"null\" *ngIf=\"isBrandList == true\"> All </mat-option>\r\n            <mat-option *ngFor=\"let hotelbrand of HotelbrandList\" [value]=\"hotelbrand.hotelBrandId\" aria-selected=\"true\">\r\n              {{hotelbrand.hotelBrandName}}\r\n            </mat-option>\r\n          </mat-select>\r\n        </mat-form-field>\r\n      </div>\r\n      <div class=\"form-group col-md-4 col-lg-3 mb-0\">\r\n        <mat-form-field>\r\n          <mat-select placeholder=\"Hotel Name - ID\" name=\"Hotel Name - ID\" formControlName=\"hotelId\" (change)=\"selectAllHotels();\" multiple required>\r\n            <mat-option [value]=\"null\" *ngIf=\"isHotelList == true\" > All  </mat-option>\r\n            <mat-option *ngFor=\"let hotel of hotelNameList\" [value]=\"hotel.hotelId\">\r\n              {{hotel.hotelName}} - {{hotel.hotelCode}}\r\n            </mat-option>\r\n          </mat-select>\r\n        </mat-form-field>\r\n      </div>\r\n    </div>\r\n    <div class=\"row customeRow\">\r\n      <div class=\"col-md-2\">\r\n        <mat-icon class=\"userImage\">account_circle</mat-icon>\r\n        <button class=\"deletePhoto\" mat-raised-button title=\"Delete Image\"><i class=\"fa fa-times-thin\"></i></button>\r\n        <div class=\"image-upload\">\r\n          <label for=\"file-input\">\r\n            <img src=\"assets/uploadPhoto.png\" title=\"Upload Image\" />\r\n          </label>\r\n          <input id=\"file-input\" type=\"file\" />\r\n        </div>\r\n      </div>\r\n    </div>\r\n    <div class=\"row customeRow\">\r\n      <div class=\"form-group col-md-4 col-lg-3\">\r\n        <mat-form-field class=\"example-full-width\">\r\n          <input matInput placeholder=\"User Name\" name=\"firstName\" formControlName=\"firstName\" required />\r\n        </mat-form-field>\r\n      </div>\r\n      <div class=\"form-group col-md-4 col-lg-3\">\r\n        <mat-form-field>\r\n          <mat-select placeholder=\"Designation\" name=\"Designation\" formControlName=\"designationId\" required>\r\n            <mat-option *ngFor=\"let designation of designationList\" [value]=\"designation.designationId\">\r\n              {{designation.title}}\r\n            </mat-option>\r\n          </mat-select>\r\n        </mat-form-field>\r\n      </div>\r\n    </div>\r\n    <div class=\"row customeRow\">\r\n      <div class=\"form-group col-md-4 col-lg-3\">\r\n        <mat-form-field class=\"example-full-width\">\r\n          <input matInput placeholder=\"Email ID\" name=\"emailID\" formControlName=\"email\" pattern=\"\\w+@\\w+\\.\\w+(,\\s*\\w+@\\w+\\.\\w+)*\" required />\r\n        </mat-form-field>\r\n\r\n      </div>\r\n      <div class=\"form-group col-md-4 col-lg-3\">\r\n        <mat-form-field>\r\n          <mat-select placeholder=\"Role\" name=\"Role\" formControlName=\"extranetRoleId\" required>\r\n            <mat-option *ngFor=\"let role of roleList\" [value]=\"role.id\">\r\n              {{role.name}}\r\n            </mat-option>\r\n          </mat-select>\r\n        </mat-form-field>\r\n      </div>\r\n    </div>\r\n    <div class=\"row customeRow\">\r\n      <div class=\"col-md-3\">\r\n        <mat-form-field class=\"example-full-width\">\r\n          <input matInput [matDatepicker]=\"activationDate\" placeholder=\"Activation Date\" formControlName=\"activationDate\" [min]=\"(operation === create) ? todaysDate : minDate\"\r\n                 required>\r\n          <mat-datepicker-toggle matSuffix [for]=\"activationDate\">\r\n            <mat-icon matDatepickerToggleIcon>\r\n              <i class=\"fa fa-calendar\" aria-hidden=\"true\"></i>\r\n            </mat-icon>\r\n          </mat-datepicker-toggle>\r\n          <mat-datepicker #activationDate></mat-datepicker>\r\n\r\n        </mat-form-field>\r\n      </div>\r\n    </div>\r\n    <div class=\"row\">\r\n      <div class=\"col-md-12 controlButtons mt-5 mb-4\">\r\n        <button title=\"Save\" type=\"submit\" class=\"genericButton activeButton mat-primary mr-2\" [disabled]=\"!hotelUserForm.valid\" mat-raised-button>Save</button>\r\n        <button title=\"Cancel\" type=\"submit\" class=\"genericButton defaultButton\" (click)=\"cancel()\" mat-raised-button>Cancel</button>\r\n      </div>\r\n    </div>\r\n  </form>\r\n</div>\r\n"

/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/hotel-user/hotel-user-info/hotel-user-info.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return HotelUserInfoComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__common_constants__ = __webpack_require__("../../../../../src/app/common/constants.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_forms__ = __webpack_require__("../../../forms/esm5/forms.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__angular_material__ = __webpack_require__("../../../material/esm5/material.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__common_backoffice_shared_services_backoffice_lookup__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/backoffice-lookup.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__common_shared_services_lookup_service__ = __webpack_require__("../../../../../src/app/common/shared/services/lookup.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__common_backoffice_shared_services_user_data_service__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/user-data.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








var HotelUserInfoComponent = (function () {
    function HotelUserInfoComponent(router, activatedRoute, cd, snackBar, lookupService, userDataService, backOfficeLookUpService) {
        this.router = router;
        this.activatedRoute = activatedRoute;
        this.cd = cd;
        this.snackBar = snackBar;
        this.lookupService = lookupService;
        this.userDataService = userDataService;
        this.backOfficeLookUpService = backOfficeLookUpService;
        this.todaysDate = new Date();
        this.edit = __WEBPACK_IMPORTED_MODULE_2__common_constants__["a" /* CONSTANTS */].operation.edit;
        this.create = __WEBPACK_IMPORTED_MODULE_2__common_constants__["a" /* CONSTANTS */].operation.create;
        this.read = __WEBPACK_IMPORTED_MODULE_2__common_constants__["a" /* CONSTANTS */].operation.read;
        this.hotelUserDetails = {};
    }
    HotelUserInfoComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.operation = this.activatedRoute.snapshot.params['operation'];
        this.userId = this.activatedRoute.snapshot.params['userId'];
        this.getHotelChainList();
        this.getDesignations();
        this.getRoles();
        this.allBrandIds = [0];
        this.allHotelIds = [''];
        this.isHotelList = false;
        this.isBrandList = false;
        this.hotelUserForm = new __WEBPACK_IMPORTED_MODULE_3__angular_forms__["FormGroup"]({
            chainId: new __WEBPACK_IMPORTED_MODULE_3__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_3__angular_forms__["Validators"].required),
            brandIds: new __WEBPACK_IMPORTED_MODULE_3__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_3__angular_forms__["Validators"].required),
            hotelId: new __WEBPACK_IMPORTED_MODULE_3__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_3__angular_forms__["Validators"].required),
            firstName: new __WEBPACK_IMPORTED_MODULE_3__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_3__angular_forms__["Validators"].required),
            designationId: new __WEBPACK_IMPORTED_MODULE_3__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_3__angular_forms__["Validators"].required),
            email: new __WEBPACK_IMPORTED_MODULE_3__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_3__angular_forms__["Validators"].required),
            extranetRoleId: new __WEBPACK_IMPORTED_MODULE_3__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_3__angular_forms__["Validators"].required),
            activationDate: new __WEBPACK_IMPORTED_MODULE_3__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_3__angular_forms__["Validators"].required),
        });
        if (this.operation === 'edit') {
            this.userDataService.getHotelUserById(this.userId).subscribe(function (hotelUser) {
                _this.hotelUser = hotelUser;
            });
        }
    };
    HotelUserInfoComponent.prototype.getHotelChainList = function () {
        var _this = this;
        this.lookupService.getHotelChains().subscribe(function (mghotelchainList) {
            _this.HotelchainList = mghotelchainList;
        });
    };
    HotelUserInfoComponent.prototype.getHotelBrands = function (chainId) {
        var _this = this;
        this.lookupService.getHotelBrands(chainId).subscribe(function (mghotelbrandList) {
            _this.HotelbrandList = mghotelbrandList;
            _this.isBrandList = true;
        });
    };
    HotelUserInfoComponent.prototype.getDesignations = function () {
        var _this = this;
        this.backOfficeLookUpService.getDesignationByType(__WEBPACK_IMPORTED_MODULE_2__common_constants__["a" /* CONSTANTS */].userType.hoteluser).subscribe(function (designationData) {
            return _this.designationList = designationData;
        });
    };
    HotelUserInfoComponent.prototype.getRoles = function () {
        var _this = this;
        this.backOfficeLookUpService.getRolesByApplicationName(__WEBPACK_IMPORTED_MODULE_2__common_constants__["a" /* CONSTANTS */].application.extranet).subscribe(function (data) {
            return _this.roleList = data;
        });
    };
    HotelUserInfoComponent.prototype.selectAllHotels = function () {
        // fetch all hotelIds from hotelsList
        if (this.hotelNameList !== null) {
            this.allHotelIds.splice(0, this.allHotelIds.length);
            for (var b = 0; b < this.hotelNameList.length; b++) {
                this.allHotelIds[b] = this.hotelNameList[b].hotelId;
            }
            // select/deselect all hotels
            if (this.hotelUserForm.value.hotelId.length !== 0) {
                if (this.hotelUserForm.value.hotelId[0] == null && this.hotelUserForm.value.hotelId.length !== (this.allHotelIds.length + 1)) {
                    this.hotelUserForm.patchValue({ hotelId: this.allHotelIds });
                }
                else if (this.hotelUserForm.value.hotelId.length === (this.allHotelIds.length + 1)) {
                    this.hotelUserForm.patchValue({ hotelId: null });
                }
            }
        }
    };
    HotelUserInfoComponent.prototype.getHotels = function (brandIds) {
        var _this = this;
        // fetch all brandIds from brandsList
        this.allBrandIds.splice(0, this.allBrandIds.length);
        for (var b = 0; b < this.HotelbrandList.length; b++) {
            this.allBrandIds[b] = this.HotelbrandList[b].hotelBrandId;
        }
        // select/deselect all brands
        if (brandIds.length !== (this.allBrandIds.length + 1) && brandIds.length !== 0) {
            if (brandIds[0] == null) {
                for (var b = 0; b < this.HotelbrandList.length; b++) {
                    brandIds[b] = this.HotelbrandList[b].hotelBrandId;
                    this.hotelUserForm.value.brandIds[b] = this.HotelbrandList[b].hotelBrandId;
                }
                this.hotelUserForm.patchValue({ brandIds: brandIds });
            }
        }
        else if (brandIds.length === (this.allBrandIds.length + 1) && this.hotelNameList != null) {
            this.hotelUserForm.patchValue({ brandIds: null });
            this.hotelNameList = null;
            this.isHotelList = false;
        }
        // fetch hotels according to brandIds
        if (brandIds.length >= 1 && brandIds[0] !== null) {
            this.isHotelList = true;
            this.backOfficeLookUpService.getHotelsByBrandIds(brandIds).subscribe(function (data) {
                return _this.hotelNameList = data;
            });
        }
    };
    HotelUserInfoComponent.prototype.saveHotelUserDetails = function () {
        var _this = this;
        var hotelUser = Object.assign({}, this.hotelUserDetails, this.hotelUserForm.value);
        hotelUser.userName = hotelUser.email;
        if (hotelUser.activationDate === this.todaysDate.toISOString()) {
            hotelUser.isActive = true;
        }
        else {
            hotelUser.isActive = false;
        }
        // hotelUser.deActivationDate = '';
        hotelUser.createdBy = 'sa';
        hotelUser.updatedBy = 'sa';
        this.userDataService.createHotelUser(hotelUser)
            .subscribe(function (data) {
            _this.snackBar.open('Hotel User Saved Successfully', '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar' });
            _this.router.navigate(['/usermgmt/hoteluserslist']);
        });
    };
    HotelUserInfoComponent.prototype.cancel = function () {
        window.scrollTo(0, 0);
        this.router.navigate(['/usermgmt/hoteluserslist']);
    };
    HotelUserInfoComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-hotel-user-info',
            template: __webpack_require__("../../../../../src/app/backoffice/user-mgmt/hotel-user/hotel-user-info/hotel-user-info.component.html"),
            styles: [__webpack_require__("../../../../../src/app/backoffice/user-mgmt/hotel-user/hotel-user-info/hotel-user-info.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_router__["Router"],
            __WEBPACK_IMPORTED_MODULE_1__angular_router__["ActivatedRoute"],
            __WEBPACK_IMPORTED_MODULE_0__angular_core__["ChangeDetectorRef"],
            __WEBPACK_IMPORTED_MODULE_4__angular_material__["F" /* MatSnackBar */],
            __WEBPACK_IMPORTED_MODULE_6__common_shared_services_lookup_service__["a" /* LookupService */],
            __WEBPACK_IMPORTED_MODULE_7__common_backoffice_shared_services_user_data_service__["a" /* UserDataService */],
            __WEBPACK_IMPORTED_MODULE_5__common_backoffice_shared_services_backoffice_lookup__["a" /* BackofficeLookupService */]])
    ], HotelUserInfoComponent);
    return HotelUserInfoComponent;
}());



/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/hotel-user/hotel-user-list/hotel-user-list.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ".usernameTH{width:15%;}\r\n.hotelIDTH{width: 14%;}\r\n.designationIDTH{width: 11%;}\r\n.emailTH{width: 15%;}\r\n.applicationRoleTH{width: 10%;}\r\n.activationTH{width: 15%;}\r\n.userStatusTH{width: 10%;}\r\n.userActionTH{width: 10%;}\r\n.expandHotelDetails {\r\n  position: absolute;\r\n  left: 39px;\r\n  width: 94%;\r\n  padding: 10px;\r\n  background: #fff;\r\n  overflow: auto;\r\n  border: 1px solid #ebebeb;\r\n  height: 105px;\r\n  margin-top: 42px;\r\n}\r\n.hotelIDTH a{\r\n    cursor: pointer;\r\n    color: #2aaae1;\r\n    text-decoration: underline;\r\n    font-size: 0.875rem;\r\n}\r\n\r\n.expandHotelTitle {\r\n  display: block;\r\n  z-index: 1;\r\n  position: absolute;\r\n  left: 39px;\r\n  width: 94%;\r\n  padding-top: 16px;\r\n}\r\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/hotel-user/hotel-user-list/hotel-user-list.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"container-fluid pt-4\">\n  <h1 class=\"mainHeading pb-2 mb-4 mt-2\">Hotel/Supplier</h1>\n  <form [formGroup]=\"searchHotelUsers\" (ngSubmit)=\"findHotelUser(searchHotelUsers.get('searchText').value,searchHotelUsers.get('startDate').value,searchHotelUsers.get('endDate').value)\"\n    class=\"w-100\">\n    <div class=\"blueBackground pt-1 pb-1 pl-0 pr-2 alignItemCenter\">\n      <div class=\"row formSections borderBottomNone p-0 m-1\">\n\n        <div class=\"col-md-2 d-flex pr-0\">\n          <label class=\"optionsList mb-0 alignItemCenter pr-3\">From:</label>\n          <mat-form-field>\n            <mat-datepicker-toggle matSuffix [for]=\"startdate\">\n              <mat-icon matDatepickerToggleIcon>\n                <i class=\"fa fa-calendar\" aria-hidden=\"true\"></i>\n              </mat-icon>\n            </mat-datepicker-toggle>\n            <input matInput [matDatepicker]=\"startdate\" placeholder=\"DD-MMM-YY\" formControlName=\"startDate\">\n            <mat-datepicker #startdate></mat-datepicker>\n          </mat-form-field>\n        </div>\n\n        <div class=\"col-md-2 d-flex pr-2 pl-4\">\n          <label class=\"optionsList mb-0 alignItemCenter pr-3\">To:</label>\n          <mat-form-field>\n            <mat-datepicker-toggle matSuffix [for]=\"enddate\">\n              <mat-icon matDatepickerToggleIcon>\n                <i class=\"fa fa-calendar\" aria-hidden=\"true\"></i>\n              </mat-icon>\n            </mat-datepicker-toggle>\n            <input matInput [matDatepicker]=\"enddate\" placeholder=\"DD-MMM-YY\" formControlName=\"endDate\" [min]=\"searchHotelUsers.get('startDate').value\">\n            <mat-datepicker #enddate></mat-datepicker>\n          </mat-form-field>\n        </div>\n\n        <div class=\"col-md-7 pl-4 pr-4\">\n          <mat-form-field>\n            <input matInput placeholder=\"Search by User Name, Email Id, Designation, Roles, Activation date \" formControlName=\"searchText\"\n                   (keydown.backspace)=\"checkIsInputCleared()\">\n          </mat-form-field>\n        </div>\n\n        <div class=\"col-md-1 alignItemCenter pl-1 controlButtons\">\n          <button title=\"Search\" type=\"submit\" class=\"genericButton genericSmallButton activeButton mat-primary\" mat-raised-button>Search</button>\n        </div>\n\n      </div>\n    </div>\n  </form>\n  <div class=\"row\">\n    <div class=\"col-md-12 pt-4 mt-2 pb-3 mb-1 controlButtons\">\n      <button title=\"Create New Hotel/Supplier User\" type=\"submit\" class=\"pt-2 pb-2 genericButton genericSmallButton defaultButton createNew\"\n        mat-raised-button (click)=\"createHotelUser()\">\n        <i class=\"fa fa-plus-circle\" aria-hidden=\"true\"></i>\n        <span>Create New Hotel/Supplier User</span>\n      </button>\n    </div>\n  </div>\n\n  <mat-table class=\"flexNone mb-2 genericTable\" #table [dataSource]='!isSearch ? dataSource: filteredData' matSort (matSortChange)=\"sortData($event)\"\n    matSortActive=\"activationDate\" matSortDirection=\"desc\">\n\n\n    <ng-container matColumnDef=\"userName\">\n      <mat-header-cell class=\"usernameTH alignItemCenter pr-0\" *matHeaderCellDef mat-sort-header> User Name </mat-header-cell>\n      <mat-cell class=\"usernameTH\" *matCellDef=\"let element\">\n        <div class=\"d-flex\">\n          <mat-icon class=\"userIcon alignItemCenter\">account_circle</mat-icon>\n          <span class=\"d-flex pl-4 alignItemCenter\">{{element.userName}}</span>\n        </div>\n      </mat-cell>\n    </ng-container>\n\n\n    <ng-container matColumnDef=\"hotels\">\n      <mat-header-cell class=\"hotelIDTH\" *matHeaderCellDef mat-sort-header> Hotel Name-ID </mat-header-cell>\n      <mat-cell class=\"hotelIDTH\" *matCellDef=\"let element\">\n        <ng-container *ngIf=\"element.hotels.length > 1\">\n          <span class=\"d-block\">{{element.hotels[0].name}} - {{element.hotels[0].id}}</span>\n          <a (click)=\"element.hideme = !element.hideme\">More</a>\n          <span [hidden]=\"!element.hideme\" class=\"expandHotelTitle\">Hotel Name - ID</span>\n          <div [hidden]=\"!element.hideme\" class=\"expandHotelDetails\">\n              <ng-container *ngFor=\"let c of element.hotels; let first = first\">\n                <span *ngIf=\"!first\">{{c.name}} - {{c.id}}  ,  </span>\n              </ng-container>\n          </div>\n        </ng-container>\n        <ng-container *ngIf=\"element.hotels.length==1\">\n          <span class=\"d-block\">{{element.hotels[0].name}} - {{element.hotels[0].id}}</span>\n        </ng-container>\n      </mat-cell>\n    </ng-container>\n\n    <ng-container matColumnDef=\"designation\">\n      <mat-header-cell class=\"designationIDTH\" *matHeaderCellDef mat-sort-header> Designation </mat-header-cell>\n      <mat-cell class=\"designationIDTH\" *matCellDef=\"let element\"> {{element.designation}} </mat-cell>\n    </ng-container>\n\n    <ng-container matColumnDef=\"email\">\n      <mat-header-cell class=\"emailTH\" *matHeaderCellDef mat-sort-header> Email ID </mat-header-cell>\n      <mat-cell class=\"emailTH\" *matCellDef=\"let element\"> {{element.email}} </mat-cell>\n    </ng-container>\n\n    <ng-container matColumnDef=\"userApplicationRole\">\n      <mat-header-cell class=\"applicationRoleTH\" *matHeaderCellDef mat-sort-header> Role(s)\n      </mat-header-cell>\n      <mat-cell class=\"applicationRoleTH\" *matCellDef=\"let element\">\n        <ng-container *ngFor=\"let c of element.userApplicationRole\">\n          <span class=\"d-block\"> {{c.roleName}}</span>\n        </ng-container>\n      </mat-cell>\n    </ng-container>\n\n    <ng-container matColumnDef=\"activationDate\">\n      <mat-header-cell class=\"activationTH\" *matHeaderCellDef mat-sort-header>\n        <span class=\"text-center\">\n          <span class=\"d-block\">Activation/</span>Inactivation Date</span>\n      </mat-header-cell>\n      <mat-cell class=\"activationTH\" *matCellDef=\"let element\">\n        <span class=\"d-block\">{{element.activationDate | date : \"dd-MMM-yy\"}}/</span>\n        <ng-container *ngIf=\"!element.isActive\">\n          {{element.deActivationDate | date : \"dd-MMM-yy\"}}\n        </ng-container>\n      </mat-cell>\n    </ng-container>\n\n    <ng-container matColumnDef=\"isActive\">\n      <mat-header-cell class=\"userStatusTH noOutlineOnFocus\" *matHeaderCellDef mat-sort-header> Status </mat-header-cell>\n      <mat-cell class=\"userStatusTH\" *matCellDef=\"let element\">\n        <ng-container *ngIf=\"!element.isActive \">\n          <i class=\"fa fa-circle inactive_status\" aria-hidden=\"true\"></i>InActive</ng-container>\n        <ng-container *ngIf=\"element.isActive == true\">\n          <i class=\"fa fa-circle active_status\" aria-hidden=\"true\"></i>Active\n        </ng-container>\n      </mat-cell>\n    </ng-container>\n\n    <ng-container matColumnDef=\"actions\" class=\"text-center\">\n      <mat-header-cell class=\"userActionTH noOutlineOnFocus\" *matHeaderCellDef mat-sort-header> </mat-header-cell>\n      <mat-cell class=\"userActionTH\" *matCellDef=\"let element\">\n        <mat-select placeholder=\"Actions\" name=\"Actions\" [(ngModel)]=\"actions\">\n          <ng-container *ngIf=\"element.isActive \">\n              <!-- <mat-option value=\"{{element.id}}:edit:{{element.userType}}\" #edit (click)=\"GoUserUpdate(edit.value)\">Edit</mat-option> -->\n            <mat-option value=\"{{element.id}}:edit:1\" #edit (click)=\"GoUserUpdate(edit.value)\">Edit</mat-option>\n          </ng-container>\n          <mat-option value=\"{{element.id}}:delete\" #delete (click)=\"GoUserDelete(delete.value)\">Delete</mat-option>\n        </mat-select>\n      </mat-cell>\n    </ng-container>\n\n    <mat-header-row *matHeaderRowDef=\"displayedColumns\"></mat-header-row>\n    <mat-row *matRowDef=\"let row; columns: displayedColumns;\" [style.padding-bottom]=\"row.hideme ? '144px': '0px'\"></mat-row>\n\n\n  </mat-table>\n\n  <mat-paginator #paginator class=\"genericPagination\" [pageSize]=\"10\" [pageSizeOptions]=\"[5, 10, 20]\"></mat-paginator>\n</div>\n"

/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/hotel-user/hotel-user-list/hotel-user-list.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export DatePickerDateAdapter */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return HotelUserListComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__common_backoffice_shared_services_user_data_service__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/user-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_common__ = __webpack_require__("../../../common/esm5/common.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_material_core__ = __webpack_require__("../../../material/esm5/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__common_constants__ = __webpack_require__("../../../../../src/app/common/constants.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__angular_material__ = __webpack_require__("../../../material/esm5/material.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__angular_forms__ = __webpack_require__("../../../forms/esm5/forms.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__common_backoffice_shared_dialogs_dialogs_service__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/dialogs/dialogs.service.ts");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};









var DATE_FORMATS = {
    parse: {
        dateInput: { month: 'short', year: 'numeric', day: 'numeric' }
    },
    display: {
        dateInput: 'input',
        monthYearLabel: { year: 'numeric', month: 'short' },
        dateA11yLabel: { year: 'numeric', month: 'long', day: 'numeric' },
        monthYearA11yLabel: { year: 'numeric', month: 'long' },
    }
};
var DatePickerDateAdapter = (function (_super) {
    __extends(DatePickerDateAdapter, _super);
    function DatePickerDateAdapter() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    DatePickerDateAdapter.prototype.format = function (date, displayFormat) {
        date.setMinutes((date.getTimezoneOffset() * -1));
        if (displayFormat === 'input') {
            var day = date.getDate();
            var month = date.toLocaleString('en-us', { month: 'long' });
            var year = date.getFullYear();
            return this._to2digit(day) + '-' + month.substring(0, 3) + '-' + year % 100;
        }
        else {
            return date.toDateString();
        }
    };
    DatePickerDateAdapter.prototype._to2digit = function (n) {
        return ('00' + n).slice(-2);
    };
    return DatePickerDateAdapter;
}(__WEBPACK_IMPORTED_MODULE_2__angular_material_core__["u" /* NativeDateAdapter */]));

var HotelUserListComponent = (function () {
    function HotelUserListComponent(router, activatedRoute, userDataService, dialogsService, datepipe) {
        this.router = router;
        this.activatedRoute = activatedRoute;
        this.userDataService = userDataService;
        this.dialogsService = dialogsService;
        this.datepipe = datepipe;
        this.edit = __WEBPACK_IMPORTED_MODULE_4__common_constants__["a" /* CONSTANTS */].operation.edit;
        this.create = __WEBPACK_IMPORTED_MODULE_4__common_constants__["a" /* CONSTANTS */].operation.create;
        this.read = __WEBPACK_IMPORTED_MODULE_4__common_constants__["a" /* CONSTANTS */].operation.read;
        this.displayedColumns = ['userName', 'hotels', 'designation', 'email', 'userApplicationRole', 'activationDate', 'isActive', 'actions'];
        this.hotel = {
            ' kind ': ' title ',
            'label': 'ADD_TITLE'
        };
    }
    HotelUserListComponent.prototype.ngOnInit = function () {
        this.getHotelUserList();
        this.hideme = {};
        this.isSearch = false;
        this.searchHotelUsers = new __WEBPACK_IMPORTED_MODULE_7__angular_forms__["FormGroup"]({
            startDate: new __WEBPACK_IMPORTED_MODULE_7__angular_forms__["FormControl"](),
            endDate: new __WEBPACK_IMPORTED_MODULE_7__angular_forms__["FormControl"](),
            searchText: new __WEBPACK_IMPORTED_MODULE_7__angular_forms__["FormControl"]()
        });
    };
    HotelUserListComponent.prototype.getHotelUserList = function () {
        var _this = this;
        this.userDataService.getHotelUsers().subscribe(function (mgUsersList) {
            _this.hotelUserList = mgUsersList;
            _this.dataSource = new __WEBPACK_IMPORTED_MODULE_6__angular_material__["K" /* MatTableDataSource */](_this.hotelUserList);
            _this.dataSource.paginator = _this.paginator;
            _this.dataSource.sort = _this.sort;
        });
    };
    HotelUserListComponent.prototype.createHotelUser = function () {
        this.router.navigate(['../hotelusers'], { relativeTo: this.activatedRoute });
    };
    HotelUserListComponent.prototype.findHotelUser = function (filterValue, filterFrom, filterTo) {
        var _this = this;
        if (filterFrom !== null || filterTo !== null || (filterValue !== null && filterValue.length >= 3)) {
            this.isSearch = true;
        }
        if (filterFrom !== null) {
            filterFrom = this.datepipe.transform(filterFrom, 'yyyy-MM-dd');
        }
        if (filterTo !== null) {
            filterTo = this.datepipe.transform(filterTo, 'yyyy-MM-dd');
        }
        if (filterValue !== null) {
            filterValue = filterValue.trim();
            filterValue = filterValue.toLowerCase();
        }
        this.filteredData = new __WEBPACK_IMPORTED_MODULE_6__angular_material__["K" /* MatTableDataSource */](this.hotelUserList.filter(function (user) {
            var searchActivationDate = _this.datepipe.transform(user.activationDate, 'dd-MMM-yy hh:mm a');
            var activationDate = _this.datepipe.transform(user.activationDate, 'yyyy-MM-dd');
            if (filterValue !== null && (filterFrom === null && filterTo === null)) {
                return _this.filterHotelUser(user, filterValue) ||
                    searchActivationDate.toLowerCase().includes(filterValue);
            }
            else if (filterFrom !== null && (filterTo === null && filterValue === null)) {
                return activationDate >= filterFrom;
            }
            else if (filterTo !== null && (filterFrom === null && filterValue === null)) {
                return activationDate <= filterTo;
            }
            else if (filterValue === null && (filterFrom !== null && filterTo !== null)) {
                return filterFrom <= activationDate && activationDate <= filterTo;
            }
            else if (filterFrom === null && (filterValue !== null && filterTo !== null)) {
                return (_this.filterHotelUser(user, filterValue) ||
                    searchActivationDate.toLowerCase().includes(filterValue)) && activationDate <= filterTo;
            }
            else if (filterTo === null && (filterFrom !== null && filterValue !== null)) {
                return (_this.filterHotelUser(user, filterValue) ||
                    searchActivationDate.toLowerCase().includes(filterValue)) &&
                    activationDate >= filterFrom;
            }
            else if (filterFrom !== null && filterTo !== null && filterValue !== null) {
                return (_this.filterHotelUser(user, filterValue) ||
                    searchActivationDate.toLowerCase().includes(filterValue)) &&
                    (filterFrom <= activationDate && activationDate <= filterTo);
            }
        }));
        this.filteredData.paginator = this.paginator;
        this.filteredData.sort = this.sort;
    };
    HotelUserListComponent.prototype.filterHotelUser = function (user, filterValue) {
        this.isAppRoleData = false;
        for (var i = 0; i < user.userApplicationRole.length; i++) {
            if (user.userApplicationRole[i].roleName.toLowerCase().includes(filterValue)) {
                this.isAppRoleData = true;
                break;
            }
        }
        for (var j = 0; j < user.hotels.length; j++) {
            if (user.hotels[j].name.toLowerCase().includes(filterValue)) {
                this.isHotelData = true;
            }
        }
        return user.userName.toLowerCase().includes(filterValue) ||
            user.email.toLowerCase().includes(filterValue) ||
            // user.designation.toLowerCase().includes(filterValue)
            this.isAppRoleData || this.isHotelData;
    };
    HotelUserListComponent.prototype.checkIsInputCleared = function () {
        if (this.searchHotelUsers.get('searchText').value.length === 1) {
            this.filteredData = new __WEBPACK_IMPORTED_MODULE_6__angular_material__["K" /* MatTableDataSource */](this.hotelUserList);
        }
    };
    HotelUserListComponent.prototype.sortData = function (sort) {
        var data = this.hotelUserList.slice();
        if (!sort.active || sort.direction === '') {
            this.dataSource.data = data.sort(function (a, b) {
                var isAsc = sort.direction === 'desc';
                return compare(a.activationDate, b.activationDate, isAsc);
            });
            return;
        }
        else {
            if (this.isSearch) {
                this.filteredData.data = this.filteredData.data.sort(function (a, b) {
                    var isAsc = sort.direction === 'asc';
                    switch (sort.active) {
                        // case 'name': return compare(a.firstName, b.firstName, isAsc);
                        case 'name': return compare(a.userName, b.userName, isAsc);
                        case 'email': return compare(a.email, b.email, isAsc);
                        case 'hotels':
                            return compare((a.hotels.length === 0) ? '' :
                                a.hotels[0].name, (b.hotels.length === 0) ? '' :
                                b.hotels[0].name, isAsc);
                        case 'isActive': return compare(a.isActive, b.isActive, isAsc);
                        case 'userApplicationRole':
                            return compare((a.userApplicationRole.length === 0) ? '' :
                                a.userApplicationRole[0].roleName, (b.userApplicationRole.length === 0) ? '' :
                                b.userApplicationRole[0].roleName, isAsc);
                        case 'activationDate': return compare(a.activationDate, b.activationDate, isAsc);
                        default: return 0;
                    }
                });
                this.filteredData.paginator = this.paginator;
            }
            this.dataSource.data = data.sort(function (a, b) {
                var isAsc = sort.direction === 'asc';
                switch (sort.active) {
                    // case 'name': return compare(a.firstName, b.firstName, isAsc);
                    case 'name': return compare(a.userName, b.userName, isAsc);
                    case 'email': return compare(a.email, b.email, isAsc);
                    case 'hotels':
                        return compare((a.hotels.length === 0) ? '' :
                            a.hotels[0].name, (b.hotels.length === 0) ? '' :
                            b.hotels[0].name, isAsc);
                    case 'isActive': return compare(a.isActive, b.isActive, isAsc);
                    case 'userApplicationRole':
                        return compare((a.userApplicationRole.length === 0) ? '' :
                            a.userApplicationRole[0].roleName, (b.userApplicationRole.length === 0) ? '' :
                            b.userApplicationRole[0].roleName, isAsc);
                    case 'activationDate': return compare(a.activationDate, b.activationDate, isAsc);
                    default: return 0;
                }
            });
            this.dataSource.paginator = this.paginator;
        }
    };
    HotelUserListComponent.prototype.GoUserUpdate = function (value) {
        var val = value.split(':');
        var userId = val[0];
        this.operation = val[1];
        var userType = val[2];
        if (userType === '1') {
            this.router.navigate(['../hoteluserinfo', userId, this.operation.trim().toLowerCase()], { relativeTo: this.activatedRoute });
        }
        else if (userType === '2') {
            this.router.navigate(['../individual', userId, this.operation.trim().toLowerCase()], { relativeTo: this.activatedRoute });
        }
    };
    HotelUserListComponent.prototype.deleteHotelUser = function (userId) {
        var _this = this;
        this.userDataService.deleteHotelUser(userId).subscribe(function (isDeleted) {
            _this.isDeleted = isDeleted;
        });
    };
    HotelUserListComponent.prototype.GoUserDelete = function (value) {
        var _this = this;
        var val = value.split(':');
        var userId = val[0];
        this.dialogsService
            .confirm('Confirm', 'Are you sure you want to delete this user?').subscribe(function (res) {
            _this.result = res;
            if (_this.result) {
                // this.deleteHotelUser(userId);
                _this.getHotelUserList();
            }
            else {
                _this.actions = null;
            }
        });
    };
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_3__angular_core__["ViewChild"])(__WEBPACK_IMPORTED_MODULE_6__angular_material__["v" /* MatPaginator */]),
        __metadata("design:type", __WEBPACK_IMPORTED_MODULE_6__angular_material__["v" /* MatPaginator */])
    ], HotelUserListComponent.prototype, "paginator", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_3__angular_core__["ViewChild"])(__WEBPACK_IMPORTED_MODULE_6__angular_material__["H" /* MatSort */]),
        __metadata("design:type", __WEBPACK_IMPORTED_MODULE_6__angular_material__["H" /* MatSort */])
    ], HotelUserListComponent.prototype, "sort", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_3__angular_core__["Input"])(),
        __metadata("design:type", Object)
    ], HotelUserListComponent.prototype, "_dateValue", void 0);
    HotelUserListComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_3__angular_core__["Component"])({
            selector: 'app-hotel-user-list',
            template: __webpack_require__("../../../../../src/app/backoffice/user-mgmt/hotel-user/hotel-user-list/hotel-user-list.component.html"),
            styles: [__webpack_require__("../../../../../src/app/backoffice/user-mgmt/hotel-user/hotel-user-list/hotel-user-list.component.css")],
            providers: [__WEBPACK_IMPORTED_MODULE_1__angular_common__["DatePipe"], __WEBPACK_IMPORTED_MODULE_8__common_backoffice_shared_dialogs_dialogs_service__["a" /* DialogsService */],
                { provide: __WEBPACK_IMPORTED_MODULE_2__angular_material_core__["c" /* DateAdapter */], useClass: DatePickerDateAdapter },
                { provide: __WEBPACK_IMPORTED_MODULE_2__angular_material_core__["f" /* MAT_DATE_FORMATS */], useValue: DATE_FORMATS },
            ]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_5__angular_router__["Router"],
            __WEBPACK_IMPORTED_MODULE_5__angular_router__["ActivatedRoute"],
            __WEBPACK_IMPORTED_MODULE_0__common_backoffice_shared_services_user_data_service__["a" /* UserDataService */],
            __WEBPACK_IMPORTED_MODULE_8__common_backoffice_shared_dialogs_dialogs_service__["a" /* DialogsService */],
            __WEBPACK_IMPORTED_MODULE_1__angular_common__["DatePipe"]])
    ], HotelUserListComponent);
    return HotelUserListComponent;
}());

function compare(a, b, isAsc) {
    return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}


/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/hotel-user/individual-hotel-user-info/individual-hotel-user-info.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/hotel-user/individual-hotel-user-info/individual-hotel-user-info.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"container-fluid\">\r\n  <form [formGroup]=\"individualHotelForm\" (ngSubmit)=\"saveIndividualHotelUserDetails()\">\r\n    <div class=\"row customeRow\">\r\n      <div class=\"form-group col-md-4 col-lg-3 mb-0\">\r\n        <mat-form-field>\r\n          <mat-select placeholder=\"Hotel Name - ID\" name=\"Hotel Name - ID\" formControlName=\"hotelId\" multiple required>\r\n            <mat-option [value]=\"null\"> Select </mat-option>\r\n            <mat-option *ngFor=\"let hotel of hotelList\" [value]=\"hotel.hotelId\">{{hotel.hotelName}} - {{hotel.hotelCode}}\r\n            </mat-option>\r\n          </mat-select>\r\n        </mat-form-field>\r\n      </div>\r\n    </div>\r\n    <div class=\"row customeRow\">\r\n      <div class=\"col-md-2\">\r\n        <mat-icon class=\"userImage\">account_circle</mat-icon>\r\n        <button class=\"deletePhoto\" mat-raised-button title=\"Delete Image\">\r\n          <i class=\"fa fa-times-thin\"></i>\r\n        </button>\r\n        <div class=\"image-upload\">\r\n          <label for=\"file-input\">\r\n            <img src=\"assets/uploadPhoto.png\" title=\"Upload Image\" />\r\n          </label>\r\n          <input id=\"file-input\" type=\"file\" />\r\n        </div>\r\n      </div>\r\n    </div>\r\n    <div class=\"row customeRow\">\r\n      <div class=\"form-group col-md-4 col-lg-3\">\r\n        <mat-form-field class=\"example-full-width\">\r\n          <input matInput placeholder=\"User Name\" id=\"userName\" formControlName=\"userName\" required />\r\n        </mat-form-field>\r\n      </div>\r\n      <div class=\"form-group col-md-4 col-lg-3\">\r\n        <mat-form-field>\r\n          <mat-select placeholder=\"Designation\" formControlName=\"designationId\" required>\r\n            <mat-option [value]=\"null\">Select</mat-option>\r\n            <mat-option *ngFor=\"let designation of designationList\" [value]=\"designation.designationId\">{{designation.title}}</mat-option>\r\n          </mat-select>\r\n        </mat-form-field>\r\n      </div>\r\n    </div>\r\n    <div class=\"row customeRow\">\r\n      <div class=\"form-group col-md-4 col-lg-3\">\r\n        <mat-form-field class=\"example-full-width\">\r\n          <input matInput placeholder=\"Email ID\" id=\"emailID\" formControlName=\"email\" pattern=\"\\w+@\\w+\\.\\w+(,\\s*\\w+@\\w+\\.\\w+)*\" required />\r\n        </mat-form-field>\r\n      </div>\r\n      <div class=\"form-group col-md-4 col-lg-3\">\r\n        <mat-form-field>\r\n          <mat-select placeholder=\"Role\" formControlName=\"extranetRoleId\" required>\r\n            <mat-option [value]=\"null\">Select</mat-option>\r\n            <mat-option *ngFor=\"let role of roleList\" [value]=\"role.id\">{{role.name}}</mat-option>\r\n          </mat-select>\r\n        </mat-form-field>\r\n      </div>\r\n    </div>\r\n    <div class=\"row customeRow\">\r\n      <div class=\"col-md-3\">\r\n        <mat-form-field class=\"example-full-width\">\r\n          <input matInput [matDatepicker]=\"activationDate\" placeholder=\"Activation Date\" formControlName=\"activationDate\"\r\n              [min]=\"(operation === create) ?  todaysDate : minDate\" required>\r\n            <mat-datepicker-toggle matSuffix [for]=\"activationDate\">\r\n                <mat-icon matDatepickerToggleIcon>\r\n                  <i class=\"fa fa-calendar\" aria-hidden=\"true\"></i>\r\n                </mat-icon>\r\n            </mat-datepicker-toggle>\r\n            <mat-datepicker #activationDate></mat-datepicker>\r\n        </mat-form-field>\r\n      </div>\r\n    </div>\r\n    <div class=\"row\">\r\n      <div class=\"col-md-12 controlButtons mt-5 mb-4\">\r\n        <button title=\"Save\" type=\"submit\" class=\"genericButton activeButton mat-primary mr-2\" [disabled]=\"!individualHotelForm.valid\" mat-raised-button>Save</button>\r\n        <button title=\"Cancel\" type=\"submit\" class=\"genericButton defaultButton\" mat-raised-button (click)=\"cancel()\">Cancel</button>\r\n      </div>\r\n    </div>\r\n  </form>\r\n</div>\r\n"

/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/hotel-user/individual-hotel-user-info/individual-hotel-user-info.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return IndividualHotelUserInfoComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__common_constants__ = __webpack_require__("../../../../../src/app/common/constants.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_forms__ = __webpack_require__("../../../forms/esm5/forms.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__common_backoffice_shared_services_backoffice_lookup__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/backoffice-lookup.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__common_backoffice_shared_services_user_data_service__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/user-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__angular_material__ = __webpack_require__("../../../material/esm5/material.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__common_shared_services_user_profile_service__ = __webpack_require__("../../../../../src/app/common/shared/services/user-profile.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








var IndividualHotelUserInfoComponent = (function () {
    function IndividualHotelUserInfoComponent(backOfficeLookUpService, activatedRoute, userDataService, snackBar, router, userProfileService) {
        this.backOfficeLookUpService = backOfficeLookUpService;
        this.activatedRoute = activatedRoute;
        this.userDataService = userDataService;
        this.snackBar = snackBar;
        this.router = router;
        this.userProfileService = userProfileService;
        this.edit = __WEBPACK_IMPORTED_MODULE_1__common_constants__["a" /* CONSTANTS */].operation.edit;
        this.create = __WEBPACK_IMPORTED_MODULE_1__common_constants__["a" /* CONSTANTS */].operation.create;
        this.read = __WEBPACK_IMPORTED_MODULE_1__common_constants__["a" /* CONSTANTS */].operation.read;
        this.mgHotelViewModel = {};
        this.todaysDate = new Date();
    }
    IndividualHotelUserInfoComponent.prototype.ngOnInit = function () {
        this.operation = this.activatedRoute.snapshot.params['operation'];
        this.userId = this.activatedRoute.snapshot.params['id'];
        this.individualHotelForm = new __WEBPACK_IMPORTED_MODULE_2__angular_forms__["FormGroup"]({
            hotelId: new __WEBPACK_IMPORTED_MODULE_2__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_2__angular_forms__["Validators"].required),
            userName: new __WEBPACK_IMPORTED_MODULE_2__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_2__angular_forms__["Validators"].required),
            designationId: new __WEBPACK_IMPORTED_MODULE_2__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_2__angular_forms__["Validators"].required),
            email: new __WEBPACK_IMPORTED_MODULE_2__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_2__angular_forms__["Validators"].required),
            extranetRoleId: new __WEBPACK_IMPORTED_MODULE_2__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_2__angular_forms__["Validators"].required),
            activationDate: new __WEBPACK_IMPORTED_MODULE_2__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_2__angular_forms__["Validators"].required),
        });
        if (this.operation.toLowerCase().trim() === this.edit) {
            this.Checked = true;
            this.getIndividualHotelUser(this.userId);
        }
        this.getDesignations();
        this.getRoles();
        this.getHotels();
    };
    IndividualHotelUserInfoComponent.prototype.getDesignations = function () {
        this.designationList = this.activatedRoute.snapshot.data['designations'];
    };
    IndividualHotelUserInfoComponent.prototype.getRoles = function () {
        this.roleList = this.activatedRoute.snapshot.data['roles'];
    };
    IndividualHotelUserInfoComponent.prototype.getHotels = function () {
        this.hotelList = this.activatedRoute.snapshot.data['hotels'];
    };
    IndividualHotelUserInfoComponent.prototype.saveIndividualHotelUserDetails = function () {
        var _this = this;
        var individualHotelUser = Object.assign({}, this.mgHotelViewModel, this.individualHotelForm.value);
        if (individualHotelUser.activationDate.toISOString() > this.todaysDate.toISOString()) {
            individualHotelUser.isActive = false;
        }
        else {
            individualHotelUser.isActive = true;
        }
        individualHotelUser.createdBy = this.userProfileService.GetBasicUserInfo().FirstName + ' ' +
            this.userProfileService.GetBasicUserInfo().LastName;
        individualHotelUser.updatedBy = this.userProfileService.GetBasicUserInfo().FirstName + ' ' +
            this.userProfileService.GetBasicUserInfo().LastName;
        individualHotelUser.userName = individualHotelUser.email;
        if (this.operation === this.create) {
            this.userDataService.createHotelUser(individualHotelUser)
                .subscribe(function (data) {
                window.scrollTo(0, 0);
                _this.snackBar.open('New user is created successfully', '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar' });
                _this.router.navigate(['/usermgmt/hoteluserslist']);
            });
        }
    };
    IndividualHotelUserInfoComponent.prototype.cancel = function () {
        window.scrollTo(0, 0);
        this.router.navigate(['/usermgmt/hoteluserslist']);
    };
    IndividualHotelUserInfoComponent.prototype.getIndividualHotelUser = function (userId) {
        var _this = this;
        this.userDataService.getHotelUserById(userId).subscribe(function (individualHotelUserData) {
            _this.individualHotelForm.get('userName').setValue(individualHotelUserData.userName);
            _this.individualHotelForm.get('email').setValue(individualHotelUserData.email);
            _this.individualHotelForm.get('extranetRoleId').setValue(individualHotelUserData.extranetRoleId);
            _this.individualHotelForm.get('designationId').setValue(individualHotelUserData.designationId);
            _this.individualHotelForm.get('activationDate').setValue(individualHotelUserData.activationDate);
            _this.individualHotelForm.get('hotelId').setValue(individualHotelUserData.hotelId);
        });
    };
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Output"])(),
        __metadata("design:type", Boolean)
    ], IndividualHotelUserInfoComponent.prototype, "Checked", void 0);
    IndividualHotelUserInfoComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-individual-hotel-user-info',
            template: __webpack_require__("../../../../../src/app/backoffice/user-mgmt/hotel-user/individual-hotel-user-info/individual-hotel-user-info.component.html"),
            styles: [__webpack_require__("../../../../../src/app/backoffice/user-mgmt/hotel-user/individual-hotel-user-info/individual-hotel-user-info.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_3__common_backoffice_shared_services_backoffice_lookup__["a" /* BackofficeLookupService */],
            __WEBPACK_IMPORTED_MODULE_4__angular_router__["ActivatedRoute"],
            __WEBPACK_IMPORTED_MODULE_5__common_backoffice_shared_services_user_data_service__["a" /* UserDataService */],
            __WEBPACK_IMPORTED_MODULE_6__angular_material__["F" /* MatSnackBar */],
            __WEBPACK_IMPORTED_MODULE_4__angular_router__["Router"],
            __WEBPACK_IMPORTED_MODULE_7__common_shared_services_user_profile_service__["a" /* UserProfileService */]])
    ], IndividualHotelUserInfoComponent);
    return IndividualHotelUserInfoComponent;
}());



/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/hotel-user/supplier-user-info/supplier-user-info.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/hotel-user/supplier-user-info/supplier-user-info.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"container-fluid\" style=\"-webkit-filter: blur(2px);\r\nfilter: blur(2px); pointer-events: none;\">\r\n  <form [formGroup]=\"individualHotelForm\">\r\n\r\n    <div class=\"row customeRow\">\r\n      <div class=\"form-group col-md-4 col-lg-3 mb-0\">\r\n        <mat-select placeholder=\"Supplier\" name=\"Supplier\" required>\r\n          <mat-option [value]=\"null\"> Select </mat-option>\r\n          <mat-option [value]=\"1\"> select </mat-option>\r\n        </mat-select>\r\n      </div>\r\n      <div class=\"form-group col-md-4 col-lg-3 mb-0\">\r\n        <mat-form-field>\r\n          <input type=\"text\" matInput placeholder=\"Search by Hotel Name/Code\" formControlName=\"hotelNameId\" [matAutocomplete]=\"auto\">\r\n        </mat-form-field>\r\n      </div>\r\n\r\n    </div>\r\n\r\n    <div class=\"row customeRow\">\r\n      <div class=\"col-md-2\">\r\n        <mat-icon class=\"userImage\">account_circle</mat-icon>\r\n        <button class=\"deletePhoto\" mat-raised-button title=\"Delete Image\">\r\n          <i class=\"fa fa-times-thin\"></i>\r\n        </button>\r\n        <div class=\"image-upload\">\r\n          <label for=\"file-input\">\r\n            <img src=\"assets/uploadPhoto.png\" title=\"Upload Image\" />\r\n          </label>\r\n          <input id=\"file-input\" type=\"file\" />\r\n        </div>\r\n      </div>\r\n    </div>\r\n\r\n    <div class=\"row customeRow\">\r\n      <div class=\"form-group col-md-4 col-lg-3\">\r\n        <mat-form-field class=\"example-full-width\">\r\n          <input matInput placeholder=\"User Name\" id=\"userName\" formControlName=\"userName\" required />\r\n        </mat-form-field>\r\n      </div>\r\n      <div class=\"form-group col-md-4 col-lg-3\">\r\n        <mat-form-field>\r\n          <mat-select placeholder=\"Designation\" formControlName=\"designation\" required>\r\n            <mat-option [value]=\"null\">Select</mat-option>\r\n            <mat-option *ngFor=\"let designation of designationList\" [value]=\"designation.designationId\">{{designation.title}}</mat-option>\r\n          </mat-select>\r\n        </mat-form-field>\r\n      </div>\r\n    </div>\r\n\r\n\r\n    <div class=\"row customeRow\">\r\n      <div class=\"form-group col-md-4 col-lg-3\">\r\n        <mat-form-field class=\"example-full-width\">\r\n          <input matInput placeholder=\"Email ID\" id=\"emailID\" formControlName=\"email\" required />\r\n        </mat-form-field>\r\n      </div>\r\n      <div class=\"form-group col-md-4 col-lg-3\">\r\n        <mat-form-field>\r\n          <mat-select placeholder=\"Role\" formControlName=\"role\" required>\r\n            <mat-option [value]=\"null\">Select</mat-option>\r\n            <mat-option *ngFor=\"let role of roleList\" [value]=\"role.id\">{{role.name}}</mat-option>\r\n          </mat-select>\r\n        </mat-form-field>\r\n      </div>\r\n    </div>\r\n\r\n    <div class=\"row customeRow\">\r\n      <div class=\"col-md-3\">\r\n        <mat-form-field class=\"example-full-width\">\r\n          <input matInput [matDatepicker]=\"activationDate\" placeholder=\"Activation Date\" formControlName=\"activationDate\"\r\n                 [min]=\"(operation === create) ? (agentForm.get('activationDate').value || todaysDate) : minDate\"\r\n                 required>\r\n          <mat-datepicker-toggle matSuffix [for]=\"activationDate\">\r\n            <mat-icon matDatepickerToggleIcon>\r\n              <i class=\"fa fa-calendar\" aria-hidden=\"true\"></i>\r\n            </mat-icon>\r\n          </mat-datepicker-toggle>\r\n          <mat-datepicker #activationDate></mat-datepicker>\r\n\r\n        </mat-form-field>\r\n      </div>\r\n    </div>\r\n\r\n    <div class=\"row\">\r\n      <div class=\"col-md-12 controlButtons mt-5 mb-4\">\r\n        <button title=\"Save\" type=\"submit\" class=\"genericButton activeButton mat-primary mr-2\" mat-raised-button>Save</button>\r\n        <button title=\"Cancel\" type=\"submit\" class=\"genericButton defaultButton\" mat-raised-button>Cancel</button>\r\n      </div>\r\n    </div>\r\n  </form>\r\n\r\n</div>\r\n"

/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/hotel-user/supplier-user-info/supplier-user-info.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return SupplierUserInfoComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_forms__ = __webpack_require__("../../../forms/esm5/forms.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__common_constants__ = __webpack_require__("../../../../../src/app/common/constants.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__common_backoffice_shared_services_backoffice_lookup__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/backoffice-lookup.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





var SupplierUserInfoComponent = (function () {
    function SupplierUserInfoComponent(backOfficeLookUpService, activatedRoute) {
        this.backOfficeLookUpService = backOfficeLookUpService;
        this.activatedRoute = activatedRoute;
        this.edit = __WEBPACK_IMPORTED_MODULE_2__common_constants__["a" /* CONSTANTS */].operation.edit;
        this.create = __WEBPACK_IMPORTED_MODULE_2__common_constants__["a" /* CONSTANTS */].operation.create;
        this.read = __WEBPACK_IMPORTED_MODULE_2__common_constants__["a" /* CONSTANTS */].operation.read;
    }
    SupplierUserInfoComponent.prototype.ngOnInit = function () {
        this.individualHotelForm = new __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormGroup"]({
            hotelNameId: new __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormControl"],
            userName: new __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].required),
            designation: new __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].required),
            email: new __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].required),
            role: new __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].required),
            activationDate: new __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].required),
        });
        this.getDesignations();
        this.getRoles();
    };
    SupplierUserInfoComponent.prototype.getDesignations = function () {
        this.designationList = this.activatedRoute.snapshot.data['designations'];
    };
    SupplierUserInfoComponent.prototype.getRoles = function () {
        this.roleList = this.activatedRoute.snapshot.data['roles'];
    };
    SupplierUserInfoComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-supplier-user-info',
            template: __webpack_require__("../../../../../src/app/backoffice/user-mgmt/hotel-user/supplier-user-info/supplier-user-info.component.html"),
            styles: [__webpack_require__("../../../../../src/app/backoffice/user-mgmt/hotel-user/supplier-user-info/supplier-user-info.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_3__common_backoffice_shared_services_backoffice_lookup__["a" /* BackofficeLookupService */],
            __WEBPACK_IMPORTED_MODULE_4__angular_router__["ActivatedRoute"]])
    ], SupplierUserInfoComponent);
    return SupplierUserInfoComponent;
}());



/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/mg-user/mg-user-info/mg-user-info.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "\r\n.transparent-circle span:before{\r\n    top:-11px;\r\n}\r\n\r\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/mg-user/mg-user-info/mg-user-info.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"container-fluid pt-4\">\r\n  <div class=\"customBreadcrumb mb-4\">\r\n    <span>MG </span>\r\n    <span *ngIf=\"operation == 'create'\">&gt; Create New MG User</span>\r\n    <span *ngIf=\"operation == 'edit'\">&gt; Edit MG User</span>\r\n    <span class=\"mandatoryInfo\">Indicates Mandatory Fields</span>\r\n  </div>\r\n  <h1 *ngIf=\"operation == 'create'\" class=\"mainHeading mb-2\">Create New User</h1>\r\n  <h1 *ngIf=\"operation == 'edit'\" class=\"mainHeading mb-2\">Edit User</h1>\r\n  <form [formGroup]=\"mgUserForm\" (ngSubmit)=\"saveUser()\">\r\n  <div class=\"row customeRow\">\r\n    <div class=\"col-md-2\">\r\n      <mat-icon class=\"userImage\">account_circle</mat-icon>\r\n      <button class=\"deletePhoto\" mat-raised-button title=\"Delete Image\">\r\n        <i class=\"fa fa-times-thin\"></i>\r\n      </button>\r\n      <div class=\"image-upload\">\r\n        <label for=\"file-input\">\r\n          <img src=\"assets/uploadPhoto.png\" title=\"Upload Image\" />\r\n        </label>\r\n        <input id=\"file-input\" type=\"file\" />\r\n      </div>\r\n    </div>\r\n  </div>\r\n\r\n  <div class=\"row customeRow formSections p-0 borderBottomNone\">\r\n    <div class=\"form-group col-md-4 col-lg-3 mb-0\">\r\n      <mat-form-field>\r\n        <input matInput placeholder=\"User Name\" formControlName=\"userName\" id=\"userName\" required />\r\n      </mat-form-field>\r\n    </div>\r\n    <div class=\"form-group col-md-4 col-lg-3 mb-0\">\r\n      <mat-form-field>\r\n        <input matInput placeholder=\"Employee ID\" formControlName=\"employeeId\" id=\"employeeID\" required />\r\n      </mat-form-field>\r\n    </div>\r\n  </div>\r\n\r\n  <div class=\"row customeRow formSections p-0 borderBottomNone\">\r\n\r\n    <div class=\"form-group col-md-4 col-lg-3\">\r\n      <mat-form-field>\r\n        <input matInput placeholder=\"Email ID\" formControlName=\"email\" id=\"email\" required />\r\n      </mat-form-field>\r\n    </div>\r\n    <div class=\"form-group col-md-4 col-lg-3\">\r\n      <mat-form-field>\r\n        <mat-select placeholder=\"Department(s)\" name=\"department\" formControlName=\"departments\" multiple required>\r\n          <mat-option *ngFor=\"let department of departmentList\" [value]=\"department.id\">{{department.name}}</mat-option>\r\n        </mat-select>\r\n      </mat-form-field>\r\n    </div>\r\n  </div>\r\n\r\n  <div formArrayName=\"userApplicationRole\" *ngFor=\"let appRole of userApplicationRole.controls; let i =index\">\r\n\r\n    <div [formGroupName]=\"i\">\r\n      <div class=\"row customeRow formSections p-0 borderBottomNone alignItemCenter\">\r\n        <div class=\"form-group col-md-4 col-lg-3 mb-0\">\r\n          <mat-form-field>\r\n            <mat-select formControlName=\"applicationId\" placeholder=\"Application\" (change)=\"getRolesForApplication(i)\" required >\r\n                <mat-option [value]=\"null\">Select</mat-option>\r\n              <ng-container *ngFor=\"let app of applicationList\">\r\n                <mat-option [value]=\"app.id\">{{app.name}}</mat-option>\r\n              </ng-container>\r\n            </mat-select>\r\n          </mat-form-field>\r\n        </div>\r\n        <div class=\"form-group col-md-4 col-lg-3 mb-0\">\r\n          <mat-form-field>\r\n            <mat-select formControlName=\"roleId\" placeholder=\"Roles\"  required>\r\n                <mat-option [value]=\"null\">Select</mat-option>\r\n              <ng-container *ngFor=\"let role of this.appRolesListArray[i] \">\r\n                <mat-option [value]=\"role.id\">{{role.name}}</mat-option>\r\n              </ng-container>\r\n            </mat-select>\r\n        </mat-form-field>\r\n\r\n    </div>\r\n    <div class=\"col-md-2 pl-0\">\r\n      <span class=\"btn transparent-circle mr-2\" title=\"Add\" [hidden]='isMaxLength' (click)=\"addAppRole()\"><span></span></span>\r\n\t\t<ng-container *ngIf=\"i > 0\">\r\n        <span class=\"btn transparent-circle\" title=\"Delete\" (click)=\"deleteAppRole(i)\"><i aria-hidden=\"true\" class=\"fa fa-times-thin\"></i></span>\r\n      </ng-container>\r\n\t</div>\r\n  </div>\r\n</div>\r\n</div>\r\n<div>\r\n<mat-error *ngIf=\"mgUserForm.get('userApplicationRole').errors && mgUserForm.get('userApplicationRole').errors.ValidateAppRole\">\r\n  This app type is already selected.\r\n </mat-error>\r\n\r\n <mat-error *ngIf=\"mgUserForm.get('userApplicationRole').errors && mgUserForm.get('userApplicationRole').errors.ValidateAppRoleNotNull\">\r\n  Role needs to be selected\r\n </mat-error>\r\n\r\n</div>\r\n\r\n  <div class=\"row customeRow formSections p-0 borderBottomNone\">\r\n    <div class=\"form-group col-md-3 pt-3 mb-0\">\r\n      <mat-form-field>\r\n        <input matInput [matDatepickerFilter]=\"myFilter\" [matDatepicker]=\"picker\" placeholder=\"Activation Date\" formControlName=\"activationDate\" required>\r\n        <mat-datepicker-toggle matSuffix [for]=\"picker\">\r\n        <mat-icon matDatepickerToggleIcon>\r\n          <i class=\"fa fa-calendar\" aria-hidden=\"true\"></i>\r\n        </mat-icon>\r\n      </mat-datepicker-toggle>\r\n        <mat-datepicker #picker></mat-datepicker>\r\n      </mat-form-field>\r\n    </div>\r\n  </div>\r\n\t<div class=\"row\">\r\n\t  <div class=\"controlButtons pl-3 mt-5 mb-4\">\r\n\t\t<button title=\"Save\" type=\"submit\" class=\"genericButton activeButton mat-primary mr-2\" mat-raised-button>Save</button>\r\n\t\t<button title=\"Cancel\" type=\"button\" class=\"genericButton defaultButton\" mat-raised-button (click)=\"cancel()\">Cancel</button>\r\n\t  </div>\r\n  </div>\r\n</form>\r\n</div>\r\n"

/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/mg-user/mg-user-info/mg-user-info.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return MgUserInfoComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__common_constants__ = __webpack_require__("../../../../../src/app/common/constants.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_forms__ = __webpack_require__("../../../forms/esm5/forms.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__angular_material__ = __webpack_require__("../../../material/esm5/material.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__common_backoffice_shared_services_user_data_service__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/user-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__common_backoffice_shared_services_backoffice_lookup__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/backoffice-lookup.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__common_shared_services_user_profile_service__ = __webpack_require__("../../../../../src/app/common/shared/services/user-profile.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








function ValidateAppRole(control) {
    var appRoleList = control;
    if ((appRoleList.value !== undefined) && (appRoleList.value !== null) &&
        (appRoleList.value.length > 0)) {
        var appList_1 = [];
        var appRoleArray_1 = [];
        appRoleList.value.forEach(function (element) {
            appList_1.push(element.applicationId);
            appRoleArray_1.push({ applicationId: element.applicationId, roleId: element.roleId });
        });
        var sorterAppList = appList_1.sort();
        var duplicateApp = false;
        for (var i = 0; i < sorterAppList.length - 1; i++) {
            if (sorterAppList[i + 1] != null && sorterAppList[i] != null) {
                if (sorterAppList[i + 1] === sorterAppList[i]) {
                    return { 'ValidateAppRole': true };
                }
            }
        }
        for (var i = 0; i < appRoleArray_1.length; i++) {
            if (appRoleArray_1[i] != null) {
                if (appRoleArray_1[i].applicationId !== null && appRoleArray_1[i].roleId === null) {
                    return { 'ValidateAppRoleNotNull': true };
                }
            }
        }
    }
    return null;
}
var MgUserInfoComponent = (function () {
    function MgUserInfoComponent(router, activatedRoute, cd, snackBar, userDataService, backofficeLookupService, userProfileService) {
        this.router = router;
        this.activatedRoute = activatedRoute;
        this.cd = cd;
        this.snackBar = snackBar;
        this.userDataService = userDataService;
        this.backofficeLookupService = backofficeLookupService;
        this.userProfileService = userProfileService;
        this.edit = __WEBPACK_IMPORTED_MODULE_2__common_constants__["a" /* CONSTANTS */].operation.edit;
        this.create = __WEBPACK_IMPORTED_MODULE_2__common_constants__["a" /* CONSTANTS */].operation.create;
        this.read = __WEBPACK_IMPORTED_MODULE_2__common_constants__["a" /* CONSTANTS */].operation.read;
        this.mgUserViewModel = {};
        this.appRolesListArray = Array();
    }
    MgUserInfoComponent.prototype.ngOnInit = function () {
        // Get the id from the activated route
        this.userId = this.activatedRoute.snapshot.params['id'];
        this.operation = this.activatedRoute.snapshot.params['operation'];
        // Get all the master data
        this.getDepartments();
        this.getApplications();
        // Create the Form Model
        this.mgUserForm = new __WEBPACK_IMPORTED_MODULE_3__angular_forms__["FormGroup"]({
            userName: new __WEBPACK_IMPORTED_MODULE_3__angular_forms__["FormControl"](),
            employeeId: new __WEBPACK_IMPORTED_MODULE_3__angular_forms__["FormControl"](),
            email: new __WEBPACK_IMPORTED_MODULE_3__angular_forms__["FormControl"](),
            // multiSelectedDepartmentIds: new FormControl(['a7140da7-b28b-4f6d-cbbc-08d58a2490fd']),
            departments: new __WEBPACK_IMPORTED_MODULE_3__angular_forms__["FormControl"](),
            activationDate: new __WEBPACK_IMPORTED_MODULE_3__angular_forms__["FormControl"](),
            userApplicationRole: new __WEBPACK_IMPORTED_MODULE_3__angular_forms__["FormArray"]([], ValidateAppRole),
        });
        if (this.operation.toLowerCase().trim() === this.create) {
            this.addAppRole();
        }
        else if (this.operation.toLocaleLowerCase().trim() === this.edit) {
            // Get Roles for the application ;
            this.getMGUser(this.userId);
        }
    };
    MgUserInfoComponent.prototype.getMGUser = function (userId) {
        var _this = this;
        this.userDataService.getMGUserById(userId).subscribe(function (mgUserData) {
            if (_this.operation.toLowerCase().trim() === _this.edit) {
                _this.mgUserViewModel = mgUserData;
                _this.mgUserForm.get('userName').setValue(mgUserData.userName);
                _this.mgUserForm.get('employeeId').setValue(mgUserData.employeeId);
                _this.mgUserForm.get('email').setValue(mgUserData.email);
                var departmentIds = [];
                for (var _i = 0, _a = mgUserData.departments; _i < _a.length; _i++) {
                    var departmentId = _a[_i];
                    departmentIds.push(departmentId);
                }
                _this.mgUserForm.get('departments').setValue(departmentIds);
                // this.mgUserForm.get('userApplicationRole').setValue(mgUserData.userApplicationRole);
                _this.mgUserForm.get('activationDate').setValue(mgUserData.activationDate);
                var applicationRoleIdArray = [];
                var appRoleValue_1 = mgUserData.userApplicationRole;
                for (var i = 0; i < appRoleValue_1.length; i++) {
                    _this.addAppRole();
                }
                _this.userApplicationRole.controls.forEach(function (control, index) {
                    control.get('applicationId').setValue(appRoleValue_1[index].applicationId);
                    _this.getRolesForApplication(index);
                    control.get('roleId').setValue(appRoleValue_1[index].roleId);
                });
            }
        });
    };
    MgUserInfoComponent.prototype.getDepartments = function () {
        this.departmentList = this.activatedRoute.snapshot.data['departments'];
    };
    MgUserInfoComponent.prototype.getApplications = function () {
        this.applicationList = this.activatedRoute.snapshot.data['applications'];
    };
    Object.defineProperty(MgUserInfoComponent.prototype, "userApplicationRole", {
        get: function () {
            return this.mgUserForm.get('userApplicationRole');
        },
        enumerable: true,
        configurable: true
    });
    MgUserInfoComponent.prototype.buildAppRole = function () {
        var appRoleFormGroup;
        appRoleFormGroup = new __WEBPACK_IMPORTED_MODULE_3__angular_forms__["FormGroup"]({
            applicationId: new __WEBPACK_IMPORTED_MODULE_3__angular_forms__["FormControl"](),
            roleId: new __WEBPACK_IMPORTED_MODULE_3__angular_forms__["FormControl"]()
        });
        return appRoleFormGroup;
    };
    MgUserInfoComponent.prototype.addAppRole = function () {
        this.userApplicationRole.push(this.buildAppRole());
        if (this.appRolesListArray === null || this.appRolesListArray === undefined) {
            this.appRolesListArray = new Array();
        }
        else {
            this.appRolesListArray.push([]);
        }
        if (this.userApplicationRole.length === this.applicationList.length) {
            this.isMaxLength = true;
        }
        this.cd.detectChanges();
    };
    MgUserInfoComponent.prototype.deleteAppRole = function (index) {
        this.isMaxLength = false;
        this.userApplicationRole.removeAt(index);
        this.appRolesListArray.splice(index, 1);
        this.cd.detectChanges();
    };
    MgUserInfoComponent.prototype.getRolesForApplication = function (applicationIndex) {
        var _this = this;
        var applicationId = this.userApplicationRole.controls[applicationIndex].get('applicationId').value;
        this.appRoles = this.backofficeLookupService.getRolesByApplicationId(applicationId);
        this.appRoles.subscribe(function (data) {
            _this.appRolesListArray[applicationIndex] = data;
        });
    };
    MgUserInfoComponent.prototype.saveUser = function () {
        var _this = this;
        var savedMGUser = Object.assign({}, this.mgUserViewModel, this.mgUserForm.value);
        savedMGUser.updatedBy = this.userProfileService.GetBasicUserInfo().FirstName + ' ' +
            this.userProfileService.GetBasicUserInfo().LastName;
        if (this.operation === this.create) {
            savedMGUser.createdBy = this.userProfileService.GetBasicUserInfo().FirstName + ' ' +
                this.userProfileService.GetBasicUserInfo().LastName;
            this.userDataService.createMGUser(savedMGUser)
                .subscribe(function (data) {
                window.scrollTo(0, 0);
                _this.snackBar.open('New user is created successfully', '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar' });
                _this.router.navigate(['/usermgmt/mgusers']);
            });
        }
        else if (this.operation === this.edit) {
            savedMGUser.createdBy = this.mgUserViewModel.createdBy;
            this.userDataService.updateMGUser(this.userId, savedMGUser)
                .subscribe(function (data) {
                window.scrollTo(0, 0);
                _this.snackBar.open('The user is updated successfully', '', { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar' });
                _this.router.navigate(['/usermgmt/mgusers']);
            });
        }
    };
    MgUserInfoComponent.prototype.cancel = function () {
        window.scrollTo(0, 0);
        this.router.navigate(['/usermgmt/mgusers']);
    };
    MgUserInfoComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-mg-user-info',
            template: __webpack_require__("../../../../../src/app/backoffice/user-mgmt/mg-user/mg-user-info/mg-user-info.component.html"),
            styles: [__webpack_require__("../../../../../src/app/backoffice/user-mgmt/mg-user/mg-user-info/mg-user-info.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_router__["Router"],
            __WEBPACK_IMPORTED_MODULE_1__angular_router__["ActivatedRoute"],
            __WEBPACK_IMPORTED_MODULE_0__angular_core__["ChangeDetectorRef"],
            __WEBPACK_IMPORTED_MODULE_4__angular_material__["F" /* MatSnackBar */],
            __WEBPACK_IMPORTED_MODULE_5__common_backoffice_shared_services_user_data_service__["a" /* UserDataService */],
            __WEBPACK_IMPORTED_MODULE_6__common_backoffice_shared_services_backoffice_lookup__["a" /* BackofficeLookupService */],
            __WEBPACK_IMPORTED_MODULE_7__common_shared_services_user_profile_service__["a" /* UserProfileService */]])
    ], MgUserInfoComponent);
    return MgUserInfoComponent;
}());



/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/mg-user/mg-user-list/mg-user-list.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ".usernameTH{\r\n\twidth:14%;\r\n}\r\n.empIDTH{width:12%;}\r\n.emailTH{width:14%;}\r\n.departmentTH{width:10%;}\r\n.applicationRoleTH{width: 14%;}\r\n.activationTH{width: 16%;}\r\n.userStatusTH{\r\n\twidth:10%; \r\n\tdisplay:-webkit-box; \r\n\tdisplay:-ms-flexbox; \r\n\tdisplay:flex;\r\n\t-webkit-box-align: center;\r\n\t    -ms-flex-align: center;\r\n\t        align-items: center;\r\n}\r\n.userActionTH{width:10%;}\r\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/mg-user/mg-user-list/mg-user-list.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"container-fluid pt-4\">\r\n  <h1 class=\"mainHeading mb-4 mt-2\">MG</h1>\r\n      <form [formGroup]=\"searchUsers\" (ngSubmit)=\"findUsers(searchUsers.get('searchText').value,searchUsers.get('startDate').value,searchUsers.get('endDate').value)\"\r\n      class=\"w-100\">\r\n\r\n        <div class=\"blueBackground pb-2 pl-4 pr-4 pt-2 alignItemCenter\">\r\n          <div class=\"row formSections borderBottomNone p-0\">\r\n                <div class=\"col-md-7\">\r\n                  <mat-form-field>\r\n                    <input matInput placeholder=\"Search by User Name, Employee ID, Email ID, Departments, Application, Roles, Activation date \" formControlName=\"searchText\" (keydown.backspace)=\"checkIsInputCleared()\">\r\n                  </mat-form-field>\r\n                </div>\r\n\r\n          <div class=\"col-md-2 d-flex pr-0\">\r\n          <label class=\"optionsList mb-0 alignItemCenter pr-3\">From:</label>\r\n            <mat-form-field>\r\n                <mat-datepicker-toggle matSuffix [for]=\"sdate\">\r\n                    <mat-icon matDatepickerToggleIcon>\r\n                    <i class=\"fa fa-calendar\" aria-hidden=\"true\"></i>\r\n                    </mat-icon>\r\n                </mat-datepicker-toggle>\r\n                  <input matInput [matDatepicker]=\"sdate\" placeholder=\"DD-MMM-YY\" formControlName=\"startDate\">\r\n                  <mat-datepicker #sdate></mat-datepicker>\r\n            </mat-form-field>\r\n                </div>\r\n                <div class=\"col-md-3 d-flex pr-0\">\r\n          <label class=\"optionsList mb-0 alignItemCenter pr-3\">To:</label>\r\n                  <mat-form-field>\r\n                    <input matInput [matDatepicker]=\"enddate\" placeholder=\"DD-MMM-YY\" formControlName=\"endDate\" [min]=\"searchUsers.get('startDate').value\">\r\n                    <mat-datepicker-toggle matSuffix [for]=\"enddate\">\r\n                      <mat-icon matDatepickerToggleIcon>\r\n                        <i class=\"fa fa-calendar\" aria-hidden=\"true\"></i>\r\n                      </mat-icon>\r\n                    </mat-datepicker-toggle>\r\n                    <mat-datepicker #enddate></mat-datepicker>\r\n                  </mat-form-field>\r\n                  <div class=\"controlButtons ml-4 mt-2\">\r\n                    <button title=\"Search\" type=\"submit\" class=\"genericButton genericSmallButton activeButton mat-primary mt-1\" mat-raised-button>Search</button>\r\n                  </div>\r\n                </div>\r\n              </div>\r\n            </div>\r\n    </form>\r\n    <div class=\"row\">\r\n      <div class=\"col-md-12 controlButtons pt-5 pb-4\">\r\n      <button title=\"Create New MG User\" type=\"submit\" class=\"genericButton genericSmallButton defaultButton\" mat-raised-button\r\n        (click)=\"createMgUser()\">\r\n        <i class=\"fa fa-plus-circle\" aria-hidden=\"true\"></i><span>Create New MG User</span></button>\r\n      </div>\r\n    </div>\r\n    <mat-table #table [dataSource]= '!isSearch ? dataSource: filteredData' matSort (matSortChange)=\"sortData($event)\" matSortActive=\"activationDate\" matSortDirection=\"desc\" class=\"flexNone genericTable mb-2\">\r\n\r\n      <ng-container matColumnDef=\"userName\">\r\n        <mat-header-cell class =\"usernameTH alignItemCenter pr-0\" *matHeaderCellDef mat-sort-header> User Name </mat-header-cell>\r\n          <mat-cell class =\"usernameTH\" *matCellDef=\"let element\"><div class=\"d-flex\"><mat-icon class=\"userIcon alignItemCenter\">account_circle</mat-icon><span class=\"d-flex pl-4 alignItemCenter\">{{element.userName}}</span></div></mat-cell>\r\n        </ng-container>\r\n\r\n      <ng-container matColumnDef=\"employeeId\">\r\n        <mat-header-cell class =\"empIDTH\" *matHeaderCellDef mat-sort-header> Employee ID </mat-header-cell>\r\n        <mat-cell class =\"empIDTH\" *matCellDef=\"let element\"> {{element.employeeId}} </mat-cell>\r\n      </ng-container>\r\n\r\n      <ng-container matColumnDef=\"email\">\r\n        <mat-header-cell class =\"emailTH\" *matHeaderCellDef mat-sort-header> Email ID </mat-header-cell>\r\n        <mat-cell class =\"emailTH\" *matCellDef=\"let element\"> {{element.email}} </mat-cell>\r\n      </ng-container>\r\n\r\n      <ng-container matColumnDef=\"departments\">\r\n        <mat-header-cell class =\"departmentTH pl-0 pr-0\" *matHeaderCellDef mat-sort-header> Department(s) </mat-header-cell>\r\n        <mat-cell class =\"departmentTH pl-0 pr-0\" *matCellDef=\"let element\">\r\n          <ng-container *ngFor=\"let c of element.departments\">\r\n              <ng-container *ngIf=\"element.departments[0].name == c.name\">\r\n                  {{c.name}}<span>,</span>\r\n                  </ng-container>\r\n                  <ng-container *ngIf=\"element.departments[0].name != c.name\">\r\n                     {{c.name}}\r\n                  </ng-container>\r\n          </ng-container>\r\n        </mat-cell>\r\n      </ng-container>\r\n\r\n      <ng-container matColumnDef=\"userApplicationRole\">\r\n          <mat-header-cell class =\"applicationRoleTH\" *matHeaderCellDef mat-sort-header> Application(s) &amp; Role(s)\r\n            </mat-header-cell>\r\n          <mat-cell class =\"applicationRoleTH\" *matCellDef=\"let element\">\r\n              <ng-container *ngFor=\"let c of element.userApplicationRole\">\r\n                        <span class=\"d-block\">{{c.applicationName}} - {{c.roleName}}</span>\r\n                </ng-container>\r\n             </mat-cell>\r\n        </ng-container>\r\n\r\n        <ng-container matColumnDef=\"activationDate\">\r\n          <mat-header-cell class =\"activationTH\" *matHeaderCellDef mat-sort-header>\r\n\t\t  <span class=\"text-center\"><span class=\"d-block\">Activation/</span>Inactivation Date</span></mat-header-cell>\r\n          <mat-cell class =\"activationTH\" *matCellDef=\"let element\"><span class=\"d-block\">{{element.activationDate | date : \"dd-MMM-yy\"}}/</span>\r\n            <ng-container *ngIf=\"!element.isActive\">\r\n              {{element.deActivationDate | date : \"dd-MMM-yy\"}}\r\n              </ng-container>\r\n          </mat-cell>\r\n        </ng-container>\r\n\r\n      <ng-container matColumnDef=\"isActive\">\r\n          <mat-header-cell class=\"userStatusTH noOutlineOnFocus\" *matHeaderCellDef mat-sort-header> Status </mat-header-cell>\r\n          <mat-cell class=\"userStatusTH\" *matCellDef=\"let element\">\r\n            <ng-container *ngIf=\"element.isActive\">\r\n              <i class=\"fa fa-circle active_status\" aria-hidden=\"true\"></i>Active</ng-container>\r\n            <ng-container *ngIf=\"!element.isActive\">\r\n              <i class=\"fa fa-circle inactive_status\" aria-hidden=\"true\"></i>InActive\r\n             <span matTooltip=\"Activation Date:{{element.activationDate | date : 'dd-MMM-yy'}}/&#010; Deactivation Date: {{element.deActivationDate | date : 'dd-MMM-yy'}}\" matTooltipPosition=\"below\"><i class=\"fa fa-info-circle ml-2\" aria-hidden=\"true\"></i></span>\r\n            </ng-container>\r\n          </mat-cell>\r\n        </ng-container>\r\n\r\n        <ng-container  matColumnDef=\"actions\" class=\"text-center\">\r\n          <mat-header-cell class=\"userActionTH noOutlineOnFocus\" *matHeaderCellDef mat-sort-header> </mat-header-cell>\r\n          <mat-cell class=\"userActionTH\" *matCellDef=\"let element\">\r\n            <mat-select placeholder=\"Actions\" name=\"Actions\" [(ngModel)]=\"actions\">\r\n                <ng-container *ngIf=\"element.isActive\">\r\n                     <mat-option value=\"{{element.id}}:edit\" #edit (click)=\"GoUserUpdate(edit.value)\">Edit</mat-option>\r\n                </ng-container>\r\n              <mat-option value=\"{{element.id}}:delete\" #delete (click)=\"GoUserDelete(delete.value)\">Delete</mat-option>\r\n            </mat-select>\r\n          </mat-cell>\r\n        </ng-container>\r\n\r\n  <mat-header-row *matHeaderRowDef=\"displayedColumns\"></mat-header-row>\r\n  <mat-row *matRowDef=\"let row; columns: displayedColumns;\"></mat-row>\r\n\r\n  </mat-table>\r\n  <mat-paginator #paginator class=\"genericPagination\" [pageSize]=\"10\" [pageSizeOptions]=\"[5, 10, 20]\"></mat-paginator>\r\n\r\n  </div>\r\n\r\n"

/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/mg-user/mg-user-list/mg-user-list.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export DatePickerDateAdapter */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return MgUserListComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_forms__ = __webpack_require__("../../../forms/esm5/forms.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__common_constants__ = __webpack_require__("../../../../../src/app/common/constants.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__common_backoffice_shared_services_user_data_service__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/user-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__angular_material__ = __webpack_require__("../../../material/esm5/material.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__angular_material_core__ = __webpack_require__("../../../material/esm5/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__angular_common__ = __webpack_require__("../../../common/esm5/common.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__common_backoffice_shared_dialogs_dialogs_service__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/dialogs/dialogs.service.ts");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};









var DATE_FORMATS = {
    parse: {
        dateInput: { month: 'short', year: 'numeric', day: 'numeric' }
    },
    display: {
        dateInput: 'input',
        monthYearLabel: { year: 'numeric', month: 'short' },
        dateA11yLabel: { year: 'numeric', month: 'long', day: 'numeric' },
        monthYearA11yLabel: { year: 'numeric', month: 'long' },
    }
};
var DatePickerDateAdapter = (function (_super) {
    __extends(DatePickerDateAdapter, _super);
    function DatePickerDateAdapter() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    DatePickerDateAdapter.prototype.format = function (date, displayFormat) {
        date.setMinutes((date.getTimezoneOffset() * -1));
        if (displayFormat === 'input') {
            var day = date.getDate();
            var month = date.toLocaleString('en-us', { month: 'long' });
            var year = date.getFullYear();
            return this._to2digit(day) + '-' + month.substring(0, 3) + '-' + year % 100;
        }
        else {
            return date.toDateString();
        }
    };
    DatePickerDateAdapter.prototype._to2digit = function (n) {
        return ('00' + n).slice(-2);
    };
    return DatePickerDateAdapter;
}(__WEBPACK_IMPORTED_MODULE_6__angular_material_core__["u" /* NativeDateAdapter */]));

var MgUserListComponent = (function () {
    function MgUserListComponent(router, activatedRoute, userDataService, dialogsService, datepipe) {
        this.router = router;
        this.activatedRoute = activatedRoute;
        this.userDataService = userDataService;
        this.dialogsService = dialogsService;
        this.datepipe = datepipe;
        this.edit = __WEBPACK_IMPORTED_MODULE_3__common_constants__["a" /* CONSTANTS */].operation.edit;
        this.create = __WEBPACK_IMPORTED_MODULE_3__common_constants__["a" /* CONSTANTS */].operation.create;
        this.read = __WEBPACK_IMPORTED_MODULE_3__common_constants__["a" /* CONSTANTS */].operation.read;
        this.displayedColumns = [/*'firstName'*/ 'userName', 'employeeId', 'email', 'departments',
            'userApplicationRole', 'activationDate', 'isActive', 'actions'];
    }
    MgUserListComponent.prototype.ngOnInit = function () {
        this.getMgUserList();
        this.isSearch = false;
        this.searchUsers = new __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormGroup"]({
            startDate: new __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormControl"](),
            endDate: new __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormControl"](),
            searchText: new __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormControl"]()
        });
    };
    MgUserListComponent.prototype.findUsers = function (filterValue, filterFrom, filterTo) {
        var _this = this;
        if (filterFrom !== null || filterTo !== null || (filterValue !== null && filterValue.length >= 3)) {
            this.isSearch = true;
        }
        if (filterFrom !== null) {
            filterFrom = this.datepipe.transform(filterFrom, 'yyyy-MM-dd');
        }
        if (filterTo !== null) {
            filterTo = this.datepipe.transform(filterTo, 'yyyy-MM-dd');
        }
        if (filterValue !== null) {
            filterValue = filterValue.trim();
            filterValue = filterValue.toLowerCase();
        }
        this.filteredData = new __WEBPACK_IMPORTED_MODULE_5__angular_material__["K" /* MatTableDataSource */](this.userList.filter(function (user) {
            var searchActivationDate = _this.datepipe.transform(user.activationDate, 'dd-MMM-yy hh:mm a');
            var activationDate = _this.datepipe.transform(user.activationDate, 'yyyy-MM-dd');
            if (filterValue !== null && (filterFrom === null && filterTo === null)) {
                return _this.filterUser(user, filterValue) ||
                    searchActivationDate.toLowerCase().includes(filterValue);
            }
            else if (filterFrom !== null && (filterTo === null && filterValue === null)) {
                return activationDate >= filterFrom;
            }
            else if (filterTo !== null && (filterFrom === null && filterValue === null)) {
                return activationDate <= filterTo;
            }
            else if (filterValue === null && (filterFrom !== null && filterTo !== null)) {
                return filterFrom <= activationDate && activationDate <= filterTo;
            }
            else if (filterFrom === null && (filterValue !== null && filterTo !== null)) {
                return (_this.filterUser(user, filterValue) ||
                    searchActivationDate.toLowerCase().includes(filterValue)) && activationDate <= filterTo;
            }
            else if (filterTo === null && (filterFrom !== null && filterValue !== null)) {
                return (_this.filterUser(user, filterValue) ||
                    searchActivationDate.toLowerCase().includes(filterValue)) &&
                    activationDate >= filterFrom;
            }
            else if (filterFrom !== null && filterTo !== null && filterValue !== null) {
                return (_this.filterUser(user, filterValue) ||
                    searchActivationDate.toLowerCase().includes(filterValue)) &&
                    (filterFrom <= activationDate && activationDate <= filterTo);
            }
        }));
        this.filteredData.paginator = this.paginator;
        this.filteredData.sort = this.sort;
    };
    MgUserListComponent.prototype.filterUser = function (user, filterValue) {
        this.isAppRoleData = false;
        this.isDepartmentData = false;
        for (var i = 0; i < user.userApplicationRole.length; i++) {
            if ((user.userApplicationRole[i].applicationName.toLowerCase().includes(filterValue))
                || (user.userApplicationRole[i].roleName.toLowerCase().includes(filterValue))) {
                this.isAppRoleData = true;
                break;
            }
        }
        for (var j = 0; j < user.departments.length; j++) {
            if (user.departments[j].name.toLowerCase().includes(filterValue)) {
                this.isDepartmentData = true;
            }
        }
        return user.lastName.toLowerCase().includes(filterValue) ||
            user.email.toLowerCase().includes(filterValue) ||
            // user.firstName.toLowerCase().includes(filterValue) ||
            user.userName.toString().includes(filterValue) ||
            user.employeeId.toString().includes(filterValue) ||
            this.isAppRoleData || this.isDepartmentData;
    };
    MgUserListComponent.prototype.checkIsInputCleared = function () {
        if (this.searchUsers.get('searchText').value.length === 1) {
            this.filteredData = new __WEBPACK_IMPORTED_MODULE_5__angular_material__["K" /* MatTableDataSource */](this.userList);
        }
    };
    MgUserListComponent.prototype.sortData = function (sort) {
        var data = this.userList.slice();
        if (!sort.active || sort.direction === '') {
            this.dataSource.data = data.sort(function (a, b) {
                var isAsc = sort.direction === 'desc';
                return compare(a.activationDate, b.activationDate, isAsc);
            });
            return;
        }
        else {
            if (this.isSearch) {
                this.filteredData.data = this.filteredData.data.sort(function (a, b) {
                    var isAsc = sort.direction === 'asc';
                    switch (sort.active) {
                        // case 'name': return compare(a.firstName, b.firstName, isAsc);
                        case 'name': return compare(a.userName, b.userName, isAsc);
                        case 'email': return compare(a.email, b.email, isAsc);
                        case 'employeeId': return compare(+a.employeeId, +b.employeeId, isAsc);
                        case 'isActive': return compare(a.isActive, b.isActive, isAsc);
                        case 'departments': return compare((a.departments.length === 0) ? '' :
                            a.departments[0].name, (b.departments.length === 0) ? '' :
                            b.departments[0].name, isAsc);
                        case 'userApplicationRole':
                            return compare((a.userApplicationRole.length === 0) ? '' :
                                a.userApplicationRole[0].applicationName, (b.userApplicationRole.length === 0) ? '' :
                                b.userApplicationRole[0].applicationName, isAsc);
                        case 'activationDate': return compare(a.activationDate, b.activationDate, isAsc);
                        default: return 0;
                    }
                });
                this.filteredData.paginator = this.paginator;
            }
            this.dataSource.data = data.sort(function (a, b) {
                var isAsc = sort.direction === 'asc';
                switch (sort.active) {
                    // case 'name': return compare(a.firstName, b.firstName, isAsc);
                    case 'name': return compare(a.userName, b.userName, isAsc);
                    case 'email': return compare(a.email, b.email, isAsc);
                    case 'employeeId': return compare(+a.employeeId, +b.employeeId, isAsc);
                    case 'isActive': return compare(a.isActive, b.isActive, isAsc);
                    case 'departments': return compare((a.departments.length === 0) ? '' :
                        a.departments[0].name, (b.departments.length === 0) ? '' :
                        b.departments[0].name, isAsc);
                    case 'userApplicationRole':
                        return compare((a.userApplicationRole.length === 0) ? '' :
                            a.userApplicationRole[0].applicationName, (b.userApplicationRole.length === 0) ? '' :
                            b.userApplicationRole[0].applicationName, isAsc);
                    case 'activationDate': return compare(a.activationDate, b.activationDate, isAsc);
                    default: return 0;
                }
            });
            this.dataSource.paginator = this.paginator;
        }
    };
    MgUserListComponent.prototype.getMgUserList = function () {
        var _this = this;
        this.userDataService.getMgUsers().subscribe(function (mgUsersList) {
            _this.userList = mgUsersList;
            _this.dataSource = new __WEBPACK_IMPORTED_MODULE_5__angular_material__["K" /* MatTableDataSource */](_this.userList);
            _this.dataSource.paginator = _this.paginator;
            _this.dataSource.sort = _this.sort;
        });
    };
    MgUserListComponent.prototype.createMgUser = function () {
        this.router.navigate(['../mguser', 0, this.create], { relativeTo: this.activatedRoute });
    };
    MgUserListComponent.prototype.deleteUser = function (userId) {
        var _this = this;
        this.userDataService.deleteMGUser(userId).subscribe(function (isDeleted) {
            _this.isDeleted = isDeleted;
        });
    };
    MgUserListComponent.prototype.GoUserUpdate = function (value) {
        var val = value.split(':');
        var userId = val[0];
        this.operation = val[1];
        this.router.navigate(['../mguser', userId, this.operation.trim().toLowerCase()], { relativeTo: this.activatedRoute });
    };
    MgUserListComponent.prototype.GoUserDelete = function (value) {
        var _this = this;
        var val = value.split(':');
        var userId = val[0];
        this.dialogsService
            .confirm('Confirm', 'Are you sure you want to delete this user?').subscribe(function (res) {
            _this.result = res;
            if (_this.result) {
                // this.deleteUser(userId);
                _this.getMgUserList();
            }
            else {
                _this.actions = null;
            }
        });
    };
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["ViewChild"])(__WEBPACK_IMPORTED_MODULE_5__angular_material__["v" /* MatPaginator */]),
        __metadata("design:type", __WEBPACK_IMPORTED_MODULE_5__angular_material__["v" /* MatPaginator */])
    ], MgUserListComponent.prototype, "paginator", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["ViewChild"])(__WEBPACK_IMPORTED_MODULE_5__angular_material__["H" /* MatSort */]),
        __metadata("design:type", __WEBPACK_IMPORTED_MODULE_5__angular_material__["H" /* MatSort */])
    ], MgUserListComponent.prototype, "sort", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Object)
    ], MgUserListComponent.prototype, "_dateValue", void 0);
    MgUserListComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-mg-user-list',
            template: __webpack_require__("../../../../../src/app/backoffice/user-mgmt/mg-user/mg-user-list/mg-user-list.component.html"),
            styles: [__webpack_require__("../../../../../src/app/backoffice/user-mgmt/mg-user/mg-user-list/mg-user-list.component.css")],
            providers: [__WEBPACK_IMPORTED_MODULE_7__angular_common__["DatePipe"], __WEBPACK_IMPORTED_MODULE_8__common_backoffice_shared_dialogs_dialogs_service__["a" /* DialogsService */],
                { provide: __WEBPACK_IMPORTED_MODULE_6__angular_material_core__["c" /* DateAdapter */], useClass: DatePickerDateAdapter },
                { provide: __WEBPACK_IMPORTED_MODULE_6__angular_material_core__["f" /* MAT_DATE_FORMATS */], useValue: DATE_FORMATS },
            ]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_2__angular_router__["Router"],
            __WEBPACK_IMPORTED_MODULE_2__angular_router__["ActivatedRoute"],
            __WEBPACK_IMPORTED_MODULE_4__common_backoffice_shared_services_user_data_service__["a" /* UserDataService */],
            __WEBPACK_IMPORTED_MODULE_8__common_backoffice_shared_dialogs_dialogs_service__["a" /* DialogsService */],
            __WEBPACK_IMPORTED_MODULE_7__angular_common__["DatePipe"]])
    ], MgUserListComponent);
    return MgUserListComponent;
}());

function compare(a, b, isAsc) {
    return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}


/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/user-mgmt-routing.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export userRoutes */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return UserMgmtRoutingModule; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "b", function() { return routedUserComponents; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__mg_user_mg_user_list_mg_user_list_component__ = __webpack_require__("../../../../../src/app/backoffice/user-mgmt/mg-user/mg-user-list/mg-user-list.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__mg_user_mg_user_info_mg_user_info_component__ = __webpack_require__("../../../../../src/app/backoffice/user-mgmt/mg-user/mg-user-info/mg-user-info.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__common_backoffice_shared_services_department_resolver_service__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/department-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__common_backoffice_shared_services_application_resolver_service__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/application-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__agent_user_agent_user_list_agent_user_list_component__ = __webpack_require__("../../../../../src/app/backoffice/user-mgmt/agent-user/agent-user-list/agent-user-list.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__agent_user_agent_user_info_agent_user_info_component__ = __webpack_require__("../../../../../src/app/backoffice/user-mgmt/agent-user/agent-user-info/agent-user-info.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__hotel_user_hotel_user_list_hotel_user_list_component__ = __webpack_require__("../../../../../src/app/backoffice/user-mgmt/hotel-user/hotel-user-list/hotel-user-list.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_9__hotel_user_hotel_user_info_hotel_user_info_component__ = __webpack_require__("../../../../../src/app/backoffice/user-mgmt/hotel-user/hotel-user-info/hotel-user-info.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_10__common_backoffice_shared_services_role_resolver_service__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/role-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_11__common_backoffice_shared_services_designation_resolver_service__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/designation-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_12__hotel_user_individual_hotel_user_info_individual_hotel_user_info_component__ = __webpack_require__("../../../../../src/app/backoffice/user-mgmt/hotel-user/individual-hotel-user-info/individual-hotel-user-info.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_13__hotel_user_hotel_type_hotel_type_component__ = __webpack_require__("../../../../../src/app/backoffice/user-mgmt/hotel-user/hotel-type/hotel-type.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_14__hotel_user_supplier_user_info_supplier_user_info_component__ = __webpack_require__("../../../../../src/app/backoffice/user-mgmt/hotel-user/supplier-user-info/supplier-user-info.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_15__common_backoffice_shared_services_hotel_resolver_service__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/hotel-resolver.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
















// import { RoleResolverService } from '../common/backoffice-shared/services/role-resolver.service';
var userRoutes = [
    // { path: '', redirectTo: 'mgusers', pathMatch: 'full' },
    { path: 'mgusers', component: __WEBPACK_IMPORTED_MODULE_1__mg_user_mg_user_list_mg_user_list_component__["a" /* MgUserListComponent */] },
    { path: 'mguser/:id/:operation',
        component: __WEBPACK_IMPORTED_MODULE_2__mg_user_mg_user_info_mg_user_info_component__["a" /* MgUserInfoComponent */],
        resolve: {
            departments: __WEBPACK_IMPORTED_MODULE_4__common_backoffice_shared_services_department_resolver_service__["a" /* DepartmentResolverService */],
            applications: __WEBPACK_IMPORTED_MODULE_5__common_backoffice_shared_services_application_resolver_service__["a" /* ApplicationResolverService */]
        }
    },
    { path: 'agentusers', component: __WEBPACK_IMPORTED_MODULE_6__agent_user_agent_user_list_agent_user_list_component__["a" /* AgentUserListComponent */] },
    { path: 'agentusers/:id/:operation',
        component: __WEBPACK_IMPORTED_MODULE_7__agent_user_agent_user_info_agent_user_info_component__["a" /* AgentUserInfoComponent */],
    },
    { path: 'hoteluserslist', component: __WEBPACK_IMPORTED_MODULE_8__hotel_user_hotel_user_list_hotel_user_list_component__["a" /* HotelUserListComponent */] },
    {
        path: 'hotelusers', component: __WEBPACK_IMPORTED_MODULE_13__hotel_user_hotel_type_hotel_type_component__["a" /* HotelTypeComponent */],
        children: [
            { path: '', redirectTo: 'hoteldetails', pathMatch: 'full' },
            // {
            //     path: 'hotelchainusers', component: HotelChainUserComponent
            // } ,
            { path: 'hoteluserinfo/:id/:operation', component: __WEBPACK_IMPORTED_MODULE_9__hotel_user_hotel_user_info_hotel_user_info_component__["a" /* HotelUserInfoComponent */] },
            {
                path: 'hotelusers/hoteluserinfo/:id/:operation', component: __WEBPACK_IMPORTED_MODULE_9__hotel_user_hotel_user_info_hotel_user_info_component__["a" /* HotelUserInfoComponent */],
                resolve: {
                    roles: __WEBPACK_IMPORTED_MODULE_10__common_backoffice_shared_services_role_resolver_service__["a" /* RoleResolverService */],
                }
            },
            { path: 'individual/:id/:operation',
                component: __WEBPACK_IMPORTED_MODULE_12__hotel_user_individual_hotel_user_info_individual_hotel_user_info_component__["a" /* IndividualHotelUserInfoComponent */],
                resolve: {
                    roles: __WEBPACK_IMPORTED_MODULE_10__common_backoffice_shared_services_role_resolver_service__["a" /* RoleResolverService */],
                    designations: __WEBPACK_IMPORTED_MODULE_11__common_backoffice_shared_services_designation_resolver_service__["a" /* DesignationResolverService */],
                    hotels: __WEBPACK_IMPORTED_MODULE_15__common_backoffice_shared_services_hotel_resolver_service__["a" /* HotelResolverService */]
                }
            },
            { path: 'supplieruser/:id/:operation',
                component: __WEBPACK_IMPORTED_MODULE_14__hotel_user_supplier_user_info_supplier_user_info_component__["a" /* SupplierUserInfoComponent */],
                resolve: {
                    roles: __WEBPACK_IMPORTED_MODULE_10__common_backoffice_shared_services_role_resolver_service__["a" /* RoleResolverService */],
                    designations: __WEBPACK_IMPORTED_MODULE_11__common_backoffice_shared_services_designation_resolver_service__["a" /* DesignationResolverService */]
                }
            }
        ]
    },
];
var UserMgmtRoutingModule = (function () {
    function UserMgmtRoutingModule() {
    }
    UserMgmtRoutingModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_3__angular_core__["NgModule"])({
            imports: [__WEBPACK_IMPORTED_MODULE_0__angular_router__["RouterModule"].forChild(userRoutes)],
            exports: [__WEBPACK_IMPORTED_MODULE_0__angular_router__["RouterModule"]]
        })
    ], UserMgmtRoutingModule);
    return UserMgmtRoutingModule;
}());

var routedUserComponents = [
    __WEBPACK_IMPORTED_MODULE_1__mg_user_mg_user_list_mg_user_list_component__["a" /* MgUserListComponent */],
    __WEBPACK_IMPORTED_MODULE_2__mg_user_mg_user_info_mg_user_info_component__["a" /* MgUserInfoComponent */],
    __WEBPACK_IMPORTED_MODULE_6__agent_user_agent_user_list_agent_user_list_component__["a" /* AgentUserListComponent */],
    __WEBPACK_IMPORTED_MODULE_7__agent_user_agent_user_info_agent_user_info_component__["a" /* AgentUserInfoComponent */],
    __WEBPACK_IMPORTED_MODULE_8__hotel_user_hotel_user_list_hotel_user_list_component__["a" /* HotelUserListComponent */],
    __WEBPACK_IMPORTED_MODULE_9__hotel_user_hotel_user_info_hotel_user_info_component__["a" /* HotelUserInfoComponent */]
];


/***/ }),

/***/ "../../../../../src/app/backoffice/user-mgmt/user-mgmt.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "UserMgmtModule", function() { return UserMgmtModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_common__ = __webpack_require__("../../../common/esm5/common.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__user_mgmt_routing_module__ = __webpack_require__("../../../../../src/app/backoffice/user-mgmt/user-mgmt-routing.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_forms__ = __webpack_require__("../../../forms/esm5/forms.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__common_material_material_module__ = __webpack_require__("../../../../../src/app/common/material/material.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__common_backoffice_shared_services_backoffice_lookup__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/backoffice-lookup.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__common_backoffice_shared_services_department_resolver_service__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/department-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__common_backoffice_shared_services_application_resolver_service__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/application-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__agent_user_agent_user_info_agent_user_info_component__ = __webpack_require__("../../../../../src/app/backoffice/user-mgmt/agent-user/agent-user-info/agent-user-info.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_9__agent_user_agent_user_list_agent_user_list_component__ = __webpack_require__("../../../../../src/app/backoffice/user-mgmt/agent-user/agent-user-list/agent-user-list.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_10__hotel_user_hotel_user_list_hotel_user_list_component__ = __webpack_require__("../../../../../src/app/backoffice/user-mgmt/hotel-user/hotel-user-list/hotel-user-list.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_11__hotel_user_hotel_user_info_hotel_user_info_component__ = __webpack_require__("../../../../../src/app/backoffice/user-mgmt/hotel-user/hotel-user-info/hotel-user-info.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_12__hotel_user_individual_hotel_user_info_individual_hotel_user_info_component__ = __webpack_require__("../../../../../src/app/backoffice/user-mgmt/hotel-user/individual-hotel-user-info/individual-hotel-user-info.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_13__common_backoffice_shared_services_designation_resolver_service__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/designation-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_14__common_backoffice_shared_services_role_resolver_service__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/role-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_15__hotel_user_hotel_type_hotel_type_component__ = __webpack_require__("../../../../../src/app/backoffice/user-mgmt/hotel-user/hotel-type/hotel-type.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_16__hotel_user_supplier_user_info_supplier_user_info_component__ = __webpack_require__("../../../../../src/app/backoffice/user-mgmt/hotel-user/supplier-user-info/supplier-user-info.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_17__common_backoffice_shared_services_hotel_resolver_service__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/hotel-resolver.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



















// import { RoleResolverService } from '../common/backoffice-shared/services/role-resolver.service';
var UserMgmtModule = (function () {
    function UserMgmtModule() {
    }
    UserMgmtModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            imports: [
                __WEBPACK_IMPORTED_MODULE_1__angular_common__["CommonModule"],
                __WEBPACK_IMPORTED_MODULE_2__user_mgmt_routing_module__["a" /* UserMgmtRoutingModule */],
                __WEBPACK_IMPORTED_MODULE_3__angular_forms__["ReactiveFormsModule"],
                __WEBPACK_IMPORTED_MODULE_4__common_material_material_module__["a" /* MaterialModule */],
                __WEBPACK_IMPORTED_MODULE_3__angular_forms__["FormsModule"]
            ],
            declarations: [__WEBPACK_IMPORTED_MODULE_2__user_mgmt_routing_module__["b" /* routedUserComponents */], __WEBPACK_IMPORTED_MODULE_8__agent_user_agent_user_info_agent_user_info_component__["a" /* AgentUserInfoComponent */],
                __WEBPACK_IMPORTED_MODULE_9__agent_user_agent_user_list_agent_user_list_component__["a" /* AgentUserListComponent */], __WEBPACK_IMPORTED_MODULE_10__hotel_user_hotel_user_list_hotel_user_list_component__["a" /* HotelUserListComponent */],
                __WEBPACK_IMPORTED_MODULE_11__hotel_user_hotel_user_info_hotel_user_info_component__["a" /* HotelUserInfoComponent */],
                __WEBPACK_IMPORTED_MODULE_12__hotel_user_individual_hotel_user_info_individual_hotel_user_info_component__["a" /* IndividualHotelUserInfoComponent */],
                __WEBPACK_IMPORTED_MODULE_15__hotel_user_hotel_type_hotel_type_component__["a" /* HotelTypeComponent */],
                __WEBPACK_IMPORTED_MODULE_16__hotel_user_supplier_user_info_supplier_user_info_component__["a" /* SupplierUserInfoComponent */]],
            providers: [__WEBPACK_IMPORTED_MODULE_5__common_backoffice_shared_services_backoffice_lookup__["a" /* BackofficeLookupService */], __WEBPACK_IMPORTED_MODULE_6__common_backoffice_shared_services_department_resolver_service__["a" /* DepartmentResolverService */],
                __WEBPACK_IMPORTED_MODULE_7__common_backoffice_shared_services_application_resolver_service__["a" /* ApplicationResolverService */], __WEBPACK_IMPORTED_MODULE_13__common_backoffice_shared_services_designation_resolver_service__["a" /* DesignationResolverService */],
                __WEBPACK_IMPORTED_MODULE_14__common_backoffice_shared_services_role_resolver_service__["a" /* RoleResolverService */], __WEBPACK_IMPORTED_MODULE_1__angular_common__["DatePipe"], __WEBPACK_IMPORTED_MODULE_17__common_backoffice_shared_services_hotel_resolver_service__["a" /* HotelResolverService */]]
        })
    ], UserMgmtModule);
    return UserMgmtModule;
}());



/***/ })

});
//# sourceMappingURL=user-mgmt.module.chunk.js.map