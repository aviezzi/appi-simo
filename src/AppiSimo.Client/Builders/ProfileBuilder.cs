namespace AppiSimo.Client.Builders
{
    using Abstract;
    using Model.Auth;
    using System;

    public class ProfileBuilder : IQueryBuilder<Profile>
    {
        public string Fields => "id, name, surname, gender, address, email, birthdate";

        public string BuildCreate(Profile entity) => throw new NotImplementedException();

        public string BuildUpdate(Profile entity) => throw new NotImplementedException();
    }
}