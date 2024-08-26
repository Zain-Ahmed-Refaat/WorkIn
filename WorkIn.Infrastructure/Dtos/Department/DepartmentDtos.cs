namespace WorkIn.Infrastructure.Dtos.Department
{
    public class DepartmentDtos
    {
        public class DepartmentDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int? ManagerId { get; set; }
        }

        public class CreateDepartmentDto
        {
            public string Name { get; set; }
            public int? ManagerId { get; set; }
        }

        public class UpdateDepartmentDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int? ManagerId { get; set; }
        }

    }
}
