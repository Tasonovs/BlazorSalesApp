using BlazorSalesApp.SharedApiContracts.Common;
using BlazorSalesApp.SharedApiContracts.Windows;

namespace BlazorSalesApp.SharedApiContracts.Orders;

public class OrderDto : BaseEntityDto
{
    public string Name { get; set; }

    public LookupViewModel State { get; set; }

    public List<WindowDto> Windows { get; set; }
}