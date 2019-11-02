namespace AppiSimo.Client.Builders
{
    using Abstract;
    using Model;
    using NodaTime;
    using System;
    using System.Linq;

    public class RateBuilder : IQueryBuilder<Rate>
    {
        readonly ITypeConverter<LocalTime> _converter;

        public RateBuilder(ITypeConverter<LocalTime> converter)
        {
            _converter = converter;
        }

        public string Fields => "id, name, start, end, dailyRates { id, start, end, price }";

        public string BuildCreate(Rate rate) =>
            $@"{{
                ""rate"": {{
                    ""id"":""{rate.Id}"",
                    ""name"":""{rate.Name}"",
                    ""start"":""{rate.Start}"",
                    ""end"":""{rate.End}"",
                    ""dailyRates"": {{
                        ""create"":[{
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

        public string BuildUpdate(Rate rate)
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
        }
    }
}