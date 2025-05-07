namespace AFTERCLASS.AMS.API.Domain.Entities
{


    public class Teacher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
       
        
   
        public Teacher(string name, string email)
        {
            Name = name;
            Email = email;
            IsActive = true;
            
        }

        public Teacher()
        {
        }
    }

}

