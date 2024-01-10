namespace BlazorSalesApp.SharedApiContracts.SubElements;

public class EditSubElementRequest
{
    public long Id { get; set; }
    
    public long TypeId { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }
}