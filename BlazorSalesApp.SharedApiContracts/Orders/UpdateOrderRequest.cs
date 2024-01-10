using System.Text.Json.Serialization;

namespace BlazorSalesApp.SharedApiContracts.Orders;

public class UpdateOrderRequest : CreateOrderRequest
{
    [JsonIgnore]
    public long Id { get; set; }
}