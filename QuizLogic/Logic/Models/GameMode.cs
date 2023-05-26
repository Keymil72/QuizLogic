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
                Dictionary<Question, string> answer = msg.DisplayQuestionScreen(q, questions.Count);
                int checkedValue = verify.VerifyAnswer(q, answer.Values.FirstOrDefault());
                while (checkedValue == 0)
                {
                    answer = msg.DisplayQuestionScreen(q, questions.Count);
                    checkedValue = verify.VerifyAnswer(q, answer.Values.FirstOrDefault());
                }
                if (verify.CheckIfAnswerIsCorrect(answer.Keys.FirstOrDefault(), checkedValue))
                {
                    msg.GoodAnswerScreen();
                    points++;
                }
                else
                    break;
            }

            return points;
        }
    }
}
