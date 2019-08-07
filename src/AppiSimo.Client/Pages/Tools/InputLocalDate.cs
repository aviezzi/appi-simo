using System;
using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.RenderTree;
using NodaTime;
using NodaTime.Text;

namespace AppiSimo.Client.Pages.Tools
{
    public class InputLocalDate : InputBase<LocalDate>
    {
        const string Pattern = "d";
        readonly LocalDatePattern _pattern = LocalDatePattern.CreateWithInvariantCulture(Pattern);
        
        protected override bool TryParseValueFromString(string value, out LocalDate result,
            out string validationErrorMessage)
        {
            validationErrorMessage = "Error";
            return _pattern.Parse(value).TryGetValue(default, out result);
        }

        protected override string FormatValueAsString(LocalDate value) =>  value.ToString(Pattern, CultureInfo.InvariantCulture);

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "input");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddAttribute(2, "type", "text");
            builder.AddAttribute(3, "id", Id);
            builder.AddAttribute(4, "class", CssClass);
            builder.AddAttribute(5, "value", BindMethods.GetValue(CurrentValueAsString));
            builder.AddAttribute(6, "onchange",
                BindMethods.SetValueHandler(value => CurrentValueAsString = value, CurrentValueAsString));
            builder.CloseElement();
        }
    }
}