namespace WorkIn.Domain.Entities
{
    public class Department : EntityBase
    {
        public string Name { get; set; }
        public int? ManagerId { get; set; }
    }
}
