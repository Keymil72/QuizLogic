using Trivia4NET.Entities;

namespace QuizLogic.Logic.Models
{
    internal class InputVerify
    {
        internal int VerifyCategory(string key)
        {
            bool parse = int.TryParse(key, out int selected);
            //24 is max category id - 8
            int toReturn = 0;
            if (parse)
            {
                toReturn = selected >= 1 && selected <= 24 ? selected + 8 : 0;
            }
            
            return toReturn;
        }

        internal int VerifyAmount(string key) 
        {
            bool parse = int.TryParse(key, out int selected);
            int toReturn = parse && selected >= 1 && selected <= 20? selected : 10;
            return toReturn;

        }

        internal int VerifyType(string key) 
        {
            bool parse = int.TryParse(key, out int selected);
            int toReturn = parse && selected >= 1 && selected <= 2 ? selected : 0;
            return toReturn;

        }
        internal int VerifyDififculty(string key)
        {
            bool parse = int.TryParse(key, out int selected);
            int toReturn = parse && selected >= 1 && selected <= 3 ? selected : 0;
            return toReturn;
        }

        internal int VerifyAnswerInput(Question q,string key)
        {
            bool parse = int.TryParse(key, out int selected);
            int toReturn;

            if (q.questionType.Equals(QuestionType.Multiple))
                toReturn = parse && selected >= 1 && selected <= 4 ? selected : 0;
            else
                toReturn = parse && selected >= 1 && selected <= 2 ? selected : 0;
            
            return toReturn;
        }

        internal bool CheckIfAnswerIsCorrect(Question question, int selected)
        {
            bool toReturn = question.answers.Where(x => x.displayOrder.Equals(selected)).First().isCorrect ? true : false;

            return toReturn;
        }
    }
}
