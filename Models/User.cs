﻿using System;
using System.Collections.Generic;

namespace ShoppingList.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? UserSurname { get; set; }

    public string? UserEmail { get; set; }

    public string? Password { get; set; }
}
