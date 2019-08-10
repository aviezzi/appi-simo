using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.RenderTree;
using NodaTime;
using NodaTime.Text;

namespace AppiSimo.Client.Pages.Tools
{
    public class InputLocalTime : InputBase<LocalTime>
     {
         static readonly LocalTimePattern Pattern = LocalTimePattern.CreateWithInvariantCulture("HH:mm");
 
         protected override bool TryParseValueFromString(string value, out LocalTime result,
             out string validationErrorMessage)
         {
             validationErrorMessage = "Error";
             return Pattern.Parse(value).TryGetValue(default, out result);
         }
 
         protected override string FormatValueAsString(LocalTime value) => Pattern.Format(value);
 
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