using System;
using System.Collections.Generic;
using FluentMigrator.Infrastructure;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ShoppingList.Models;

public partial class User
{
    public int UserId { get; set; }
    [Required(ErrorMessage = "Ad zorunludur.")]

    public string? UserName { get; set; }
    [Required(ErrorMessage = "Soyad zorunludur.")]

    public string? UserSurname { get; set; }
    [Required(ErrorMessage = "Eposta adı zorunludur.")]
    public string UserEmail { get; set; }
    [Required(ErrorMessage = "Şifre zorunludur.")]
    [MinLength(8, ErrorMessage = "Şifre en az 8 karakter olmalıdır.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$",
        ErrorMessage = "Şifre büyük harf, küçük harf ve rakam içermelidir.")]
    public string? Password { get; set; }
    [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
    public string? RePassword { get; set; }

    public virtual ICollection<List> Lists { get; set; } = new List<List>();
}
