using System;
using System.Collections.Generic;
using AppiSimo.Client.Abstract;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.RenderTree;
using NodaTime;
using NodaTime.Text;

namespace AppiSimo.Client.Pages.Tools
{
    public class InputSelectT<T>: InputBase<T>
    {
        static readonly LocalTimePattern Pattern = LocalTimePattern.CreateWithInvariantCulture("HH:mm");

        [Inject] ITypeConverter<T> Converter { get; set; }
        
        [Parameter] RenderFragment ChildContent { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "select");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddAttribute(2, "id", Id);
            builder.AddAttribute(3, "class", CssClass);
            builder.AddAttribute(4, "value", BindMethods.GetValue(CurrentValueAsString));
            builder.AddAttribute(5, "onchange", BindMethods.SetValueHandler(value => CurrentValueAsString = value, CurrentValueAsString));
            builder.AddContent(6, ChildContent);
            builder.CloseElement();
        }

        protected override string FormatValueAsString(T value) => Converter.FormatValueAsString(value);

        protected override bool TryParseValueFromString(
            string value,
            out T result,

            out string validationErrorMessage)
        {
            validationErrorMessage = "TODO";
            return Converter.TryParseValueFromString(value, out result);
        }
    }
}
