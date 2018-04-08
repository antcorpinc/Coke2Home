// <copyright file="BaseViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    using MG.Jarvis.Api.Extranet.Helper;

    /// <summary>
    /// Base View Model
    /// </summary>
    public class BaseViewModel
    {
        public int HotelId { get; set; }

        public ObjectState? ObjectState { get; set; }
    }
}
