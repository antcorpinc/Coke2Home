webpackJsonp(["main"],{

/***/ "../../../../../src/$$_lazy_route_resource lazy recursive":
/***/ (function(module, exports, __webpack_require__) {

var map = {
	"./backoffice/user-mgmt/user-mgmt.module": [
		"../../../../../src/app/backoffice/user-mgmt/user-mgmt.module.ts",
		"user-mgmt.module"
	],
	"./extranet/contract-mgmt/contracts/contracts.module": [
		"../../../../../src/app/extranet/contract-mgmt/contracts/contracts.module.ts",
		"contracts.module",
		"common"
	],
	"./extranet/contract-mgmt/templates/templates.module": [
		"../../../../../src/app/extranet/contract-mgmt/templates/templates.module.ts",
		"templates.module",
		"common"
	],
	"./extranet/hotel-mgmt/hotel-mgmt.module": [
		"../../../../../src/app/extranet/hotel-mgmt/hotel-mgmt.module.ts",
		"hotel-mgmt.module",
		"common"
	]
};
function webpackAsyncContext(req) {
	var ids = map[req];
	if(!ids)
		return Promise.reject(new Error("Cannot find module '" + req + "'."));
	return Promise.all(ids.slice(1).map(__webpack_require__.e)).then(function() {
		return __webpack_require__(ids[0]);
	});
};
webpackAsyncContext.keys = function webpackAsyncContextKeys() {
	return Object.keys(map);
};
webpackAsyncContext.id = "../../../../../src/$$_lazy_route_resource lazy recursive";
module.exports = webpackAsyncContext;

/***/ }),

/***/ "../../../../../src/app/app-routing.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export routes */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppRoutingModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__common_core_dashboards_dashboard_dashboard_component__ = __webpack_require__("../../../../../src/app/common/core/dashboards/dashboard/dashboard.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__common_core_dashboards_agent_dashboard_agent_dashboard_component__ = __webpack_require__("../../../../../src/app/common/core/dashboards/agent-dashboard/agent-dashboard.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__backoffice_common_backoffice_shared_dashboard_backoffice_dashboard_backoffice_component__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/dashboard-backoffice/dashboard-backoffice.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__extranet_common_extranet_shared_dashboard_extranet_dashboard_extranet_component__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dashboard-extranet/dashboard-extranet.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__framework_fw_unauthorized_unauthorized_component__ = __webpack_require__("../../../../../src/app/framework/fw/unauthorized/unauthorized.component.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







// import {ErrorhandlerComponent} from './framework/fw/errorhandler/errorhandler.component';
var routes = [
    { path: 'dashboard', component: __WEBPACK_IMPORTED_MODULE_2__common_core_dashboards_dashboard_dashboard_component__["a" /* DashboardComponent */] },
    // { path: 'hoteladmindashboard', component: HotelAdminDashboardComponent},
    { path: 'agentdashboard', component: __WEBPACK_IMPORTED_MODULE_3__common_core_dashboards_agent_dashboard_agent_dashboard_component__["a" /* AgentDashboardComponent */] },
    // { path: 'dashboardbackoffice', component: DashboardBackofficeComponent },
    // { path: 'handleerror', component: ErrorhandlerComponent },
    { path: 'backofficedashboard', component: __WEBPACK_IMPORTED_MODULE_4__backoffice_common_backoffice_shared_dashboard_backoffice_dashboard_backoffice_component__["a" /* DashboardBackofficeComponent */] },
    { path: 'extranetdashboard', component: __WEBPACK_IMPORTED_MODULE_5__extranet_common_extranet_shared_dashboard_extranet_dashboard_extranet_component__["a" /* DashboardExtranetComponent */] },
    { path: 'unauthorized', component: __WEBPACK_IMPORTED_MODULE_6__framework_fw_unauthorized_unauthorized_component__["a" /* UnauthorizedComponent */] },
    { path: 'contractmgmt', loadChildren: './extranet/contract-mgmt/contracts/contracts.module#ContractsModule' },
    { path: 'hotelmgmt', loadChildren: './extranet/hotel-mgmt/hotel-mgmt.module#HotelMgmtModule' },
    { path: 'templatemgmt', loadChildren: './extranet/contract-mgmt/templates/templates.module#TemplatesModule' },
    { path: 'usermgmt', loadChildren: './backoffice/user-mgmt/user-mgmt.module#UserMgmtModule' },
    { path: '', component: __WEBPACK_IMPORTED_MODULE_2__common_core_dashboards_dashboard_dashboard_component__["a" /* DashboardComponent */] },
    { path: '**', component: __WEBPACK_IMPORTED_MODULE_2__common_core_dashboards_dashboard_dashboard_component__["a" /* DashboardComponent */] },
];
var AppRoutingModule = (function () {
    function AppRoutingModule() {
    }
    AppRoutingModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_1__angular_core__["NgModule"])({
            imports: [
                __WEBPACK_IMPORTED_MODULE_0__angular_router__["RouterModule"].forRoot(routes)
            ],
            exports: [__WEBPACK_IMPORTED_MODULE_0__angular_router__["RouterModule"]],
            providers: []
        })
    ], AppRoutingModule);
    return AppRoutingModule;
}());



/***/ }),

/***/ "../../../../../src/app/app.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "\r\n\r\n\r\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/app.component.html":
/***/ (function(module, exports) {

module.exports = "<fw-framework-body></fw-framework-body>\n\n\n\n"

/***/ }),

/***/ "../../../../../src/app/app.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_rxjs_add_operator_map__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/map.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_rxjs_add_operator_catch__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/catch.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__framework_fw_services_menu_service__ = __webpack_require__("../../../../../src/app/framework/fw/services/menu.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__common_shared_services_user_profile_service__ = __webpack_require__("../../../../../src/app/common/shared/services/user-profile.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__common_shared_services_portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

 // Todo Rxjs into Shared module





var AppComponent = (function () {
    function AppComponent(menuService, userProfileService, portalService, router) {
        //  menuService.items = initialMenuItems;
        this.menuService = menuService;
        this.userProfileService = userProfileService;
        this.portalService = portalService;
        this.router = router;
        this.title = 'app';
    }
    AppComponent.prototype.ngOnInit = function () {
        this.InitializeApplication();
    };
    AppComponent.prototype.InitializeApplication = function () {
        /*  if (this.portalService.appSettings.Disabled.toUpperCase() === 'TRUE' ) {
          this.router.navigate(['/unauthorized']);
         } else { */
        this.userProfileService.GetUserProfileAsync(this.portalService.appSettings.SubjectId);
        // }
    };
    AppComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-root',
            template: __webpack_require__("../../../../../src/app/app.component.html"),
            styles: [__webpack_require__("../../../../../src/app/app.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_3__framework_fw_services_menu_service__["b" /* MenuService */],
            __WEBPACK_IMPORTED_MODULE_4__common_shared_services_user_profile_service__["a" /* UserProfileService */],
            __WEBPACK_IMPORTED_MODULE_5__common_shared_services_portal_service__["a" /* PortalService */],
            __WEBPACK_IMPORTED_MODULE_6__angular_router__["Router"]])
    ], AppComponent);
    return AppComponent;
}());



/***/ }),

/***/ "../../../../../src/app/app.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__app_component__ = __webpack_require__("../../../../../src/app/app.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_http__ = __webpack_require__("../../../http/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_platform_browser__ = __webpack_require__("../../../platform-browser/esm5/platform-browser.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__angular_platform_browser_animations__ = __webpack_require__("../../../platform-browser/esm5/animations.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__framework_fw_fw_module__ = __webpack_require__("../../../../../src/app/framework/fw/fw.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__common_core_core_module__ = __webpack_require__("../../../../../src/app/common/core/core.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__common_shared_shared_module__ = __webpack_require__("../../../../../src/app/common/shared/shared.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__app_routing_module__ = __webpack_require__("../../../../../src/app/app-routing.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_9__backoffice_common_backoffice_shared_backoffice_shared_module__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/backoffice-shared.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_10__extranet_common_extranet_shared_extranet_shared_module__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/extranet-shared.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_11__common_material_material_module__ = __webpack_require__("../../../../../src/app/common/material/material.module.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};


 //  Tobe removed later.



 // Tobe removed later.





var AppModule = (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            declarations: [
                __WEBPACK_IMPORTED_MODULE_1__app_component__["a" /* AppComponent */]
            ],
            imports: [
                __WEBPACK_IMPORTED_MODULE_3__angular_platform_browser__["BrowserModule"],
                __WEBPACK_IMPORTED_MODULE_4__angular_platform_browser_animations__["a" /* BrowserAnimationsModule */],
                __WEBPACK_IMPORTED_MODULE_7__common_shared_shared_module__["a" /* SharedModule */],
                __WEBPACK_IMPORTED_MODULE_2__angular_http__["b" /* HttpModule */],
                __WEBPACK_IMPORTED_MODULE_5__framework_fw_fw_module__["a" /* FwModule */],
                __WEBPACK_IMPORTED_MODULE_6__common_core_core_module__["a" /* CoreModule */],
                __WEBPACK_IMPORTED_MODULE_9__backoffice_common_backoffice_shared_backoffice_shared_module__["a" /* BackofficeSharedModule */],
                __WEBPACK_IMPORTED_MODULE_10__extranet_common_extranet_shared_extranet_shared_module__["a" /* ExtranetSharedModule */],
                __WEBPACK_IMPORTED_MODULE_11__common_material_material_module__["a" /* MaterialModule */],
                // Should be last for Routing
                __WEBPACK_IMPORTED_MODULE_8__app_routing_module__["a" /* AppRoutingModule */]
            ],
            providers: [],
            bootstrap: [__WEBPACK_IMPORTED_MODULE_1__app_component__["a" /* AppComponent */]]
        })
    ], AppModule);
    return AppModule;
}());



/***/ }),

/***/ "../../../../../src/app/backoffice/common/Constants.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return BACKOFFICECONSTANTS; });
var BACKOFFICECONSTANTS = {
    userType: {
        mgUser: 1,
        hotelUser: 2,
        agentUser: 3
    }
};


/***/ }),

/***/ "../../../../../src/app/backoffice/common/backoffice-shared/backoffice-shared.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return BackofficeSharedModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_common__ = __webpack_require__("../../../common/esm5/common.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__dashboard_backoffice_dashboard_backoffice_component__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/dashboard-backoffice/dashboard-backoffice.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_forms__ = __webpack_require__("../../../forms/esm5/forms.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__common_material_material_module__ = __webpack_require__("../../../../../src/app/common/material/material.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__services_backoffice_lookup__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/backoffice-lookup.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__services_user_data_service__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/services/user-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__dialogs_dialogs_module__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/dialogs/dialogs.module.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};








var BackofficeSharedModule = (function () {
    function BackofficeSharedModule() {
    }
    BackofficeSharedModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            imports: [
                __WEBPACK_IMPORTED_MODULE_1__angular_common__["CommonModule"],
                __WEBPACK_IMPORTED_MODULE_3__angular_forms__["FormsModule"],
                __WEBPACK_IMPORTED_MODULE_4__common_material_material_module__["a" /* MaterialModule */],
                __WEBPACK_IMPORTED_MODULE_7__dialogs_dialogs_module__["a" /* DialogsModule */]
            ],
            declarations: [__WEBPACK_IMPORTED_MODULE_2__dashboard_backoffice_dashboard_backoffice_component__["a" /* DashboardBackofficeComponent */]],
            providers: [__WEBPACK_IMPORTED_MODULE_5__services_backoffice_lookup__["a" /* BackofficeLookupService */], __WEBPACK_IMPORTED_MODULE_6__services_user_data_service__["a" /* UserDataService */]]
        })
    ], BackofficeSharedModule);
    return BackofficeSharedModule;
}());



/***/ }),

/***/ "../../../../../src/app/backoffice/common/backoffice-shared/dashboard-backoffice/dashboard-backoffice.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/backoffice/common/backoffice-shared/dashboard-backoffice/dashboard-backoffice.component.html":
/***/ (function(module, exports) {

module.exports = "<p>\n  dashboard-backoffice works!\n</p>\n"

/***/ }),

/***/ "../../../../../src/app/backoffice/common/backoffice-shared/dashboard-backoffice/dashboard-backoffice.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return DashboardBackofficeComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var DashboardBackofficeComponent = (function () {
    function DashboardBackofficeComponent() {
    }
    DashboardBackofficeComponent.prototype.ngOnInit = function () {
    };
    DashboardBackofficeComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-dashboard-backoffice',
            template: __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/dashboard-backoffice/dashboard-backoffice.component.html"),
            styles: [__webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/dashboard-backoffice/dashboard-backoffice.component.css")]
        }),
        __metadata("design:paramtypes", [])
    ], DashboardBackofficeComponent);
    return DashboardBackofficeComponent;
}());



/***/ }),

/***/ "../../../../../src/app/backoffice/common/backoffice-shared/dialogs/confirm-dialog/confirm-dialog.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/backoffice/common/backoffice-shared/dialogs/confirm-dialog/confirm-dialog.component.html":
/***/ (function(module, exports) {

module.exports = "\n<div class=\"modalHeading\">\n  <span class=\"float-left\">{{ title }}</span>\n  <span class=\"closeIcon float-right\" (click)=\"dialogRef.close(false)\"><i aria-hidden=\"true\" class=\"fa fa-times-thin\"></i></span>\n</div>\n<div class=\"moddalContent\">\n  <p>{{ message }}</p>\n  <div class=\"controlButtons \">\n      <button type=\"button\" title=\"OK\" mat-raised-button class=\"activeButton mat-raised-button\"\n          (click)=\"dialogRef.close(true)\">OK</button>\n      <button type=\"button\" title=\"Cancel\" mat-raised-button class=\"defaultButton mat-raised-button\"\n          (click)=\"dialogRef.close(false)\">Cancel</button>\n  </div>\n</div>\n"

/***/ }),

/***/ "../../../../../src/app/backoffice/common/backoffice-shared/dialogs/confirm-dialog/confirm-dialog.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ConfirmDialogComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_material__ = __webpack_require__("../../../material/esm5/material.es5.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var ConfirmDialogComponent = (function () {
    function ConfirmDialogComponent(dialogRef) {
        this.dialogRef = dialogRef;
    }
    ConfirmDialogComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-confirm-dialog',
            template: __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/dialogs/confirm-dialog/confirm-dialog.component.html"),
            styles: [__webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/dialogs/confirm-dialog/confirm-dialog.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_material__["m" /* MatDialogRef */]])
    ], ConfirmDialogComponent);
    return ConfirmDialogComponent;
}());



/***/ }),

/***/ "../../../../../src/app/backoffice/common/backoffice-shared/dialogs/dialogs.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return DialogsModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_common__ = __webpack_require__("../../../common/esm5/common.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__confirm_dialog_confirm_dialog_component__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/dialogs/confirm-dialog/confirm-dialog.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__dialogs_service__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/dialogs/dialogs.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__angular_material__ = __webpack_require__("../../../material/esm5/material.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__common_material_material_module__ = __webpack_require__("../../../../../src/app/common/material/material.module.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};






var DialogsModule = (function () {
    function DialogsModule() {
    }
    DialogsModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            imports: [
                __WEBPACK_IMPORTED_MODULE_1__angular_common__["CommonModule"],
                __WEBPACK_IMPORTED_MODULE_4__angular_material__["l" /* MatDialogModule */],
                __WEBPACK_IMPORTED_MODULE_4__angular_material__["e" /* MatButtonModule */],
                __WEBPACK_IMPORTED_MODULE_5__common_material_material_module__["a" /* MaterialModule */]
            ],
            declarations: [__WEBPACK_IMPORTED_MODULE_2__confirm_dialog_confirm_dialog_component__["a" /* ConfirmDialogComponent */]],
            exports: [__WEBPACK_IMPORTED_MODULE_2__confirm_dialog_confirm_dialog_component__["a" /* ConfirmDialogComponent */]],
            entryComponents: [__WEBPACK_IMPORTED_MODULE_2__confirm_dialog_confirm_dialog_component__["a" /* ConfirmDialogComponent */]],
            providers: [__WEBPACK_IMPORTED_MODULE_3__dialogs_service__["a" /* DialogsService */]]
        })
    ], DialogsModule);
    return DialogsModule;
}());



/***/ }),

/***/ "../../../../../src/app/backoffice/common/backoffice-shared/dialogs/dialogs.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return DialogsService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__confirm_dialog_confirm_dialog_component__ = __webpack_require__("../../../../../src/app/backoffice/common/backoffice-shared/dialogs/confirm-dialog/confirm-dialog.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_material__ = __webpack_require__("../../../material/esm5/material.es5.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var DialogsService = (function () {
    function DialogsService(dialog) {
        this.dialog = dialog;
    }
    DialogsService.prototype.confirm = function (title, message) {
        var dialogRef;
        dialogRef = this.dialog.open(__WEBPACK_IMPORTED_MODULE_1__confirm_dialog_confirm_dialog_component__["a" /* ConfirmDialogComponent */]);
        dialogRef.componentInstance.title = title;
        dialogRef.componentInstance.message = message;
        return dialogRef.afterClosed();
    };
    DialogsService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_2__angular_material__["k" /* MatDialog */]])
    ], DialogsService);
    return DialogsService;
}());



/***/ }),

/***/ "../../../../../src/app/backoffice/common/backoffice-shared/services/backoffice-lookup.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return BackofficeLookupService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__ = __webpack_require__("../../../../../src/app/common/shared/services/authenticated-http.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__common_shared_services_portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var BackofficeLookupService = (function () {
    function BackofficeLookupService(authenticatedHttpService, portalService) {
        this.authenticatedHttpService = authenticatedHttpService;
        this.portalService = portalService;
        this.hotelsDto = [];
        this.branchDto = [];
        this.agencyDto = [];
    }
    BackofficeLookupService.prototype.getApplications = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.UserMgmtApi + 'api/Application/Get').map(function (data) {
            _this.applicationsDto = data;
            console.log('Applications at service', _this.applicationsDto);
            return _this.applicationsDto;
        });
    };
    BackofficeLookupService.prototype.getRolesByApplicationId = function (applicationId) {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.UserMgmtApi
            + 'api/Role/GetByApplicationId?applicationId=' + applicationId).map(function (data) {
            _this.rolesDto = data;
            console.log('Roles at service', _this.rolesDto);
            return _this.rolesDto;
        });
    };
    BackofficeLookupService.prototype.getDepartments = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.UserMgmtApi + 'api/Department/Get').map(function (data) {
            _this.departmentsDto = data;
            return _this.departmentsDto;
        });
    };
    BackofficeLookupService.prototype.getRolesByApplicationName = function (applicationName) {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.UserMgmtApi
            + 'api/Role/GetByApplicationName?applicationName=' + applicationName).map(function (data) {
            _this.rolesDto = data;
            return _this.rolesDto;
        });
    };
    BackofficeLookupService.prototype.getHotelsByBrands = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/HotelManagement/GetAllHotelNames').map(function (data) {
            _this.hotelsDto = data.result;
            return _this.hotelsDto;
        });
    };
    BackofficeLookupService.prototype.getHotelsByBrandIds = function (brandIds) {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/HotelManagement/GetHotelNamesByBrandIds?ids=' + brandIds).map(function (data) {
            _this.hotelsDto = data;
            return _this.hotelsDto;
        });
    };
    BackofficeLookupService.prototype.getAgencies = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.BackOfficeApi
            + 'api/Agency/Get').map(
        // return this.authenticatedHttpService.get('http://172.27.127.102:5000/api/Agency/Get').map(
        function (data) {
            data.result.forEach(function (element) {
                _this.agencyDto.push(element.mgAgency);
            });
            return _this.agencyDto;
        });
    };
    BackofficeLookupService.prototype.getAgencyBranches = function (id) {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.BackOfficeApi
            + 'api/Branch/GetBranchByAgancyId?agencyId=' + id).map(
        // console.log('getBranches - Agency ID: ', id);
        //  return this.authenticatedHttpService.get('http://172.27.127.102:5000/api/Branch/GetBranchByAgancyId?agencyId=' + id).map(
        function (data) {
            data.result.forEach(function (element) {
                _this.branchDto.push(element.mgBranch);
            });
            return _this.branchDto;
        });
    };
    BackofficeLookupService.prototype.getIndividualHotels = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/HotelManagement/GetHotelsWithoutBrands').map(function (data) {
            _this.hotelsDto = data.result;
            return _this.hotelsDto;
        });
    };
    BackofficeLookupService.prototype.getDesignationByType = function (userType) {
        var _this = this;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/Miscellaneous/GetDesignation/', JSON.stringify(userType)).map(function (data) {
            _this.designationDto = data.result;
            return _this.designationDto;
        });
    };
    BackofficeLookupService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__["a" /* AuthenticatedHttpService */],
            __WEBPACK_IMPORTED_MODULE_2__common_shared_services_portal_service__["a" /* PortalService */]])
    ], BackofficeLookupService);
    return BackofficeLookupService;
}());



/***/ }),

/***/ "../../../../../src/app/backoffice/common/backoffice-shared/services/user-data.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return UserDataService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__ = __webpack_require__("../../../../../src/app/common/shared/services/authenticated-http.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__common_shared_services_portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__Constants__ = __webpack_require__("../../../../../src/app/backoffice/common/Constants.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__viewmodel_usersviewmodel_mguserviewmodel__ = __webpack_require__("../../../../../src/app/backoffice/viewmodel/usersviewmodel/mguserviewmodel.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__viewmodel_usersviewmodel_applicationroleidviewmodel__ = __webpack_require__("../../../../../src/app/backoffice/viewmodel/usersviewmodel/applicationroleidviewmodel.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var userType = __WEBPACK_IMPORTED_MODULE_4__Constants__["a" /* BACKOFFICECONSTANTS */].userType.mgUser;
var UserDataService = (function () {
    function UserDataService(authenticatedHttpService, portalService, activatedRoute) {
        this.authenticatedHttpService = authenticatedHttpService;
        this.portalService = portalService;
        this.activatedRoute = activatedRoute;
    }
    UserDataService.prototype.getMgUsers = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.UserMgmtApi
            + 'api/MGUser/Get').map(function (data) {
            if (data === null) {
                _this.mgUserListDto = [];
            }
            else {
                _this.mgUserListDto = data;
            }
            return _this.mgUserListDto;
        });
    };
    UserDataService.prototype.getHotelUsers = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.UserMgmtApi
            + 'api/HotelUser/Get').map(function (response) {
            if (response === null) {
                _this.hotelUserListDto = [];
            }
            else {
                _this.hotelUserListDto = response;
            }
            return _this.hotelUserListDto;
        });
    };
    UserDataService.prototype.getAgentUsers = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.UserMgmtApi
            + 'api/Agent/Get').map(function (data) {
            if (data === null) {
                _this.agentUserListDto = [];
            }
            else {
                _this.agentUserListDto = data;
            }
            return _this.agentUserListDto;
        });
    };
    UserDataService.prototype.deleteAgentUser = function (agentUserId) {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.UserMgmtApi
            + 'api/Agent/Delete/', agentUserId);
    };
    UserDataService.prototype.deleteMGUser = function (userId) {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.UserMgmtApi
            + 'api/MGUser/Delete/', userId);
    };
    UserDataService.prototype.deleteHotelUser = function (userId) {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.UserMgmtApi
            + 'api/HotelUser/Delete/', JSON.stringify(userId));
    };
    UserDataService.prototype.createMGUser = function (mgUserViewModel) {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.UserMgmtApi
            + 'api/MGUser/Create/', mgUserViewModel);
    };
    UserDataService.prototype.updateMGUser = function (id, mgUserViewModel) {
        return this.authenticatedHttpService.put(this.portalService.appSettings.BaseUrls.UserMgmtApi
            + 'api/MGUser/Update/' + id + '/', mgUserViewModel);
    };
    UserDataService.prototype.getMGUserById = function (userId) {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.UserMgmtApi
            + 'api/MGUser/GetById?userId=' + userId).map(function (data) {
            _this.mgUserDto = new __WEBPACK_IMPORTED_MODULE_5__viewmodel_usersviewmodel_mguserviewmodel__["a" /* MgUserViewModel */]();
            _this.mgUserDto.employeeId = data.employeeId;
            _this.mgUserDto.id = data.id;
            _this.mgUserDto.userName = data.userName;
            _this.mgUserDto.email = data.email;
            _this.mgUserDto.profilePictureUri = data.profilePictureUri;
            _this.mgUserDto.activationDate = data.activationDate;
            _this.mgUserDto.firstName = data.firstName;
            _this.mgUserDto.lastName = data.lastName;
            _this.mgUserDto.createdBy = data.createdBy;
            data.departments.forEach(function (element) {
                if (_this.mgUserDto.departments == null || _this.mgUserDto.departments === undefined) {
                    _this.mgUserDto.departments = new Array();
                }
                _this.mgUserDto.departments.push(element.id);
            });
            data.userApplicationRole.forEach(function (element) {
                if (_this.mgUserDto.userApplicationRole == null || _this.mgUserDto.userApplicationRole === undefined) {
                    _this.mgUserDto.userApplicationRole = new Array();
                }
                var appRoleId = new __WEBPACK_IMPORTED_MODULE_6__viewmodel_usersviewmodel_applicationroleidviewmodel__["a" /* ApplicationRoleIdViewModel */]();
                appRoleId.applicationId = element.applicationId;
                appRoleId.roleId = element.roleId;
                _this.mgUserDto.userApplicationRole.push(appRoleId);
            });
            return _this.mgUserDto;
        });
    };
    UserDataService.prototype.createAgentUser = function (agentInfo) {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.UserMgmtApi
            + 'api/agent/Create/', JSON.stringify(agentInfo));
    };
    UserDataService.prototype.createHotelUser = function (hotelUserInfo) {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.UserMgmtApi
            + 'api/HotelUser/Create/', hotelUserInfo);
    };
    UserDataService.prototype.getHotelUserById = function (userId) {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.UserMgmtApi
            + 'api/HotelUser/GetById?userId=' + userId).map(function (data) {
            _this.hotelUserDto = data;
            _this.hotelUserDto.extranetRoleId = data.userApplicationRole[0].roleId;
            _this.hotelUserDto.hotelId = data.hotels;
            data.hotels.forEach(function (element) {
                if (_this.hotelUserDto.hotelId == null || _this.hotelUserDto.hotelId === undefined) {
                    _this.hotelUserDto.hotelId = new Array();
                }
                _this.hotelUserDto.hotelId.push(element.id);
            });
            return _this.hotelUserDto;
        });
    };
    UserDataService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__["a" /* AuthenticatedHttpService */],
            __WEBPACK_IMPORTED_MODULE_2__common_shared_services_portal_service__["a" /* PortalService */],
            __WEBPACK_IMPORTED_MODULE_3__angular_router__["ActivatedRoute"]])
    ], UserDataService);
    return UserDataService;
}());



/***/ }),

/***/ "../../../../../src/app/backoffice/viewmodel/usersviewmodel/applicationroleidviewmodel.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ApplicationRoleIdViewModel; });
var ApplicationRoleIdViewModel = (function () {
    function ApplicationRoleIdViewModel() {
    }
    return ApplicationRoleIdViewModel;
}());



/***/ }),

/***/ "../../../../../src/app/backoffice/viewmodel/usersviewmodel/mguserviewmodel.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return MgUserViewModel; });
var MgUserViewModel = (function () {
    function MgUserViewModel() {
    }
    return MgUserViewModel;
}());



/***/ }),

/***/ "../../../../../src/app/common/constants.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return CONSTANTS; });
var CONSTANTS = {
    operation: {
        read: 'read',
        create: 'create',
        edit: 'edit',
        delete: 'delete'
    },
    // // FeatureTypeId's  are the same Id's as defined in FeatureType enum
    featuretypeid: {
        HotelProfile: 21,
        Templates: 14
    },
    application: {
        backoffice: 'backoffice',
        extranet: 'extranet',
        b2b: 'b2b'
    },
    userType: {
        mguser: 'MGUser',
        agentuser: 'AgentUser',
        hoteluser: 'HotelUser'
    }
};


/***/ }),

