import { Pipe, PipeTransform } from '@angular/core';
import { MarketCountryViewModel } from '../../viewmodel/common/marketcountryviewmodel';

@Pipe({
    name: 'searchCountry'
})

export class MarketCountryFilterPipe implements PipeTransform {
    transform(countries: MarketCountryViewModel[], searchText: string): MarketCountryViewModel[] {
        if (!countries || !searchText) {
            return countries;
        } else {
            searchText = searchText.toLowerCase();
            return countries.filter(country => country.countryName.toLowerCase().includes(searchText));
        }
    }
}
