using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorSalesApp.Domain.Models.Common;
using BlazorSalesApp.Domain.Models.Orders;
using BlazorSalesApp.Domain.Models.SubElements;

namespace BlazorSalesApp.Domain.Models.Windows;

public class Window : BaseEntity
{
    public long OrderId { get; set; }
    [ForeignKey(nameof(OrderId))]
    public Order Order { get; set; }
    
    [Required]
    [MaxLength(64)]
    public string Name { get; set; }

    public int QuantityOfWindows { get; set; }

    public List<SubElement> SubElements { get; set; } = [];
}