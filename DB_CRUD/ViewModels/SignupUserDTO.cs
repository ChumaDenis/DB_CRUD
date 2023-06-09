﻿using System.ComponentModel.DataAnnotations;

namespace DB_CRUD.ViewModels
{
    public class SignupUserDto
    {
        public string Login { get; set; }

        public string Password { get; set; }

        [Required, Compare("Password")]
        public string PasswordConfirmation { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; }
    }
}
