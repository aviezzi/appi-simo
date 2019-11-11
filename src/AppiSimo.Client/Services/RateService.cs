namespace AppiSimo.Client.Services
{
    using Abstract;
    using Extensions;
    using Model;
    using NodaTime;
    using System;
    using System.Linq;

    public class RateService : GraphQlServiceBase<Rate>
    {
        readonly ITypeConverter<LocalTime> _converter;

        protected override string Fields { get; } = "id, name, start, end, dailyRates { id, start, end, price }";

        protected override Func<Rate, string> CreateQuery => rate =>
            $@"{{
                ""rate"": {{
                    ""id"":""{rate.Id}"",
                    ""name"":""{rate.Name}"",
                    ""start"":""{rate.Start}"",
                    ""end"":""{rate.End}"",
                    ""dailyRates"": {{
                        ""create"": [{
                    string.Join(",", rate.DailyRates.Select(dr =>
                        "{" +
                        $@"""id"":""{Guid.NewGuid()}""," +
                        $@"""start"":""{_converter.FormatValueAsString(dr.Start)}""," +
                        $@"""end"":""{_converter.FormatValueAsString(dr.End)}""," +
                        $@"""price"":{dr.Price}" +
                        "}"))
                }]
                    }}
                }}
            }}";

        protected override Func<Rate, string> UpdateQuery => rate =>
        {
            var update = rate.DailyRates.Where(dailyRate => dailyRate.Id != Guid.Empty);
            var create = rate.DailyRates.Where(dailyRate => dailyRate.Id == Guid.Empty);

            return $@"{{
                    ""id"":""{rate.Id}"",
                    ""patch"":{{
                        ""name"":""{rate.Name}"",
                        ""start"":""{rate.Start}"",
                        ""end"":""{rate.End}"",
                        ""dailyRates"": {{
                            ""updateById"":[{
                    string.Join(",", update.Select(dr =>
                        "{" +
                        $@"""id"":""{dr.Id}""," +
                        @"""patch"":{" +
                        $@"""start"":""{_converter.FormatValueAsString(dr.Start)}""," +
                        $@"""end"":""{_converter.FormatValueAsString(dr.End)}""," +
                        $@"""price"":{dr.Price}" +
                        "}}"))
                }],
                            ""create"":[{
                    string.Join(",", create.Select(dr =>
                        "{" +
                        $@"""id"":""{Guid.NewGuid()}""," +
                        $@"""start"":""{_converter.FormatValueAsString(dr.Start)}""," +
                        $@"""end"":""{_converter.FormatValueAsString(dr.End)}""," +
                        $@"""price"":{dr.Price}" +
                        "}"))
                }]
                        }}
                }}";
        };

        public RateService(IFactoryAsync factoryAsync, GraphQlExtensions extensions,
            ITypeConverter<LocalTime> converter)
            : base(factoryAsync, extensions)
        {
            _converter = converter;
        }
    }
}