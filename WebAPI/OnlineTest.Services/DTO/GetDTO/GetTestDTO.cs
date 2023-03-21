using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.GetDTO
{
    public class GetTestDTO
    {
        public int Id { get; set; }
        public string TestName { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public DateTime? ExpireOn { get; set; } = DateTime.UtcNow;

        public int TechnologyId { get; set; }
        public List<GetQuestionDTO>? Questions { get; set; }
    }
}