/***/ "../../../../../src/app/common/core/core.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return CoreModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_common__ = __webpack_require__("../../../common/esm5/common.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__dashboards_dashboard_dashboard_component__ = __webpack_require__("../../../../../src/app/common/core/dashboards/dashboard/dashboard.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__dashboards_hotel_admin_dashboard_hotel_admin_dashboard_component__ = __webpack_require__("../../../../../src/app/common/core/dashboards/hotel-admin-dashboard/hotel-admin-dashboard.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__dashboards_agent_dashboard_agent_dashboard_component__ = __webpack_require__("../../../../../src/app/common/core/dashboards/agent-dashboard/agent-dashboard.component.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};





var CoreModule = (function () {
    function CoreModule() {
    }
    CoreModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            imports: [
                __WEBPACK_IMPORTED_MODULE_1__angular_common__["CommonModule"]
            ],
            declarations: [__WEBPACK_IMPORTED_MODULE_2__dashboards_dashboard_dashboard_component__["a" /* DashboardComponent */], __WEBPACK_IMPORTED_MODULE_3__dashboards_hotel_admin_dashboard_hotel_admin_dashboard_component__["a" /* HotelAdminDashboardComponent */], __WEBPACK_IMPORTED_MODULE_4__dashboards_agent_dashboard_agent_dashboard_component__["a" /* AgentDashboardComponent */]]
        })
    ], CoreModule);
    return CoreModule;
}());



/***/ }),

/***/ "../../../../../src/app/common/core/dashboards/agent-dashboard/agent-dashboard.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/common/core/dashboards/agent-dashboard/agent-dashboard.component.html":
/***/ (function(module, exports) {

module.exports = "<p>\n  agent-dashboard works!\n</p>\n"

/***/ }),

/***/ "../../../../../src/app/common/core/dashboards/agent-dashboard/agent-dashboard.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AgentDashboardComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var AgentDashboardComponent = (function () {
    function AgentDashboardComponent() {
    }
    AgentDashboardComponent.prototype.ngOnInit = function () {
    };
    AgentDashboardComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-agent-dashboard',
            template: __webpack_require__("../../../../../src/app/common/core/dashboards/agent-dashboard/agent-dashboard.component.html"),
            styles: [__webpack_require__("../../../../../src/app/common/core/dashboards/agent-dashboard/agent-dashboard.component.css")]
        }),
        __metadata("design:paramtypes", [])
    ], AgentDashboardComponent);
    return AgentDashboardComponent;
}());



/***/ }),

/***/ "../../../../../src/app/common/core/dashboards/dashboard/dashboard.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/common/core/dashboards/dashboard/dashboard.component.html":
/***/ (function(module, exports) {

module.exports = "<p>\n  dashboard works!\n  <button class=\"btn btn-primary\" (click)='OnButtonClick()'>BackOfficeTest</button>\n  <button class=\"btn btn-primary\" (click)='OnExtranetButtonClick()'>ExtranetTest</button>\n</p>\n"

/***/ }),

/***/ "../../../../../src/app/common/core/dashboards/dashboard/dashboard.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return DashboardComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__shared_services_authenticated_http_service__ = __webpack_require__("../../../../../src/app/common/shared/services/authenticated-http.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__shared_services_portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

// import { AuthenticatedHttpService } from '../../../../services/authenticated-http.service';


var DashboardComponent = (function () {
    function DashboardComponent(authenticatedHttpService, portalService) {
        this.authenticatedHttpService = authenticatedHttpService;
        this.portalService = portalService;
    }
    DashboardComponent.prototype.ngOnInit = function () {
        console.log('Init Dashboard Component');
    };
    DashboardComponent.prototype.OnButtonClick = function () {
        var _this = this;
        // this.authenticatedHttpService.getTest()
        // this.authenticatedHttpService.get()
        // this.authenticatedHttpService.getBackofficeTest('api/Users/test')
        this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.BackOfficeApi
            + 'api/Users/test')
            .subscribe(function (test) {
            _this.testData = test;
            console.log('Returned From New Auth Service is ' + JSON.stringify(_this.testData));
        }, function (error) { return _this.err = error; });
    };
    DashboardComponent.prototype.OnExtranetButtonClick = function () {
        var _this = this;
        // this.authenticatedHttpService.getTest()
        // this.authenticatedHttpService.get()
        // this.authenticatedHttpService.getExtranetTest('api/Hotels/test')
        this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/Hotels/test')
            .subscribe(function (test) {
            _this.testData = test;
            console.log('Returned From Service with Extranet Call ' + JSON.stringify(_this.testData));
        }, function (error) { return _this.err = error; });
    };
    DashboardComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-dashboard',
            template: __webpack_require__("../../../../../src/app/common/core/dashboards/dashboard/dashboard.component.html"),
            styles: [__webpack_require__("../../../../../src/app/common/core/dashboards/dashboard/dashboard.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__shared_services_authenticated_http_service__["a" /* AuthenticatedHttpService */],
            __WEBPACK_IMPORTED_MODULE_2__shared_services_portal_service__["a" /* PortalService */]])
    ], DashboardComponent);
    return DashboardComponent;
}());



/***/ }),

/***/ "../../../../../src/app/common/core/dashboards/hotel-admin-dashboard/hotel-admin-dashboard.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/common/core/dashboards/hotel-admin-dashboard/hotel-admin-dashboard.component.html":
/***/ (function(module, exports) {

module.exports = "<p>\n  hotel-admin-dashboard works!\n</p>\n"

/***/ }),

/***/ "../../../../../src/app/common/core/dashboards/hotel-admin-dashboard/hotel-admin-dashboard.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return HotelAdminDashboardComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var HotelAdminDashboardComponent = (function () {
    function HotelAdminDashboardComponent() {
    }
    HotelAdminDashboardComponent.prototype.ngOnInit = function () {
    };
    HotelAdminDashboardComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-hotel-admin-dashboard',
            template: __webpack_require__("../../../../../src/app/common/core/dashboards/hotel-admin-dashboard/hotel-admin-dashboard.component.html"),
            styles: [__webpack_require__("../../../../../src/app/common/core/dashboards/hotel-admin-dashboard/hotel-admin-dashboard.component.css")]
        }),
        __metadata("design:paramtypes", [])
    ], HotelAdminDashboardComponent);
    return HotelAdminDashboardComponent;
}());



/***/ }),

/***/ "../../../../../src/app/common/enums.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "c", function() { return ObjectState; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "b", function() { return EntityState; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ContractType; });
var ObjectState;
(function (ObjectState) {
    ObjectState[ObjectState["Unchanged"] = 0] = "Unchanged";
    ObjectState[ObjectState["Added"] = 1] = "Added";
    ObjectState[ObjectState["Modified"] = 2] = "Modified";
    ObjectState[ObjectState["Deleted"] = 3] = "Deleted";
})(ObjectState || (ObjectState = {}));
var EntityState;
(function (EntityState) {
    EntityState[EntityState["New"] = 0] = "New";
    EntityState[EntityState["Inserted"] = 1] = "Inserted";
})(EntityState || (EntityState = {}));
var ContractType;
(function (ContractType) {
    ContractType[ContractType["MGStatic"] = 0] = "MGStatic";
    ContractType[ContractType["MGDynamic"] = 1] = "MGDynamic";
    ContractType[ContractType["NonMG"] = 2] = "NonMG";
})(ContractType || (ContractType = {}));


/***/ }),

/***/ "../../../../../src/app/common/material/material.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return MaterialModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_material__ = __webpack_require__("../../../material/esm5/material.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_cdk_table__ = __webpack_require__("../../../cdk/esm5/table.es5.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var MaterialModule = (function () {
    function MaterialModule() {
    }
    MaterialModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            imports: [
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["d" /* MatAutocompleteModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["e" /* MatButtonModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["f" /* MatButtonToggleModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["g" /* MatCardModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["h" /* MatCheckboxModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["i" /* MatChipsModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["j" /* MatDatepickerModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["l" /* MatDialogModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["n" /* MatExpansionModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["o" /* MatFormFieldModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["p" /* MatGridListModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["q" /* MatIconModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["r" /* MatInputModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["s" /* MatListModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["t" /* MatMenuModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["u" /* MatNativeDateModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["w" /* MatPaginatorModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["x" /* MatProgressBarModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["y" /* MatProgressSpinnerModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["z" /* MatRadioModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["A" /* MatRippleModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["B" /* MatSelectModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["C" /* MatSidenavModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["E" /* MatSliderModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["D" /* MatSlideToggleModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["G" /* MatSnackBarModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["J" /* MatStepperModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["I" /* MatSortModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["L" /* MatTableModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["M" /* MatTabsModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["N" /* MatToolbarModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["O" /* MatTooltipModule */],
                __WEBPACK_IMPORTED_MODULE_2__angular_cdk_table__["m" /* CdkTableModule */]
            ],
            exports: [
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["d" /* MatAutocompleteModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["e" /* MatButtonModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["f" /* MatButtonToggleModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["g" /* MatCardModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["h" /* MatCheckboxModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["i" /* MatChipsModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["j" /* MatDatepickerModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["l" /* MatDialogModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["n" /* MatExpansionModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["p" /* MatGridListModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["q" /* MatIconModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["r" /* MatInputModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["s" /* MatListModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["t" /* MatMenuModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["u" /* MatNativeDateModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["w" /* MatPaginatorModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["x" /* MatProgressBarModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["y" /* MatProgressSpinnerModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["z" /* MatRadioModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["A" /* MatRippleModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["B" /* MatSelectModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["C" /* MatSidenavModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["E" /* MatSliderModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["D" /* MatSlideToggleModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["G" /* MatSnackBarModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["J" /* MatStepperModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["I" /* MatSortModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["L" /* MatTableModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["M" /* MatTabsModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["N" /* MatToolbarModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_material__["O" /* MatTooltipModule */],
                __WEBPACK_IMPORTED_MODULE_2__angular_cdk_table__["m" /* CdkTableModule */]
            ]
        })
    ], MaterialModule);
    return MaterialModule;
}());



/***/ }),

/***/ "../../../../../src/app/common/shared/services/authenticated-http.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AuthenticatedHttpService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_http__ = __webpack_require__("../../../http/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_Observable__ = __webpack_require__("../../../../rxjs/_esm5/Observable.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_rxjs_add_observable_throw__ = __webpack_require__("../../../../rxjs/_esm5/add/observable/throw.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5_rxjs_add_operator_map__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/map.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6_rxjs_add_operator_catch__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/catch.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7_rxjs_add_operator_do__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/do.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8_rxjs_add_operator_mergeMap__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/mergeMap.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_9_rxjs_add_operator_merge__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/merge.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_10__angular_common_http__ = __webpack_require__("../../../common/esm5/http.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

 // Todo: Remove this later









var AuthenticatedHttpService = (function () {
    function AuthenticatedHttpService(http, portalService, _http) {
        this.http = http;
        this.portalService = portalService;
        this._http = _http;
    }
    AuthenticatedHttpService.prototype.handleError = function (err) {
        console.log(err.message);
        return __WEBPACK_IMPORTED_MODULE_3_rxjs_Observable__["a" /* Observable */].throw(err.message);
    };
    AuthenticatedHttpService.prototype.get = function (url) {
        var _this = this;
        var request = function () {
            console.log('Invoking get with token' + _this.portalService.appSettings.AccessToken);
            return _this._http.get(url, {
                headers: new __WEBPACK_IMPORTED_MODULE_10__angular_common_http__["c" /* HttpHeaders */]().set('Authorization', 'Bearer ' + _this.portalService.appSettings.AccessToken)
            })
                .do(function (data) { return console.log('All From new get with headers(url):' + JSON.stringify(data)); });
        };
        return this.refreshTokenOnAuthorizationFailure(request);
    };
    AuthenticatedHttpService.prototype.post = function (url, data) {
        var _this = this;
        var request = function () {
            return _this._http.post(url, data, {
                headers: new __WEBPACK_IMPORTED_MODULE_10__angular_common_http__["c" /* HttpHeaders */]().set('Authorization', 'Bearer ' + _this.portalService.appSettings.AccessToken)
                    .set('Content-Type', 'application/json')
            });
        };
        return this.refreshTokenOnAuthorizationFailure(request);
    };
    AuthenticatedHttpService.prototype.put = function (url, data) {
        var _this = this;
        var request = function () {
            return _this._http.put(url, data, {
                headers: new __WEBPACK_IMPORTED_MODULE_10__angular_common_http__["c" /* HttpHeaders */]().set('Authorization', 'Bearer ' + _this.portalService.appSettings.AccessToken)
                    .set('Content-Type', 'application/json')
            });
        };
        return this.refreshTokenOnAuthorizationFailure(request);
    };
    /*    post(url, data) {
        const request = () => {
          const headers = this.createHeaders();
          headers.append('Content-Type', 'application/json');
          return this.http.post(this.apiUrl + url ,
            data,
              {
                headers: headers
              });
        };
        return this.refreshTokenOnAuthorizationFailure(request);
      }
     */
    AuthenticatedHttpService.prototype.refreshTokenOnAuthorizationFailure = function (request) {
        var _this = this;
        return request().catch(function (err, caught) {
            // Handle Unauthorized responses
            if (err.status === 401) {
                console.log('Before Calling Refresh Tokens');
                return _this.refreshTokens().flatMap(function (newTokenResponse) {
                    if (!newTokenResponse || !newTokenResponse.access_token) {
                        console.log('Unable to get Token ');
                        window.location.href = _this.portalService.appSettings.BaseUrls.Web + 'Account/Logout';
                        return __WEBPACK_IMPORTED_MODULE_3_rxjs_Observable__["a" /* Observable */].throw('Could not refresh Auth Token . Redirecting to logoff');
                    }
                    _this.portalService.appSettings.AccessToken = newTokenResponse.access_token;
                    return request();
                });
            }
            return __WEBPACK_IMPORTED_MODULE_3_rxjs_Observable__["a" /* Observable */].throw(err);
        });
    };
    AuthenticatedHttpService.prototype.refreshTokens = function () {
        return this._http.get(this.portalService.appSettings.BaseUrls.Web + 'Account/RefreshTokens')
            .map(function (r) { return r; });
    };
    AuthenticatedHttpService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_http__["a" /* Http */], __WEBPACK_IMPORTED_MODULE_2__portal_service__["a" /* PortalService */],
            __WEBPACK_IMPORTED_MODULE_10__angular_common_http__["a" /* HttpClient */]])
    ], AuthenticatedHttpService);
    return AuthenticatedHttpService;
}());



/***/ }),

/***/ "../../../../../src/app/common/shared/services/lookup.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return LookupService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__authenticated_http_service__ = __webpack_require__("../../../../../src/app/common/shared/services/authenticated-http.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var LookupService = (function () {
    // roomsDto: RoomTypeViewModel[];
    function LookupService(authenticatedHttpService, portalService) {
        this.authenticatedHttpService = authenticatedHttpService;
        this.portalService = portalService;
    }
    LookupService.prototype.getCountries = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/MasterData/GetCountries/').map(function (data) {
            // data.json();
            _this.countriesDto = data.result;
            console.log('Country at service', _this.countriesDto);
            return _this.countriesDto;
        });
    };
    LookupService.prototype.getCities = function (countryId) {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/MasterData/GetCities?id=' + countryId).map(function (data) {
            _this.citiesDto = data.result;
            console.log('Cities at service', _this.citiesDto);
            return _this.citiesDto;
        });
    };
    LookupService.prototype.getHotelTypes = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/MasterData/GetHoteltypes/').map(function (data) {
            _this.hotelTypesDto = data.result;
            console.log('Type at service', _this.hotelTypesDto);
            return _this.hotelTypesDto;
        });
    };
    LookupService.prototype.getHotelChains = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/MasterData/GetHotelChains/').map(function (data) {
            _this.hotelChainDto = data.result;
            console.log('Chain at service', _this.hotelChainDto);
            return _this.hotelChainDto;
        });
    };
    LookupService.prototype.getHotelBrands = function (chainId) {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/MasterData/GetHotelBrands?id=' + chainId).map(function (data) {
            _this.hotelBrandDto = data.result;
            console.log('Brand at service', _this.hotelBrandDto);
            return _this.hotelBrandDto;
        });
    };
    LookupService.prototype.getDesignation = function () {
        var _this = this;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/Miscellaneous/GetDesignation/', '').map(function (data) {
            _this.contactTitleDto = data.result;
            console.log('Contact at service', _this.contactTitleDto);
            return _this.contactTitleDto;
        });
    };
    LookupService.prototype.getCurrency = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/PaymentData/GetCurrency/').map(function (data) {
            _this.currencyDto = data.result;
            return _this.currencyDto;
        });
    };
    LookupService.prototype.getPaymentMethod = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/PaymentData/GetPaymentMethod/').map(function (data) {
            _this.paymentMethodDto = data.result;
            return _this.paymentMethodDto;
        });
    };
    LookupService.prototype.getRateType = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/PaymentData/GetRateType/').map(function (data) {
            _this.rateTypeDto = data.result;
            return _this.rateTypeDto;
        });
    };
    LookupService.prototype.getChannelManager = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/Miscellaneous/GetChannelManager/').map(function (data) {
            _this.channelmanagerDto = data.result;
            return _this.channelmanagerDto;
        });
    };
    LookupService.prototype.getTaxType = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/PaymentData/GetTaxType/').map(function (data) {
            _this.taxTypeDto = data.result;
            return _this.taxTypeDto;
        });
    };
    LookupService.prototype.getTaxApplicability = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/PaymentData/GetTaxApplicability/').map(function (data) {
            _this.taxApplicabilityDto = data.result;
            return _this.taxApplicabilityDto;
        });
    };
    LookupService.prototype.getStarRating = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/MasterData/GetStarRating/').map(function (data) {
            _this.starRatingDto = data.result;
            return _this.starRatingDto;
        });
    };
    LookupService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__authenticated_http_service__["a" /* AuthenticatedHttpService */],
            __WEBPACK_IMPORTED_MODULE_2__portal_service__["a" /* PortalService */]])
    ], LookupService);
    return LookupService;
}());



/***/ }),

/***/ "../../../../../src/app/common/shared/services/menu-data.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return MenuDataService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__framework_fw_services_menu_service__ = __webpack_require__("../../../../../src/app/framework/fw/services/menu.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__framework_fw_services_top_bar_service__ = __webpack_require__("../../../../../src/app/framework/fw/services/top-bar.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var MenuDataService = (function () {
    function MenuDataService(menuService, topBarService) {
        var _this = this;
        this.menuService = menuService;
        this.topBarService = topBarService;
        // Subscribe to the event when the top bar application changes
        this.topBarService.appChange$.subscribe(function (app) { return _this.UpdateApp(app); });
    }
    MenuDataService.prototype.UpdateApp = function (appName) {
        this.TransformMenuData(appName);
    };
    MenuDataService.prototype.InitializeMenuData = function (userDetails) {
        console.log('InitializeMenuData');
        this._userDetails = userDetails;
        if (userDetails.applicationPermissions.length > 0) {
            var app = userDetails.applicationPermissions[0].name;
            var translatedMenu = this.TransformMenuData(app);
            console.log('Translated Menus' + JSON.stringify(translatedMenu));
        }
    };
    MenuDataService.prototype.TransformMenuData = function (app, role) {
        var _this = this;
        var appPermission = this._userDetails.applicationPermissions.find(function (x) { return x.name.trim() === app.trim(); });
        if (appPermission != null) {
            var appRole = appPermission.role;
        }
        var featureListData = appPermission.featuresList;
        var parentsMenuData = new Array();
        if (featureListData != null && featureListData.length > 0) {
            // Top Level Menus
            parentsMenuData = featureListData.filter(function (val) { return val.parentFeatureId == null; });
            parentsMenuData.forEach(function (parentMenuItem) {
                _this.buildTreeviewMenu(parentMenuItem, featureListData);
            });
        }
        console.log('Parent Menu Data' + JSON.stringify(parentsMenuData));
        var translatedMenus = this.translateModelToMenusRecursively(parentsMenuData);
        console.log('TranslatedMenus' + JSON.stringify(translatedMenus));
        this.menuService.items = translatedMenus;
        return translatedMenus;
    };
    MenuDataService.prototype.translateModelToMenusRecursively = function (featurePermissionViewModel) {
        var _this = this;
        var translatedMenus = new Array();
        featurePermissionViewModel.forEach(function (element) {
            var tempMenuItem = new __WEBPACK_IMPORTED_MODULE_1__framework_fw_services_menu_service__["a" /* MenuItems */]();
            tempMenuItem.icon = element.icon;
            tempMenuItem.route = element.route;
            tempMenuItem.text = element.label;
            if (element.subFeaturePermissionViewModel != null && element.subFeaturePermissionViewModel.length > 0) {
                tempMenuItem.submenu = _this.translateModelToMenusRecursively(element.subFeaturePermissionViewModel);
            }
            else {
                tempMenuItem.submenu = null;
            }
            translatedMenus.push(tempMenuItem);
        });
        return translatedMenus;
    };
    MenuDataService.prototype.buildTreeviewMenu = function (parentMenuItem, menuData) {
        var _this = this;
        var menuItems;
        // Get all child menu Items for the Parent
        menuItems = menuData.filter(function (menu) { return menu.parentFeatureId === parentMenuItem.featureTypeId; });
        if (menuItems != null && menuItems.length > 0) {
            parentMenuItem.subFeaturePermissionViewModel = new Array();
            this.AddAdditionalMenuAttributes(parentMenuItem, true);
            menuItems.forEach(function (childMenu) {
                parentMenuItem.subFeaturePermissionViewModel.push(childMenu);
                _this.buildTreeviewMenu(childMenu, menuData);
            });
        }
        else {
            this.AddAdditionalMenuAttributes(parentMenuItem, false);
        }
    };
    MenuDataService.prototype.AddAdditionalMenuAttributes = function (menuItem, parent) {
        if (menuItem != null) {
            menuItem.icon = this.getIconforMenuFeature(menuItem.typeName);
            if (parent === false) {
                menuItem.route = this.getRoutforMenuFeature(menuItem.typeName);
            }
            else {
                menuItem.route = null;
            }
        }
        return menuItem;
    };
    MenuDataService.prototype.getIconforMenuFeature = function (feature) {
        if (feature.toUpperCase() === 'EXTRANETDASHBOARD') {
            return 'fa fa-tachometer';
        }
        else if (feature.toUpperCase() === 'BACKOFFICEDASHBOARD') {
            return 'fa fa-tachometer';
        }
        else if (feature.toUpperCase() === 'CONTRACT') {
            return 'fa fa-pencil';
        }
        else if (feature.toUpperCase() === 'AGENCYMANAGEMENT') {
            return 'fa fa-users';
        }
        else if (feature.toUpperCase() === 'REPORTS') {
            return 'fa fa-file-text-o';
        }
        else if (feature.toUpperCase() === 'MASTERDATA') {
            return 'fa fa-database';
        }
        else if (feature.toUpperCase() === 'HOTELMANAGEMENT') {
            return 'fa fa-user';
        }
        else if (feature.toUpperCase() === 'FINANCEMANAGEMENT') {
            return 'fa fa-usd';
        }
        else if (feature.toUpperCase() === 'RESERVATIONMANAGEMENT') {
            return 'fa fa-calendar-check-o';
        }
        else if (feature.toUpperCase() === 'REVENUEMANAGEMENT') {
            return 'fa fa-line-chart';
        }
        else if (feature.toUpperCase() === 'SUPPLIERMANAGEMENT') {
            return 'fa fa-users';
        }
        else if (feature.toUpperCase() === 'USERMANAGEMENT') {
            return 'fa fa-users';
        }
        else if (feature.toUpperCase() === 'TOOLSMANAGEMENT') {
            return 'fa fa-cogs';
        }
        else if (feature.toUpperCase() === 'REPORTSMANAGEMENT') {
            return 'fa fa-file-text-o';
        }
        else {
            return null;
        }
    };
    MenuDataService.prototype.getRoutforMenuFeature = function (feature) {
        if (feature.toUpperCase() === 'HOTELPROFILE') {
            return 'hotelmgmt/hotels';
        }
        else if (feature.toUpperCase() === 'EXTRANETDASHBOARD') {
            return 'extranetdashboard';
        }
        else if (feature.toUpperCase() === 'BACKOFFICEDASHBOARD') {
            return 'backofficedashboard';
        }
        else if (feature.toUpperCase() === 'TEMPLATES') {
            return 'templatemgmt/templates';
        }
        else if (feature.toUpperCase() === 'MGUSER') {
            return 'usermgmt/mgusers';
        }
        else if (feature.toUpperCase() === 'CONTRACTS') {
            return 'contractmgmt/contracts';
        }
        else if (feature.toUpperCase() === 'AGENTSUSER') {
            return 'usermgmt/agentusers';
        }
        else if (feature.toUpperCase() === 'HOTELSUPPLIERUSER') {
            return 'usermgmt/hoteluserslist';
        }
        else {
            return null;
        }
    };
    MenuDataService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__framework_fw_services_menu_service__["b" /* MenuService */],
            __WEBPACK_IMPORTED_MODULE_2__framework_fw_services_top_bar_service__["b" /* TopBarService */]])
    ], MenuDataService);
    return MenuDataService;
}());



/***/ }),

/***/ "../../../../../src/app/common/shared/services/portal.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return PortalService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var PortalService = (function () {
    function PortalService() {
        this.loadSettings();
        // Todo: Remove this later
        console.log(this.appSettings.Name);
        console.log(this.appSettings.SubjectId);
        console.log(this.appSettings.AccessToken);
        console.log(this.appSettings.BaseUrls.Api);
        console.log(this.appSettings.BaseUrls.BackOfficeApi);
        console.log(this.appSettings.BaseUrls.ExtranetApi);
        console.log(this.appSettings.BaseUrls.UserMgmtApi);
        console.log(this.appSettings.FirstName);
        console.log(this.appSettings.IdToken);
        console.log('Disabled ' + this.appSettings.Disabled);
        // ~Todo: Remove this later
    }
    PortalService.prototype.loadSettings = function () {
        this.appSettings = {
            BaseUrls: {
                Api: JarvisAppSettings.BaseUrls.Api,
                Auth: JarvisAppSettings.BaseUrls.Auth,
                Web: JarvisAppSettings.BaseUrls.Web,
                BackOfficeApi: JarvisAppSettings.BaseUrls.BackOfficeApi,
                ExtranetApi: JarvisAppSettings.BaseUrls.ExtranetApi,
                UserMgmtApi: JarvisAppSettings.BaseUrls.UserMgmtApi
            },
            AccessToken: JarvisAppSettings.AccessToken,
            UserFullName: '',
            Name: JarvisAppSettings.Name,
            FirstName: JarvisAppSettings.FirstName,
            IdToken: JarvisAppSettings.IdToken,
            SubjectId: JarvisAppSettings.SubjectId,
            Disabled: JarvisAppSettings.Disabled
        };
    };
    PortalService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [])
    ], PortalService);
    return PortalService;
}());



/***/ }),

/***/ "../../../../../src/app/common/shared/services/state.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return StateService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__framework_fw_services_top_bar_service__ = __webpack_require__("../../../../../src/app/framework/fw/services/top-bar.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



//  This StateService is used only for complex route navigation .
// Ex. Initiallly when the application load , When the application is changed from the UI
var StateService = (function () {
    function StateService(router, topBarService) {
        var _this = this;
        this.router = router;
        this.topBarService = topBarService;
        // Subscribe to the event when the top bar application changes
        this.topBarService.appChange$.subscribe(function (app) { return _this.UpdateApp(app); });
    }
    StateService.prototype.InitializeState = function (userDetails) {
        this._userDetails = userDetails;
        if (userDetails.applicationPermissions.length > 0) {
            var app = userDetails.applicationPermissions[0].name;
            this.SetAppState(app);
        }
    };
    StateService.prototype.UpdateApp = function (appName) {
        this.SetAppState(appName);
    };
    StateService.prototype.SetAppState = function (app, role) {
        var appPermission = this._userDetails.applicationPermissions.find(function (x) { return x.name === app; });
        if (appPermission != null) {
            var appRole = appPermission.role;
            if (app.toUpperCase() === 'EXTRANET') {
                this.router.navigate(['/extranetdashboard']);
            }
            if (app.toUpperCase() === 'BACKOFFICE') {
                this.router.navigate(['/backofficedashboard']);
            }
        }
        // Todo: Inject the TopService component Add Conditions to route to the right component
    };
    StateService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_router__["Router"],
            __WEBPACK_IMPORTED_MODULE_2__framework_fw_services_top_bar_service__["b" /* TopBarService */]])
    ], StateService);
    return StateService;
}());



/***/ }),

