using Trivia4NET;

namespace QuizLogic.Logic.Models
{
    internal class Play
    {
        Messages msg = new Messages();
        GameMode gameMode = new GameMode();
        QuestionsGenerator generator = new QuestionsGenerator();
        AllCategories allCategories = new AllCategories();


        internal int Start(TriviaService service, string token)
        {
            msg.LoadingScreen(150, "ładowanie aplikacji");
            var categories = allCategories.Get();

            int points = 0;
 
            Question tempQuestion = new Question();
            Game tempGame = new Game();

            bool loadingEnds = msg.StopLoadingScreen(true);
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
                loadingEnds = msg.StopLoadingScreen(true);
                if (questions.Count <= 0)
                {
                    msg.NoQuestionsFoundScreen();
                    Start(service, token);
                }
                points = gameMode.Endless(service, token, questions);
            }
            

            return points;
        }



    }
}
