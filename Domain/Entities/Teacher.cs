namespace AFTERCLASS.AMS.API.Domain.Entities
{


    public class Teacher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Disabled { get; set; } = false;
    }

}