/***/ "../../../../../src/app/common/shared/services/top-bar-data.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return TopBarDataService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__framework_fw_services_top_bar_service__ = __webpack_require__("../../../../../src/app/framework/fw/services/top-bar.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var TopBarDataService = (function () {
    function TopBarDataService(topBarService) {
        this.topBarService = topBarService;
    }
    TopBarDataService.prototype.InitializeTopBarData = function (userDetails) {
        this._userDetails = userDetails;
        this.TransformTopBarData();
        this.topBarService.setTopBarItem(this._topBarItem);
    };
    TopBarDataService.prototype.TransformTopBarData = function () {
        this._topBarItem = new __WEBPACK_IMPORTED_MODULE_1__framework_fw_services_top_bar_service__["a" /* TopBarItemViewModel */]();
        var topBarItemViewModel = new __WEBPACK_IMPORTED_MODULE_1__framework_fw_services_top_bar_service__["a" /* TopBarItemViewModel */]();
        topBarItemViewModel.firstName = this._userDetails.firstName;
        topBarItemViewModel.lastName = this._userDetails.lastName;
        // Todo: Remove this later as we are using applications
        this._userDetails.applicationPermissions.forEach(function (val) { return topBarItemViewModel.appRole[val.name] = val.role; });
        topBarItemViewModel.applications = new Array();
        this._userDetails.applicationPermissions.forEach(function (val) {
            return topBarItemViewModel.applications.push({
                application: val.name,
                role: val.role
            });
        });
        this._topBarItem = topBarItemViewModel;
    };
    TopBarDataService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__framework_fw_services_top_bar_service__["b" /* TopBarService */]])
    ], TopBarDataService);
    return TopBarDataService;
}());



/***/ }),

/***/ "../../../../../src/app/common/shared/services/user-account.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return UserAccountService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_common_http__ = __webpack_require__("../../../common/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__authenticated_http_service__ = __webpack_require__("../../../../../src/app/common/shared/services/authenticated-http.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__angular_common__ = __webpack_require__("../../../common/esm5/common.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





var UserAccountService = (function () {
    function UserAccountService(authenticatedHttpService, http, portalService, location) {
        this.authenticatedHttpService = authenticatedHttpService;
        this.http = http;
        this.portalService = portalService;
        this.location = location;
    }
    UserAccountService.prototype.logOut = function () {
        var _this = this;
        console.log('Invoked logOut');
        this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.Web + 'account/logout')
            .subscribe(function () {
            console.log('Logout response ');
            _this.reloadPage();
        }, function (err) {
            console.log('Error in logout ' + err);
        }, function () { return console.log('Logout Response Complete'); });
    };
    UserAccountService.prototype.reloadPage = function () {
        window.location.href = this.portalService.appSettings.BaseUrls.Web;
        window.location.reload(true);
    };
    UserAccountService.prototype.changePassword = function () {
        console.log('Invoked changePassword');
        // this.http.post(this.portalService.appSettings.BaseUrls.Web + 'Account/Logout', null);
        /*  this.authenticatedHttpService
         .get(this.portalService.appSettings.BaseUrls.Web + 'Account/Logout'); */
        // this.http.get(this.portalService.appSettings.BaseUrls.Web + 'account/logout')
        /* this.http.get(this.portalService.appSettings.BaseUrls.Web + 'account/logout',
        {
         headers: new HttpHeaders().set('Accept', 'text/html')
       }) */
        // .subscribe(() => console.log('Logout response '), (err) => console.log(err));
        return;
    };
    UserAccountService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_3__authenticated_http_service__["a" /* AuthenticatedHttpService */],
            __WEBPACK_IMPORTED_MODULE_1__angular_common_http__["a" /* HttpClient */], __WEBPACK_IMPORTED_MODULE_2__portal_service__["a" /* PortalService */],
            __WEBPACK_IMPORTED_MODULE_4__angular_common__["Location"]])
    ], UserAccountService);
    return UserAccountService;
}());



/***/ }),

/***/ "../../../../../src/app/common/shared/services/user-profile.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export UserInfo */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return UserProfileService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__authenticated_http_service__ = __webpack_require__("../../../../../src/app/common/shared/services/authenticated-http.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__top_bar_data_service__ = __webpack_require__("../../../../../src/app/common/shared/services/top-bar-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__state_service__ = __webpack_require__("../../../../../src/app/common/shared/services/state.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__menu_data_service__ = __webpack_require__("../../../../../src/app/common/shared/services/menu-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__viewmodels_userdetailsviewmodel__ = __webpack_require__("../../../../../src/app/common/viewmodels/userdetailsviewmodel.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








// import {TopBarService} from '../../../framework/fw/services/top-bar.service';
var UserInfo = (function () {
    function UserInfo() {
    }
    return UserInfo;
}());

var UserProfileService = (function () {
    function UserProfileService(authenticatedHttpService, portalService, router, topBarDataService, stateService, menuDataService) {
        this.authenticatedHttpService = authenticatedHttpService;
        this.portalService = portalService;
        this.router = router;
        this.topBarDataService = topBarDataService;
        this.stateService = stateService;
        this.menuDataService = menuDataService;
        this.userDetailsDto = new __WEBPACK_IMPORTED_MODULE_7__viewmodels_userdetailsviewmodel__["a" /* UserDetailsViewModel */]();
        // topBarService.appChange$.subscribe((app)=> this.UpdateApp(app));
    }
    /*   UpdateApp(appName) {
        console.log('AppName:' + appName);
        this.menuDataService.TransformTopBarData(appName);
       } */
    UserProfileService.prototype.GetUserProfileAsync = function (id) {
        var _this = this;
        this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.BackOfficeApi
            + 'api/Users/' + id).subscribe(function (user) {
            _this.userDetails = user;
            _this.userDetailsDto = user;
            if (_this.userDetailsDto) {
                console.log('From User DEtails DTO' + _this.userDetailsDto);
                if (_this.userDetailsDto.disabled) {
                    _this.router.navigate(['/unauthorized']);
                }
                else {
                    _this.SetBasicUserInfo(_this.userDetails);
                    // Give it all information that is needed to display the TopBar component
                    _this.topBarDataService.InitializeTopBarData(_this.userDetailsDto);
                    // Give it all information that is needed to display the Menu component
                    _this.menuDataService.InitializeMenuData(_this.userDetailsDto);
                    // Todo: Whenever the app refreshes - the menu service & State service listens
                    // Create a State Service to route to the right View
                    // this.router.navigate(['/agentdashboard']); // Todo : Change accordingly.
                    _this.stateService.InitializeState(_this.userDetailsDto);
                }
            }
        }, function (err) {
            console.log(err);
        }, function () { return console.log('GetUserProfile() retrieved user details '); });
    };
    UserProfileService.prototype.SetBasicUserInfo = function (userDetails) {
        this.basicUserInfo = new UserInfo();
        this.basicUserInfo.FirstName = this.userDetails.firstName;
        this.basicUserInfo.LastName = this.userDetails.lastName;
    };
    UserProfileService.prototype.GetBasicUserInfo = function () {
        return this.basicUserInfo;
    };
    UserProfileService.prototype.GetUserPermissionsForFeature = function (applicationName, featureTypeId) {
        var priviligesArray = Array();
        var apps = this.userDetailsDto.applicationPermissions
            .filter(function (app) { return app.name.toUpperCase() === applicationName.toUpperCase(); });
        if (apps != null && apps.length > 0) {
            var priv = apps[0].featuresList.find(function (fea) { return fea.featureTypeId === featureTypeId; })
                .privileges;
            // const privArray = priv.split('|');
            priviligesArray = priv.split('|');
            return priviligesArray;
        }
        return null;
    };
    UserProfileService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_3__authenticated_http_service__["a" /* AuthenticatedHttpService */],
            __WEBPACK_IMPORTED_MODULE_2__portal_service__["a" /* PortalService */], __WEBPACK_IMPORTED_MODULE_1__angular_router__["Router"],
            __WEBPACK_IMPORTED_MODULE_4__top_bar_data_service__["a" /* TopBarDataService */],
            __WEBPACK_IMPORTED_MODULE_5__state_service__["a" /* StateService */],
            __WEBPACK_IMPORTED_MODULE_6__menu_data_service__["a" /* MenuDataService */]])
    ], UserProfileService);
    return UserProfileService;
}());



/***/ }),

/***/ "../../../../../src/app/common/shared/shared.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return SharedModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_common__ = __webpack_require__("../../../common/esm5/common.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_common_http__ = __webpack_require__("../../../common/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__angular_forms__ = __webpack_require__("../../../forms/esm5/forms.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__services_portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__services_authenticated_http_service__ = __webpack_require__("../../../../../src/app/common/shared/services/authenticated-http.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__services_user_profile_service__ = __webpack_require__("../../../../../src/app/common/shared/services/user-profile.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__services_menu_data_service__ = __webpack_require__("../../../../../src/app/common/shared/services/menu-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_9__services_top_bar_data_service__ = __webpack_require__("../../../../../src/app/common/shared/services/top-bar-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_10__services_state_service__ = __webpack_require__("../../../../../src/app/common/shared/services/state.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_11__services_lookup_service__ = __webpack_require__("../../../../../src/app/common/shared/services/lookup.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_12__services_user_account_service__ = __webpack_require__("../../../../../src/app/common/shared/services/user-account.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_13__framework_fw_users_user_account_api__ = __webpack_require__("../../../../../src/app/framework/fw/users/user-account-api.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};














var SharedModule = (function () {
    // Preventing importing this modules more than once
    // https://angular.io/guide/ngmodule-faq
    function SharedModule(parentModule) {
        if (parentModule) {
            throw new Error('SharedModule is already loaded. Import it in the AppModule only');
        }
    }
    SharedModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            imports: [
                __WEBPACK_IMPORTED_MODULE_1__angular_common__["CommonModule"],
                __WEBPACK_IMPORTED_MODULE_2__angular_router__["RouterModule"],
                __WEBPACK_IMPORTED_MODULE_3__angular_common_http__["b" /* HttpClientModule */],
                __WEBPACK_IMPORTED_MODULE_4__angular_forms__["FormsModule"]
            ],
            exports: [
                __WEBPACK_IMPORTED_MODULE_1__angular_common__["CommonModule"],
                __WEBPACK_IMPORTED_MODULE_2__angular_router__["RouterModule"],
                __WEBPACK_IMPORTED_MODULE_3__angular_common_http__["b" /* HttpClientModule */],
                __WEBPACK_IMPORTED_MODULE_4__angular_forms__["FormsModule"]
            ],
            declarations: [],
            providers: [
                __WEBPACK_IMPORTED_MODULE_5__services_portal_service__["a" /* PortalService */],
                __WEBPACK_IMPORTED_MODULE_6__services_authenticated_http_service__["a" /* AuthenticatedHttpService */],
                __WEBPACK_IMPORTED_MODULE_7__services_user_profile_service__["a" /* UserProfileService */],
                __WEBPACK_IMPORTED_MODULE_8__services_menu_data_service__["a" /* MenuDataService */],
                __WEBPACK_IMPORTED_MODULE_9__services_top_bar_data_service__["a" /* TopBarDataService */],
                __WEBPACK_IMPORTED_MODULE_10__services_state_service__["a" /* StateService */],
                __WEBPACK_IMPORTED_MODULE_11__services_lookup_service__["a" /* LookupService */],
                __WEBPACK_IMPORTED_MODULE_12__services_user_account_service__["a" /* UserAccountService */],
                { provide: __WEBPACK_IMPORTED_MODULE_13__framework_fw_users_user_account_api__["a" /* UserAccountApi */], useExisting: __WEBPACK_IMPORTED_MODULE_12__services_user_account_service__["a" /* UserAccountService */] }
            ]
        }),
        __param(0, Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Optional"])()), __param(0, Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["SkipSelf"])()),
        __metadata("design:paramtypes", [SharedModule])
    ], SharedModule);
    return SharedModule;
}());



/***/ }),

/***/ "../../../../../src/app/common/viewmodels/userdetailsviewmodel.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export FeaturePermissionViewModel */
/* unused harmony export ApplicationPermissionViewModel */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return UserDetailsViewModel; });
var FeaturePermissionViewModel = (function () {
    function FeaturePermissionViewModel() {
        this.subFeaturePermissionViewModel = new Array();
        this.submenu = new Array();
    }
    return FeaturePermissionViewModel;
}());

var ApplicationPermissionViewModel = (function () {
    function ApplicationPermissionViewModel() {
        this.featurePermissions = new Map();
        this.featuresList = new Array();
    }
    return ApplicationPermissionViewModel;
}());

var UserDetailsViewModel = (function () {
    function UserDetailsViewModel() {
        this.applicationPermissions = new Array();
    }
    return UserDetailsViewModel;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/dashboard-extranet/dashboard-extranet.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ".example-container {\r\n  display: -webkit-box;\r\n  display: -ms-flexbox;\r\n  display: flex;\r\n  -webkit-box-orient: vertical;\r\n  -webkit-box-direction: normal;\r\n      -ms-flex-direction: column;\r\n          flex-direction: column;\r\n  max-height: 500px;\r\n  min-width: 300px;\r\n}\r\n\r\n.mat-table {\r\n  overflow: auto;\r\n  max-height: 500px;\r\n}\r\n\r\n.example-header {\r\n  min-height: 64px;\r\n  padding: 8px 24px 0;\r\n}\r\n\r\n.mat-form-field {\r\n  font-size: 14px;\r\n  width: 100%;\r\n}\r\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/dashboard-extranet/dashboard-extranet.component.html":
/***/ (function(module, exports) {

module.exports = "<p>\n  dashboard-extranet works!\n</p>\n\n<p>Just Testing Here</p>\n\n<form #form=\"ngForm\">\n  <input type=\"text\" placeholder=\"Name\" name=\"name\"  ngModel>\n  <button type=\"submit\">Ok</button>\n</form>\n\n{{form.pristine}}\n\n<button mat-button>\n  <mat-icon>face</mat-icon>\n  Click me!\n</button>\n<mat-checkbox>Check me!</mat-checkbox>\n\n<div class=\"example-container mat-elevation-z8\">\n\n    <div class=\"example-header\">\n        <mat-form-field>\n          <input matInput (keyup)=\"applyFilter($event.target.value)\" placeholder=\"Filter\">\n        </mat-form-field>\n      </div>\n\n  <mat-table #table [dataSource]=\"dataSource\" matSort>\n\n    <!--- Note that these columns can be defined in any order.\n          The actual rendered columns are set as a property on the row definition\" -->\n\n    <!-- Position Column -->\n    <ng-container matColumnDef=\"position\">\n      <mat-header-cell *matHeaderCellDef mat-sort-header> No. </mat-header-cell>\n      <mat-cell *matCellDef=\"let element\"> <a [routerLink]=\"['/hotelmgmt/hotel', element.position, 'create']\">{{element.position}}</a> </mat-cell>\n    </ng-container>\n\n    <!-- Name Column -->\n    <ng-container matColumnDef=\"name\">\n      <mat-header-cell *matHeaderCellDef mat-sort-header> Name </mat-header-cell>\n      <mat-cell *matCellDef=\"let element\"> {{element.name}} </mat-cell>\n    </ng-container>\n\n    <!-- Weight Column -->\n    <ng-container matColumnDef=\"weight\">\n      <mat-header-cell *matHeaderCellDef mat-sort-header> Weight </mat-header-cell>\n      <mat-cell *matCellDef=\"let element\"> <a href=''>{{element.weight}}</a> </mat-cell>\n    </ng-container>\n\n    <!-- Symbol Column -->\n    <ng-container matColumnDef=\"symbol\">\n      <mat-header-cell *matHeaderCellDef mat-sort-header> Symbol </mat-header-cell>\n      <mat-cell *matCellDef=\"let element\"> {{element.symbol}} </mat-cell>\n    </ng-container>\n\n    <mat-header-row *matHeaderRowDef=\"displayedColumns\"></mat-header-row>\n    <mat-row *matRowDef=\"let row; columns: displayedColumns;\"></mat-row>\n  </mat-table>\n\n  <mat-paginator #paginator [pageSize]=\"10\"   [pageSizeOptions]=\"[5, 10, 20]\">\n  </mat-paginator>\n</div>\n\n"

/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/dashboard-extranet/dashboard-extranet.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export TestHotel */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return DashboardExtranetComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_material__ = __webpack_require__("../../../material/esm5/material.es5.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var TestHotel = (function () {
    function TestHotel() {
    }
    return TestHotel;
}());

var DashboardExtranetComponent = (function () {
    function DashboardExtranetComponent() {
        this.displayedColumns = ['position', 'name', 'weight', 'symbol'];
        this.dataSource = new __WEBPACK_IMPORTED_MODULE_1__angular_material__["K" /* MatTableDataSource */](ELEMENT_DATA);
    }
    /**
     * Set the paginator after the view init since this component will
     * be able to query its view for the initialized paginator.
     */
    DashboardExtranetComponent.prototype.applyFilter = function (filterValue) {
        filterValue = filterValue.trim(); // Remove whitespace
        filterValue = filterValue.toLowerCase(); // MatTableDataSource defaults to lowercase matches
        this.dataSource.filter = filterValue;
    };
    // tslint:disable-next-line:use-life-cycle-interface
    DashboardExtranetComponent.prototype.ngAfterViewInit = function () {
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
    };
    DashboardExtranetComponent.prototype.ngOnInit = function () {
    };
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["ViewChild"])(__WEBPACK_IMPORTED_MODULE_1__angular_material__["v" /* MatPaginator */]),
        __metadata("design:type", __WEBPACK_IMPORTED_MODULE_1__angular_material__["v" /* MatPaginator */])
    ], DashboardExtranetComponent.prototype, "paginator", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["ViewChild"])(__WEBPACK_IMPORTED_MODULE_1__angular_material__["H" /* MatSort */]),
        __metadata("design:type", __WEBPACK_IMPORTED_MODULE_1__angular_material__["H" /* MatSort */])
    ], DashboardExtranetComponent.prototype, "sort", void 0);
    DashboardExtranetComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-dashboard-extranet',
            template: __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dashboard-extranet/dashboard-extranet.component.html"),
            styles: [__webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dashboard-extranet/dashboard-extranet.component.css")]
        }),
        __metadata("design:paramtypes", [])
    ], DashboardExtranetComponent);
    return DashboardExtranetComponent;
}());

