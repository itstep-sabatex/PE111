using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemo.Models
{
    public enum UserLevel
    {
        [Description("Звичайний користувач")]
        User = 1,
        [Description("Адміністратор")]
        Admin =2
    }
}
