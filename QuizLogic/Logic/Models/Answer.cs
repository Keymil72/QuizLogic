using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizLogic.Logic.Models
{
    internal class Answer
    {
        public int id { get; set; }
        public string content { get; set; }
        public bool isCorrect { get; set; }
        public int displayOrder { get; set; }

    }
}
