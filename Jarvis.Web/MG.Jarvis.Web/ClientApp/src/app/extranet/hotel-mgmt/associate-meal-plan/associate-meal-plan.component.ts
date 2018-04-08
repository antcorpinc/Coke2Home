import { Component, OnInit } from '@angular/core';
import { FormArray, FormGroup, Validators, FormControl } from '@angular/forms';
import { MealPlanViewModel } from '../../viewmodel/associatemealplanviewmodel/mealplanviewmodel';
import { MealOptionViewModel } from '../../viewmodel/associatemealplanviewmodel/mealoptionviewmodel';
import { CuisineViewModel } from '../../viewmodel/associatemealplanviewmodel/cuisineviewmodel';
import { MealTypeViewModel } from '../../viewmodel/associatemealplanviewmodel/mealtypeviewmodel';
import { ActivatedRoute, Router } from '@angular/router';
import { CuisineTypeViewModel } from '../../viewmodel/associatemealplanviewmodel/cuisinetypeviewmodel';
import { AssociateMealplanDataService } from '../../common/extranet-shared/services/associate-mealplan-data.service';
import { CONSTANTS } from '../../../common/constants';
import { ObjectState } from '../../../common/enums';
import { MatSnackBar } from '@angular/material';
import { ExtranetLookupService } from '../../common/extranet-shared/services/extranet-lookup';
import { HotelCurrencyViewModel } from '../../viewmodel/common/hotelcurrencyviewmodel';

@Component({
  selector: 'app-associate-meal-plan',
  templateUrl: './associate-meal-plan.component.html',
  styleUrls: ['./associate-meal-plan.component.css']
})
export class AssociateMealPlanComponent implements OnInit {

  associateMealPlanForm: FormGroup;
  associatedMealPlans: MealPlanViewModel[] = [];
  associatedMealPlansSave: MealPlanViewModel[];
  mealPlanOperation: string;
  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;

  mealTypes: MealTypeViewModel[];
  cuisineTypes: CuisineTypeViewModel[];
  hotelCurrency: HotelCurrencyViewModel[];
  hotelId: number;
  isMealplanExits: boolean;
  currencyCode: string;

  constructor(private activatedRoute: ActivatedRoute, private router: Router, private mealplanService: AssociateMealplanDataService,
    public snackBar: MatSnackBar, private extranetLookupService: ExtranetLookupService) { }

  ngOnInit() {
    window.scrollTo(0, 0);
    this.hotelId = this.activatedRoute.parent.snapshot.params['id'];
    this.getAssociatedMealPlans();

    this.mealplanService.isMealPlanExits().subscribe(isMealplanExits => {
      this.isMealplanExits = isMealplanExits.result;
      if (this.isMealplanExits === false) {
        this.mealPlanOperation = CONSTANTS.operation.create;
      } else {
        this.mealPlanOperation = CONSTANTS.operation.edit;
        this.getMealPlan();
      }
    });

  }

  getAssociatedMealPlans() {
    this.hotelCurrency = this.activatedRoute.snapshot.data['HotelCurrencyData'];
    this.mealTypes = this.activatedRoute.snapshot.data['mealTypesData'];
    this.cuisineTypes = this.activatedRoute.snapshot.data['cuisineTypesData'];
    this.currencyCode = this.hotelCurrency[0].currencyCode;

    this.associateMealPlanForm = new FormGroup({
      associatedMealPlanArray: this.buildMealPlanForm()
    }
    );
  }

  get associatedMealPlanArray(): FormArray {
    return <FormArray>this.associateMealPlanForm.get('associatedMealPlanArray');
  }
  getcuisineOptions(mealTypeIndex: number): FormArray {
    return <FormArray>this.associatedMealPlanArray.controls[mealTypeIndex].
      get('mealPlanOptions').get('cuisineOptions');
  }

  buildMealPlanForm() {
    let mealPlanArray: FormArray;
    let mealPlanGroup: FormGroup;
    this.mealTypes.forEach(mealtype => {
      mealPlanGroup = new FormGroup({
        hotelId: new FormControl(this.hotelId),
        mealId: new FormControl(mealtype.id),
        mealName: new FormControl(mealtype.meal),
        isSelected: new FormControl(mealtype.isSelected),
        objectState: new FormControl(ObjectState.Unchanged),
        mealPlanOptions: this.buildPlanOptions()
      });
      if (mealPlanArray === null || mealPlanArray === undefined) {
        mealPlanArray = new FormArray([mealPlanGroup]);
      } else {
        mealPlanArray.push(mealPlanGroup);
      }
    });
    return mealPlanArray;
  }

  buildPlanOptions(): FormGroup {
    let mealPlanOptionsFormGroup: FormGroup;
    mealPlanOptionsFormGroup = new FormGroup({
      currencyId: new FormControl(this.hotelCurrency[0].currencyId),
      price: new FormControl(0, Validators.required),
      objectState: new FormControl(ObjectState.Unchanged),
      cuisineOptions: this.buildCuisineTypes()
    });
    return mealPlanOptionsFormGroup;
  }

