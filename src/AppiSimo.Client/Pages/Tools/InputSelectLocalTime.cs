namespace AppiSimo.Client.Pages.Tools
{
    using AppiSimo.Client.Abstract;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;
    using Microsoft.AspNetCore.Components.RenderTree;

    public class InputSelectT<T> : InputBase<T>
    {
        [Inject] ITypeConverter<T> Converter { get; set; }

        [Parameter] RenderFragment ChildContent { get; set; }

        protected override string FormatValueAsString(T value) => Converter.FormatValueAsString(value);

        protected override bool TryParseValueFromString(
            string value,
            out T result,
            out string validationErrorMessage)
        {
            validationErrorMessage = "TODO";
            return Converter.TryParseValueFromString(value, out result);
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "select");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddAttribute(2, "class", CssClass);
            builder.AddAttribute(3, "value", BindConverter.FormatValue(CurrentValueAsString));
            builder.AddAttribute(4, "onchange",
                                 EventCallback.Factory.CreateBinder<string>(this, value => CurrentValueAsString = value,
                                                                            CurrentValueAsString));
            builder.AddContent(5, ChildContent);
            builder.CloseElement();
        }
    }
}