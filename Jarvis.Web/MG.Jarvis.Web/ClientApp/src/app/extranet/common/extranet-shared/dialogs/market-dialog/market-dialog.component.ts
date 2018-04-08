import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { FormArray, FormBuilder, FormGroup, Validators, FormControl, AbstractControl } from '@angular/forms';
import { MatSnackBar } from '@angular/material';
import { MarketCountryViewModel } from '../../../../viewmodel/common/marketcountryviewmodel';
import { MarketContinentViewModel } from '../../../../viewmodel/common/marketcontinentviewmodel';
import { MarketDetailsViewModel } from '../../../../viewmodel/common/marketdetailsviewmodel';
import { MarketDataService } from '../../../../common/extranet-shared/services/market-data.service';
import { MarketViewModel } from '../../../../viewmodel/common/marketviewmodel';

@Component({
  selector: 'app-market-dialog',
  templateUrl: './market-dialog.component.html',
  styleUrls: ['./market-dialog.component.css']
})
export class MarketDialogComponent implements OnInit {
  public title: string;
  isIncludedSelected: boolean;
  isExcludedSelected: boolean;
  showIncludedCountries: MarketCountryViewModel[] = [];
  showExcludedCountries: MarketCountryViewModel[] = [];
  selectedOptions: MarketCountryViewModel[] = [];
  selectedOptions2: MarketCountryViewModel[] = [];
  searchbox: string;
  searchbox2: string;
  continents: MarketContinentViewModel[] = [];
  excludedCountries: MarketCountryViewModel[] = [];
  includedCountries: MarketCountryViewModel[] = [];
  countries: MarketCountryViewModel[] = [];
  marketList: MarketViewModel[];
  marketDetails: MarketDetailsViewModel = <MarketDetailsViewModel>{};
  newMarketName: string;
  isBlankflag: boolean;
  isBlankError: string;
  isMarketNameExist: boolean;
  isMarketNameExistError: string;

  marketForm: FormGroup;

  constructor(public dialogRef: MatDialogRef<MarketDialogComponent>, private marketDataService: MarketDataService,
    public snackBar: MatSnackBar) { }

  ngOnInit() {
    this.includedCountries = this.countries;
    this.isIncludedSelected = false;
    this.isExcludedSelected = false;
    this.getMarkets();

    this.marketForm = new FormGroup({
      marketId: new FormControl(0),
      marketName: new FormControl('', Validators.required)
    });
  }

  getMarkets() {
    this.marketDataService.getMarkets().subscribe(marketList => {
      this.marketList = marketList;
    });
  }

  getContinentOfIncludedCountries(continent: string) {
    this.showIncludedCountries = [];
    this.isIncludedSelected = true;
    this.includedCountries.forEach(item => {
      if (item.continentName === continent) {
        this.showIncludedCountries.push(item);
      }
    });
    if ((this.includedCountries.length > 0) && (this.excludedCountries.length > 0)) {
      this.isBlankflag = true;
    } else {
      this.isBlankflag = false;
    }
  }

  getContinentOfExcludedCountries(continent: string) {
    this.showExcludedCountries = [];
    this.isExcludedSelected = true;
    if (this.excludedCountries != null) {
      this.excludedCountries.forEach(item => {
        if (item.continentName === continent) {
          this.showExcludedCountries.push(item);
        }
      });
    }
    if ((this.includedCountries.length > 0) && (this.excludedCountries.length > 0)) {
      this.isBlankflag = true;
    } else {
      this.isBlankflag = false;
    }
  }

