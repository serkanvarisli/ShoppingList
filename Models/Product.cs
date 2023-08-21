﻿using System;
using System.Collections.Generic;

namespace ShoppingList.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public int ListId { get; set; }

    public int CategoryId { get; set; }

    public string? ProductName { get; set; }

    public string? ProductBrand { get; set; }

    public string? ProductQuantity { get; set; }

    public string? ProductDetail { get; set; }

    public byte[]? ProductImage { get; set; }
}
