﻿using System.ComponentModel.DataAnnotations;

namespace PBP.Models;

public class Contact
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "شماره همراه باید ۱۱ رقمی باشد.")]
    public string PhoneNumber { get; set; } = string.Empty;

    public DateTime? BirthDate { get; set; }

    public int? ImageId { get; set; }
    public Image? Image { get; set; }
}