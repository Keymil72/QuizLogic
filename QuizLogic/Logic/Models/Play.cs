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
        InputVerify verify = new InputVerify();
        AllCategories allCategories = new AllCategories();

        internal int start(TriviaService service, string token)
        {
            msg.LoadingScreen(150, "ładowanie aplikacji");
            var categories = allCategories.Get();

            int points = 0;
 
            Question tempQuestion = new Question();
            Game tempGame = new Game();

            bool loaded = msg.StopLoadingScreen(true);
            msg.WelcomeScreen();
            tempQuestion.questionCategory = msg.SelectCategoryScreen(categories);
            tempGame.id = 0;
            tempGame.gameType = 1;
            tempGame.questionsAmount = msg.SelectAmountOfQuestionsScreen();
            tempQuestion.questionType = msg.SelectTypeOfQuestionScreen();
            tempQuestion.difficulty = msg.SelectDifficultyScreen();
            
            if (tempGame.gameType == 1)
            {
                msg.LoadingScreen(30*tempGame.questionsAmount, "wyszukiwanie pytań");

                List<Question> questions = generator.Get(service, token, tempGame, tempQuestion);
                loaded = msg.StopLoadingScreen(true);
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
