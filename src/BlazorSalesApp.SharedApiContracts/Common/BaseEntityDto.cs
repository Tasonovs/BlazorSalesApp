﻿namespace BlazorSalesApp.SharedApiContracts.Common;

public class BaseEntityDto
{
    public long Id { get; set; }
    
    public DateTime CreatedUtc { get; set; }
    
    public DateTime? UpdatedUtc { get; set; }
    
    public DateTime? DeletedUtc { get; set; }
}