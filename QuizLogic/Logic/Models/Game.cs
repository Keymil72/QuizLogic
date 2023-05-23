using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace QuizLogic.Logic.Models
{
    internal class Game
    {
        Messages msg = new Messages();
        internal void CheckIfAnswerIsCorrect(Question question, string? selected)
        {
            bool parse = int.TryParse(selected, out int answer);
            if (parse)
            {
                if (question.answers.Where(x => x.displayOrder.Equals(answer)).First().isCorrect)
                {
                    msg.CorrectAnswerScreen();
                }
                else
                {
                    msg.WrongAnswerScreen();
                }
            }else msg.DisplayQuestionScreen(question);
        }
    }
}
