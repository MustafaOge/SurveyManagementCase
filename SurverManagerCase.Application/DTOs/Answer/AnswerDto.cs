﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManagement.Application.DTOs.Answer
{
    public class AnswerDto
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
    }
}
