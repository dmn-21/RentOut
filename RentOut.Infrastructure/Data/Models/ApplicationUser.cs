﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static RentOut.Infrastructure.Constants.DataConstants;

namespace RentOut.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(UserFirstNameMaxLength)]
        [PersonalData]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(UserLastNameMaxLength)]
        [PersonalData]
        public string LastName { get; set; } = string.Empty;

        public Rentier? Rentier { get; set; }
    }
}