var ELEMENT_DATA = [
    { position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H' },
    { position: 2, name: 'Helium', weight: 4.0026, symbol: 'He' },
    { position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li' },
    { position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be' },
    { position: 5, name: 'Boron', weight: 10.811, symbol: 'B' },
    { position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C' },
    { position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N' },
    { position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O' },
    { position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F' },
    { position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne' },
    { position: 11, name: 'Sodium', weight: 22.9897, symbol: 'Na' },
    { position: 12, name: 'Magnesium', weight: 24.305, symbol: 'Mg' },
    { position: 13, name: 'Aluminum', weight: 26.9815, symbol: 'Al' },
    { position: 14, name: 'Silicon', weight: 28.0855, symbol: 'Si' },
    { position: 15, name: 'Phosphorus', weight: 30.9738, symbol: 'P' },
    { position: 16, name: 'Sulfur', weight: 32.065, symbol: 'S' },
    { position: 17, name: 'Chlorine', weight: 35.453, symbol: 'Cl' },
    { position: 18, name: 'Argon', weight: 39.948, symbol: 'Ar' },
    { position: 19, name: 'Potassium', weight: 39.0983, symbol: 'K' },
    { position: 20, name: 'Calcium', weight: 40.078, symbol: 'Ca' },
];


/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/dialogs/confirm-dialog/confirm-dialog.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/dialogs/confirm-dialog/confirm-dialog.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"modalContainer\">\n    <div class=\"modalHeading\">\n        <span class=\"float-left modalHeader\">{{ title }}</span>\n        <span class=\"closeIcon float-right\" (click)=\"dialogRef.close(false)\">\n            <i aria-hidden=\"true\" class=\"fa fa-times-thin\"></i>\n        </span>\n    </div>\n    <div class=\"modalContent\">\n        <p>{{ message }}</p>\n        <div class=\"controlButtons mt-5\">\n            <button type=\"button\" title=\"OK\" mat-raised-button class=\"genericButton activeButton mat-primary mat-raised-button\" (click)=\"dialogRef.close(true)\">OK</button>\n            <button type=\"button\" title=\"Cancel\" mat-raised-button class=\"genericButton defaultButton mat-raised-button\" (click)=\"dialogRef.close(false)\">Cancel</button>\n        </div>\n    </div>\n</div>"

/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/dialogs/confirm-dialog/confirm-dialog.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ConfirmDialogComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_material__ = __webpack_require__("../../../material/esm5/material.es5.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var ConfirmDialogComponent = (function () {
    function ConfirmDialogComponent(dialogRef) {
        this.dialogRef = dialogRef;
    }
    ConfirmDialogComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-confirm-dialog',
            template: __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dialogs/confirm-dialog/confirm-dialog.component.html"),
            styles: [__webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dialogs/confirm-dialog/confirm-dialog.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_material__["m" /* MatDialogRef */]])
    ], ConfirmDialogComponent);
    return ConfirmDialogComponent;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/dialogs/contract-template-type/contract-template-type.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "\r\n.modalContainer {\r\n  width: 800px;\r\n}\r\n\r\n.templateImage, .templateImage:hover {\r\n  height: 95px;\r\n  width: 111px;\r\n  background-image: url(" + __webpack_require__("../../../../../src/assets/templateimages/normal.jpg") + ");\r\n  display: inline-block;\r\n  transition: all 0.3s ease;\r\n}\r\n\r\n.templateImage:hover, .activeClass {\r\n  background-image: url(" + __webpack_require__("../../../../../src/assets/templateimages/hover.jpg") + ");\r\n} \r\n\r\n.templateContainer {\r\n  max-height: 275px;\r\n  overflow-y: auto;\r\n}\r\n\r\n.templateContainer .templateImage:hover, .activeClass {\r\n  box-shadow: 0px 0px 13px 0px #26a9df;\r\n}\r\n\r\np.semiBold:nth-child(2) {\r\n  margin-top: 35px;\r\n}\r\n\r\n.disabled{\r\n  opacity: 0.5;\r\n  pointer-events: none;\r\n  cursor: not-allowed;\r\n}\r\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/dialogs/contract-template-type/contract-template-type.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"modalContainer\">\n    <div class=\"modalHeading\">\n        <span class=\"float-left modalHeader\">Contract and Template Type</span>\n        <span class=\"closeIcon float-right\" (click)=\"dialogRef.close(false)\">\n            <i aria-hidden=\"true\" class=\"fa fa-times-thin\"></i>\n        </span>\n    </div>\n    <form [formGroup]=\"contractTemplateForm\" (ngSubmit)=\"openContract()\">\n        <div class=\"modalContent\">\n            <p class=\"semiBold marginBottom10px\">Contract Type</p>\n            <mat-radio-group formControlName=\"contractType\" name=\"contractType\" (change)=\"isTemplateDisabled($event)\" required>\n                <div class=\"row\">\n                    <div class=\"col-md-3\">\n                        <mat-radio-button [value]=\"3\">MG</mat-radio-button>\n                    </div>\n                    <div class=\"col-md-3\">\n                        <mat-radio-button [value]=\"nonMg\">Non MG</mat-radio-button>\n                    </div>\n                </div>\n            </mat-radio-group>\n\n            <p class=\"semiBold marginBottom10px mt-4\">Template Type</p>\n            <mat-radio-group formControlName=\"templateType\" name=\"templateType\" (change)=\"isTemplateListDisabled($event)\" required>\n                <div class=\"row\">\n                    <div class=\"col-md-3\">\n                        <mat-radio-button [value]=\"mgStatic\">Static</mat-radio-button>\n                    </div>\n                    <div class=\"col-md-3\">\n                        <mat-radio-button [value]=\"mgDynamic\">Dynamic</mat-radio-button>\n                    </div>\n                </div>\n            </mat-radio-group>\n            <div class=\"mb-3\">\n                <div class=\"row mb-2 mt-4\">\n                    <div class=\"col-md-6\">\n                        <mat-form-field>\n                            <input type=\"text\" placeholder=\"Search by template name\" matInput formControlName=\"searchTemplate\" (focus)=\"clearSelectedTemplate()\"\n                                (keyup)=\"searchByTemplate()\" (keydown.backspace)=\"checkInputCleared()\">\n                        </mat-form-field>\n                    </div>\n                </div>\n                <span>Select from below templates OR </span>\n                <span>\n                    <a href=\"/\" onclick=\"return false;\">Create New Custom Contract</a>\n                </span>\n                <div class=\"row templateContainer mr-1 mt-4\">\n                    <div class=\"col-md-12\">\n                        <div class=\"row pt-2\">\n                            <div class=\"col-md-3 mb-3\" [ngClass]=\"{'disabled': contractTemplateForm.get('templateType').value === mgDynamic || contractTemplateForm.get('contractType').value === nonMg}\"\n                                *ngFor=\"let template of (!isSearch ? templates : filteredData)\" (click)=\"selectTemplate(template.id)\">\n                                <div class=\"text-center\">\n                                    <span class=\"templateImage\" [ngClass]=\"{'activeClass': template.id === selectedTemplateId}\"></span>\n                                </div>\n                                <div class=\"text-center\">\n                                    <span>{{template.name}}</span>\n                                </div>\n                            </div>\n                        </div>\n                    </div>\n                </div>\n            </div>\n            <div class=\"controlButtons mt-5\">\n                <button type=\"submit\" title=\"OK\" mat-raised-button class=\"genericButton activeButton mat-primary mat-raised-button\" mat-raised-button\n                    [disabled]=\"contractTemplateForm.invalid || (contractTemplateForm.get('templateType').value === mgStatic && (!selectedTemplateId  || !isSelected))\">Open</button>\n                <button type=\"button\" title=\"Cancel\" mat-raised-button class=\"genericButton defaultButton mat-raised-button\" mat-raised-button\n                    (click)=\"dialogRef.close(false)\">Cancel</button>\n            </div>\n        </div>\n    </form>\n</div>\n"

/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/dialogs/contract-template-type/contract-template-type.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ContractTemplateTypeComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_material__ = __webpack_require__("../../../material/esm5/material.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_forms__ = __webpack_require__("../../../forms/esm5/forms.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__common_enums__ = __webpack_require__("../../../../../src/app/common/enums.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__services_contracts_contract_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/contracts/contract-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__common_constants__ = __webpack_require__("../../../../../src/app/common/constants.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var ContractTemplateTypeComponent = (function () {
    function ContractTemplateTypeComponent(dialogRef, contractDataService, router, activatedRoute) {
        this.dialogRef = dialogRef;
        this.contractDataService = contractDataService;
        this.router = router;
        this.activatedRoute = activatedRoute;
        this.edit = __WEBPACK_IMPORTED_MODULE_6__common_constants__["a" /* CONSTANTS */].operation.edit;
        this.create = __WEBPACK_IMPORTED_MODULE_6__common_constants__["a" /* CONSTANTS */].operation.create;
        this.nonMg = __WEBPACK_IMPORTED_MODULE_3__common_enums__["a" /* ContractType */].NonMG;
        this.mgStatic = __WEBPACK_IMPORTED_MODULE_3__common_enums__["a" /* ContractType */].MGStatic;
        this.mgDynamic = __WEBPACK_IMPORTED_MODULE_3__common_enums__["a" /* ContractType */].MGDynamic;
    }
    ContractTemplateTypeComponent.prototype.ngOnInit = function () {
        this.isSearch = false;
        this.isSelected = false;
        this.contractTemplateForm = new __WEBPACK_IMPORTED_MODULE_2__angular_forms__["FormGroup"]({
            contractType: new __WEBPACK_IMPORTED_MODULE_2__angular_forms__["FormControl"](null, __WEBPACK_IMPORTED_MODULE_2__angular_forms__["Validators"].required),
            templateType: new __WEBPACK_IMPORTED_MODULE_2__angular_forms__["FormControl"](null, __WEBPACK_IMPORTED_MODULE_2__angular_forms__["Validators"].required),
            searchTemplate: new __WEBPACK_IMPORTED_MODULE_2__angular_forms__["FormControl"](null)
        });
        this.getPublishedTemplates();
    };
    ContractTemplateTypeComponent.prototype.isTemplateDisabled = function (e) {
        if (e.value === this.nonMg) {
            this.contractTemplateForm.get('templateType').setValue(null);
            this.selectedTemplateId = 0;
            this.contractTemplateForm.get('templateType').disable();
        }
        else {
            if (this.contractTemplateForm.get('templateType').value !== this.mgDynamic) {
                this.contractTemplateForm.get('templateType').enable();
            }
        }
    };
    ContractTemplateTypeComponent.prototype.isTemplateListDisabled = function (e) {
        if (e.value === this.mgDynamic) {
            this.selectedTemplateId = 0;
        }
        else {
        }
    };
    ContractTemplateTypeComponent.prototype.searchByTemplate = function () {
        var _this = this;
        this.isSearch = true;
        this.filteredData = this.templates.filter(function (template) {
            if (template.name.toLowerCase().includes(_this.contractTemplateForm.get('searchTemplate').value)) {
                return template;
            }
        });
    };
    ContractTemplateTypeComponent.prototype.checkInputCleared = function () {
        if (this.contractTemplateForm.get('searchTemplate').value.length === 1) {
            this.isSearch = false;
            this.isSelected = false;
            this.selectedTemplateId = 0;
            this.getPublishedTemplates();
        }
    };
    ContractTemplateTypeComponent.prototype.clearSelectedTemplate = function () {
        this.isSelected = false;
        this.selectedTemplateId = 0;
    };
    ContractTemplateTypeComponent.prototype.selectTemplate = function (templateId) {
        this.isSelected = true;
        this.selectedTemplateId = templateId;
        this.contractDataService.templateId = templateId;
        this.contractTemplateForm.get('searchTemplate').setValue(null);
        console.log('selectedTemplate: ' + this.contractDataService.templateId);
    };
    ContractTemplateTypeComponent.prototype.openContract = function () {
        if (this.contractTemplateForm.get('contractType').value === this.nonMg) {
            this.contractDataService.contractType = this.nonMg;
        }
        else {
            if (this.contractTemplateForm.get('templateType').value === this.mgStatic) {
                this.contractDataService.contractType = this.mgStatic;
            }
            else {
                this.contractDataService.contractType = this.mgDynamic;
            }
        }
        this.router.navigate(['contractmgmt/contract', 0, this.create]);
        this.dialogRef.close(true);
    };
    ContractTemplateTypeComponent.prototype.getPublishedTemplates = function () {
        var _this = this;
        this.contractDataService.getPublishedTemplates().subscribe(function (templatesList) {
            if (templatesList !== null) {
                _this.templates = templatesList.result;
            }
        });
    };
    ContractTemplateTypeComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-contract-template-type',
            template: __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dialogs/contract-template-type/contract-template-type.component.html"),
            styles: [__webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dialogs/contract-template-type/contract-template-type.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_material__["m" /* MatDialogRef */],
            __WEBPACK_IMPORTED_MODULE_4__services_contracts_contract_data_service__["a" /* ContractDataService */],
            __WEBPACK_IMPORTED_MODULE_5__angular_router__["Router"],
            __WEBPACK_IMPORTED_MODULE_5__angular_router__["ActivatedRoute"]])
    ], ContractTemplateTypeComponent);
    return ContractTemplateTypeComponent;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/dialogs/copy-template/copy-template.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/dialogs/copy-template/copy-template.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"modalContainer\">\n<div class=\"modalHeading\">\n    <span class=\"float-left modalHeader\">Copy</span>\n    <span class=\"closeIcon float-right\"><i aria-hidden=\"true\" class=\"fa fa-times-thin\"></i></span>\n</div>\n<div class=\"modalContent\">\n    <form [formGroup]=\"copyTemplateForm\" (ngSubmit)=\"createTemplateCopy()\">\n        <div class=\"row\">\n            <div class=\"col-md-6\">\n                <mat-form-field>\n                    <input matInput placeholder=\"Template Name\" (change)=\"uniqueTemplateError()\" (keyup)=\"uniqueTemplateError()\" formControlName=\"newTemplateName\" name=\"newTemplateName\" required/>\n                </mat-form-field>\n            </div>\n            <div class=\"col-md-12 templateNameError\">\n              <mat-error *ngIf=\"uniqueNameError\">\n                  Template name already exists.\n              </mat-error>\n          </div>\n        </div>\n        <p>Note: The Template Name shown is a suggestion. You can edit the Template Name now, or later after the template is\n            copied.\n        </p>\n        <div class=\"controlButtons mt-5\">\n            <button type=\"submit\" mat-raised-button title=\"copy\" class=\"genericButton activeButton mat-primary mat-raised-button\" [disabled]=\"copyTemplateForm.invalid\">Copy</button>\n            <button type=\"button\" mat-raised-button title=\"cancel\" class=\"genericButton defaultButton mat-raised-button\" (click)=\"dialogRef.close(null)\">Cancel</button>\n        </div>\n    </form>\n</div>\n</div>"

/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/dialogs/copy-template/copy-template.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return CopyTemplateComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_material__ = __webpack_require__("../../../material/esm5/material.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_forms__ = __webpack_require__("../../../forms/esm5/forms.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__services_templates_templates_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/templates/templates-data.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var CopyTemplateComponent = (function () {
    function CopyTemplateComponent(dialogRef, templatesDataService) {
        this.dialogRef = dialogRef;
        this.templatesDataService = templatesDataService;
        this.copyTemplate = {};
    }
    CopyTemplateComponent.prototype.ngOnInit = function () {
        this.copyTemplateForm = new __WEBPACK_IMPORTED_MODULE_2__angular_forms__["FormGroup"]({
            newTemplateName: new __WEBPACK_IMPORTED_MODULE_2__angular_forms__["FormControl"](this.templateName + '_Copy', __WEBPACK_IMPORTED_MODULE_2__angular_forms__["Validators"].required)
        });
        var randomNumber = Math.floor(Math.random() * 2000);
        this.uniqueTemplateError();
        if (this.uniqueNameError) {
            this.uniqueNameError = false;
            this.copyTemplateForm.controls['newTemplateName'].setValue(this.templateName + '_Copy' + randomNumber);
        }
    };
    CopyTemplateComponent.prototype.createTemplateCopy = function () {
        if (!this.uniqueNameError) {
            this.copyTemplate.templateId = this.templateId;
            this.copyTemplate.templateName = this.copyTemplateForm.get('newTemplateName').value;
            this.dialogRef.close(this.copyTemplate);
        }
    };
    CopyTemplateComponent.prototype.uniqueTemplateError = function () {
        for (var i = 0; i < this.templateList.length; i++) {
            if (this.templateList[i].name.toLowerCase() === this.copyTemplateForm.get('newTemplateName').value.toLowerCase()) {
                this.uniqueNameError = true;
                break;
            }
            else {
                this.uniqueNameError = false;
            }
        }
    };
    CopyTemplateComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-copy-template',
            template: __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dialogs/copy-template/copy-template.component.html"),
            styles: [__webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dialogs/copy-template/copy-template.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_material__["m" /* MatDialogRef */],
            __WEBPACK_IMPORTED_MODULE_3__services_templates_templates_data_service__["a" /* TemplatesDataService */]])
    ], CopyTemplateComponent);
    return CopyTemplateComponent;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/dialogs/dialogs.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return DialogsModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_common__ = __webpack_require__("../../../common/esm5/common.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__confirm_dialog_confirm_dialog_component__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dialogs/confirm-dialog/confirm-dialog.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__dialogs_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dialogs/dialogs.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__angular_material__ = __webpack_require__("../../../material/esm5/material.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__edit_photo_dialog_edit_photo_dialog_component__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dialogs/edit-photo-dialog/edit-photo-dialog.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__common_material_material_module__ = __webpack_require__("../../../../../src/app/common/material/material.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__angular_forms__ = __webpack_require__("../../../forms/esm5/forms.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__copy_template_copy_template_component__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dialogs/copy-template/copy-template.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_9__market_dialog_market_dialog_component__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dialogs/market-dialog/market-dialog.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_10__contract_template_type_contract_template_type_component__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dialogs/contract-template-type/contract-template-type.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_11__common_pipes_marketcountryfilterpipe__ = __webpack_require__("../../../../../src/app/extranet/common/pipes/marketcountryfilterpipe.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};












var DialogsModule = (function () {
    function DialogsModule() {
    }
    DialogsModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            imports: [
                __WEBPACK_IMPORTED_MODULE_1__angular_common__["CommonModule"],
                __WEBPACK_IMPORTED_MODULE_4__angular_material__["l" /* MatDialogModule */],
                __WEBPACK_IMPORTED_MODULE_4__angular_material__["e" /* MatButtonModule */],
                __WEBPACK_IMPORTED_MODULE_6__common_material_material_module__["a" /* MaterialModule */],
                __WEBPACK_IMPORTED_MODULE_7__angular_forms__["FormsModule"],
                __WEBPACK_IMPORTED_MODULE_7__angular_forms__["ReactiveFormsModule"]
            ],
            declarations: [__WEBPACK_IMPORTED_MODULE_2__confirm_dialog_confirm_dialog_component__["a" /* ConfirmDialogComponent */],
                __WEBPACK_IMPORTED_MODULE_5__edit_photo_dialog_edit_photo_dialog_component__["a" /* EditPhotoDialogComponent */],
                __WEBPACK_IMPORTED_MODULE_9__market_dialog_market_dialog_component__["a" /* MarketDialogComponent */],
                __WEBPACK_IMPORTED_MODULE_10__contract_template_type_contract_template_type_component__["a" /* ContractTemplateTypeComponent */],
                __WEBPACK_IMPORTED_MODULE_8__copy_template_copy_template_component__["a" /* CopyTemplateComponent */],
                __WEBPACK_IMPORTED_MODULE_11__common_pipes_marketcountryfilterpipe__["a" /* MarketCountryFilterPipe */]],
            exports: [__WEBPACK_IMPORTED_MODULE_2__confirm_dialog_confirm_dialog_component__["a" /* ConfirmDialogComponent */],
                __WEBPACK_IMPORTED_MODULE_5__edit_photo_dialog_edit_photo_dialog_component__["a" /* EditPhotoDialogComponent */],
                __WEBPACK_IMPORTED_MODULE_9__market_dialog_market_dialog_component__["a" /* MarketDialogComponent */],
                __WEBPACK_IMPORTED_MODULE_10__contract_template_type_contract_template_type_component__["a" /* ContractTemplateTypeComponent */],
                __WEBPACK_IMPORTED_MODULE_8__copy_template_copy_template_component__["a" /* CopyTemplateComponent */]],
            entryComponents: [__WEBPACK_IMPORTED_MODULE_2__confirm_dialog_confirm_dialog_component__["a" /* ConfirmDialogComponent */],
                __WEBPACK_IMPORTED_MODULE_5__edit_photo_dialog_edit_photo_dialog_component__["a" /* EditPhotoDialogComponent */],
                __WEBPACK_IMPORTED_MODULE_9__market_dialog_market_dialog_component__["a" /* MarketDialogComponent */],
                __WEBPACK_IMPORTED_MODULE_10__contract_template_type_contract_template_type_component__["a" /* ContractTemplateTypeComponent */],
                __WEBPACK_IMPORTED_MODULE_8__copy_template_copy_template_component__["a" /* CopyTemplateComponent */]],
            providers: [__WEBPACK_IMPORTED_MODULE_3__dialogs_service__["a" /* DialogsService */]]
        })
    ], DialogsModule);
    return DialogsModule;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/dialogs/dialogs.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return DialogsService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__confirm_dialog_confirm_dialog_component__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dialogs/confirm-dialog/confirm-dialog.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_material__ = __webpack_require__("../../../material/esm5/material.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__edit_photo_dialog_edit_photo_dialog_component__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dialogs/edit-photo-dialog/edit-photo-dialog.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__market_dialog_market_dialog_component__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dialogs/market-dialog/market-dialog.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__contract_template_type_contract_template_type_component__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dialogs/contract-template-type/contract-template-type.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__copy_template_copy_template_component__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dialogs/copy-template/copy-template.component.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var DialogsService = (function () {
    function DialogsService(dialog) {
        this.dialog = dialog;
    }
    DialogsService.prototype.confirm = function (title, message) {
        var dialogRef;
        dialogRef = this.dialog.open(__WEBPACK_IMPORTED_MODULE_1__confirm_dialog_confirm_dialog_component__["a" /* ConfirmDialogComponent */]);
        dialogRef.componentInstance.title = title;
        dialogRef.componentInstance.message = message;
        return dialogRef.afterClosed();
    };
    DialogsService.prototype.openModal = function () {
        var dialogRef;
        dialogRef = this.dialog.open(__WEBPACK_IMPORTED_MODULE_3__edit_photo_dialog_edit_photo_dialog_component__["a" /* EditPhotoDialogComponent */]);
        return dialogRef.afterClosed();
    };
    DialogsService.prototype.market = function (title, country, continent) {
        var dialogRef;
        dialogRef = this.dialog.open(__WEBPACK_IMPORTED_MODULE_4__market_dialog_market_dialog_component__["a" /* MarketDialogComponent */]);
        dialogRef.componentInstance.title = title;
        dialogRef.componentInstance.countries = country;
        dialogRef.componentInstance.continents = continent;
        return dialogRef.afterClosed();
    };
    DialogsService.prototype.openContractTemplateModal = function () {
        var dialogRef;
        dialogRef = this.dialog.open(__WEBPACK_IMPORTED_MODULE_5__contract_template_type_contract_template_type_component__["a" /* ContractTemplateTypeComponent */]);
        return dialogRef.afterClosed();
    };
    DialogsService.prototype.openCopyModal = function (templateId, templateName, templatesList) {
        var dialogRef;
        dialogRef = this.dialog.open(__WEBPACK_IMPORTED_MODULE_6__copy_template_copy_template_component__["a" /* CopyTemplateComponent */]);
        dialogRef.componentInstance.templateName = templateName;
        dialogRef.componentInstance.templateId = templateId;
        dialogRef.componentInstance.templateList = templatesList;
        return dialogRef.afterClosed();
    };
    DialogsService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_2__angular_material__["k" /* MatDialog */]])
    ], DialogsService);
    return DialogsService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/dialogs/edit-photo-dialog/edit-photo-dialog.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ".img-placeholder {\r\n    padding-top: 24%;\r\n    display: block;\r\n    margin-left: auto;\r\n    margin-right: auto;\r\n}\r\n\r\n.placeholderSection {\r\n    width: 100%;\r\n    height: 254px;\r\n    margin-bottom: 20px;\r\n    border: 1px solid #e3e3e3;\r\n    background: #ededed;\r\n}\r\n\r\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/dialogs/edit-photo-dialog/edit-photo-dialog.component.html":
/***/ (function(module, exports) {

module.exports = "<!-- Edit Modal -->\n<div class=\"genericPopover\">\n    <div class=\"row\">\n        <div class=\"col-md-10 popoverHeader\">\n            <h5 class=\"h5 popoverTitle\">Add/Edit Photos</h5>\n        </div>\n        <div class=\"col-md-2 popoverHeader\">\n            <button mat-button [mat-dialog-close]=\"true\" class=\"ml-4 pl-4 close\" title=\"Close\" (click)=\"dialogRef.close(false)\">×</button>\n        </div>\n    </div>\n    \n    <div class=\"row\">\n        <div class=\"col-md-12\">\n         <div class=\"row\">\n            <div class=\"col-md-12\">\n            <h6 class=\"semiboldText pt-4 pb-2\">Select photo to upload</h6>\n            </div>\n        </div>\n        <div class=\"row\">\n            <div class=\"col-md-9\">\n                <label class=\"custom-file\">\n                    <input type=\"file\" id=\"uploadFile\" name=\"image\" class=\"img\">\n                    <span class=\"custom-file-control\"></span>\n                </label>\n            </div>\n            <div class=\"col-md-3 controlButtons pl-0 pr-0\">\n                 <button type=\"button\" title=\"Upload\" class=\"ml-5 pt-2 pb-2 genericButton activeButton\" mat-raised-button>Upload</button>\n            </div>\n    </div>\n    <div class=\"row\">\n        <div class=\"col-md-12\">\n        <span class=\"infoNote d-block pt-2 pb-4 mb-2\">Minimum Size:600px/800px</span>\n        </div>\n    </div>\n    </div>\n    </div>\n     \n      <div class=\"row\">\n            <div class=\"col-md-6\">\n            \n                <mat-checkbox class=\"popoverCheckbox\">Set as the main photo</mat-checkbox>\n                <h6 class=\"pt-3 pb-3 font-weight-bold\">Select if this is a room photo</h6>\n\n                <mat-checkbox class=\"popoverCheckbox\">Haven - Double or Twin room</mat-checkbox>\n\n\n                <mat-checkbox class=\"popoverCheckbox\">Haven - Double with Balcony</mat-checkbox>\n\n\n                <mat-checkbox class=\"popoverCheckbox\">Haven - Double Garden facing</mat-checkbox>\n\n\n                <mat-checkbox class=\"popoverCheckbox\">Haven - Double Sunroof</mat-checkbox>\n\t\t\t\t<mat-checkbox class=\"popoverCheckbox\">Haven - Double Beach Front</mat-checkbox>\n                </div>\n        \n                <div class=\"col-md-6\">\n                    <div class=\"row\">\n                        <div class=\"col-md-12\">\n                            <div class=\"placeholderSection\">\n                            <img src=\"assets/photosAndVideos/img-placeholder.jpg\" class=\"img-placeholder\"/>\n                            <span class=\"d-block text-center mt-2 optionsList\">Photo will be shown here</span>\n                            </div>\n                        </div>\n                    </div>\n                    <div class=\"row\">\n                            <div class=\"col-md-12 controlButtons mt-3\">\n                                <button mat-raised-button title=\"Save and upload another Photo\" class=\"float-left genericButton genericSmallButton defaultButton\">Save and upload another Photo/Video</button>\n                            </div>\n                    </div>\n                </div>\t\n                </div> \n    <div class=\"row\">\n        <div class=\"col-md-12\">\n            <mat-dialog-actions>\n                <div class=\"controlButtons pb-3\">\n                    <button title=\"Save\" type=\"submit\" class=\"genericButton activeButton\" mat-raised-button \n                    (click)=\"dialogRef.close(true)\">Save</button>\n                    <button type=\"button\" mat-button type=\"reset\" title=\"Cancel\" class=\"genericButton defaultButton\" \n                    (click)=\"dialogRef.close(false)\">Cancel</button>\n                </div>\n            </mat-dialog-actions>\n        </div>\n    </div>\n</div>\n"

/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/dialogs/edit-photo-dialog/edit-photo-dialog.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return EditPhotoDialogComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_material__ = __webpack_require__("../../../material/esm5/material.es5.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var EditPhotoDialogComponent = (function () {
    function EditPhotoDialogComponent(dialogRef) {
        this.dialogRef = dialogRef;
    }
    EditPhotoDialogComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-edit-photo-dialog',
            template: __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dialogs/edit-photo-dialog/edit-photo-dialog.component.html"),
            styles: [__webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dialogs/edit-photo-dialog/edit-photo-dialog.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_material__["m" /* MatDialogRef */]])
    ], EditPhotoDialogComponent);
    return EditPhotoDialogComponent;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/dialogs/market-dialog/market-dialog.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ".container {\r\n    max-height: 775px;\r\n}\r\n\r\n.col-md-5 .d-block {\r\n    margin-bottom: 0.5rem;\r\n}\r\n\r\n.col-md-2 button {\r\n    height: 35px;\r\n    width: 35px;\r\n    font-size: 24px;\r\n    color: #fff;\r\n    background-color: #2aaae1;\r\n    border-width: 0px;\r\n}\r\n\r\n.countryList {\r\n    max-height: 350px;\r\n    overflow-y: auto;\r\n}\r\n\r\n.continentList {\r\n    max-height: 70px;\r\n    overflow-y: auto;\r\n}\r\n\r\n.col-md-5 {\r\n    max-height: 640px;\r\n}\r\n\r\n.mat-card {\r\n    height: 560px;\r\n}\r\n\r\n.arrowsButtons {\r\n    position: relative;\r\n    top: 40%;\r\n    left: 40%;\r\n}\r\n\r\n.selectedCountry {\r\n    background-color: #26a9df;\r\n    color: #fff;\r\n}\r\n\r\n.unselectedCountry {\r\n    background-color: transparent;\r\n    color: #000;\r\n}\r\n\r\n.continentList button {\r\n    padding: 6px 10px;\r\n    min-width: auto;\r\n    line-height: 20px;\r\n}\r\n\r\n.continentList button .mat-button-wrapper {\r\n    font-size: 14px;\r\n    font-family: 'montserratregular';\r\n    color: #666;\r\n    margin-bottom: 5px;\r\n}\r\n\r\n.countryList .mat-list-text {\r\n    font-size: 15px;\r\n    font-family: 'montserratregular';\r\n    color: #666;\r\n}\r\n\r\n.continentListContainer {\r\n    border-bottom: 1px solid #d5d5d5;\r\n}\r\n\r\n.arrowsButtons button:first-child, .arrowsButtons button:last-child {\r\n    background-color: #8b9095;\r\n}\r\n\r\n.mat-selection-list  mat-list-option[aria-selected=\"true\"]{\r\n    background: #2aaae1;\r\n    color: #fff;\r\n  }\r\n  .continentList .cdk-focused{\r\n    background: #2aaae1;\r\n    color: #fff;\r\n  }", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/dialogs/market-dialog/market-dialog.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"modalContainer\">\n  <div class=\"modalHeading\">\n    <span class=\"float-left modalHeader\">{{ title }}</span>\n    <span class=\"closeIcon float-right\" (click)=\"dialogRef.close(false)\">\n      <i aria-hidden=\"true\" class=\"fa fa-times-thin\"></i>\n    </span>\n  </div>\n  <div class=\"modalContent\">\n    <div class=\"container p-0\">\n      <form [formGroup]=\"marketForm\" (ngSubmit)=\"saveMarket()\" >\n      <div class=\"row\">\n        <div class=\"col-md-12\">\n          <div class=\"row\">\n            <div class=\"col-md-5  mb-2\">\n              <span class=\"d-block\">Applicable Countries</span>\n              <mat-card class=\"mb-3 noOutlineOnFocus p-0\">\n                <div class=\"pr-3 pt-2 pl-3 pb-2 continentListContainer\">\n                  <div class=\"continentList\">\n                    <button type=\"button\" mat-button (click)=\"this.isIncludedSelected = false\"> All </button>\n                    <button type=\"button\" mat-button *ngFor=\"let continent of continents\" (click)=\"getContinentOfIncludedCountries(continent.name)\"> {{continent.name}} </button>\n                  </div>\n                </div>\n                <div class=\"pr-2 pt-3 pl-2 pb-3\">\n                  <div class=\"pl-3 pr-3\">\n                    <mat-form-field class=\"example-full-width\">\n                      <input matInput placeholder=\"Search by Country\" [(ngModel)]=\"searchbox\" [ngModelOptions]=\"{standalone: true}\">\n                    </mat-form-field>\n                  </div>\n                  <div class=\"countryList mt-4\">\n                    <mat-selection-list #includedCountries *ngFor=\"let country of (isIncludedSelected ? showIncludedCountries : includedCountries)| searchCountry: searchbox;index as i\"\n                      class=\"p-0\">\n                      <mat-list-option (click)=\"selectIncludedCountries(country)\" [value]=\"country.countryName\">{{country.countryName}}</mat-list-option>\n                    </mat-selection-list>\n                  </div>\n                </div>\n              </mat-card>\n            </div>\n            <div class=\"col-md-2 float-left\">\n              <div class=\"arrowsButtons\">\n                <button type=\"button\" class=\"d-block\" (click)=\"excludeAllCountries()\">\n                  <i class=\"fa fa-angle-double-right\"></i>\n                </button>\n                <button type=\"button\" class=\"d-block mt-4\" (click)=\"addexcludedCountries()\">\n                  <i class=\"fa fa-angle-right\"></i>\n                </button>\n                <button type=\"button\" class=\"d-block mb-4 mt-1\" (click)=\"addincludedCountries()\">\n                  <i class=\"fa fa-angle-left\"></i>\n                </button>\n                <button type=\"button\" class=\"d-block\" (click)=\"includeAllCountries()\">\n                  <i class=\"fa fa-angle-double-left\"></i>\n                </button>\n              </div>\n            </div>\n            <div class=\"col-md-5  mb-2\">\n              <span class=\"d-block\">Excluded Countries</span>\n              <mat-card class=\"mb-3 noOutlineOnFocus p-0\">\n                <div class=\"pr-3 pt-2 pl-3 pb-2 continentListContainer\">\n                  <div class=\"continentList\">\n                    <button type=\"button\" mat-button (click)=\"this.isExcludedSelected = false\"> All </button>\n                    <button type=\"button\" mat-button *ngFor=\"let continent of continents\" (click)=\"getContinentOfExcludedCountries(continent.name)\"> {{continent.name}} </button>\n                  </div>\n                </div>\n                <div class=\"pr-2 pt-3 pl-2 pb-3\">\n                  <div class=\"pl-3 pr-3\">\n                    <mat-form-field class=\"example-full-width\">\n                      <input matInput placeholder=\"Search by Country\" [(ngModel)]=\"searchbox2\" [ngModelOptions]=\"{standalone: true}\">\n                    </mat-form-field>\n                  </div>\n                  <div class=\"countryList mt-4\">\n                    <mat-selection-list #excludedCountries *ngFor=\"let country of (isExcludedSelected ? showExcludedCountries : excludedCountries) | searchCountry: searchbox2;index as i\">\n                      <mat-list-option (click)=\"selectExcludedCountries(country)\" [value]=\"country.countryName\">{{country.countryName}}</mat-list-option>\n                    </mat-selection-list>\n                  </div>\n                </div>\n              </mat-card>\n            </div>\n          </div>\n        </div>\n      </div>\n      <mat-form-field class=\"example-full-width\">\n        <input matInput placeholder=\"Enter Market Name\" formControlName=\"marketName\" required>\n      </mat-form-field>\n      <div>{{isBlankError}}</div> <div>{{ isMarketNameExistError }}</div>\n      <div class=\"controlButtons mt-5\">\n        <button type=\"submit\" title=\"Save Market\" mat-raised-button class=\"genericButton activeButton mat-primary mat-raised-button\" [disabled]=\"(!marketForm.valid)\">Save Market</button>\n        <button type=\"button\" title=\"Cancel\" mat-raised-button class=\"genericButton defaultButton mat-raised-button\" mat-raised-button (click)=\"dialogRef.close(false)\">Cancel</button>\n      </div>\n      </form>\n    </div>\n  </div>\n</div>"

/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/dialogs/market-dialog/market-dialog.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return MarketDialogComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_material__ = __webpack_require__("../../../material/esm5/material.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_forms__ = __webpack_require__("../../../forms/esm5/forms.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__common_extranet_shared_services_market_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/market-data.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





var MarketDialogComponent = (function () {
    function MarketDialogComponent(dialogRef, marketDataService, snackBar) {
        this.dialogRef = dialogRef;
        this.marketDataService = marketDataService;
        this.snackBar = snackBar;
        this.showIncludedCountries = [];
        this.showExcludedCountries = [];
        this.selectedOptions = [];
        this.selectedOptions2 = [];
        this.continents = [];
        this.excludedCountries = [];
        this.includedCountries = [];
        this.countries = [];
        this.marketDetails = {};
    }
    MarketDialogComponent.prototype.ngOnInit = function () {
        this.includedCountries = this.countries;
        this.isIncludedSelected = false;
        this.isExcludedSelected = false;
        this.getMarkets();
        this.marketForm = new __WEBPACK_IMPORTED_MODULE_2__angular_forms__["FormGroup"]({
            marketId: new __WEBPACK_IMPORTED_MODULE_2__angular_forms__["FormControl"](0),
            marketName: new __WEBPACK_IMPORTED_MODULE_2__angular_forms__["FormControl"]('', __WEBPACK_IMPORTED_MODULE_2__angular_forms__["Validators"].required)
        });
    };
    MarketDialogComponent.prototype.getMarkets = function () {
        var _this = this;
        this.marketDataService.getMarkets().subscribe(function (marketList) {
            _this.marketList = marketList;
        });
    };
    MarketDialogComponent.prototype.getContinentOfIncludedCountries = function (continent) {
        var _this = this;
        this.showIncludedCountries = [];
        this.isIncludedSelected = true;
        this.includedCountries.forEach(function (item) {
            if (item.continentName === continent) {
                _this.showIncludedCountries.push(item);
            }
        });
        if ((this.includedCountries.length > 0) && (this.excludedCountries.length > 0)) {
            this.isBlankflag = true;
        }
        else {
            this.isBlankflag = false;
        }
    };
    MarketDialogComponent.prototype.getContinentOfExcludedCountries = function (continent) {
        var _this = this;
        this.showExcludedCountries = [];
        this.isExcludedSelected = true;
        if (this.excludedCountries != null) {
            this.excludedCountries.forEach(function (item) {
                if (item.continentName === continent) {
                    _this.showExcludedCountries.push(item);
                }
            });
        }
        if ((this.includedCountries.length > 0) && (this.excludedCountries.length > 0)) {
            this.isBlankflag = true;
        }
        else {
            this.isBlankflag = false;
        }
    };
    MarketDialogComponent.prototype.addexcludedCountries = function () {
        var _this = this;
        this.selectedOptions.forEach(function (country) {
            _this.includedCountries.splice(_this.includedCountries.indexOf(country), 1);
            _this.excludedCountries.push(country);
        });
        this.isIncludedSelected = false;
        if (this.showExcludedCountries != null) {
            this.isExcludedSelected = false;
        }
        this.searchbox = null;
        this.searchbox2 = null;
        this.selectedOptions = [];
        if ((this.includedCountries.length > 0) && (this.excludedCountries.length > 0)) {
            this.isBlankflag = true;
        }
        else {
            this.isBlankflag = false;
        }
    };
    MarketDialogComponent.prototype.addincludedCountries = function () {
        var _this = this;
        this.selectedOptions2.forEach(function (country) {
            _this.excludedCountries.splice(_this.excludedCountries.indexOf(country), 1);
            _this.includedCountries.push(country);
        });
        this.isExcludedSelected = false;
        if (this.showIncludedCountries != null) {
            this.isIncludedSelected = false;
        }
        this.searchbox = null;
        this.searchbox2 = null;
        this.selectedOptions2 = [];
        if ((this.includedCountries.length > 0) && (this.excludedCountries.length > 0)) {
            this.isBlankflag = true;
        }
        else {
            this.isBlankflag = false;
        }
    };
    MarketDialogComponent.prototype.excludeAllCountries = function () {
        var _this = this;
        this.selectedOptions = [];
        if (this.isIncludedSelected === false) {
            if (this.excludedCountries.length === 0 && this.includedCountries.length !== 0) {
                this.excludedCountries = this.includedCountries;
                this.includedCountries = [];
                this.isExcludedSelected = false;
            }
            if (this.excludedCountries.length !== 0 && this.includedCountries.length !== 0) {
                for (var _i = 0, _a = this.includedCountries; _i < _a.length; _i++) {
                    var country = _a[_i];
                    this.excludedCountries.push(country);
                }
                this.includedCountries = [];
                this.isExcludedSelected = false;
            }
        }
        if (this.showExcludedCountries != null) {
            this.isExcludedSelected = false;
        }
        if (this.isIncludedSelected === true && this.excludedCountries.length === 0) {
            this.excludedCountries = this.showIncludedCountries;
            this.showIncludedCountries.forEach(function (country) {
                _this.includedCountries.splice(_this.includedCountries.indexOf(country), 1);
            });
            this.isExcludedSelected = false;
            this.isIncludedSelected = false;
            this.showIncludedCountries = [];
        }
        if (this.isIncludedSelected === true && this.excludedCountries.length !== 0) {
            for (var _b = 0, _c = this.showIncludedCountries; _b < _c.length; _b++) {
                var country = _c[_b];
                this.excludedCountries.push(country);
            }
            this.showIncludedCountries.forEach(function (country) {
                _this.includedCountries.splice(_this.includedCountries.indexOf(country), 1);
            });
            this.isExcludedSelected = false;
            this.isIncludedSelected = false;
            this.showIncludedCountries = [];
        }
        if ((this.includedCountries.length > 0) && (this.excludedCountries.length > 0)) {
            this.isBlankflag = true;
        }
        else {
            this.isBlankflag = false;
        }
    };
    MarketDialogComponent.prototype.includeAllCountries = function () {
        var _this = this;
        this.selectedOptions2 = [];
        if (this.isExcludedSelected === false) {
            if (this.includedCountries.length !== 0 && this.excludedCountries.length !== 0) {
                for (var _i = 0, _a = this.excludedCountries; _i < _a.length; _i++) {
                    var country = _a[_i];
                    this.includedCountries.push(country);
                }
                this.excludedCountries = [];
                this.isIncludedSelected = false;
            }
            if (this.includedCountries.length === 0 && this.excludedCountries.length !== 0) {
                this.includedCountries = this.excludedCountries;
                this.showIncludedCountries = this.excludedCountries;
                this.excludedCountries = [];
                this.isIncludedSelected = false;
            }
        }
        if (this.isExcludedSelected && this.includedCountries.length === 0) {
            this.includedCountries = this.showExcludedCountries;
            this.showExcludedCountries.forEach(function (country) {
                _this.excludedCountries.splice(_this.excludedCountries.indexOf(country), 1);
            });
            this.isExcludedSelected = false;
            this.isIncludedSelected = false;
            this.showExcludedCountries = [];
        }
        if (this.isExcludedSelected && this.includedCountries.length !== 0) {
            for (var _b = 0, _c = this.showExcludedCountries; _b < _c.length; _b++) {
                var country = _c[_b];
                this.includedCountries.push(country);
            }
            this.showExcludedCountries.forEach(function (country) {
                _this.excludedCountries.splice(_this.excludedCountries.indexOf(country), 1);
            });
            this.isExcludedSelected = false;
            this.isIncludedSelected = false;
            this.showExcludedCountries = [];
        }
        if (this.showIncludedCountries != null) {
            this.isIncludedSelected = false;
        }
        if ((this.includedCountries.length > 0) && (this.excludedCountries.length > 0)) {
            this.isBlankflag = true;
        }
        else {
            this.isBlankflag = false;
        }
    };
    MarketDialogComponent.prototype.selectIncludedCountries = function (country) {
        var _this = this;
        var isBoolean;
        var isRemoveCountry = false;
        if (this.selectedOptions.length === 0) {
            this.selectedOptions.push(country);
        }
        else {
            this.selectedOptions.forEach(function (data) {
                if (country.countryId !== data.countryId) {
                    isBoolean = true;
                }
                else {
                    isBoolean = false;
                    isRemoveCountry = true;
                    _this.selectedOptions.splice(_this.selectedOptions.indexOf(country), 1);
                }
            });
        }
        if (isBoolean === true && isRemoveCountry === false) {
            this.selectedOptions.push(country);
        }
    };
    MarketDialogComponent.prototype.selectExcludedCountries = function (country) {
        var _this = this;
        var isBoolean;
        var isRemoveCountry = false;
        if (this.selectedOptions2.length === 0) {
            this.selectedOptions2.push(country);
        }
        else {
            isBoolean = false;
            this.selectedOptions2.forEach(function (data) {
                if (country.countryId !== data.countryId) {
                    isBoolean = true;
                }
                else {
                    isBoolean = false;
                    isRemoveCountry = true;
                    _this.selectedOptions2.splice(_this.selectedOptions2.indexOf(country), 1);
                }
            });
        }
        if (isBoolean === true && isRemoveCountry === false) {
            this.selectedOptions2.push(country);
        }
    };
    MarketDialogComponent.prototype.saveMarket = function () {
        var _this = this;
        this.newMarketName = this.marketForm.controls.marketName.value;
        this.isMarketNameExist = false;
        this.marketList.forEach(function (data) {
            if (_this.newMarketName === data.marketName) {
                _this.isMarketNameExist = true;
            }
        });
        if (this.isBlankflag) {
            if (!this.isMarketNameExist) {
                var markettypes = Object.assign({}, this.marketDetails, this.marketForm.value);
                markettypes.IncludedMarketList = this.includedCountries;
                markettypes.ExcludedMarketList = this.excludedCountries;
                this.marketDataService.addMarket(markettypes)
                    .subscribe(function (data) {
                    _this.dialogRef.close(true);
                    _this.snackBar.open('Market Created Successfully', 'close', { duration: 5000 });
                });
            }
            else {
                this.isMarketNameExistError = 'Market name already exist.';
            }
        }
        else {
            this.isBlankError = 'Country list can not be empty.';
        }
    };
    MarketDialogComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-market-dialog',
            template: __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dialogs/market-dialog/market-dialog.component.html"),
            styles: [__webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dialogs/market-dialog/market-dialog.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_material__["m" /* MatDialogRef */], __WEBPACK_IMPORTED_MODULE_3__common_extranet_shared_services_market_data_service__["a" /* MarketDataService */],
            __WEBPACK_IMPORTED_MODULE_1__angular_material__["F" /* MatSnackBar */]])
    ], MarketDialogComponent);
    return MarketDialogComponent;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/extranet-shared.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ExtranetSharedModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_common__ = __webpack_require__("../../../common/esm5/common.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__dashboard_extranet_dashboard_extranet_component__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dashboard-extranet/dashboard-extranet.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__services_extranet_lookup__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/extranet-lookup.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__services_hotel_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/hotel-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__angular_forms__ = __webpack_require__("../../../forms/esm5/forms.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__common_material_material_module__ = __webpack_require__("../../../../../src/app/common/material/material.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__services_facilities_services_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/facilities-services.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_9__services_facilities_services_resolver_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/facilities-services-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_10__services_roomtype_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/roomtype-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_11__services_message_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/message-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_12__services_ratecategory_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/ratecategory-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_13__services_ratecategory_data_resolver_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/ratecategory-data-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_14__services_currency_resolver_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/currency-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_15__services_mealtypes_resolver_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/mealtypes-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_16__services_cuisinetypes_resolver_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/cuisinetypes-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_17__services_associate_mealplan_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/associate-mealplan-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_18__services_templates_templates_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/templates/templates-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_19__services_templates_template_hotel_fields_resolver_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/templates/template-hotel-fields-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_20__services_policies_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/policies-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_21__services_policies_data_resolver_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/policies-data-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_22__services_templates_template_facilities_resolver_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/templates/template-facilities-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_23__services_templates_template_facilities_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/templates/template-facilities-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_24__dialogs_dialogs_module__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/dialogs/dialogs.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_25__services_hotelcurrency_resolver_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/hotelcurrency-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_26__services_templates_contract_terms_resolver_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/templates/contract-terms-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_27__services_templates_contract_terms_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/templates/contract-terms-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_28__services_templates_template_amenities_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/templates/template-amenities-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_29__services_templates_template_amenities_resolver_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/templates/template-amenities-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_30__services_amenities_resolver_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/amenities-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_31__services_amenities_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/amenities-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_32__services_templates_template_room_type_fields_resolver_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/templates/template-room-type-fields-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_33__services_templates_template_room_type_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/templates/template-room-type-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_34__services_market_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/market-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_35__services_templates_templates_data_resolver_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/templates/templates-data-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_36__common_extranet_shared_services_contracts_contract_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/contracts/contract-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_37__services_contracts_contract_hotel_details_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/contracts/contract-hotel-details-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_38__services_contracts_hotels_name_resolver_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/contracts/hotels-name-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_39__services_contracts_template_hotel_details_resolver_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/contracts/template-hotel-details-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_40__services_contracts_contract_data_resolver_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/contracts/contract-data-resolver.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_41__services_hotelroom_resolver_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/hotelroom-resolver.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};










































var ExtranetSharedModule = (function () {
    function ExtranetSharedModule() {
    }
    ExtranetSharedModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            imports: [
                __WEBPACK_IMPORTED_MODULE_1__angular_common__["CommonModule"],
                __WEBPACK_IMPORTED_MODULE_5__angular_forms__["FormsModule"],
                __WEBPACK_IMPORTED_MODULE_6__common_material_material_module__["a" /* MaterialModule */],
                __WEBPACK_IMPORTED_MODULE_7__angular_router__["RouterModule"],
                __WEBPACK_IMPORTED_MODULE_24__dialogs_dialogs_module__["a" /* DialogsModule */] // SharedModule
            ],
            declarations: [__WEBPACK_IMPORTED_MODULE_2__dashboard_extranet_dashboard_extranet_component__["a" /* DashboardExtranetComponent */]],
            providers: [__WEBPACK_IMPORTED_MODULE_3__services_extranet_lookup__["a" /* ExtranetLookupService */], __WEBPACK_IMPORTED_MODULE_4__services_hotel_data_service__["a" /* HotelDataService */], __WEBPACK_IMPORTED_MODULE_8__services_facilities_services_service__["a" /* FacilitiesServicesService */], __WEBPACK_IMPORTED_MODULE_9__services_facilities_services_resolver_service__["a" /* FacilitiesServicesResolverService */],
                __WEBPACK_IMPORTED_MODULE_10__services_roomtype_data_service__["a" /* RoomtypeDataService */], __WEBPACK_IMPORTED_MODULE_11__services_message_data_service__["a" /* MessageDataService */], __WEBPACK_IMPORTED_MODULE_12__services_ratecategory_data_service__["a" /* RatecategoryDataService */], __WEBPACK_IMPORTED_MODULE_18__services_templates_templates_data_service__["a" /* TemplatesDataService */], __WEBPACK_IMPORTED_MODULE_20__services_policies_data_service__["a" /* PoliciesDataService */],
                __WEBPACK_IMPORTED_MODULE_14__services_currency_resolver_service__["a" /* CurrencyResolverService */], __WEBPACK_IMPORTED_MODULE_15__services_mealtypes_resolver_service__["a" /* MealtypesResolverService */], __WEBPACK_IMPORTED_MODULE_16__services_cuisinetypes_resolver_service__["a" /* CuisinetypesResolverService */], __WEBPACK_IMPORTED_MODULE_25__services_hotelcurrency_resolver_service__["a" /* HotelcurrencyResolverService */],
                __WEBPACK_IMPORTED_MODULE_17__services_associate_mealplan_data_service__["a" /* AssociateMealplanDataService */], __WEBPACK_IMPORTED_MODULE_19__services_templates_template_hotel_fields_resolver_service__["a" /* TemplateHotelFieldsResolverService */], __WEBPACK_IMPORTED_MODULE_22__services_templates_template_facilities_resolver_service__["a" /* TemplateFacilitiesResolverService */],
                __WEBPACK_IMPORTED_MODULE_23__services_templates_template_facilities_data_service__["a" /* TemplateFacilitiesDataService */], __WEBPACK_IMPORTED_MODULE_21__services_policies_data_resolver_service__["a" /* PoliciesDataResolverService */],
                __WEBPACK_IMPORTED_MODULE_27__services_templates_contract_terms_data_service__["a" /* ContractTermsDataService */], __WEBPACK_IMPORTED_MODULE_26__services_templates_contract_terms_resolver_service__["a" /* ContractTermsResolverService */], __WEBPACK_IMPORTED_MODULE_28__services_templates_template_amenities_data_service__["a" /* TemplateAmenitiesDataService */], __WEBPACK_IMPORTED_MODULE_29__services_templates_template_amenities_resolver_service__["a" /* TemplateAmenitiesResolverService */],
                __WEBPACK_IMPORTED_MODULE_30__services_amenities_resolver_service__["a" /* AmenitiesResolverService */], __WEBPACK_IMPORTED_MODULE_31__services_amenities_data_service__["a" /* AmenitiesDataService */], __WEBPACK_IMPORTED_MODULE_32__services_templates_template_room_type_fields_resolver_service__["a" /* TemplateRoomTypeFieldsResolverService */], __WEBPACK_IMPORTED_MODULE_33__services_templates_template_room_type_data_service__["a" /* TemplateRoomTypeDataService */],
                __WEBPACK_IMPORTED_MODULE_13__services_ratecategory_data_resolver_service__["a" /* RatecategoryDataResolverService */], __WEBPACK_IMPORTED_MODULE_34__services_market_data_service__["a" /* MarketDataService */], __WEBPACK_IMPORTED_MODULE_35__services_templates_templates_data_resolver_service__["a" /* TemplatesDataResolverService */], __WEBPACK_IMPORTED_MODULE_36__common_extranet_shared_services_contracts_contract_data_service__["a" /* ContractDataService */],
                __WEBPACK_IMPORTED_MODULE_37__services_contracts_contract_hotel_details_data_service__["a" /* ContractHotelDetailsDataService */], __WEBPACK_IMPORTED_MODULE_38__services_contracts_hotels_name_resolver_service__["a" /* HotelsNameResolverService */], __WEBPACK_IMPORTED_MODULE_39__services_contracts_template_hotel_details_resolver_service__["a" /* TemplateHotelDetailsResolverService */],
                __WEBPACK_IMPORTED_MODULE_40__services_contracts_contract_data_resolver_service__["a" /* ContractDataResolverService */], __WEBPACK_IMPORTED_MODULE_41__services_hotelroom_resolver_service__["a" /* HotelRoomResolverService */]]
        })
    ], ExtranetSharedModule);
    return ExtranetSharedModule;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/amenities-data.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AmenitiesDataService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__ = __webpack_require__("../../../../../src/app/common/shared/services/authenticated-http.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_rxjs_Observable__ = __webpack_require__("../../../../rxjs/_esm5/Observable.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__common_shared_services_portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__hotel_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/hotel-data.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





var AmenitiesDataService = (function () {
    function AmenitiesDataService(authenticatedHttpService, portalService, hotelDataService) {
        this.authenticatedHttpService = authenticatedHttpService;
        this.portalService = portalService;
        this.hotelDataService = hotelDataService;
    }
    AmenitiesDataService.prototype.getAmenities = function (hotelId) {
        var _this = this;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/Amenities/GetRoomFacilityGroups/', hotelId).map(function (data) {
            _this.amenitiesGroupDto = data.result;
            return _this.amenitiesGroupDto;
        });
    };
    AmenitiesDataService.prototype.addAmenities = function (amenitiesGroup) {
        var amenities = {
            hotelId: this.hotelDataService.hotelId,
            facilityGroupList: amenitiesGroup
        };
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/Amenities/CreateRoomFacilityRelation/', amenities)
            .do(function (data) { return console.log('All:'); })
            .catch(this.handleError);
    };
    AmenitiesDataService.prototype.isAmenitiesExits = function () {
        var id = this.hotelDataService.hotelId;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/Amenities/IsAmenitiesExits/', id);
    };
    AmenitiesDataService.prototype.getRoomsByHotelId = function (hotelId) {
        var _this = this;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/room/GetRoomsByHotelId', hotelId).map(function (data) {
            if (data === null) {
                _this.roomTypeListDto = [];
            }
            else {
                _this.roomTypeListDto = data.result;
            }
            return _this.roomTypeListDto;
        });
    };
    AmenitiesDataService.prototype.handleError = function (err) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        var errorMessage = '';
        if (err.error instanceof Error) {
            // A client-side or network error occurred. Handle it accordingly.
            errorMessage = "An error occurred: " + err.error.message;
        }
        else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            errorMessage = "Server returned code: " + err.status + ", error message is: " + err.message;
        }
        return __WEBPACK_IMPORTED_MODULE_2_rxjs_Observable__["a" /* Observable */].throw(errorMessage);
    };
    AmenitiesDataService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__["a" /* AuthenticatedHttpService */],
            __WEBPACK_IMPORTED_MODULE_3__common_shared_services_portal_service__["a" /* PortalService */],
            __WEBPACK_IMPORTED_MODULE_4__hotel_data_service__["a" /* HotelDataService */]])
    ], AmenitiesDataService);
    return AmenitiesDataService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/amenities-resolver.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AmenitiesResolverService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__amenities_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/amenities-data.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var AmenitiesResolverService = (function () {
    function AmenitiesResolverService(amenitiesService) {
        this.amenitiesService = amenitiesService;
    }
    AmenitiesResolverService.prototype.resolve = function (route, state) {
        var hotelId = route.parent.params['id'];
        return this.amenitiesService.getAmenities(hotelId);
    };
    AmenitiesResolverService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__amenities_data_service__["a" /* AmenitiesDataService */]])
    ], AmenitiesResolverService);
    return AmenitiesResolverService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/associate-mealplan-data.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AssociateMealplanDataService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__common_shared_services_portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__common_shared_services_authenticated_http_service__ = __webpack_require__("../../../../../src/app/common/shared/services/authenticated-http.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_Observable__ = __webpack_require__("../../../../rxjs/_esm5/Observable.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__hotel_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/hotel-data.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





var AssociateMealplanDataService = (function () {
    function AssociateMealplanDataService(authenticatedHttpService, portalService, hotelDataService) {
        this.authenticatedHttpService = authenticatedHttpService;
        this.portalService = portalService;
        this.hotelDataService = hotelDataService;
    }
    AssociateMealplanDataService.prototype.isMealPlanExits = function () {
        var id = this.hotelDataService.hotelId;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/MealPlan/GetIsMealPlanExist/', id);
    };
    AssociateMealplanDataService.prototype.addMealPlan = function (associatedMealPlans) {
        // console.log(JSON.stringify(facilities));
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/MealPlan/CreateMealPlan/', associatedMealPlans)
            .do(function (data) { return console.log('All: '); })
            .catch(this.handleError);
    };
    AssociateMealplanDataService.prototype.getMealPlan = function (hotelId) {
        var _this = this;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/MealPlan/GetMealPlan/', hotelId).map(function (data) {
            _this.mealPlanDto = data.result;
            console.log('mealPlanDto', _this.mealPlanDto);
            return _this.mealPlanDto;
        });
    };
    AssociateMealplanDataService.prototype.handleError = function (err) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        var errorMessage = '';
        if (err.error instanceof Error) {
            // A client-side or network error occurred. Handle it accordingly.
            errorMessage = "An error occurred: " + err.error.message;
        }
        else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            errorMessage = "Server returned code: " + err.status + ", error message is: " + err.message;
        }
        console.error(errorMessage);
        return __WEBPACK_IMPORTED_MODULE_3_rxjs_Observable__["a" /* Observable */].throw(errorMessage);
    };
    AssociateMealplanDataService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_2__common_shared_services_authenticated_http_service__["a" /* AuthenticatedHttpService */], __WEBPACK_IMPORTED_MODULE_1__common_shared_services_portal_service__["a" /* PortalService */],
            __WEBPACK_IMPORTED_MODULE_4__hotel_data_service__["a" /* HotelDataService */]])
    ], AssociateMealplanDataService);
    return AssociateMealplanDataService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/contracts/contract-data-resolver.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ContractDataResolverService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__contract_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/contracts/contract-data.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var ContractDataResolverService = (function () {
    function ContractDataResolverService(contractsDataService) {
        this.contractsDataService = contractsDataService;
    }
    ContractDataResolverService.prototype.resolve = function (route, state) {
        return this.contractsDataService.getContractsList();
    };
    ContractDataResolverService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__contract_data_service__["a" /* ContractDataService */]])
    ], ContractDataResolverService);
    return ContractDataResolverService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/contracts/contract-data.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ContractDataService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__ = __webpack_require__("../../../../../src/app/common/shared/services/authenticated-http.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__common_shared_services_portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var ContractDataService = (function () {
    function ContractDataService(authenticatedHttpService, portalService) {
        this.authenticatedHttpService = authenticatedHttpService;
        this.portalService = portalService;
    }
    Object.defineProperty(ContractDataService.prototype, "contractType", {
        get: function () {
            return this._contractType;
        },
        set: function (value) {
            this._contractType = value;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ContractDataService.prototype, "templateId", {
        get: function () {
            return this._templateId;
        },
        set: function (value) {
            this._templateId = value;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ContractDataService.prototype, "showamenity", {
        get: function () {
            return this._showamenity;
        },
        set: function (value) {
            this._showamenity = value;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ContractDataService.prototype, "showFacility", {
        get: function () {
            return this._showFacility;
        },
        set: function (value) {
            this._showFacility = value;
        },
        enumerable: true,
        configurable: true
    });
    ContractDataService.prototype.getPublishedTemplates = function () {
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/ContractTemplates/GetPublishedTemplatesForContractCreation/');
    };
    ContractDataService.prototype.getContractsList = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/Contracts/getallcontracts').map(function (data) {
            if (data === null) {
                _this.contractListDto = [];
            }
            else {
                _this.contractListDto = data.result;
            }
            return _this.contractListDto;
        });
    };
    ContractDataService.prototype.getTemplateSteps = function (templateId) {
        var _this = this;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/ContractTemplates/GetCountOfFacilitiesAndAmenitiesForSelectedTemplate/', templateId).map(function (data) {
            _this.templateStep = data.result;
            return _this.templateStep;
        });
    };
    ContractDataService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__["a" /* AuthenticatedHttpService */], __WEBPACK_IMPORTED_MODULE_2__common_shared_services_portal_service__["a" /* PortalService */]])
    ], ContractDataService);
    return ContractDataService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/contracts/contract-hotel-details-data.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ContractHotelDetailsDataService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_rxjs_Observable__ = __webpack_require__("../../../../rxjs/_esm5/Observable.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__common_shared_services_authenticated_http_service__ = __webpack_require__("../../../../../src/app/common/shared/services/authenticated-http.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__common_shared_services_portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var ContractHotelDetailsDataService = (function () {
    function ContractHotelDetailsDataService(authenticatedHttpService, portalService) {
        this.authenticatedHttpService = authenticatedHttpService;
        this.portalService = portalService;
    }
    ContractHotelDetailsDataService.prototype.getAllHotelsName = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/HotelManagement/GetAllHotelNames/').map(function (data) {
            _this.hotelsNameList = data.result;
            return _this.hotelsNameList;
        });
    };
    ContractHotelDetailsDataService.prototype.addNonMgContract = function (nonMgContractDetails) {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/Contracts/CreateNonMGContract/', nonMgContractDetails)
            .do(function (data) { return console.log('All: '); })
            .catch(this.handleError);
    };
    ContractHotelDetailsDataService.prototype.addDynamicContract = function (dynamicContractDetails) {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/Contracts/CreateMGDynamicContract/', dynamicContractDetails)
            .do(function (data) { return console.log('All: '); })
            .catch(this.handleError);
    };
    ContractHotelDetailsDataService.prototype.addStaticContract = function (staticContractDetails) {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/Contracts/CreateStaticContract/', staticContractDetails)
            .do(function (data) { return console.log('All: '); })
            .catch(this.handleError);
    };
    ContractHotelDetailsDataService.prototype.handleError = function (err) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        var errorMessage = '';
        if (err.error instanceof Error) {
            // A client-side or network error occurred. Handle it accordingly.
            errorMessage = "An error occurred: " + err.error.message;
        }
        else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            errorMessage = "Server returned code: " + err.status + ", error message is: " + err.message;
        }
        console.error(errorMessage);
        return __WEBPACK_IMPORTED_MODULE_1_rxjs_Observable__["a" /* Observable */].throw(errorMessage);
    };
    ContractHotelDetailsDataService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_2__common_shared_services_authenticated_http_service__["a" /* AuthenticatedHttpService */], __WEBPACK_IMPORTED_MODULE_3__common_shared_services_portal_service__["a" /* PortalService */]])
    ], ContractHotelDetailsDataService);
    return ContractHotelDetailsDataService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/contracts/hotels-name-resolver.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return HotelsNameResolverService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__contract_hotel_details_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/contracts/contract-hotel-details-data.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var HotelsNameResolverService = (function () {
    function HotelsNameResolverService(contractHotelDetailsDataService) {
        this.contractHotelDetailsDataService = contractHotelDetailsDataService;
    }
    HotelsNameResolverService.prototype.resolve = function (route, state) {
        var hotelId = route.parent.params['id'];
        return this.contractHotelDetailsDataService.getAllHotelsName();
    };
    HotelsNameResolverService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__contract_hotel_details_data_service__["a" /* ContractHotelDetailsDataService */]])
    ], HotelsNameResolverService);
    return HotelsNameResolverService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/contracts/template-hotel-details-resolver.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return TemplateHotelDetailsResolverService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__templates_templates_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/templates/templates-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__contract_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/contracts/contract-data.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var TemplateHotelDetailsResolverService = (function () {
    function TemplateHotelDetailsResolverService(templatesDataService, contractDataService) {
        this.templatesDataService = templatesDataService;
        this.contractDataService = contractDataService;
        this.templateId = this.contractDataService.templateId;
    }
    TemplateHotelDetailsResolverService.prototype.resolve = function (route, state) {
        this.templateViewModel = {
            id: this.templateId
        };
        return this.templatesDataService.getTemplateHotelFields(this.templateViewModel);
    };
    TemplateHotelDetailsResolverService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__templates_templates_data_service__["a" /* TemplatesDataService */],
            __WEBPACK_IMPORTED_MODULE_2__contract_data_service__["a" /* ContractDataService */]])
    ], TemplateHotelDetailsResolverService);
    return TemplateHotelDetailsResolverService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/cuisinetypes-resolver.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return CuisinetypesResolverService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__extranet_lookup__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/extranet-lookup.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var CuisinetypesResolverService = (function () {
    function CuisinetypesResolverService(extranetLookupService) {
        this.extranetLookupService = extranetLookupService;
    }
    CuisinetypesResolverService.prototype.resolve = function (route, state) {
        return this.extranetLookupService.getCuisineType();
    };
    CuisinetypesResolverService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__extranet_lookup__["a" /* ExtranetLookupService */]])
    ], CuisinetypesResolverService);
    return CuisinetypesResolverService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/currency-resolver.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return CurrencyResolverService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__common_shared_services_lookup_service__ = __webpack_require__("../../../../../src/app/common/shared/services/lookup.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var CurrencyResolverService = (function () {
    function CurrencyResolverService(lookupService) {
        this.lookupService = lookupService;
    }
    CurrencyResolverService.prototype.resolve = function (route, state) {
        return this.lookupService.getCurrency();
    };
    CurrencyResolverService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__common_shared_services_lookup_service__["a" /* LookupService */]])
    ], CurrencyResolverService);
    return CurrencyResolverService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/extranet-lookup.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ExtranetLookupService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__ = __webpack_require__("../../../../../src/app/common/shared/services/authenticated-http.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__common_shared_services_portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var ExtranetLookupService = (function () {
    function ExtranetLookupService(authenticatedHttpService, portalService) {
        this.authenticatedHttpService = authenticatedHttpService;
        this.portalService = portalService;
    }
    ExtranetLookupService.prototype.getMeals = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/MealPlan/GetMeals/').map(function (data) {
            _this.mealtypeDto = data.result;
            return _this.mealtypeDto;
        });
    };
    ExtranetLookupService.prototype.getCuisineType = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/MealPlan/GetCuisineType/').map(function (data) {
            _this.cuisineTypeDto = data.result;
            return _this.cuisineTypeDto;
        });
    };
    ExtranetLookupService.prototype.getCurrencyByHotelId = function (hotelId) {
        var _this = this;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/PaymentData/GetCurrencyByHotelId', hotelId).map(function (data) {
            _this.hotelCurrencyDto = data.result;
            return _this.hotelCurrencyDto;
        });
    };
    ExtranetLookupService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__["a" /* AuthenticatedHttpService */],
            __WEBPACK_IMPORTED_MODULE_2__common_shared_services_portal_service__["a" /* PortalService */]])
    ], ExtranetLookupService);
    return ExtranetLookupService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/facilities-services-resolver.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return FacilitiesServicesResolverService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__facilities_services_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/facilities-services.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var FacilitiesServicesResolverService = (function () {
    function FacilitiesServicesResolverService(facilitiesServicesService) {
        this.facilitiesServicesService = facilitiesServicesService;
    }
    FacilitiesServicesResolverService.prototype.resolve = function (route, state) {
        var hotelId = route.parent.params['id'];
        return this.facilitiesServicesService.getFacilitiesAndServices(hotelId);
    };
    FacilitiesServicesResolverService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__facilities_services_service__["a" /* FacilitiesServicesService */]])
    ], FacilitiesServicesResolverService);
    return FacilitiesServicesResolverService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/facilities-services.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return FacilitiesServicesService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__ = __webpack_require__("../../../../../src/app/common/shared/services/authenticated-http.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__common_shared_services_portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_Observable__ = __webpack_require__("../../../../rxjs/_esm5/Observable.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__hotel_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/hotel-data.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





var FacilitiesServicesService = (function () {
    function FacilitiesServicesService(authenticatedHttpService, portalService, hotelDataService) {
        this.authenticatedHttpService = authenticatedHttpService;
        this.portalService = portalService;
        this.hotelDataService = hotelDataService;
    }
    FacilitiesServicesService.prototype.getFacilitiesAndServices = function (hotelId) {
        var _this = this;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/Facilities/GetHotelFacilityGroups/', hotelId).map(function (data) {
            _this.facilityGroupDto = data.result;
            //  console.log('Country at service', this.facilityGroupDto);
            return _this.facilityGroupDto;
        });
    };
    FacilitiesServicesService.prototype.addFacilities = function (facilitiesGroup) {
        var facilities = {
            hotelId: this.hotelDataService.hotelId,
            facilityGroupList: facilitiesGroup
        };
        // console.log(JSON.stringify(facilities));
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/Facilities/CreateHotelFacilityRelation/', facilities)
            .do(function (data) { return console.log('All: '); })
            .catch(this.handleError);
    };
    FacilitiesServicesService.prototype.isFacilityExits = function () {
        var id = this.hotelDataService.hotelId;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/Facilities/IsHotelFacilityExits/', id);
    };
    FacilitiesServicesService.prototype.handleError = function (err) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        var errorMessage = '';
        if (err.error instanceof Error) {
            // A client-side or network error occurred. Handle it accordingly.
            errorMessage = "An error occurred: " + err.error.message;
        }
        else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            errorMessage = "Server returned code: " + err.status + ", error message is: " + err.message;
        }
        console.error(errorMessage);
        return __WEBPACK_IMPORTED_MODULE_3_rxjs_Observable__["a" /* Observable */].throw(errorMessage);
    };
    FacilitiesServicesService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__["a" /* AuthenticatedHttpService */], __WEBPACK_IMPORTED_MODULE_2__common_shared_services_portal_service__["a" /* PortalService */],
            __WEBPACK_IMPORTED_MODULE_4__hotel_data_service__["a" /* HotelDataService */]])
    ], FacilitiesServicesService);
    return FacilitiesServicesService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/hotel-data.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return HotelDataService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__ = __webpack_require__("../../../../../src/app/common/shared/services/authenticated-http.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__common_shared_services_portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var HotelDataService = (function () {
    function HotelDataService(authenticatedHttpService, portalService) {
        this.authenticatedHttpService = authenticatedHttpService;
        this.portalService = portalService;
    }
    Object.defineProperty(HotelDataService.prototype, "hotelDetails", {
        get: function () {
            return this._hotelData;
        },
        set: function (hotel) {
            this._hotelData = hotel;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(HotelDataService.prototype, "hotelId", {
        get: function () {
            if (this._hotelData.hotelId !== undefined) {
                return this._hotelData.hotelId;
            }
            else {
                return 0;
            }
        },
        enumerable: true,
        configurable: true
    });
    HotelDataService.prototype.addHotelDetails = function (hotelDetails) {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/HotelManagement/CreateHotel/', hotelDetails);
    };
    HotelDataService.prototype.getHotel = function (hotelId) {
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/hotelmanagement/gethotel?=' + hotelId);
    };
    HotelDataService.prototype.getHotelsList = function () {
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/HotelManagement/GetAllHotels/');
    };
    HotelDataService.prototype.deleteHotel = function (hotelId) {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/HotelManagement/DeleteHotelByHotelId/', hotelId);
    };
    HotelDataService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__["a" /* AuthenticatedHttpService */], __WEBPACK_IMPORTED_MODULE_2__common_shared_services_portal_service__["a" /* PortalService */]])
    ], HotelDataService);
    return HotelDataService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/hotelcurrency-resolver.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return HotelcurrencyResolverService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__extranet_lookup__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/extranet-lookup.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var HotelcurrencyResolverService = (function () {
    function HotelcurrencyResolverService(extranetLookupService) {
        this.extranetLookupService = extranetLookupService;
    }
    HotelcurrencyResolverService.prototype.resolve = function (route, state) {
        var hotelId = route.parent.params['id'];
        return this.extranetLookupService.getCurrencyByHotelId(hotelId);
    };
    HotelcurrencyResolverService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__extranet_lookup__["a" /* ExtranetLookupService */]])
    ], HotelcurrencyResolverService);
    return HotelcurrencyResolverService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/hotelroom-resolver.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return HotelRoomResolverService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__amenities_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/amenities-data.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var HotelRoomResolverService = (function () {
    function HotelRoomResolverService(amenitiesService) {
        this.amenitiesService = amenitiesService;
    }
    HotelRoomResolverService.prototype.resolve = function (route, state) {
        var hotelId = route.parent.params['id'];
        return this.amenitiesService.getRoomsByHotelId(hotelId);
    };
    HotelRoomResolverService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__amenities_data_service__["a" /* AmenitiesDataService */]])
    ], HotelRoomResolverService);
    return HotelRoomResolverService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/market-data.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return MarketDataService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__ = __webpack_require__("../../../../../src/app/common/shared/services/authenticated-http.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_rxjs_Observable__ = __webpack_require__("../../../../rxjs/_esm5/Observable.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__common_shared_services_portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
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





var MarketDataService = (function () {
    function MarketDataService(authenticatedHttpService, portalService, activatedRoute) {
        this.authenticatedHttpService = authenticatedHttpService;
        this.portalService = portalService;
        this.activatedRoute = activatedRoute;
    }
    MarketDataService.prototype.getCountries = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/MasterData/GetCountries').map(function (data) {
            if (data === null) {
                _this.countryListDto = [];
            }
            else {
                _this.countryListDto = data.result;
            }
            return _this.countryListDto;
        });
    };
    MarketDataService.prototype.getContinents = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/MasterData/GetContinents').map(function (data) {
            if (data === null) {
                _this.countinentListDto = [];
            }
            else {
                _this.countinentListDto = data.result;
            }
            return _this.countinentListDto;
        });
    };
    MarketDataService.prototype.getMarkets = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/RatesCategory/GetMarkets').map(function (data) {
            if (data === null) {
                _this.marketListDto = [];
            }
            else {
                _this.marketListDto = data.result;
            }
            return _this.marketListDto;
        });
    };
    MarketDataService.prototype.addMarket = function (markettypes) {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/Market/CreateMarket', markettypes)
            .do(function (data) { return console.log('All: '); })
            .catch(this.handleError);
    };
    MarketDataService.prototype.getMarketIncludedAndExcludedCountry = function (marketId) {
        var _this = this;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/Market/GetMarketIncludedAndExcludedCountries', marketId).map(function (data) {
            if (data === null) {
                _this.marketIncludedAndExcludedCountriesListDto = [];
            }
            else {
                _this.marketIncludedAndExcludedCountriesListDto = data.result;
            }
            return _this.marketIncludedAndExcludedCountriesListDto;
        });
    };
    MarketDataService.prototype.handleError = function (err) {
        var errorMessage = '';
        if (err.error instanceof Error) {
            errorMessage = "An error occurred : " + err.error.message;
        }
        else {
            errorMessage = "Server returned code : " + err.status + ", error message is: " + err.message;
        }
        console.error(errorMessage);
        return __WEBPACK_IMPORTED_MODULE_2_rxjs_Observable__["a" /* Observable */].throw(errorMessage);
    };
    MarketDataService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__["a" /* AuthenticatedHttpService */],
            __WEBPACK_IMPORTED_MODULE_3__common_shared_services_portal_service__["a" /* PortalService */],
            __WEBPACK_IMPORTED_MODULE_4__angular_router__["ActivatedRoute"]])
    ], MarketDataService);
    return MarketDataService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/mealtypes-resolver.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return MealtypesResolverService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__extranet_lookup__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/extranet-lookup.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var MealtypesResolverService = (function () {
    function MealtypesResolverService(extranetLookupService) {
        this.extranetLookupService = extranetLookupService;
    }
    MealtypesResolverService.prototype.resolve = function (route, state) {
        return this.extranetLookupService.getMeals();
    };
    MealtypesResolverService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__extranet_lookup__["a" /* ExtranetLookupService */]])
    ], MealtypesResolverService);
    return MealtypesResolverService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/message-data.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return MessageDataService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__ = __webpack_require__("../../../../../src/app/common/shared/services/authenticated-http.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__common_shared_services_portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__hotel_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/hotel-data.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





var MessageDataService = (function () {
    function MessageDataService(authenticatedHttpService, portalService, activatedRoute, hotelDataService) {
        this.authenticatedHttpService = authenticatedHttpService;
        this.portalService = portalService;
        this.activatedRoute = activatedRoute;
        this.hotelDataService = hotelDataService;
    }
    Object.defineProperty(MessageDataService.prototype, "messageDetails", {
        get: function () {
            return this._messageData;
        },
        set: function (message) {
            this._messageData = message;
        },
        enumerable: true,
        configurable: true
    });
    MessageDataService.prototype.getMessages = function (hotelId) {
        var _this = this;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/message/GetMessagesByHotelId', hotelId).map(function (data) {
            if (data === null) {
                _this.messageListDto = [];
            }
            else {
                _this.messageListDto = data.result;
            }
            return _this.messageListDto;
        });
    };
    MessageDataService.prototype.getMessageTypes = function () {
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/message/GetMessageType');
    };
    MessageDataService.prototype.addMessage = function (message) {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/message/CreateMessage/', message);
    };
    MessageDataService.prototype.getMessageDetails = function (messageId) {
        var _this = this;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/message/GetMessagesByMessageId/', messageId).map(function (data) {
            _this.messageInfoDto = data.result;
            return _this.messageInfoDto;
        });
    };
    MessageDataService.prototype.deleteMessage = function (messageId) {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/message/DeleteMessageByMessageId/', messageId);
    };
    MessageDataService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__["a" /* AuthenticatedHttpService */],
            __WEBPACK_IMPORTED_MODULE_2__common_shared_services_portal_service__["a" /* PortalService */],
            __WEBPACK_IMPORTED_MODULE_3__angular_router__["ActivatedRoute"],
            __WEBPACK_IMPORTED_MODULE_4__hotel_data_service__["a" /* HotelDataService */]])
    ], MessageDataService);
    return MessageDataService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/policies-data-resolver.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return PoliciesDataResolverService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__policies_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/policies-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var PoliciesDataResolverService = (function () {
    function PoliciesDataResolverService(policiesDataService) {
        this.policiesDataService = policiesDataService;
    }
    PoliciesDataResolverService.prototype.resolve = function (route, state) {
        var hotelId = route.parent.params['id'];
        return this.policiesDataService.getChildAndExtraBedpolicyDetails(hotelId);
    };
    PoliciesDataResolverService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_1__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_0__policies_data_service__["a" /* PoliciesDataService */]])
    ], PoliciesDataResolverService);
    return PoliciesDataResolverService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/policies-data.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return PoliciesDataService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__ = __webpack_require__("../../../../../src/app/common/shared/services/authenticated-http.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_rxjs_Observable__ = __webpack_require__("../../../../rxjs/_esm5/Observable.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__common_shared_services_portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var PoliciesDataService = (function () {
    function PoliciesDataService(authenticatedHttpService, portalService) {
        this.authenticatedHttpService = authenticatedHttpService;
        this.portalService = portalService;
    }
    Object.defineProperty(PoliciesDataService.prototype, "childAndExtraBedPolicyDetails", {
        get: function () {
            return this._childAndExtraBedPolicyData;
        },
        set: function (policy) {
            this._childAndExtraBedPolicyData = policy;
        },
        enumerable: true,
        configurable: true
    });
    PoliciesDataService.prototype.getChildAndExtraBedpolicyDetails = function (hotelId) {
        var _this = this;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/Policies/GetChildrenAndExtraBedPolicy', hotelId).map(function (data) {
            if (data === null) {
                _this.childAndExtraBedPolicyDto = null;
            }
            else {
                _this.childAndExtraBedPolicyDto = data.result;
            }
            return _this.childAndExtraBedPolicyDto;
        });
    };
    PoliciesDataService.prototype.getChildAndExtraBedpolicyList = function (hotelId) {
        var _this = this;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/Policies/GetChildrenAndExtraBedPolicyListingByHotelId', hotelId).map(function (data) {
            if (data === null) {
                _this.childAndExtraBedPolicyListDto = null;
            }
            else {
                _this.childAndExtraBedPolicyListDto = data.result;
            }
            return _this.childAndExtraBedPolicyListDto;
        });
    };
    /* Cancellation Policies */
    PoliciesDataService.prototype.getCancellationChargesdto = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/policies/GetCancellationCharges').map(function (data) {
            _this.cancellationClauseChargesDto = data.result;
            return _this.cancellationClauseChargesDto;
        });
    };
    PoliciesDataService.prototype.getCancellationPolicyTypedto = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/policies/GetCancellationPolicyType').map(function (data) {
            _this.cancellationClauseTypeDto = data.result;
            return _this.cancellationClauseTypeDto;
        });
    };
    PoliciesDataService.prototype.saveAndUpdateCancellationPolicydto = function (cancellationPoliciesObj) {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/policies/SaveAndUpdateCancellationPolicy', cancellationPoliciesObj).map(function (data) {
            // console.log('Data from service-saveAndUpdateCancellationPolicydto: ' + data);
        });
    };
    /* Cancellation Policy List */
    PoliciesDataService.prototype.getCancellationPolicyListdto = function (hotelId) {
        var _this = this;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/policies/GetCancellationPolicy', hotelId).map(function (data) {
            if (data === null) {
                _this.cancellationPolicyViewModelDtoList = null;
            }
            else {
                _this.cancellationPolicyViewModelDtoList = data.result;
            }
            return _this.cancellationPolicyViewModelDtoList;
        });
    };
    PoliciesDataService.prototype.addChildAndExtrabedPolicy = function (childAndExtrabedPolicy) {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/Policies/CreateChildrenAndExtraBedPolicy', childAndExtrabedPolicy)
            .do(function (data) { return console.log('All: '); })
            .catch(this.handleError);
    };
    PoliciesDataService.prototype.handleError = function (err) {
        var errorMessage = '';
        if (err.error instanceof Error) {
            errorMessage = "An error occurred 1: " + err.error.message;
        }
        else {
            errorMessage = "Server returned code 1: " + err.status + ", error message is: " + err.message;
        }
        console.error(errorMessage);
        return __WEBPACK_IMPORTED_MODULE_2_rxjs_Observable__["a" /* Observable */].throw(errorMessage);
    };
    PoliciesDataService.prototype.deletePolicyClause = function (policyClauseID) {
        var _this = this;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/policies/DeleteCancellationPolicyClause', policyClauseID).map(function (data) {
            _this.deleteClauseIdInfoDto = data.result;
            return _this.deleteClauseIdInfoDto;
        });
    };
    PoliciesDataService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__["a" /* AuthenticatedHttpService */],
            __WEBPACK_IMPORTED_MODULE_3__common_shared_services_portal_service__["a" /* PortalService */]])
    ], PoliciesDataService);
    return PoliciesDataService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/ratecategory-data-resolver.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return RatecategoryDataResolverService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__ratecategory_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/ratecategory-data.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var RatecategoryDataResolverService = (function () {
    function RatecategoryDataResolverService(ratecategoryDataService) {
        this.ratecategoryDataService = ratecategoryDataService;
    }
    RatecategoryDataResolverService.prototype.resolve = function (route, state) {
        var hotelId = route.parent.params['id'];
        return this.ratecategoryDataService.getRooms(hotelId);
    };
    RatecategoryDataResolverService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__ratecategory_data_service__["a" /* RatecategoryDataService */]])
    ], RatecategoryDataResolverService);
    return RatecategoryDataResolverService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/ratecategory-data.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return RatecategoryDataService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__ = __webpack_require__("../../../../../src/app/common/shared/services/authenticated-http.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_rxjs_Observable__ = __webpack_require__("../../../../rxjs/_esm5/Observable.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__common_shared_services_portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
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





var RatecategoryDataService = (function () {
    function RatecategoryDataService(authenticatedHttpService, portalService, activatedRoute) {
        this.authenticatedHttpService = authenticatedHttpService;
        this.portalService = portalService;
        this.activatedRoute = activatedRoute;
    }
    RatecategoryDataService.prototype.getRateCategory = function (hotelId) {
        var _this = this;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/RatesCategory/GetRateCategory', hotelId).map(function (data) {
            if (data === null) {
                _this.rateCategoryListDto = [];
            }
            else {
                _this.rateCategoryListDto = data.result;
            }
            return _this.rateCategoryListDto;
        });
    };
    RatecategoryDataService.prototype.getRooms = function (hotelId) {
        var _this = this;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/room/GetRoomsByHotelId', hotelId).map(function (data) {
            if (data === null) {
                _this.roomListDto = [];
            }
            else {
                _this.roomListDto = data.result;
            }
            return _this.roomListDto;
        });
    };
    RatecategoryDataService.prototype.getCancellationPolicies = function (hotelId) {
        var _this = this;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/policies/GetCancellationPolicy', hotelId).map(function (data) {
            if (data === null) {
                _this.cancellationPolicyListDto = [];
            }
            else {
                _this.cancellationPolicyListDto = data.result;
            }
            return _this.cancellationPolicyListDto;
        });
    };
    RatecategoryDataService.prototype.getMeal = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/MealPlan/GetMeals').map(function (data) {
            if (data === null) {
                _this.mealListDto = [];
            }
            else {
                _this.mealListDto = data.result;
            }
            return _this.mealListDto;
        });
    };
    RatecategoryDataService.prototype.getRateDetails = function (rateId) {
        var _this = this;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/RatesCategory/GetRateCategoryById', rateId).map(function (data) {
            _this.rateInfoDto = data.result;
            return _this.rateInfoDto;
        });
    };
    RatecategoryDataService.prototype.addRateCategory = function (roomtypes) {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/RatesCategory/CreateRateCategory', roomtypes)
            .do(function (data) { return console.log('All: '); })
            .catch(this.handleError);
    };
    RatecategoryDataService.prototype.handleError = function (err) {
        var errorMessage = '';
        if (err.error instanceof Error) {
            errorMessage = "An error occurred : " + err.error.message;
        }
        else {
            errorMessage = "Server returned code : " + err.status + ", error message is: " + err.message;
        }
        console.error(errorMessage);
        return __WEBPACK_IMPORTED_MODULE_2_rxjs_Observable__["a" /* Observable */].throw(errorMessage);
    };
    RatecategoryDataService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__["a" /* AuthenticatedHttpService */],
            __WEBPACK_IMPORTED_MODULE_3__common_shared_services_portal_service__["a" /* PortalService */],
            __WEBPACK_IMPORTED_MODULE_4__angular_router__["ActivatedRoute"]])
    ], RatecategoryDataService);
    return RatecategoryDataService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/roomtype-data.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return RoomtypeDataService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__ = __webpack_require__("../../../../../src/app/common/shared/services/authenticated-http.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_rxjs_Observable__ = __webpack_require__("../../../../rxjs/_esm5/Observable.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__common_shared_services_portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__hotel_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/hotel-data.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};






