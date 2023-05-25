using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia4NET.Entities;

namespace QuizLogic.Logic.Models
{
    internal class Question
    {
        public int id { get; set; }
        public QuestionType questionType { get; set; }
        public int questionCategory { get; set; }
        public Difficulty difficulty { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string content { get; set; }

        public List<Answer> answers { get; set; }

    }
}
