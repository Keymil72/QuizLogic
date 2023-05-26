using Trivia4NET;

namespace QuizLogic.Logic.Models
{
    internal class GameMode
    {
        Messages msg = new Messages();
        InputVerify verify = new InputVerify();
        internal int Endless(TriviaService service, string token, List<Question> questions)
        {
            int points = 0;
            int questionNumber = 1;
            foreach (Question q in questions.OrderBy(x => x.difficulty))
            {

                bool isAnswerCorrect = msg.DisplayQuestionScreen(q, questionNumber, questions.Count);
                

                if (isAnswerCorrect)
                {
                    //good answer screen and adding pint
                    msg.GoodAnswerScreen();
                    questionNumber++;
                    points++;
                }
                // if answer is wrong break of all loops
                else
                    break;
            }
            //returning int points
            return points;
        }
    }
}
