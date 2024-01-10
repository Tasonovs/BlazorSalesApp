using BlazorSalesApp.SharedApiContracts.Common;
using BlazorSalesApp.SharedApiContracts.SubElements;

namespace BlazorSalesApp.SharedApiContracts.Windows;

public class WindowDto : BaseEntityDto
{
    public string Name { get; set; }

    public int QuantityOfWindows { get; set; }

    public List<SubElementDto> SubElements { get; set; }

    public int TotalSubElements => SubElements.Count;
}