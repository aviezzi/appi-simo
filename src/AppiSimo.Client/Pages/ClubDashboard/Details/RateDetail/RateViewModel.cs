namespace AppiSimo.Client.Pages.ClubDashboard.Details.RateDetail
{
    using System;
    using System.Collections.Generic;
    using Model;

    public class RateViewModel : IDetailViewModel<Rate>
    {
        public IEnumerable<Court> Courts { get; }
        public Rate Entity { get; }

        public RateViewModel()
            : this(new List<Court>())
        {
        }

        public RateViewModel(IEnumerable<Court> courts)
            : this(courts, new Rate())
        {
        }

        public RateViewModel(IEnumerable<Court> courts, Rate rate)
        {
            Courts = courts ?? throw new NullReferenceException("Courts cannot be null.");
            Entity = rate ?? throw new NullReferenceException("Rate cannot be null.");
        }

        public bool IsNew => Entity.Id == Guid.Empty;

    }
}