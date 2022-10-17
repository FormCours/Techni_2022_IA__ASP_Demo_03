namespace Demo_ASP_MVC_03.Data.Entities
{
    public class Inscription
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public PersonRole PersonRole { get; set; }
        public string? PhoneNumber { get; set; }
        public int NbGuest { get; set; }
        public bool SpamOk { get; set; }
    }
}
