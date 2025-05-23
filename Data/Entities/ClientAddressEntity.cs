﻿using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ClientAddressEntity
{
    [Key]
    public string ClientId { get; set; } = new Guid().ToString();
    public virtual ClientEntity Client { get; set; } = null!;
    public string StreetName { get; set; } = null!;
    public string? StreetNumber { get; set; }
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
}