  addexcludedCountries() {
    this.selectedOptions.forEach((country) => {
        this.includedCountries.splice(this.includedCountries.indexOf(country), 1);
        this.excludedCountries.push(country);
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
    } else {
      this.isBlankflag = false;
    }
  }

  addincludedCountries() {
    this.selectedOptions2.forEach((country) => {
        this.excludedCountries.splice(this.excludedCountries.indexOf(country), 1);
        this.includedCountries.push(country);
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
    } else {
      this.isBlankflag = false;
    }
  }

  excludeAllCountries() {
    this.selectedOptions = [];
    if (this.isIncludedSelected === false) {
      if (this.excludedCountries.length === 0 && this.includedCountries.length !== 0) {
        this.excludedCountries = this.includedCountries;
        this.includedCountries = [];
        this.isExcludedSelected = false;
      }
      if (this.excludedCountries.length !== 0 && this.includedCountries.length !== 0) {
        for (const country of this.includedCountries) {
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
      this.showIncludedCountries.forEach((country) => {
          this.includedCountries.splice(this.includedCountries.indexOf(country), 1);
      });
      this.isExcludedSelected = false;
      this.isIncludedSelected = false;
      this.showIncludedCountries = [];
    }
    if (this.isIncludedSelected === true && this.excludedCountries.length !== 0) {
      for (const country of this.showIncludedCountries) {
        this.excludedCountries.push(country);
      }
      this.showIncludedCountries.forEach((country) => {
        this.includedCountries.splice(this.includedCountries.indexOf(country), 1);
    });
      this.isExcludedSelected = false;
      this.isIncludedSelected = false;
      this.showIncludedCountries = [];
    }
    if ((this.includedCountries.length > 0) && (this.excludedCountries.length > 0)) {
      this.isBlankflag = true;
    } else {
      this.isBlankflag = false;
    }
  }

  includeAllCountries() {
    this.selectedOptions2 = [];
    if (this.isExcludedSelected === false) {
      if (this.includedCountries.length !== 0 && this.excludedCountries.length !== 0) {
        for (const country of this.excludedCountries) {
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
      this.showExcludedCountries.forEach((country) => {
          this.excludedCountries.splice(this.excludedCountries.indexOf(country), 1);
      });
      this.isExcludedSelected = false;
      this.isIncludedSelected = false;
      this.showExcludedCountries = [];
    }
    if (this.isExcludedSelected && this.includedCountries.length !== 0) {
      for (const country of this.showExcludedCountries) {
        this.includedCountries.push(country);
      }
      this.showExcludedCountries.forEach((country) => {
        this.excludedCountries.splice(this.excludedCountries.indexOf(country), 1);
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
    } else {
      this.isBlankflag = false;
    }
  }

  selectIncludedCountries(country) {
    let isBoolean;
    let isRemoveCountry  = false;
    if (this.selectedOptions.length === 0) {
      this.selectedOptions.push(country);
    } else {
      this.selectedOptions.forEach(data => {
        if (country.countryId !== data.countryId ) {
          isBoolean = true;
        } else {
          isBoolean = false;
          isRemoveCountry = true;
          this.selectedOptions.splice(this.selectedOptions.indexOf(country), 1);
        }
      });
    }
    if (isBoolean === true && isRemoveCountry === false) {
      this.selectedOptions.push(country);
    }
  }

  selectExcludedCountries(country) {
    let isBoolean;
    let isRemoveCountry  = false;
    if (this.selectedOptions2.length === 0) {
      this.selectedOptions2.push(country);
    } else {
      isBoolean = false;
      this.selectedOptions2.forEach(data => {
        if (country.countryId !== data.countryId ) {
          isBoolean = true;
        } else {
          isBoolean = false;
          isRemoveCountry = true;
          this.selectedOptions2.splice(this.selectedOptions2.indexOf(country), 1);
        }
      });
    }
    if (isBoolean === true && isRemoveCountry === false) {
      this.selectedOptions2.push(country);
    }
  }

  saveMarket() {
    this.newMarketName =  this.marketForm.controls.marketName.value;
    this.isMarketNameExist = false;

    this.marketList.forEach(data => {
      if (this.newMarketName === data.marketName) {
        this.isMarketNameExist = true;
      }
    });

    if (this.isBlankflag) {
      if (!this.isMarketNameExist) {
        const markettypes = Object.assign({}, this.marketDetails, this.marketForm.value);
        markettypes.IncludedMarketList = this.includedCountries;
        markettypes.ExcludedMarketList = this.excludedCountries;

        this.marketDataService.addMarket(markettypes as MarketDetailsViewModel)
        .subscribe(data => {
            this.dialogRef.close(true);
            this.snackBar.open('Market Created Successfully', 'close', { duration: 5000 });
        });
      } else {
        this.isMarketNameExistError = 'Market name already exist.';
      }
    } else {
      this.isBlankError = 'Country list can not be empty.';
    }
   }

}
