using BlazorSalesApp.SharedApiContracts.SubElements;

namespace BlazorSalesApp.SharedApiContracts.Windows;

public class CreateWindowRequest
{
    public string Name { get; set; }

    public int QuantityOfWindows { get; set; }

    public List<CreateSubElementRequest> SubElements { get; set; }
}