var RoomtypeDataService = (function () {
    function RoomtypeDataService(authenticatedHttpService, portalService, activatedRoute, hotelDataService) {
        this.authenticatedHttpService = authenticatedHttpService;
        this.portalService = portalService;
        this.activatedRoute = activatedRoute;
        this.hotelDataService = hotelDataService;
    }
    RoomtypeDataService.prototype.getRooms = function (hotelId) {
        var _this = this;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/room/GetRoomsByHotelId', hotelId).map(function (data) {
            if (data === null) {
                _this.roomTypeListDto = [];
            }
            else {
                _this.roomTypeListDto = data.result;
            }
            return _this.roomTypeListDto;
        });
    };
    RoomtypeDataService.prototype.getRoomTypes = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/room/GetRoomType').map(function (data) {
            _this.roomTypeDto = data.result;
            return _this.roomTypeDto;
        });
    };
    RoomtypeDataService.prototype.getSizeMeasure = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/room/GetSizeMeasure').map(function (data) {
            _this.sizeMeasureDto = data.result;
            return _this.sizeMeasureDto;
        });
    };
    RoomtypeDataService.prototype.getBeds = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/room/GetBed').map(function (data) {
            _this.bedsDto = data.result;
            return _this.bedsDto;
        });
    };
    RoomtypeDataService.prototype.getOccupancy = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/room/GetOccupancy').map(function (data) {
            _this.occupancyDto = data.result;
            return _this.occupancyDto;
        });
    };
    RoomtypeDataService.prototype.addRoom = function (roomtypes) {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/room/CreateRoomType', roomtypes)
            .do(function (data) { return console.log('All: '); })
            .catch(this.handleError);
    };
    RoomtypeDataService.prototype.getRoom = function (roomId) {
        var _this = this;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/room/GetRoomDetailsByRoomId', roomId).map(function (data) {
            _this.roomInfoDto = data.result;
            return _this.roomInfoDto;
        });
    };
    RoomtypeDataService.prototype.deleteRoomBedRelation = function (id) {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/room/DeleteRoomBedRelationById ', id)
            .do(function (data) { return console.log('All: '); })
            .catch(this.handleError);
    };
    RoomtypeDataService.prototype.deleteroom = function (roomeId) {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/room/DeleteRoomById', roomeId);
    };
    RoomtypeDataService.prototype.handleError = function (err) {
        var errorMessage = '';
        if (err.error instanceof Error) {
            errorMessage = "An error occurred 1: " + err.error.message;
        }
        else {
            errorMessage = "Server returned code 1: " + err.status + ", error message is: " + err.message;
        }
        console.error(errorMessage);
        return __WEBPACK_IMPORTED_MODULE_2_rxjs_Observable__["a" /* Observable */].throw(errorMessage);
    };
    RoomtypeDataService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__["a" /* AuthenticatedHttpService */],
            __WEBPACK_IMPORTED_MODULE_3__common_shared_services_portal_service__["a" /* PortalService */],
            __WEBPACK_IMPORTED_MODULE_4__angular_router__["ActivatedRoute"],
            __WEBPACK_IMPORTED_MODULE_5__hotel_data_service__["a" /* HotelDataService */]])
    ], RoomtypeDataService);
    return RoomtypeDataService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/templates/contract-terms-data.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ContractTermsDataService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_rxjs_Observable__ = __webpack_require__("../../../../rxjs/_esm5/Observable.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__common_shared_services_authenticated_http_service__ = __webpack_require__("../../../../../src/app/common/shared/services/authenticated-http.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__common_shared_services_portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var ContractTermsDataService = (function () {
    function ContractTermsDataService(authenticatedHttpService, portalService) {
        this.authenticatedHttpService = authenticatedHttpService;
        this.portalService = portalService;
    }
    ContractTermsDataService.prototype.getContractTerms = function (templateId) {
        var _this = this;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/ContractTemplates/GetClauseLibraryFields/', templateId).map(function (data) {
            _this.contractTermsGroupDto = data.result;
            return _this.contractTermsGroupDto;
        });
    };
    // addContractTerms(contractTermsGroup: ContractTermsViewModel[], templateId): Observable<number> {
    //   const saveContractTerms: SaveContractTermsViewModel = {
    //     id : templateId,
    //     clauseLibraryFields: contractTermsGroup,
    //     objectState: ObjectState.Unchanged
    //   };
    //   console.log('Country at service', JSON.stringify(contractTermsGroup));
    //   return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
    //     + 'api/ContractTemplates/CreateOrUpdateContractTemplate/', saveContractTerms)
    //     .do(data => console.log('All: '))
    //     .catch(this.handleError)  ;
    // }
    ContractTermsDataService.prototype.addContractTerms = function (contractTerms) {
        // const saveContractTerms: SaveContractTermsViewModel = {
        //   id : templateId,
        //   clauseLibraryFields: contractTermsGroup,
        //   objectState: ObjectState.Unchanged
        // };
        // console.log('Country at service', JSON.stringify(contractTermsGroup));
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/ContractTemplates/CreateOrUpdateContractTemplate/', contractTerms)
            .do(function (data) { return console.log('All: '); })
            .catch(this.handleError);
    };
    ContractTermsDataService.prototype.handleError = function (err) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        var errorMessage = '';
        if (err.error instanceof Error) {
            // A client-side or network error occurred. Handle it accordingly.
            errorMessage = "An error occurred: " + err.error.message;
        }
        else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            errorMessage = "Server returned code: " + err.status + ", error message is: " + err.message;
        }
        console.error(errorMessage);
        return __WEBPACK_IMPORTED_MODULE_1_rxjs_Observable__["a" /* Observable */].throw(errorMessage);
    };
    ContractTermsDataService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_2__common_shared_services_authenticated_http_service__["a" /* AuthenticatedHttpService */], __WEBPACK_IMPORTED_MODULE_3__common_shared_services_portal_service__["a" /* PortalService */]])
    ], ContractTermsDataService);
    return ContractTermsDataService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/templates/contract-terms-resolver.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ContractTermsResolverService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__contract_terms_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/templates/contract-terms-data.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var ContractTermsResolverService = (function () {
    function ContractTermsResolverService(contractTermsDataService) {
        this.contractTermsDataService = contractTermsDataService;
    }
    ContractTermsResolverService.prototype.resolve = function (route, state) {
        var templateId = route.parent.params['id'];
        return this.contractTermsDataService.getContractTerms(templateId);
    };
    ContractTermsResolverService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__contract_terms_data_service__["a" /* ContractTermsDataService */]])
    ], ContractTermsResolverService);
    return ContractTermsResolverService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/templates/template-amenities-data.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return TemplateAmenitiesDataService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_rxjs_Observable__ = __webpack_require__("../../../../rxjs/_esm5/Observable.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__common_shared_services_authenticated_http_service__ = __webpack_require__("../../../../../src/app/common/shared/services/authenticated-http.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__common_shared_services_portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__common_enums__ = __webpack_require__("../../../../../src/app/common/enums.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





var TemplateAmenitiesDataService = (function () {
    function TemplateAmenitiesDataService(authenticatedHttpService, portalService) {
        this.authenticatedHttpService = authenticatedHttpService;
        this.portalService = portalService;
    }
    TemplateAmenitiesDataService.prototype.getTemplateAmenities = function (templateId) {
        var _this = this;
        var template = {
            id: templateId
        };
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/ContractTemplates/GetRoomFacilityFields/', template).map(function (data) {
            _this.templateAmenitiesGroupDto = data.result.roomFacilityFields;
            return _this.templateAmenitiesGroupDto;
        });
    };
    TemplateAmenitiesDataService.prototype.addAmenities = function (templateAmenitiesGroup, templateId) {
        var templateAmenities = {
            id: templateId,
            roomFacilityFields: templateAmenitiesGroup,
            objectState: __WEBPACK_IMPORTED_MODULE_4__common_enums__["c" /* ObjectState */].Unchanged
        };
        // console.log('Country at service', JSON.stringify(templateAmenities));
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/ContractTemplates/CreateOrUpdateContractTemplate/', templateAmenities)
            .do(function (data) { return console.log('All: '); })
            .catch(this.handleError);
    };
    TemplateAmenitiesDataService.prototype.handleError = function (err) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        var errorMessage = '';
        if (err.error instanceof Error) {
            // A client-side or network error occurred. Handle it accordingly.
            errorMessage = "An error occurred: " + err.error.message;
        }
        else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            errorMessage = "Server returned code: " + err.status + ", error message is: " + err.message;
        }
        console.error(errorMessage);
        return __WEBPACK_IMPORTED_MODULE_1_rxjs_Observable__["a" /* Observable */].throw(errorMessage);
    };
    TemplateAmenitiesDataService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_2__common_shared_services_authenticated_http_service__["a" /* AuthenticatedHttpService */], __WEBPACK_IMPORTED_MODULE_3__common_shared_services_portal_service__["a" /* PortalService */]])
    ], TemplateAmenitiesDataService);
    return TemplateAmenitiesDataService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/templates/template-amenities-resolver.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return TemplateAmenitiesResolverService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__template_amenities_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/templates/template-amenities-data.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var TemplateAmenitiesResolverService = (function () {
    function TemplateAmenitiesResolverService(templateAmenitiesDataService) {
        this.templateAmenitiesDataService = templateAmenitiesDataService;
    }
    TemplateAmenitiesResolverService.prototype.resolve = function (route, state) {
        var templateId = route.parent.params['id'];
        return this.templateAmenitiesDataService.getTemplateAmenities(templateId);
    };
    TemplateAmenitiesResolverService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__template_amenities_data_service__["a" /* TemplateAmenitiesDataService */]])
    ], TemplateAmenitiesResolverService);
    return TemplateAmenitiesResolverService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/templates/template-facilities-data.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return TemplateFacilitiesDataService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_rxjs_Observable__ = __webpack_require__("../../../../rxjs/_esm5/Observable.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__common_shared_services_authenticated_http_service__ = __webpack_require__("../../../../../src/app/common/shared/services/authenticated-http.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__common_shared_services_portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__common_enums__ = __webpack_require__("../../../../../src/app/common/enums.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





var TemplateFacilitiesDataService = (function () {
    function TemplateFacilitiesDataService(authenticatedHttpService, portalService) {
        this.authenticatedHttpService = authenticatedHttpService;
        this.portalService = portalService;
    }
    TemplateFacilitiesDataService.prototype.getTemplateFacilitiesAndServices = function (templateId) {
        var _this = this;
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/ContractTemplates/GetHotelFacilityFields/', templateId).map(function (data) {
            _this.templateFacilityGroupDto = data.result;
            return _this.templateFacilityGroupDto;
        });
    };
    TemplateFacilitiesDataService.prototype.addFacilities = function (templateFacilitiesGroup, templateId) {
        var templateFacilities = {
            id: templateId,
            hotelFacilityFields: templateFacilitiesGroup,
            objectState: __WEBPACK_IMPORTED_MODULE_4__common_enums__["c" /* ObjectState */].Unchanged
        };
        console.log('Country at service', JSON.stringify(templateFacilities));
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/ContractTemplates/CreateOrUpdateContractTemplate/', templateFacilities)
            .do(function (data) { return console.log('All: '); })
            .catch(this.handleError);
    };
    TemplateFacilitiesDataService.prototype.handleError = function (err) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        var errorMessage = '';
        if (err.error instanceof Error) {
            // A client-side or network error occurred. Handle it accordingly.
            errorMessage = "An error occurred: " + err.error.message;
        }
        else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            errorMessage = "Server returned code: " + err.status + ", error message is: " + err.message;
        }
        console.error(errorMessage);
        return __WEBPACK_IMPORTED_MODULE_1_rxjs_Observable__["a" /* Observable */].throw(errorMessage);
    };
    TemplateFacilitiesDataService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_2__common_shared_services_authenticated_http_service__["a" /* AuthenticatedHttpService */], __WEBPACK_IMPORTED_MODULE_3__common_shared_services_portal_service__["a" /* PortalService */]])
    ], TemplateFacilitiesDataService);
    return TemplateFacilitiesDataService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/templates/template-facilities-resolver.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return TemplateFacilitiesResolverService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__template_facilities_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/templates/template-facilities-data.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var TemplateFacilitiesResolverService = (function () {
    function TemplateFacilitiesResolverService(templateFacilitiesDataService) {
        this.templateFacilitiesDataService = templateFacilitiesDataService;
    }
    TemplateFacilitiesResolverService.prototype.resolve = function (route, state) {
        var templateId = route.parent.params['id'];
        return this.templateFacilitiesDataService.getTemplateFacilitiesAndServices(templateId);
    };
    TemplateFacilitiesResolverService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__template_facilities_data_service__["a" /* TemplateFacilitiesDataService */]])
    ], TemplateFacilitiesResolverService);
    return TemplateFacilitiesResolverService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/templates/template-hotel-fields-resolver.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return TemplateHotelFieldsResolverService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__templates_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/templates/templates-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__viewmodel_templates_hotel_info_hotelinfoviewmodel__ = __webpack_require__("../../../../../src/app/extranet/viewmodel/templates/hotel-info/hotelinfoviewmodel.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var templateViewModel = new __WEBPACK_IMPORTED_MODULE_2__viewmodel_templates_hotel_info_hotelinfoviewmodel__["a" /* TemplateViewModel */]();
var TemplateHotelFieldsResolverService = (function () {
    function TemplateHotelFieldsResolverService(templatesDataService) {
        this.templatesDataService = templatesDataService;
    }
    TemplateHotelFieldsResolverService.prototype.resolve = function (route, state) {
        var templateId = +route.parent.params['id'];
        templateViewModel.id = +templateId;
        if (templateId > 0 && !isNaN(templateId)) {
            // console.log('templateId- ' + templateId);
            return this.templatesDataService.getTemplateHotelFields(templateViewModel);
        }
        else {
            // console.log('templateId- ' + templateId);
            return this.templatesDataService.getInitialHotelFields();
        }
    };
    TemplateHotelFieldsResolverService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__templates_data_service__["a" /* TemplatesDataService */]])
    ], TemplateHotelFieldsResolverService);
    return TemplateHotelFieldsResolverService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/templates/template-room-type-data.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return TemplateRoomTypeDataService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__ = __webpack_require__("../../../../../src/app/common/shared/services/authenticated-http.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__common_shared_services_portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var TemplateRoomTypeDataService = (function () {
    function TemplateRoomTypeDataService(authenticatedHttpService, portalService) {
        this.authenticatedHttpService = authenticatedHttpService;
        this.portalService = portalService;
    }
    TemplateRoomTypeDataService.prototype.getTemplateRoomTypeFields = function (templateViewModel) {
        var _this = this;
        console.log('getTemplateRoomTypeFields');
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/ContractTemplates/GetRoomFields/', templateViewModel).map(function (data) {
            _this.templateRoomtypeinfoviewmodel = data.result;
            return _this.templateRoomtypeinfoviewmodel;
        });
    };
    TemplateRoomTypeDataService.prototype.saveTemplateRoomTypeFields = function (templateRoomtypeinfoviewmodel) {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/ContractTemplates/CreateOrUpdateContractTemplate/', templateRoomtypeinfoviewmodel);
    };
    TemplateRoomTypeDataService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__["a" /* AuthenticatedHttpService */],
            __WEBPACK_IMPORTED_MODULE_2__common_shared_services_portal_service__["a" /* PortalService */]])
    ], TemplateRoomTypeDataService);
    return TemplateRoomTypeDataService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/templates/template-room-type-fields-resolver.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return TemplateRoomTypeFieldsResolverService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__viewmodel_templates_hotel_info_hotelinfoviewmodel__ = __webpack_require__("../../../../../src/app/extranet/viewmodel/templates/hotel-info/hotelinfoviewmodel.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__viewmodel_templates_room_type_roomtypeinfoviewmodel__ = __webpack_require__("../../../../../src/app/extranet/viewmodel/templates/room-type/roomtypeinfoviewmodel.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__template_room_type_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/templates/template-room-type-data.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var templateViewModel = new __WEBPACK_IMPORTED_MODULE_1__viewmodel_templates_hotel_info_hotelinfoviewmodel__["a" /* TemplateViewModel */]();
var templateRoomtypeinfoviewmodel = new __WEBPACK_IMPORTED_MODULE_2__viewmodel_templates_room_type_roomtypeinfoviewmodel__["a" /* TemplateRoomtypeinfoviewmodel */]();
var TemplateRoomTypeFieldsResolverService = (function () {
    function TemplateRoomTypeFieldsResolverService(roomTypeDataService) {
        this.roomTypeDataService = roomTypeDataService;
    }
    TemplateRoomTypeFieldsResolverService.prototype.resolve = function (route, state) {
        var templateId = +route.parent.params['id'];
        templateViewModel.id = +templateId;
        return this.roomTypeDataService.getTemplateRoomTypeFields(templateViewModel);
    };
    TemplateRoomTypeFieldsResolverService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_3__template_room_type_data_service__["a" /* TemplateRoomTypeDataService */]])
    ], TemplateRoomTypeFieldsResolverService);
    return TemplateRoomTypeFieldsResolverService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/templates/templates-data-resolver.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return TemplatesDataResolverService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__templates_data_service__ = __webpack_require__("../../../../../src/app/extranet/common/extranet-shared/services/templates/templates-data.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var TemplatesDataResolverService = (function () {
    function TemplatesDataResolverService(templatesDataService) {
        this.templatesDataService = templatesDataService;
    }
    TemplatesDataResolverService.prototype.resolve = function (route, state) {
        return this.templatesDataService.getTemplatesList();
    };
    TemplatesDataResolverService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_1__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_0__templates_data_service__["a" /* TemplatesDataService */]])
    ], TemplatesDataResolverService);
    return TemplatesDataResolverService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/extranet-shared/services/templates/templates-data.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return TemplatesDataService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__ = __webpack_require__("../../../../../src/app/common/shared/services/authenticated-http.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__common_shared_services_portal_service__ = __webpack_require__("../../../../../src/app/common/shared/services/portal.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var TemplatesDataService = (function () {
    function TemplatesDataService(authenticatedHttpService, portalService) {
        this.authenticatedHttpService = authenticatedHttpService;
        this.portalService = portalService;
    }
    Object.defineProperty(TemplatesDataService.prototype, "templateHotelFieldsDetails", {
        get: function () {
            return this._templateHotelFieldsDetails;
        },
        set: function (template) {
            this._templateHotelFieldsDetails = template;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TemplatesDataService.prototype, "templateListDto", {
        get: function () {
            return this._templateListDto;
        },
        set: function (template) {
            this._templateListDto = template;
        },
        enumerable: true,
        configurable: true
    });
    TemplatesDataService.prototype.getTemplatesList = function () {
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/ContractTemplates/GetContractTemplates/');
    };
    // templateListDto: Templateslistviewmodel[];
    /*
    getTemplatesList(): Observable<any> {
      return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
        + 'api/ContractTemplates/GetContractTemplates/').map(data => {
          if (data === null) {
              this.templateListDto = [];
          } else {
              this.templateListDto = data.result;
          }
          return this.templateListDto;
      });
    }*/
    TemplatesDataService.prototype.getInitialHotelFields = function () {
        var _this = this;
        return this.authenticatedHttpService.get(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/ContractTemplates/GetHotelFields/').map(function (data) {
            _this.templateHotelInfoViewModel = data.result;
            return _this.templateHotelInfoViewModel;
        });
    };
    TemplatesDataService.prototype.saveTemplateHotelFields = function (templateHotelInfoViewModel) {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/ContractTemplates/CreateOrUpdateContractTemplate/', templateHotelInfoViewModel);
    };
    TemplatesDataService.prototype.getTemplateHotelFields = function (templateViewModel) {
        var _this = this;
        // console.log('I m at getTemplateHotelFields');
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/ContractTemplates/GetHotelFields/', templateViewModel).map(function (data) {
            _this.templateHotelInfoViewModel = data.result;
            return _this.templateHotelInfoViewModel;
        });
    };
    TemplatesDataService.prototype.copyTemplate = function (copiedTemplate) {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/ContractTemplates/CreateTemplateCopy/', copiedTemplate);
    };
    TemplatesDataService.prototype.deleteTemplate = function (templateId) {
        return this.authenticatedHttpService.post(this.portalService.appSettings.BaseUrls.ExtranetApi
            + 'api/ContractTemplates/DeleteTemplate/', templateId);
    };
    TemplatesDataService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__common_shared_services_authenticated_http_service__["a" /* AuthenticatedHttpService */], __WEBPACK_IMPORTED_MODULE_2__common_shared_services_portal_service__["a" /* PortalService */]])
    ], TemplatesDataService);
    return TemplatesDataService;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/common/pipes/marketcountryfilterpipe.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return MarketCountryFilterPipe; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

