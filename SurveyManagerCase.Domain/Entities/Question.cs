using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManagement.Domain.Entities
{
    public class Question : BaseEntity<int>
    {
        public int SurveyId { get; set; }
        public string Text { get; set; }
        public Survey Survey { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }

}
