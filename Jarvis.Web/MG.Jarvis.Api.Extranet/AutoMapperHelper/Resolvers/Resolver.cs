using AutoMapper;
using MG.Jarvis.Api.Extranet.Models.ViewModels;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.Policies;
using System;

namespace MG.Jarvis.Api.Extranet.AutoMapperHelper.Resolvers
{
    public class Resolver
    {

    }
    public class CheckInFromResolver : IValueResolver<HotelDetailsViewModel, Hotel, TimeSpan>
    {
        /// <summary>
        /// hotel name resolver
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="destMember"></param>
        /// <param name="context"></param>
        /// <returns>resolved hotel name</returns>
        public TimeSpan Resolve(HotelDetailsViewModel source, Hotel destination, TimeSpan destMember, ResolutionContext context)
        {
            DateTime dt;
            if (DateTime.TryParse(source.CheckInFrom.ToString(), out dt))
            {
                destination.CheckInFrom = dt.TimeOfDay;
            }
            return destination.CheckInFrom;
        }


    }

    //public class CheckInToResolver : IValueResolver<HotelDetailsViewModel, Hotel, TimeSpan?>
    //{
    //    /// <summary>
    //    /// hotel name resolver
    //    /// </summary>
    //    /// <param name="source"></param>
    //    /// <param name="destination"></param>
    //    /// <param name="destMember"></param>
    //    /// <param name="context"></param>
    //    /// <returns>resolved hotel name</returns>
    //    public TimeSpan? Resolve(HotelDetailsViewModel source, Hotel destination, TimeSpan? destMember, ResolutionContext context)
    //    {
    //        DateTime dt;
    //        if (source.CheckInTo != null)
    //        {
    //            if (DateTime.TryParse(source.CheckInTo.ToString(), out dt))
    //            {
    //                destination.CheckInTo = dt.TimeOfDay;
    //            }
    //            return destination.CheckInTo;
    //        }
    //        else
    //            return null;
    //    }


    //}

    //public class CheckOutFromFromResolver : IValueResolver<HotelDetailsViewModel, Hotel, TimeSpan?>
    //{
    //    /// <summary>
    //    /// hotel name resolver
    //    /// </summary>
    //    /// <param name="source"></param>
    //    /// <param name="destination"></param>
    //    /// <param name="destMember"></param>
    //    /// <param name="context"></param>
    //    /// <returns>resolved hotel name</returns>
    //    public TimeSpan? Resolve(HotelDetailsViewModel source, Hotel destination, TimeSpan? destMember, ResolutionContext context)
    //    {
    //        DateTime dt;
    //        if (source.CheckOutFrom != null)
    //        {
    //            if (DateTime.TryParse(source.CheckOutFrom.ToString(), out dt))
    //            {
    //                destination.CheckOutFrom = dt.TimeOfDay;
    //            }
    //            return destination.CheckOutFrom;
    //        }
    //        else
    //            return null;
    //    }


    //}

    public class CheckOutToResolver : IValueResolver<HotelDetailsViewModel, Hotel, TimeSpan>
    {
        /// <summary>
        /// hotel name resolver
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="destMember"></param>
        /// <param name="context"></param>
        /// <returns>resolved hotel name</returns>
        public TimeSpan Resolve(HotelDetailsViewModel source, Hotel destination, TimeSpan destMember, ResolutionContext context)
        {
            DateTime dt;
            if (DateTime.TryParse(source.CheckOutTo.ToString(), out dt))
            {
                destination.CheckOutTo = dt.TimeOfDay;
            }
            return destination.CheckOutTo;
        }


    }

    #region hotel viewmodel resolver

    public class HotelCodeResolver : IValueResolver<HotelDetailsViewModel, Hotel, string>
    {
        /// <summary>
        /// hotelcode resolver
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="destMember"></param>
        /// <param name="context"></param>
        /// <returns>resolved hotel code</returns>
        public string Resolve(HotelDetailsViewModel source, Hotel destination, string destinationMember, ResolutionContext context)
        {
            return source.HotelCode;
        }
    }
    public class HotelIdResolver : IValueResolver<HotelDetailsViewModel, Hotel, int>
    {
        /// <summary>
        /// hotelid resolver
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="destMember"></param>
        /// <param name="context"></param>
        /// <returns>resolved hotel id</returns>
        public int Resolve(HotelDetailsViewModel source, Hotel destination, int destinationMember, ResolutionContext context)
        {
            return source.HotelId;
        }
    }
    public class HotelPaymentMethodRelationIdResolver : IValueResolver<HotelPaymentMethodRelationViewModel, HotelPaymentMethodRelation, int>
    {
        /// <summary>
        /// hotelpaymentmethodId resolver
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="destMember"></param>
        /// <param name="context"></param>
        /// <returns>resolved hotel method relation</returns>
        public int Resolve(HotelPaymentMethodRelationViewModel source, HotelPaymentMethodRelation destination, int destMember, ResolutionContext context)
        {
            return source.HotelPaymentMethodRelationId;
        }
    }
    public class HotelNameResolver : IValueResolver<HotelDetailsViewModel, Hotel, string>
    {
        /// <summary>
        /// hotel name resolver
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="destMember"></param>
        /// <param name="context"></param>
        /// <returns>resolved hotel name</returns>
        public string Resolve(HotelDetailsViewModel source, Hotel destination, string destMember, ResolutionContext context)
        {
            return source.HotelName;
        }
    }


    public class CancellationPolicyIdResolver : IValueResolver<CancellationPolicyViewModel, CancellationPolicy, int>
    {
        /// <summary>
        /// Cancellation policy Id resolver
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="destMember"></param>
        /// <param name="context"></param>
        /// <returns>Resolved Cancellation policy Id</returns>
        public int Resolve(CancellationPolicyViewModel source, CancellationPolicy destination, int destMember, ResolutionContext context)
        {
            return destination.Id = (int)source.CancellationPolicyId;
        }
    }
    public class CancellationPolicyClausesIdResolver : IValueResolver<CancellationPolicyClausesViewModel, CancellationPolicyClauses, int>
    {
        /// <summary>
        /// Cancellation policy Id resolver
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="destMember"></param>
        /// <param name="context"></param>
        /// <returns>Resolved Cancellation policy Id</returns>
        public int Resolve(CancellationPolicyClausesViewModel source, CancellationPolicyClauses destination, int destMember, ResolutionContext context)
        {
            return source.CancellationPolicyClausesId;
        }
    }

    #endregion hotel viewmodel resolver

    #region Contact viewmodel resolver

    public class ContactIdResolver : IValueResolver<ContactDetailsViewModel, Contacts, int>
    {
        /// <summary>
        /// contactid resolver
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="destMember"></param>
        /// <param name="context"></param>
        /// <returns>resolved contactid</returns>
        public int Resolve(ContactDetailsViewModel source, Contacts destination, int destMember, ResolutionContext context)
        {
            return source.ContactId;
        }
    }

    #endregion Contact viewmodel resolver

    #region HotelTaxRelation viewmodel resolver
    public class HotelTaxRelationIdResolver : IValueResolver<HotelTaxRelationViewModel, HotelTaxRelation, int>
    {
        /// <summary>
        /// tax applicabilityid resolver
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="destMember"></param>
        /// <param name="context"></param>
        /// <returns>resolved tax applicability id</returns>
        public int Resolve(HotelTaxRelationViewModel source, HotelTaxRelation destination, int destMember, ResolutionContext context)
        {
            return source.TaxApplicabilityId;
        }
    }

    #endregion HotelTaxRelation viewmodel resolver
}
