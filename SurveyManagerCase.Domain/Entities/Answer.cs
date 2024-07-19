using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManagement.Domain.Entities
{
    public class Answer : BaseEntity<int>
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public Question Question { get; set; }
    }

}
