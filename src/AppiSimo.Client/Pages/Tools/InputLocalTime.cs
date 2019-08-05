namespace AppiSimo.Client.Pages.Tools
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;
    using Microsoft.AspNetCore.Components.RenderTree;
    using NodaTime;
    using NodaTime.Text;

    public class InputLocalTime :  InputBase<LocalTime>
    {
        static readonly LocalTimePattern pattern = LocalTimePattern.CreateWithInvariantCulture("HH:mm");
        
        protected override bool TryParseValueFromString(string value, out LocalTime result, out string validationErrorMessage)
        {
            validationErrorMessage = "Error";
            return pattern.Parse(value).TryGetValue(failureValue: default, out result);
        }

        protected override string FormatValueAsString(LocalTime value) 
            => pattern.Format(value);
        
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "input");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddAttribute(2, "type", "text");
            builder.AddAttribute(3, "id", Id);
            builder.AddAttribute(4, "class", CssClass);
            builder.AddAttribute(5, "value", BindMethods.GetValue(CurrentValueAsString));
            builder.AddAttribute(6, "onchange", BindMethods.SetValueHandler(__value => CurrentValueAsString = __value, CurrentValueAsString));
            builder.CloseElement();
        }
    }
}