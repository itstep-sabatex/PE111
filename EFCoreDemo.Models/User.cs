using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreDemo.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Email { get; set; } = "";
        [Display(Name = "Пароль")]
        public string Password { get; set; }=string.Empty;
        public UserLevel UserLevel { get; set; }

    }
}
