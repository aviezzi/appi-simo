namespace AppiSimo.Client.Pages.Tools
{
    using AppiSimo.Client.Abstract;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;
    using Microsoft.AspNetCore.Components.RenderTree;
    using NodaTime;

    public class InputLocalDate : InputBase<LocalDate>
    {
        [Inject] ITypeConverter<LocalDate> Converter { get; set; }

        protected override bool TryParseValueFromString(string value, out LocalDate result,
                                                        out string validationErrorMessage)
        {
            validationErrorMessage = "Error";
            return Converter.TryParseValueFromString(value, out result);
        }

        protected override string FormatValueAsString(LocalDate value) => Converter.FormatValueAsString(value);

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "input");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddAttribute(2, "type", "text");
            builder.AddAttribute(2, "class", CssClass);
            builder.AddAttribute(3, "value", FormatValueAsString(CurrentValue));
            builder.AddAttribute(4, "onchange",
                                 EventCallback.Factory.CreateBinder<string>(this, value => CurrentValueAsString = value,
                                                                            CurrentValueAsString));
            builder.CloseElement();
        }
    }
}