using BlazorSalesApp.SharedApiContracts.Common;

namespace BlazorSalesApp.SharedApiContracts.SubElements;

public class SubElementDto
{
    public long Id { get; set; }

    public LookupViewModel Type { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }
}