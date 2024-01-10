using BlazorSalesApp.SharedApiContracts.SubElements;

namespace BlazorSalesApp.SharedApiContracts.Windows;

public class EditWindowRequest
{
    public long Id { get; set; }

    public string Name { get; set; }

    public int QuantityOfWindows { get; set; }

    public List<EditSubElementRequest> SubElements { get; set; } = [];
}