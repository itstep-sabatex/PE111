namespace WebApplicationApiDemo.Services
{
    public class DateService
    {
        private readonly DateTime _date;
        public DateService()
        {
                _date = DateTime.UtcNow;
        }
        public DateTime CreateDate => _date;
    }
}
