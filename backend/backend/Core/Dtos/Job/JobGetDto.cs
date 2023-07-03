using backend.Core.Enums;

namespace backend.Core.Dtos.Job
{
    public class JobGetDto
    {
        public long Id { get; set; }
       
        public string Title { get; set; }
        public JobLevel Level { get; set; }

        public string CompanyName { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public long CompanyId { get; set; }
    }
}