var MarketCountryFilterPipe = (function () {
    function MarketCountryFilterPipe() {
    }
    MarketCountryFilterPipe.prototype.transform = function (countries, searchText) {
        if (!countries || !searchText) {
            return countries;
        }
        else {
            searchText = searchText.toLowerCase();
            return countries.filter(function (country) { return country.countryName.toLowerCase().includes(searchText); });
        }
    };
    MarketCountryFilterPipe = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Pipe"])({
            name: 'searchCountry'
        })
    ], MarketCountryFilterPipe);
    return MarketCountryFilterPipe;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/viewmodel/templates/hotel-info/hotelinfoviewmodel.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export HotelInfoViewModel */
/* unused harmony export TemplateHotelInfoViewModel */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return TemplateViewModel; });
var HotelInfoViewModel = (function () {
    function HotelInfoViewModel() {
    }
    return HotelInfoViewModel;
}());

var TemplateHotelInfoViewModel = (function () {
    function TemplateHotelInfoViewModel() {
    }
    return TemplateHotelInfoViewModel;
}());

var TemplateViewModel = (function () {
    function TemplateViewModel() {
    }
    return TemplateViewModel;
}());



/***/ }),

/***/ "../../../../../src/app/extranet/viewmodel/templates/room-type/roomtypeinfoviewmodel.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export Roomtypeinfoviewmodel */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return TemplateRoomtypeinfoviewmodel; });
var Roomtypeinfoviewmodel = (function () {
    function Roomtypeinfoviewmodel() {
    }
    return Roomtypeinfoviewmodel;
}());