  buildCuisineTypes(): FormArray {
    let cuisineArray: FormArray;
    let cuisineGroup: FormGroup;

    this.cuisineTypes.forEach(cuisine => {
      cuisineGroup = new FormGroup({
        id: new FormControl(cuisine.id),
        cusine: new FormControl(cuisine.cusine),
        isSelected: new FormControl(cuisine.isSelected),
        objectState: new FormControl(ObjectState.Unchanged)
      });

      if (cuisineArray === null || cuisineArray === undefined) {
        cuisineArray = new FormArray([cuisineGroup]);
      } else {
        cuisineArray.push(cuisineGroup);
      }
    });
    return cuisineArray;
  }

  saveMealPlan() {
    this.associatedMealPlansSave = Object.assign([], this.associatedMealPlans,
      this.associateMealPlanForm.value.associatedMealPlanArray);

    this.updateObjectState();
    this.associatedMealPlansSave.forEach(mealplan => {
      if (mealplan.isSelected === false) {
        mealplan.isSelected = false;
        mealplan.mealPlanOptions.price = 0;
        mealplan.mealPlanOptions.cuisineOptions.forEach(cuisine => {
          cuisine.isSelected = false;
        });
      }
    });

    if (this.checkIfAllUnchanged()) {
      this.router.navigate(['hotelmgmt/hotel', this.hotelId, this.edit, 'profilecompl']);
      window.scrollTo(0, 0);
    } else {
      this.mealplanService.addMealPlan(this.associatedMealPlansSave as MealPlanViewModel[])
        .subscribe(data => {
          this.router.navigate(['hotelmgmt/hotel', this.hotelId, this.edit, 'profilecompl']);
          this.snackBar.open('Associate Meal Plan Saved Successfully', '',
            { duration: 8000, verticalPosition: 'top', panelClass: 'showSnackBar' });
          window.scrollTo(0, 0);
        }
        );
    }
  }


  updateObjectState() {
    if (this.mealPlanOperation === CONSTANTS.operation.create) {
      this.associatedMealPlansSave.forEach(mealplan => {
        if (mealplan.isSelected === true) {
          mealplan.objectState = ObjectState.Added;
          mealplan.mealPlanOptions.objectState = ObjectState.Added;
          mealplan.mealPlanOptions.cuisineOptions.forEach(cuisine => {
            if (cuisine.isSelected === true) {
              cuisine.objectState = ObjectState.Added;
            } else {
              cuisine.objectState = ObjectState.Unchanged;
            }
          });
        } else {
          mealplan.objectState = ObjectState.Unchanged;
        }
      });
    } else if (this.mealPlanOperation === CONSTANTS.operation.edit) {
      // Iterate through the associatedMealPlansSave  meal types, which has all mealTypes
      this.associatedMealPlansSave.forEach((mealplan, index) => {

        let initialMealTypeState = false;
        // Check whether this meal Id present in intial Get - Get has only the selected elements
        const mealPlanInitialIndex = this.associatedMealPlans.findIndex((val, planindex) =>
          (val.mealId === mealplan.mealId) && (val.isSelected));
        if (mealPlanInitialIndex >= 0) {
          initialMealTypeState = true;
        }
        // Condition 1 --> When !present in initialMealTypeState and present in savemealPlan-isSelected
        // Then ADD in associatedMealPlansSave
        if (!initialMealTypeState && mealplan.isSelected) {
          this.associatedMealPlansSave[index].objectState = ObjectState.Added;
          this.associatedMealPlansSave[index].mealPlanOptions.objectState = ObjectState.Added;
          this.associatedMealPlansSave[index].mealPlanOptions.cuisineOptions.forEach(
            cuisine => {
              if (cuisine.isSelected === true) {
                cuisine.objectState = ObjectState.Added;
              } else {
                cuisine.objectState = ObjectState.Unchanged;
              }
            });
        } //  // Condition 2 --> When present in initialMealTypeState and !present in isSelected
        // Then DELETE in associatedMealPlansSave
        // tslint:disable-next-line:one-line
        else if (initialMealTypeState && !mealplan.isSelected) {
          this.associatedMealPlansSave[index].objectState = ObjectState.Deleted;
          this.associatedMealPlansSave[index].mealPlanOptions.objectState = ObjectState.Deleted;
          this.associatedMealPlansSave[index].mealPlanOptions.cuisineOptions.forEach(
            cuisine => cuisine.objectState = ObjectState.Deleted
          );
        }
        //  // Condition 3 --> When present in initialMealTypeState and present in isSelected
        // state is unchanged but child states needs to be computed
        // tslint:disable-next-line:one-line
        else if (initialMealTypeState && mealplan.isSelected) {
          this.associatedMealPlansSave[index].objectState = ObjectState.Unchanged;
          if ((this.associatedMealPlans[mealPlanInitialIndex].mealPlanOptions.currencyId
            !== this.associatedMealPlansSave[index].mealPlanOptions.currencyId) ||
            (this.associatedMealPlans[mealPlanInitialIndex].mealPlanOptions.price
              !== this.associatedMealPlansSave[index].mealPlanOptions.price)) {
            this.associatedMealPlansSave[index].mealPlanOptions.objectState = ObjectState.Modified;
          } else {
            this.associatedMealPlansSave[index].mealPlanOptions.objectState = ObjectState.Unchanged;
          }

          // For Each Cuisines -Compare the isSelected & update the status accordingly
          this.associatedMealPlansSave[index].mealPlanOptions.cuisineOptions.forEach((cuisine, cuiIndex) => {
            let initialCuisineTypeState = false;
            const cuisineOptionInitialIndex = this.associatedMealPlans[mealPlanInitialIndex]
              .mealPlanOptions.cuisineOptions.findIndex((val, cuisineindex) =>
                (val.id === cuisine.id) && (val.isSelected));
            if (cuisineOptionInitialIndex >= 0) {
              initialCuisineTypeState = true;
            }

            // Condition 1 --> When !present in initialCuisineTypeState and present in cuisine-isSelected
            // Then ADD in associatedMealPlansSave
            if (!initialCuisineTypeState && cuisine.isSelected) {
              this.associatedMealPlansSave[index].mealPlanOptions.cuisineOptions[cuiIndex].objectState
                = ObjectState.Added;
            }

            // Condition 1 --> When present in initialCuisineTypeState and !present in cuisine-isSelected
            // Then DELETE in associatedMealPlansSave
            // tslint:disable-next-line:one-line
            else if (initialCuisineTypeState && !cuisine.isSelected) {
              this.associatedMealPlansSave[index].mealPlanOptions.cuisineOptions[cuiIndex].objectState
                = ObjectState.Deleted;
            } else {
              this.associatedMealPlansSave[index].mealPlanOptions.cuisineOptions[cuiIndex].objectState
                = ObjectState.Unchanged;
            }
          });
        }
      });
    }
  }

