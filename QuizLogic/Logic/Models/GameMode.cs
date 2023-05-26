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
            foreach (Question q in questions)
            {

                bool isAnswerCorrect = msg.DisplayQuestionScreen(q, questions.Count);


                if (isAnswerCorrect)
                {
                    //good answer screen and adding pint
                    msg.GoodAnswerScreen();
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