var TemplateRoomtypeinfoviewmodel = (function () {
    function TemplateRoomtypeinfoviewmodel() {
    }
    return TemplateRoomtypeinfoviewmodel;
}());



/***/ }),

/***/ "../../../../../src/app/framework/fw/content/content.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ":host {\r\n  display: -webkit-box;\r\n  display: -ms-flexbox;\r\n  display: flex;\r\n  -webkit-box-flex: 1;\r\n      -ms-flex-positive: 1;\r\n          flex-grow: 1;\r\n  padding-top: 127px;\r\n  padding-bottom: 71px;\r\n}\r\n\r\n.body-style{\r\n  -webkit-box-flex: 1;\r\n      -ms-flex-positive: 1;\r\n          flex-grow: 1;\r\n}\r\n\r\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/framework/fw/content/content.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"body-style\">\n  <router-outlet></router-outlet>\n</div>\n"

/***/ }),

/***/ "../../../../../src/app/framework/fw/content/content.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ContentComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var ContentComponent = (function () {
    function ContentComponent() {
    }
    ContentComponent.prototype.ngOnInit = function () {
    };
    ContentComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            // tslint:disable-next-line:component-selector
            selector: 'fw-content',
            template: __webpack_require__("../../../../../src/app/framework/fw/content/content.component.html"),
            styles: [__webpack_require__("../../../../../src/app/framework/fw/content/content.component.css")]
        }),
        __metadata("design:paramtypes", [])
    ], ContentComponent);
    return ContentComponent;
}());



/***/ }),

/***/ "../../../../../src/app/framework/fw/framework-body/framework-body.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ":host {\r\n  -webkit-box-orient: vertical;\r\n  -webkit-box-direction: normal;\r\n      -ms-flex-direction: column;\r\n          flex-direction: column;\r\n}\r\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/framework/fw/framework-body/framework-body.component.html":
/***/ (function(module, exports) {

module.exports = "<!--Header-->\r\n<div class=\"fixed-top\"><fw-title-bar></fw-title-bar></div>\r\n<!--content-->\r\n<fw-content></fw-content>\r\n<!-- Footer-->\r\n<fw-status-bar></fw-status-bar>\r\n"

/***/ }),

/***/ "../../../../../src/app/framework/fw/framework-body/framework-body.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return FrameworkBodyComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var FrameworkBodyComponent = (function () {
    function FrameworkBodyComponent() {
    }
    FrameworkBodyComponent.prototype.ngOnInit = function () {
    };
    FrameworkBodyComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'fw-framework-body',
            template: __webpack_require__("../../../../../src/app/framework/fw/framework-body/framework-body.component.html"),
            styles: [__webpack_require__("../../../../../src/app/framework/fw/framework-body/framework-body.component.css")]
        }),
        __metadata("design:paramtypes", [])
    ], FrameworkBodyComponent);
    return FrameworkBodyComponent;
}());



/***/ }),

/***/ "../../../../../src/app/framework/fw/fw.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return FwModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_common__ = __webpack_require__("../../../common/esm5/common.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__framework_body_framework_body_component__ = __webpack_require__("../../../../../src/app/framework/fw/framework-body/framework-body.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__content_content_component__ = __webpack_require__("../../../../../src/app/framework/fw/content/content.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__title_bar_title_bar_component__ = __webpack_require__("../../../../../src/app/framework/fw/title-bar/title-bar.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__top_bar_top_bar_component__ = __webpack_require__("../../../../../src/app/framework/fw/top-bar/top-bar.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__status_bar_status_bar_component__ = __webpack_require__("../../../../../src/app/framework/fw/status-bar/status-bar.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__menus_menu_menu_component__ = __webpack_require__("../../../../../src/app/framework/fw/menus/menu/menu.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__services_menu_service__ = __webpack_require__("../../../../../src/app/framework/fw/services/menu.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_9__services_top_bar_service__ = __webpack_require__("../../../../../src/app/framework/fw/services/top-bar.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_10__menus_menu_item_menu_item_component__ = __webpack_require__("../../../../../src/app/framework/fw/menus/menu-item/menu-item.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_11__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_12__menus_popup_menu_popup_menu_component__ = __webpack_require__("../../../../../src/app/framework/fw/menus/popup-menu/popup-menu.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_13__unauthorized_unauthorized_component__ = __webpack_require__("../../../../../src/app/framework/fw/unauthorized/unauthorized.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_14__common_material_material_module__ = __webpack_require__("../../../../../src/app/common/material/material.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_15__users_change_password_change_password_component__ = __webpack_require__("../../../../../src/app/framework/fw/users/change-password/change-password.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_16__angular_forms__ = __webpack_require__("../../../forms/esm5/forms.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};


















var FwModule = (function () {
    // Preventing importing this modules more than once
    // https://angular.io/guide/ngmodule-faq
    function FwModule(parentModule) {
        if (parentModule) {
            throw new Error('FwModule is already loaded. Import it in the AppModule only');
        }
    }
    FwModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            imports: [
                __WEBPACK_IMPORTED_MODULE_1__angular_common__["CommonModule"],
                __WEBPACK_IMPORTED_MODULE_11__angular_router__["RouterModule"],
                __WEBPACK_IMPORTED_MODULE_14__common_material_material_module__["a" /* MaterialModule */],
                __WEBPACK_IMPORTED_MODULE_16__angular_forms__["FormsModule"],
                __WEBPACK_IMPORTED_MODULE_16__angular_forms__["ReactiveFormsModule"]
            ],
            declarations: [
                __WEBPACK_IMPORTED_MODULE_2__framework_body_framework_body_component__["a" /* FrameworkBodyComponent */],
                __WEBPACK_IMPORTED_MODULE_3__content_content_component__["a" /* ContentComponent */],
                __WEBPACK_IMPORTED_MODULE_4__title_bar_title_bar_component__["a" /* TitleBarComponent */],
                __WEBPACK_IMPORTED_MODULE_5__top_bar_top_bar_component__["a" /* TopBarComponent */],
                __WEBPACK_IMPORTED_MODULE_6__status_bar_status_bar_component__["a" /* StatusBarComponent */],
                __WEBPACK_IMPORTED_MODULE_7__menus_menu_menu_component__["a" /* MenuComponent */],
                __WEBPACK_IMPORTED_MODULE_10__menus_menu_item_menu_item_component__["a" /* MenuItemComponent */],
                __WEBPACK_IMPORTED_MODULE_12__menus_popup_menu_popup_menu_component__["a" /* PopupMenuComponent */],
                __WEBPACK_IMPORTED_MODULE_13__unauthorized_unauthorized_component__["a" /* UnauthorizedComponent */],
                __WEBPACK_IMPORTED_MODULE_15__users_change_password_change_password_component__["a" /* ChangePasswordComponent */]
            ],
            providers: [
                __WEBPACK_IMPORTED_MODULE_8__services_menu_service__["b" /* MenuService */],
                __WEBPACK_IMPORTED_MODULE_9__services_top_bar_service__["b" /* TopBarService */]
            ],
            exports: [
                __WEBPACK_IMPORTED_MODULE_2__framework_body_framework_body_component__["a" /* FrameworkBodyComponent */]
            ]
        }),
        __param(0, Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Optional"])()), __param(0, Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["SkipSelf"])()),
        __metadata("design:paramtypes", [FwModule])
    ], FwModule);
    return FwModule;
}());



/***/ }),

/***/ "../../../../../src/app/framework/fw/menus/menu-item/menu-item.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ":host {\r\n  display: inline-block;\r\n  position: relative;\r\n  margin-left: 0 !important;\r\n  margin-top: 0;\r\n  margin-bottom: 0;\r\n  padding: 0;\r\n  font-size: 15px;\r\n  line-height: 15px;\r\n  color: #666;\r\n  cursor: pointer;\r\n  box-sizing: border-box;\r\n  width: 100%;\r\n  height: 100%;\r\n}\r\n\r\n:host:not(.parent-is-popup) {\r\n  margin-left: 16px;\r\n  width: auto;\r\n}\r\n\r\n  :host(.parent-is-popup) {\r\n    width:100%;\r\n  }\r\n\r\n    :host(.parent-is-popup) .router-link-active, :host(.parent-is-popup) .menu-item:hover {\r\n      background: #007fb6;\r\n    }\r\n\r\nspan {\r\n  pointer-events: none;\r\n}\r\n\r\n.fa {\r\n  margin-right: 9px;\r\n}\r\n\r\n.fa.fa-angle-down {\r\n  margin: 0 0 0 11px;\r\n  color: #80a1b3;\r\n}\r\n\r\n.glyphicon-menu-right, .glyphicon-menu-down {\r\n  float: right;\r\n}\r\n\r\n\r\n\r\n.menu-item {\r\n  padding: 14px 19px;\r\n  font-size: 16px;\r\n  color: #fff;\r\n  border-right: 1px solid #4d7b95;\r\n  /*font-family: proxima_nova_ltsemibold;*/\r\n  -webkit-box-align: center;\r\n      -ms-flex-align: center;\r\n          align-items: center;\r\n  height: 100%;\r\n  display: -webkit-box;\r\n  display: -ms-flexbox;\r\n  display: flex;\r\n  transition: background-color 0.6s ease-out;\r\n  position:relative;\r\n  outline:none;\r\n}\r\n\r\n  .menu-item:after {\r\n    content: '';\r\n    position: absolute;\r\n    top: 50%;\r\n    left: 50%;\r\n    width: 5px;\r\n    height: 5px;\r\n    background: rgba(255, 255, 255, .5);\r\n    opacity: 0;\r\n    border-radius: 100%;\r\n    -webkit-transform: scale(1, 1) translate(-50%);\r\n            transform: scale(1, 1) translate(-50%);\r\n    -webkit-transform-origin: 50% 50%;\r\n            transform-origin: 50% 50%;\r\n  }\r\n\r\n@-webkit-keyframes ripple {\r\n  0% {\r\n    -webkit-transform: scale(0, 0);\r\n            transform: scale(0, 0);\r\n    opacity: 1;\r\n  }\r\n\r\n  20% {\r\n    -webkit-transform: scale(25, 25);\r\n            transform: scale(25, 25);\r\n    opacity: 1;\r\n  }\r\n\r\n  100% {\r\n    opacity: 0;\r\n    -webkit-transform: scale(40, 40);\r\n            transform: scale(40, 40);\r\n  }\r\n}\r\n\r\n@keyframes ripple {\r\n  0% {\r\n    -webkit-transform: scale(0, 0);\r\n            transform: scale(0, 0);\r\n    opacity: 1;\r\n  }\r\n\r\n  20% {\r\n    -webkit-transform: scale(25, 25);\r\n            transform: scale(25, 25);\r\n    opacity: 1;\r\n  }\r\n\r\n  100% {\r\n    opacity: 0;\r\n    -webkit-transform: scale(40, 40);\r\n            transform: scale(40, 40);\r\n  }\r\n}\r\n\r\n.menu-item:focus:not(:active)::after {\r\n  -webkit-animation: ripple 1s ease-out;\r\n          animation: ripple 1s ease-out;\r\n}\r\n\r\n\r\n\r\n  .router-link-active, .menu-item:hover {\r\n    background-color: #2aaae1;\r\n  }\r\n\r\n\r\n\r\n\r\n.navbar li a .fw-menu-item {\r\n  margin-left: 0;\r\n  line-height: 0;\r\n}\r\n\r\n.subMenu li .menu-item {\r\n  display: none;\r\n}\r\n\r\n\r\n\r\n\r\n\r\n.navbar li a .menu-item {\r\n  display: none;\r\n}\r\n\r\n\r\n.menu-item .fa{\r\n  font-size: 18px;\r\n}\r\n\r\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/framework/fw/menus/menu-item/menu-item.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"menu-item\"\n  [ngClass]=\"{'router-link-active': isActiveRoute  }\"\n  [routerLink]=\"item.route\"\n  >\n\n  <span><span class=\"{{ item.icon }}\"></span>{{ item.text }}</span>\n\n  <i *ngIf=\"item.submenu && !parentIsPopup\"\n  class=\"fa fa-angle-down\"></i>\n  <span *ngIf=\"item.submenu && parentIsPopup\"\n  class=\"glyphicon glyphicon-menu-right\"></span>\n</div>\n\n  <fw-popup-menu *ngIf=\"mouseInPopup || mouseInItem\"\n                 [menu]='item.submenu'\n                 (mouseleave)=\"onPopupMouseLeave($event)\"\n                 (mouseenter)=\"onPopupMouseEnter($event)\"\n                 [style.left.px]=\"popupLeft\"\n                 [style.top.px]=\"popupTop\">\n  </fw-popup-menu>\n"

/***/ }),

