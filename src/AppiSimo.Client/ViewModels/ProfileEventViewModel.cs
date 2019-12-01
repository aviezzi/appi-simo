namespace AppiSimo.Client.ViewModels
{
    using Model;

    public class ProfileEventViewModel : ViewModelBase<ProfileEvent>
    {
        public ProfileViewModel Profile { get; set; }

        public decimal Price
        {
            get => Entity.Price;
            set => Entity.Price = value;
        }

        public bool Paid
        {
            get => Entity.Paid;
            set => Entity.Paid = value;
        }

        public ProfileEventViewModel(ProfileEvent entity) : base(entity)
        {
            Profile = new ProfileViewModel(Entity.Profile);
        }
    }
}