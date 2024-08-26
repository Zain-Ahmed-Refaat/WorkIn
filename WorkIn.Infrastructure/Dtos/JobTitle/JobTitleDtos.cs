namespace WorkIn.Infrastructure.Dtos.JobTitle
{
    public class JobTitleDtos
    {
        public class JobTitleDto
        {
            public int Id { get; set; }
            public string Title { get; set; }
        }
        
        public class CreateJobTitleDto
        {
            public string Title { get; set; }
        }
        
        public class UpdateJobTitleDto
        {
            public int Id { get; set; }
            public string Title { get; set; }
        }

    }
}
