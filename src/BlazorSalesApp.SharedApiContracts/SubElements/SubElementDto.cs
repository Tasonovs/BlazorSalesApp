using BlazorSalesApp.SharedApiContracts.Common;

namespace BlazorSalesApp.SharedApiContracts.SubElements;

public class SubElementDto : BaseEntityDto
{
    public LookupViewModel Type { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }
}