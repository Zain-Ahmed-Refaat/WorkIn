namespace WorkIn.Domain.Entities
{
    public class Profile : EntityBase
    {
        public int? ManagerId { get; set; }
        public int? DepartmentId { get; set; }
        public int? CityId { get; set; }

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        
        public virtual Profile? Manager { get; set; }
        public virtual Department Department { get; set; }
        public virtual City City { get; set; }

    }
}