/***/ "../../../../../src/app/framework/fw/menus/menu-item/menu-item.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return MenuItemComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__services_menu_service__ = __webpack_require__("../../../../../src/app/framework/fw/services/menu.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var MenuItemComponent = (function () {
    function MenuItemComponent(router, menuService) {
        this.router = router;
        this.menuService = menuService;
        this.parentIsPopup = true;
        this.isActiveRoute = false;
        this.mouseInItem = false;
        this.mouseInPopup = false;
        this.popupLeft = 0;
        this.popupTop = 34;
    }
    MenuItemComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.checkActiveRoute(this.router.url);
        this.router.events
            .subscribe(function (event) {
            if (event instanceof __WEBPACK_IMPORTED_MODULE_2__angular_router__["NavigationEnd"]) {
                _this.checkActiveRoute(event.url);
                //   console.log(event.url + ' ' + this.item.route + ' ' + this.isActiveRoute);
            }
        });
    };
    MenuItemComponent.prototype.checkActiveRoute = function (route) {
        this.isActiveRoute = (route === '/' + this.item.route);
    };
    MenuItemComponent.prototype.onPopupMouseEnter = function (event) {
        this.mouseInPopup = true;
    };
    MenuItemComponent.prototype.onPopupMouseLeave = function (event) {
        this.mouseInPopup = false;
    };
    MenuItemComponent.prototype.onMouseLeave = function (event) {
        this.mouseInItem = false;
    };
    MenuItemComponent.prototype.onMouseEnter = function () {
        if (this.item.submenu) {
            this.mouseInItem = true;
            if (this.parentIsPopup) {
                this.popupLeft = 160;
                this.popupTop = 0;
            }
        }
    };
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Object)
    ], MenuItemComponent.prototype, "item", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["HostBinding"])('class.parent-is-popup'),
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Object)
    ], MenuItemComponent.prototype, "parentIsPopup", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["HostListener"])('mouseleave', ['$event']),
        __metadata("design:type", Function),
        __metadata("design:paramtypes", [Object]),
        __metadata("design:returntype", void 0)
    ], MenuItemComponent.prototype, "onMouseLeave", null);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["HostListener"])('mouseenter'),
        __metadata("design:type", Function),
        __metadata("design:paramtypes", []),
        __metadata("design:returntype", void 0)
    ], MenuItemComponent.prototype, "onMouseEnter", null);
    MenuItemComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            // tslint:disable-next-line:component-selector
            selector: 'fw-menu-item',
            template: __webpack_require__("../../../../../src/app/framework/fw/menus/menu-item/menu-item.component.html"),
            styles: [__webpack_require__("../../../../../src/app/framework/fw/menus/menu-item/menu-item.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_2__angular_router__["Router"],
            __WEBPACK_IMPORTED_MODULE_1__services_menu_service__["b" /* MenuService */]])
    ], MenuItemComponent);
    return MenuItemComponent;
}());



/***/ }),

/***/ "../../../../../src/app/framework/fw/menus/menu/menu.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ":host {\r\n  display: -webkit-box;\r\n  display: -ms-flexbox;\r\n  display: flex;\r\n  -webkit-box-align: start;\r\n      -ms-flex-align: start;\r\n          align-items: flex-start;\r\n  -webkit-box-pack: start;\r\n      -ms-flex-pack: start;\r\n          justify-content: flex-start;\r\n  -webkit-box-flex: 1;\r\n      -ms-flex-positive: 1;\r\n          flex-grow: 1;\r\n  background: #004267;\r\n}\r\n\r\nul {\r\n  list-style-type: none;\r\n  margin: 0;\r\n  padding: 0;\r\n  display: -webkit-box;\r\n  display: -ms-flexbox;\r\n  display: flex;\r\n  height:45px;\r\n}\r\n\r\nli {\r\n  display: inline-block;\r\n}\r\n\r\nnav.navbar {\r\n  padding: 0;\r\n  min-height:45px;\r\n}\r\n\r\n\r\n.navbar li a div{\r\n  display: none !important;\r\n}\r\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/framework/fw/menus/menu/menu.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"container-fluid\">\n  <div class=\"row\">\n    <nav class=\"navbar navbar-expand-lg fullWidth\">\n      <nav>\n        <ul>\n          <li *ngFor=\"let item of menuService.items\">\n            <a>\n              <fw-menu-item [item]=\"item\"\n                            [parentIsPopup]=\"false\">\n              </fw-menu-item>\n            </a>\n          </li>\n        </ul>\n      </nav>\n    </nav>\n  </div>\n</div>\n"

/***/ }),

/***/ "../../../../../src/app/framework/fw/menus/menu/menu.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return MenuComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__services_menu_service__ = __webpack_require__("../../../../../src/app/framework/fw/services/menu.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var MenuComponent = (function () {
    // menuService declared as public since it is used in template rather than this file
    function MenuComponent(menuService) {
        this.menuService = menuService;
    }
    MenuComponent.prototype.ngOnInit = function () {
    };
    MenuComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            // tslint:disable-next-line:component-selector
            selector: 'fw-menu',
            template: __webpack_require__("../../../../../src/app/framework/fw/menus/menu/menu.component.html"),
            styles: [__webpack_require__("../../../../../src/app/framework/fw/menus/menu/menu.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__services_menu_service__["b" /* MenuService */]])
    ], MenuComponent);
    return MenuComponent;
}());



/***/ }),

/***/ "../../../../../src/app/framework/fw/menus/popup-menu/popup-menu.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ":host {\r\n  position: absolute;\r\n  display: inline-block;\r\n  width: 100%;\r\n  top: 45px !important;\r\n  background: #2aaae1;\r\n  z-index: 100000;\r\n  transition: background-color 0.5s ease-out;\r\n  min-width:211px;\r\n}\r\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/framework/fw/menus/popup-menu/popup-menu.component.html":
/***/ (function(module, exports) {

module.exports = "\n<div class=\"subMenu\">\n\n  <li *ngFor=\"let item of menu\">\n    <fw-menu-item [item]=\"item\"\n                  class=\"in-popup\">\n    </fw-menu-item>\n  </li>\n</div>\n"

/***/ }),

/***/ "../../../../../src/app/framework/fw/menus/popup-menu/popup-menu.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return PopupMenuComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__services_menu_service__ = __webpack_require__("../../../../../src/app/framework/fw/services/menu.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var PopupMenuComponent = (function () {
    function PopupMenuComponent(menuService) {
        this.menuService = menuService;
    }
    PopupMenuComponent.prototype.ngOnInit = function () {
    };
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])(),
        __metadata("design:type", Array)
    ], PopupMenuComponent.prototype, "menu", void 0);
    PopupMenuComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            // tslint:disable-next-line:component-selector
            selector: 'fw-popup-menu',
            template: __webpack_require__("../../../../../src/app/framework/fw/menus/popup-menu/popup-menu.component.html"),
            styles: [__webpack_require__("../../../../../src/app/framework/fw/menus/popup-menu/popup-menu.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__services_menu_service__["b" /* MenuService */]])
    ], PopupMenuComponent);
    return PopupMenuComponent;
}());



/***/ }),

/***/ "../../../../../src/app/framework/fw/services/menu.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return MenuItems; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "b", function() { return MenuService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

var MenuItems = (function () {
    function MenuItems() {
    }
    return MenuItems;
}());

var MenuService = (function () {
    function MenuService() {
    }
    MenuService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])()
    ], MenuService);
    return MenuService;
}());



/***/ }),

/***/ "../../../../../src/app/framework/fw/services/top-bar.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return TopBarItemViewModel; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "b", function() { return TopBarService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_rxjs_Subject__ = __webpack_require__("../../../../rxjs/_esm5/Subject.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};


var TopBarItemViewModel = (function () {
    function TopBarItemViewModel() {
        this.appRole = new Map();
    }
    return TopBarItemViewModel;
}());

var TopBarService = (function () {
    function TopBarService() {
        this.appChangeSource = new __WEBPACK_IMPORTED_MODULE_1_rxjs_Subject__["Subject"]();
        this.appChange$ = this.appChangeSource.asObservable();
    }
    TopBarService.prototype.getTopBarItem = function () {
        return this._item;
    };
    TopBarService.prototype.setTopBarItem = function (item) {
        this._item = item;
        console.log('From TopBar service' + this._item.firstName);
    };
    TopBarService.prototype.onAppChange = function ($event) {
        this.appChangeSource.next($event.target.value);
    };
    TopBarService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])()
    ], TopBarService);
    return TopBarService;
}());



/***/ }),

/***/ "../../../../../src/app/framework/fw/status-bar/status-bar.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ":host {\r\n  background: #666666;\r\n  padding: 15px 0;\r\n  color: #adadad;\r\n  font-size: 0.875em;\r\n  width: 100%;\r\n  display: -webkit-box;\r\n  display: -ms-flexbox;\r\n  display: flex;\r\n  -webkit-box-pack: center;\r\n      -ms-flex-pack: center;\r\n          justify-content: center;\r\n  z-index: 100;\r\n  position: fixed;\r\n  bottom: 0;\r\n}\r\n\r\n\r\nfooter a {\r\n  color: #fff;\r\n  font-size: 0.9em;\r\n}\r\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/framework/fw/status-bar/status-bar.component.html":
/***/ (function(module, exports) {

module.exports = "<footer class=\"w-100\">\n  <div class=\"container-fluid\">\n    <div class=\"row centerText\">\n      <div class=\"col-md-3\">Copyright &copy; 2001-2017 All Rights Reserved</div>\n      <div class=\"col-md-9 text-right\">\n        MG Group, MG Building, JI. Majapahit No. 16, Jakarta Pusat 10160 | Tel: +62 21 2922 3933 | <a href=\"mailto:contracting@mgholidaygroup.com\">contracting@mgholidaygroup.com</a> | <a href=\"http://www.mgholidaygroup.com\">www.mgholidaygroup.com</a>\n      </div>\n    </div>\n  </div>\n</footer>\n"

/***/ }),

/***/ "../../../../../src/app/framework/fw/status-bar/status-bar.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return StatusBarComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var StatusBarComponent = (function () {
    function StatusBarComponent() {
    }
    StatusBarComponent.prototype.ngOnInit = function () {
    };
    StatusBarComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'fw-status-bar',
            template: __webpack_require__("../../../../../src/app/framework/fw/status-bar/status-bar.component.html"),
            styles: [__webpack_require__("../../../../../src/app/framework/fw/status-bar/status-bar.component.css")]
        }),
        __metadata("design:paramtypes", [])
    ], StatusBarComponent);
    return StatusBarComponent;
}());



/***/ }),

/***/ "../../../../../src/app/framework/fw/title-bar/title-bar.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/framework/fw/title-bar/title-bar.component.html":
/***/ (function(module, exports) {

module.exports = "<fw-top-bar></fw-top-bar>\n<fw-menu></fw-menu>\r\n"

/***/ }),

/***/ "../../../../../src/app/framework/fw/title-bar/title-bar.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return TitleBarComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var TitleBarComponent = (function () {
    function TitleBarComponent() {
    }
    TitleBarComponent.prototype.ngOnInit = function () {
    };
    TitleBarComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            // tslint:disable-next-line:component-selector
            selector: 'fw-title-bar',
            template: __webpack_require__("../../../../../src/app/framework/fw/title-bar/title-bar.component.html"),
            styles: [__webpack_require__("../../../../../src/app/framework/fw/title-bar/title-bar.component.css")]
        }),
        __metadata("design:paramtypes", [])
    ], TitleBarComponent);
    return TitleBarComponent;
}());



/***/ }),

/***/ "../../../../../src/app/framework/fw/top-bar/top-bar.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ":host {\r\n  display: -webkit-box;\r\n  display: -ms-flexbox;\r\n  display: flex;\r\n  background:#fff;\r\n}\r\n\r\n.viewUser:after,\r\n.viewUser:before {\r\n  content: '';\r\n  border-style: solid;\r\n  border-color: transparent;\r\n  border-width: 8px;\r\n  position: absolute;\r\n  right: 18px;\r\n  pointer-events: none;\r\n}\r\n\r\n.viewUser:before {\r\n  border-top-color: #004267;\r\n  top: .5625rem;\r\n}\r\n\r\n.viewUser:after {\r\n  border-top-color: #fff;\r\n  top: .4375rem;\r\n}\r\n\r\n.viewUser {\r\n  position: relative;\r\n  width: 120px;\r\n  margin-left: 17px;\r\n  margin-top: 1px;\r\n}\r\n\r\n  .viewUser select::-ms-expand {\r\n    display: none;\r\n  }\r\n\r\n  .viewUser select {\r\n    color: #666;\r\n    -webkit-appearance: none;\r\n    -moz-appearance: none;\r\n    width: 100%;\r\n    border-color: #fff;\r\n    outline: none;\r\n    border-style: none;\r\n    font-size: 15px;\r\n  }\r\n\r\n.userContainer i.fa.fa-caret-down {\r\n  margin-left: .5rem;\r\n  color: #c3c4c8;\r\n}\r\n\r\na.dropdownWelcomeLink {\r\n  text-decoration: none;\r\n  color: #666;\r\n}\r\n\r\n.user-img {\r\n  width: 40px;\r\n  height: 40px;\r\n  z-index: 10000;\r\n}\r\n\r\n.top-bar .row {\r\n  margin-bottom: 1rem;\r\n  margin-top: 1.3rem;\r\n}\r\n\r\n.notify-count {\r\n  font-family: monospace;\r\n  font-size: 13px;\r\n}\r\n\r\n.notification .badge-notify {\r\n  color: #fff;\r\n  position: absolute;\r\n  top: -12px;\r\n  right: -10px;\r\n  border-radius: 2.5rem 2.5rem 2.5rem 2.5rem;\r\n  background-color: #29aae2;\r\n  width: 1.25rem;\r\n  height: 1.2rem;\r\n}\r\n\r\n.notification {\r\n  border-right: .0625rem solid #ccc;\r\n  height: 33px;  \r\n  text-align: right;\r\n  padding-right: 19px;\r\n  margin-right: 17px;\r\n  margin-top: 3px;\r\n}\r\n\r\n\r\n.notification .bellIcon{\r\n  position: relative; \r\n  right: 11px;\r\n}\r\n\r\n.logoContainer {\r\n  border-right: .0625rem solid #ccc;\r\n  padding: 3px 19px 6px 0;\r\n}\r\n\r\nspan.user-name {\r\n  font-size: 14px;\r\n}\r\n\r\nspan.welcome-txt {\r\n  color: #666;\r\n  white-space: nowrap;\r\n  font-size: 13px;\r\n  margin-left: 6px;\r\n}\r\n\r\n.notification .fa-bell-o {\r\n  font-size: 1.5rem;\r\n  color: #a9b0b4;\r\n  margin-top: 6px;\r\n}\r\n\r\n.userContainer .dropdown {\r\n  position: relative;\r\n  display: inline-block;\r\n  margin-top: .8rem;\r\n  margin-left: .6rem;\r\n}\r\n\r\n.userContainer .dropdown-content {\r\n  display: none;\r\n  position: absolute;\r\n  background-color: #f9f9f9;\r\n  width: 100%;\r\n  box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);\r\n  z-index: 1;\r\n  margin-top: .5rem;\r\n  font-size: 0.9rem;\r\n}\r\n\r\n  .userContainer .dropdown-content a {\r\n    color: black;\r\n    padding: .50rem 1rem;\r\n    text-decoration: none;\r\n    white-space: nowrap;\r\n    display: block;\r\n  }\r\n\r\n    .userContainer .dropdown-content a:hover {\r\n      background-color: #f1f1f1\r\n    }\r\n\r\n.userContainer .dropdown:hover .dropdown-content {\r\n  display: block;\r\n}\r\n\r\n\r\n.mat-icon-button{\r\n  outline: none;\r\n}\r\n\r\n.mat-button-ripple-round, .mat-button-focus-overlay{\r\n  display: none !important;\r\n}\r\n\r\n.userContainer .mat-icon-button{\r\n  width: auto;\r\n  border-radius: inherit;\r\n  background: none;\r\n}\r\n\r\n.mat-icon-button .mat-button-focus-overlay{\r\n  background: none;\r\n}\r\n\r\n.mat-icon-button .mat-button-ripple-round{\r\n  border-radius: 0 !important;\r\n}\r\n\r\n.top-bar .mainTopBarLogo{\r\n  display: -webkit-box;\r\n  display: -ms-flexbox;\r\n  display: flex;  \r\n}\r\n\r\n.displayUser{\r\n  float: right;\r\n  display: -webkit-box;\r\n  display: -ms-flexbox;\r\n  display: flex;\r\n}\r\n\r\n\r\n.displayUser mat-icon{\r\n  font-size: 44px;\r\n  width: 44px;\r\n  height: 44px;\r\n  position: relative;\r\n  top: -2px;\r\n  color: #d8d8d8;\r\n}\r\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/framework/fw/top-bar/top-bar.component.html":
/***/ (function(module, exports) {

module.exports = "\r\n<div class=\"container-fluid top-bar\">\r\n  <div class=\"row\" *ngIf=\"topBarService.getTopBarItem()!= null\">\r\n    <div class=\"col-9 mainTopBarLogo alignItemCenter\">   \r\n              <div class=\"logoContainer\">\r\n                <a>\r\n                  <img src=\"assets/MgBedBank.png\" alt=\"MG Bedbank\" class=\"mg-Bedbank\" title=\"MG Bedbank\" />\r\n                </a>\r\n              </div>      \r\n               <div class=\"viewUser\" *ngIf=\"topBarService.getTopBarItem().applications!=null\">\r\n                  <select (change)=\"onApplicationChange($event)\">\r\n                    <option *ngFor=\"let item of topBarService.getTopBarItem().applications\">\r\n                      {{item.application}}\r\n                    </option>\r\n                  </select>\r\n                </div> \r\n    </div>\r\n    <div class=\"col-3\">\r\n      <div class=\"displayUser\">\r\n                <div class=\"notification\">\r\n                    <a class=\"bellIcon\"><i class=\"fa fa-bell-o\"></i><span class=\"badge badge-notify\"><span class=\"notify-count\">5</span></span></a>\r\n                </div>\r\n\r\n                <div class=\"userContainer alignItemCenter\" *ngIf=\"topBarService.getTopBarItem().firstName!=null && topBarService.getTopBarItem().lastName!=null\">\r\n                  <mat-icon>account_circle</mat-icon> \r\n                    <button mat-icon-button [matMenuTriggerFor]=\"menu\">\r\n                      <span class=\"welcome-txt\">Welcome, <span class=\"user-name\">{{topBarService.getTopBarItem().firstName}} {{topBarService.getTopBarItem().lastName}}</span></span><i class=\"fa fa-caret-down\" aria-hidden=\"true\"></i>\r\n                    </button>\r\n                    <mat-menu #menu=\"matMenu\">\r\n                      <button mat-menu-item>\r\n                        <span>Change Password</span>\r\n                      </button>\r\n                      <button mat-menu-item (click)=\"logOut()\">\r\n                        <span>Logout</span>\r\n                      </button>\r\n                    </mat-menu> \r\n                    <!-- <img src=\"assets/user.jpg\" class=\"rounded-circle img-fluid user-img\">\r\n                    <div class=\"dropdown\">\r\n                      <a class=\"dropdownWelcomeLink\"><span class=\"welcome-txt\">Welcome, <span class=\"user-name\">{{topBarService.getTopBarItem().firstName}} {{topBarService.getTopBarItem().lastName}}</span></span><i class=\"fa fa-caret-down\" aria-hidden=\"true\"></i></a>\r\n                      <div class=\"dropdown-content\">\r\n                        <a>Edit Profile</a>\r\n                        <a>Change Password</a>\r\n                        <a (click)=\"logOut()\">Logout</a>\r\n                      </div>\r\n                    </div>  -->                \r\n                </div> \r\n         </div>                \r\n    </div>\r\n  </div>\r\n\r\n  <div class=\"row\" *ngIf=\"topBarService.getTopBarItem()== null\">\r\n    <div class=\"col-7 mainTopBarLogo\">\r\n      <div class=\"logoContainer\">\r\n        <a>\r\n          <img src=\"assets/MgBedBank.png\" alt=\"MG Bedbank\" class=\"mg-Bedbank\" title=\"MG Bedbank\" />\r\n        </a>\r\n      </div>\r\n    </div>\r\n  </div>\r\n</div>\r\n"

/***/ }),

/***/ "../../../../../src/app/framework/fw/top-bar/top-bar.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return TopBarComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__services_top_bar_service__ = __webpack_require__("../../../../../src/app/framework/fw/services/top-bar.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__users_user_account_api__ = __webpack_require__("../../../../../src/app/framework/fw/users/user-account-api.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var TopBarComponent = (function () {
    function TopBarComponent(topBarService, userAccountApi) {
        this.topBarService = topBarService;
        this.userAccountApi = userAccountApi;
    }
    TopBarComponent.prototype.ngOnInit = function () {
    };
    TopBarComponent.prototype.onApplicationChange = function ($event) {
        this.topBarService.onAppChange($event);
    };
    TopBarComponent.prototype.logOut = function () {
        this.userAccountApi.logOut();
    };
    TopBarComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            // tslint:disable-next-line:component-selector
            selector: 'fw-top-bar',
            template: __webpack_require__("../../../../../src/app/framework/fw/top-bar/top-bar.component.html"),
            styles: [__webpack_require__("../../../../../src/app/framework/fw/top-bar/top-bar.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__services_top_bar_service__["b" /* TopBarService */], __WEBPACK_IMPORTED_MODULE_2__users_user_account_api__["a" /* UserAccountApi */]])
    ], TopBarComponent);
    return TopBarComponent;
}());



/***/ }),

/***/ "../../../../../src/app/framework/fw/unauthorized/unauthorized.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/framework/fw/unauthorized/unauthorized.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"container\">\n  <div class=\"row\">\n      <div class=\"col-md-12\">\n          <div class=\"alert alert-danger mt-5\" role=\"alert\">\n              User has been deactivated. Please contact support\n          </div>\n      </div>\n  </div>\n</div>"

/***/ }),

/***/ "../../../../../src/app/framework/fw/unauthorized/unauthorized.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return UnauthorizedComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var UnauthorizedComponent = (function () {
    function UnauthorizedComponent() {
    }
    UnauthorizedComponent.prototype.ngOnInit = function () {
    };
    UnauthorizedComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-unauthorized',
            template: __webpack_require__("../../../../../src/app/framework/fw/unauthorized/unauthorized.component.html"),
            styles: [__webpack_require__("../../../../../src/app/framework/fw/unauthorized/unauthorized.component.css")]
        }),
        __metadata("design:paramtypes", [])
    ], UnauthorizedComponent);
    return UnauthorizedComponent;
}());



/***/ }),

/***/ "../../../../../src/app/framework/fw/users/change-password/change-password.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/framework/fw/users/change-password/change-password.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"example-container\">\n\n\t<mat-form-field>\n\t\t<input matInput placeholder=\"Old password\" [formControl]=\"oldpassword\" [type]=\"hide1 ? 'password' : 'text'\" required>\n\t\t<mat-icon matSuffix (click)=\"hide1 = !hide1\">{{hide1 ? 'visibility' : 'visibility_off'}}</mat-icon>\n\t\t<mat-error *ngIf=\"oldpassword.invalid\">{{getErrorMessage1()}}</mat-error>\n\t</mat-form-field>\n\n\t<mat-form-field hintLabel=\"Min 6 characters\">\n\t\t<input matInput placeholder=\"New password\" #newPassword [formControl]=\"newpassword\" [type]=\"hide2 ? 'password' : 'text'\"\n\t\t name=\"newPassword\" (keyup)=\"checkLength(newPassword.value)\" required>\n\t\t<mat-icon matSuffix (click)=\"hide2 = !hide2\">{{hide2 ? 'visibility' : 'visibility_off'}}</mat-icon>\n\t\t<mat-error *ngIf=\"newpassword.invalid\">{{getErrorMessage2()}}</mat-error>\n\t</mat-form-field>\n\n  <span *ngIf=\"invalid\">Password must be at least 6 characters long</span>\n\t<mat-form-field>\n\t\t<input matInput placeholder=\"Confirm password\" #confirmPassword [formControl]=\"confirmpassword\" [type]=\"hide3 ? 'password' : 'text'\"\n\t\t name=\"confirmPassword\" (keyup)=\"checkEqual(newPassword.value,confirmPassword.value)\" required>\n\t\t<mat-icon matSuffix (click)=\"hide3 = !hide3\">{{hide3 ? 'visibility' : 'visibility_off'}}</mat-icon>\n\t</mat-form-field>\n\t<span *ngIf=\"!same && (confirmpassword.dirty || confirmpassword.touched)\">Passwords do not match</span>\n\n\t<div>\n\t\t<button [disabled]=\"oldpassword.invalid || invalid || !same\" mat-raised-button type=\"submit\">Submit</button>\n\t\t<button mat-raised-button>Cancel</button>\n\t</div>\n\n</div>"

/***/ }),

/***/ "../../../../../src/app/framework/fw/users/change-password/change-password.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ChangePasswordComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_forms__ = __webpack_require__("../../../forms/esm5/forms.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var ChangePasswordComponent = (function () {
    function ChangePasswordComponent() {
        this.hide1 = true;
        this.hide2 = true;
        this.hide3 = true;
        this.oldpassword = new __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormControl"]('', [__WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].required]);
        this.newpassword = new __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormControl"]('', [__WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].required]);
        this.confirmpassword = new __WEBPACK_IMPORTED_MODULE_1__angular_forms__["FormControl"]('', [__WEBPACK_IMPORTED_MODULE_1__angular_forms__["Validators"].required]);
    }
    ChangePasswordComponent.prototype.ngOnInit = function () {
    };
    ChangePasswordComponent.prototype.getErrorMessage1 = function () {
        // return this.oldpassword.hasError('required') ? 'You must enter a value' : '';
    };
    ChangePasswordComponent.prototype.getErrorMessage2 = function () {
        // return this.oldpassword.hasError('required') ? 'You must enter a value' : '';
    };
    ChangePasswordComponent.prototype.getErrorMessage3 = function () {
    };
    ChangePasswordComponent.prototype.checkLength = function (newPassword) {
        if (newPassword.length < 6) {
            this.invalid = true;
        }
        else {
            this.invalid = false;
        }
    };
    ChangePasswordComponent.prototype.checkEqual = function (newPassword, confirmPassword) {
        if (newPassword === confirmPassword) {
            this.same = true;
        }
        else {
            this.same = false;
        }
    };
    ChangePasswordComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            // tslint:disable-next-line:component-selector
            selector: 'fw-change-password',
            template: __webpack_require__("../../../../../src/app/framework/fw/users/change-password/change-password.component.html"),
            styles: [__webpack_require__("../../../../../src/app/framework/fw/users/change-password/change-password.component.css")]
        }),
        __metadata("design:paramtypes", [])
    ], ChangePasswordComponent);
    return ChangePasswordComponent;
}());



/***/ }),

/***/ "../../../../../src/app/framework/fw/users/user-account-api.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return UserAccountApi; });
var UserAccountApi = (function () {
    function UserAccountApi() {
    }
    return UserAccountApi;
}());



/***/ }),

/***/ "../../../../../src/assets/templateimages/hover.jpg":
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__.p + "hover.0e3c70171d1f4cf74ed3.jpg";

/***/ }),

/***/ "../../../../../src/assets/templateimages/normal.jpg":
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__.p + "normal.2726b3cd07f3025ee2ee.jpg";

/***/ }),

/***/ "../../../../../src/environments/environment.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return environment; });
// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.
var environment = {
    production: false
};


/***/ }),

/***/ "../../../../../src/main.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_platform_browser_dynamic__ = __webpack_require__("../../../platform-browser-dynamic/esm5/platform-browser-dynamic.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__app_app_module__ = __webpack_require__("../../../../../src/app/app.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__environments_environment__ = __webpack_require__("../../../../../src/environments/environment.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_hammerjs__ = __webpack_require__("../../../../hammerjs/hammer.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_hammerjs___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_4_hammerjs__);





if (__WEBPACK_IMPORTED_MODULE_3__environments_environment__["a" /* environment */].production) {
    Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["enableProdMode"])();
}
Object(__WEBPACK_IMPORTED_MODULE_1__angular_platform_browser_dynamic__["a" /* platformBrowserDynamic */])().bootstrapModule(__WEBPACK_IMPORTED_MODULE_2__app_app_module__["a" /* AppModule */])
    .catch(function (err) { return console.log(err); });


/***/ }),

/***/ 0:
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__("../../../../../src/main.ts");


/***/ })

},[0]);
//# sourceMappingURL=main.bundle.js.map