using Microsoft.AspNetCore.Identity;

namespace WebApplicationIdentityCustomDemo.Data
{
    public class AppUser:IdentityUser
    {
        [PersonalData]
        public string Name { get; set; } //Full user name Імя Прізвище
        [PersonalData]
        public string IdCode { get; set; } // ДРФО або номер паспорта
    }
}
