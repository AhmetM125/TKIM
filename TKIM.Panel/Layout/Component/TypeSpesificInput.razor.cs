using Microsoft.AspNetCore.Components;
using TKIM.Panel.Base;

namespace TKIM.Panel.Layout.Component;

public partial class TypeSpesificInput : RazorComponentBase
{
    [Parameter] public string Type { get; set; }
    [Parameter] public string StringValue { get; set; }
    [Parameter] public decimal DecimalValue { get; set; }
    [Parameter] public string IntegerValue { get; set; }
    [Parameter] public string Css { get; set; }
}
