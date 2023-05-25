using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia4NET;
using static System.Net.Mime.MediaTypeNames;

namespace QuizLogic.Logic.Models
{
    internal class Play
    {
        Messages msg = new Messages();
        QuestionsGenerator generator = new QuestionsGenerator();

        internal int start(TriviaService service, string token)
        {

            int points = 0;
            Dictionary<Question, Game> dictionary = msg.WelcomeScreen();
            Question question = dictionary.FirstOrDefault().Key;
            Game game = dictionary.FirstOrDefault().Value;
            InputVerify verify = new InputVerify();

            if (game.gameType == 1)
            {
                List<Question> questions = generator.Get(service, token, game, question);
                foreach (Question q in questions)
                {
                    Dictionary<Question, string> answer = msg.DisplayQuestionScreen(q);
                    int checkedValue = verify.VerifyAnswer(q, answer.Values.FirstOrDefault());
                    while (checkedValue == 0)
                    {
                        answer = msg.DisplayQuestionScreen(q);
                        checkedValue = verify.VerifyAnswer(q, answer.Values.FirstOrDefault());
                    } 
                    if (CheckIfAnswerIsCorrect(answer.Keys.FirstOrDefault(), checkedValue)) 
                        points++;
                    else
                        break;
                }
            }
            

            return points;
        }


        internal bool CheckIfAnswerIsCorrect(Question question, int selected)
        {
            bool toReturn = question.answers.Where(x => x.displayOrder.Equals(selected)).First().isCorrect ? true : false;

            return toReturn;
        }
    }
}