  private getMealPlan() {
    this.mealplanService.getMealPlan(this.hotelId).subscribe(associateMealPlanData => {
      this.associatedMealPlans = associateMealPlanData;
      associateMealPlanData.forEach(mealdata => {
        this.associatedMealPlanArray.controls.forEach((control, index) => {
          if (control.get('mealId').value === mealdata.mealId) {
            // Here means only the set values from database will be updated in model
            control.get('isSelected').setValue(mealdata.isSelected);
            control.get('mealPlanOptions').get('currencyId').setValue(mealdata.mealPlanOptions.currencyId);
            control.get('mealPlanOptions').get('price').setValue(mealdata.mealPlanOptions.price);

            mealdata.mealPlanOptions.cuisineOptions.forEach((cuisine) => {
              this.getcuisineOptions(index).controls.forEach(item => {
                // Check for cuisine Id
                if (item.get('id').value === cuisine.id) {
                  item.get('isSelected').setValue(cuisine.isSelected);
                }
              });
            });
          }
        });
      });
    });
  }


  resetOnUncheck(event, mealId) {
    let isExist = false;
    if (event.checked === false) {
      this.associatedMealPlans.forEach(mealplan => {
        if (mealplan.mealId === mealId) {
          isExist = true;
        }

        if (!isExist) {
          this.associatedMealPlanArray.controls.forEach((control, index) => {
            if (control.get('mealId').value === mealId) {
              control.get('isSelected').setValue(false);
              control.get('mealPlanOptions').get('price').setValue(0);
              this.getcuisineOptions(index).controls.forEach((cuisine) => {
                cuisine.get('isSelected').setValue(false);
              });
            }
          });
        }
      });
    }
  }

  cancelMealPlan() {
    this.router.navigate(['hotelmgmt/hotel', this.hotelId, this.edit, 'profilecompl']);
    window.scrollTo(0, 0);
  }

  checkIfAllUnchanged() {
    const allUnchangedCuisineArray = [];
    let allUnchangedMealPlan;
    const allUnchangedMealPlanArray = [];
    let allUnchangedCuisine;

    this.associatedMealPlansSave.forEach((mealplan, j) => {
      if (mealplan.mealPlanOptions.objectState === ObjectState.Unchanged && mealplan.objectState === ObjectState.Unchanged) {
        allUnchangedMealPlanArray[j] = true;
      } else {
        allUnchangedMealPlanArray[j] = false;
      }

      allUnchangedCuisineArray[j] = mealplan.mealPlanOptions.cuisineOptions.every(function (cuisine: any) {
        return cuisine.objectState === ObjectState.Unchanged;
      });
    });

    allUnchangedCuisine = allUnchangedCuisineArray.every(function (item: any) {
      return item === true;
    });

    allUnchangedMealPlan = allUnchangedMealPlanArray.every(function (item: any) {
      return item === true;
    });

    if (allUnchangedCuisine === true && allUnchangedMealPlan === true) {
      return true;
    } else {
      return false;
    }
  }

}
