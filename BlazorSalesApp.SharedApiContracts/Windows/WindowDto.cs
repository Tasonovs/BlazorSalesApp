using BlazorSalesApp.SharedApiContracts.SubElements;

namespace BlazorSalesApp.SharedApiContracts.Windows;

public class WindowDto
{
    public long Id { get; set; }

    public string Name { get; set; }

    public int QuantityOfWindows { get; set; }

    public List<SubElementDto> SubElements { get; set; }

    public int TotalSubElements => SubElements.Count;
}