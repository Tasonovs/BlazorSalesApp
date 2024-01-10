namespace BlazorSalesApp.SharedApiContracts.SubElements;

public class CreateSubElementRequest
{
    public long TypeId { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }
}