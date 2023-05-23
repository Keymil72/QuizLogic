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
        public string questionCategory { get; set; }
        public Difficulty difficulty { get; set; }
        public string content { get; set; }

        public List<Answer> answers { get; set; } = new List<Answer>();








    }
}
