using System;
using System.Linq;
using AppiSimo.Client.Abstract;
using AppiSimo.Client.Model;
using NodaTime;

namespace AppiSimo.Client.Builders
{
    public class RateQueryBuilder : IStringQueryBuilder<Rate>
    {
        readonly ITypeConverter<LocalTime?> _converter;

        public RateQueryBuilder(ITypeConverter<LocalTime?> converter)
        {
            _converter = converter;
        }

        public string Fields => "id, name, start, end, dailyRates  { id, start, end, price }";
        
        public string BuildCreateQuery(Rate rate) =>
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

        public string BuildUpdateQuery(Rate entity)
        {
            throw new NotImplementedException();
        }
    }
}