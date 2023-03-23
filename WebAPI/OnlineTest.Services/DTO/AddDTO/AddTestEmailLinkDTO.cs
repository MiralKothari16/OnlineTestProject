using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.AddDTO
{
    public class AddTestEmailLinkDTO
    {
        public Guid Token { get; set; }
        public int TestId { get; set; }
        public int UserId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int AccessCount { get; set; }
        public DateTime ExpireOn { get; set; }
        public bool IsActive { get; set; }
    }
}
