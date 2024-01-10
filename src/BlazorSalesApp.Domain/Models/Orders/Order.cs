using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorSalesApp.Domain.Models.Common;
using BlazorSalesApp.Domain.Models.Windows;

namespace BlazorSalesApp.Domain.Models.Orders;

public class Order : BaseEntity
{
    [Required]
    [MaxLength(64)]
    public string Name { get; set; }

    public long StateId { get; set; }
    [ForeignKey(nameof(StateId))]
    public OrderStateLookup State { get; set; }

    public List<Window> Windows { get; set; } = [];
}