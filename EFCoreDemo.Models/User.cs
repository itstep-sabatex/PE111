using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace EFCoreDemo.Models
{
    public class User
    {
        public int Id { get; set; } //int-32, long-64, Guid-128 (16), string (Guid) 32  64 
        public string Name { get; set; } = default!;// ivan ivanovich
        public string? Email { get; set; } = "";
        [Display(Name = "Пароль")]
        public string Password { get; set; }=string.Empty;
        
        public UserLevel UserLevel { get; set; }

    }
}
