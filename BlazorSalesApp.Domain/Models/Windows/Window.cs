using BlazorSalesApp.Domain.Models.Common;
using BlazorSalesApp.Domain.Models.SubElements;

namespace BlazorSalesApp.Domain.Models.Windows;

public class Window : BaseEntity
{
    public string Name { get; set; }

    public int QuantityOfWindows { get; set; }

    public int TotalSubElements { get; set; }

    public List<SubElement> SubElements { get; set; } = [];
}