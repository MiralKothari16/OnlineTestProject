using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model
{
    public class EmailNotification
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey ("user_Id")]
        public int UserId { get; set; }
        public string ToEmail { get; set; }
        public string FromEmail { get; set; }
        public string MainContentHTML { get; set; }
        public int CreatedBy { get; set; }
        [Column (TypeName ="DateTime")]
        public DateTime CreatedOn { get; set; }
        public bool IsProcessed { get; set; }
        [Column (TypeName ="DateTime")]
        public DateTime? ProcessedOn { get; set;}

        public virtual User user_Id { get; set; }
    }
}
