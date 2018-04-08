import {MarketIncludedOrExcludedCountryViewModel} from './marketincludedorexcludedcountryviewmodel';

export class MarketDetailsViewModel {
    marketId: number;
    marketName: string;
    IncludedMarketList: MarketIncludedOrExcludedCountryViewModel[];
    ExcludedMarketList: MarketIncludedOrExcludedCountryViewModel[];
}
