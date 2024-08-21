using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkIn.Infrastructure.Dtos.Department
{
    public class DepartmentDtos
    {
        public class DepartmentDto : UpdateDepartmentDto
        {
            public DateTime? CreationDate { get; set; }
            public DateTime? LastModificationDate { get; set; }
            public bool? IsDeleted { get; set; }
        }

        public class CreateDepartmentDto
        {
            public string Name { get; set; }
            public int? ManagerId { get; set; }
        }

        public class UpdateDepartmentDto : CreateDepartmentDto
        {
            public int Id { get; set; }
        }

    }
}
