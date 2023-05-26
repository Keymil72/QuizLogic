using QuizLogic.Logic.Models;

using Trivia4NET.Entities;
using Convert = QuizLogic.Logic.Models.Convert;
using Question = QuizLogic.Logic.Models.Question;

namespace QuizLogic.Logic
{
    internal class Messages
    {
        Convert convert = new Convert();
        TranslatorDeepl deepl = new TranslatorDeepl();
        InputVerify verify = new InputVerify();

        bool stop = false;
        internal async void LoadingScreen(int delay, string text)
        {
            string l = "..................................................";
            for (int i = 0; i < 50; i++)
            {
                if (stop)
                {
                    delay = 10;
                }

                l = l.Remove(i, 1).Insert(i, "#");
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Trwa " + text);
                Console.WriteLine("[" + l + "]");
                // prefer to use await over thread.sleep for delay
                await Task.Delay(delay);
            }
            Console.ForegroundColor= ConsoleColor.White;
            stop = false;
        }

        internal bool StopLoadingScreen(bool s)
        {
            stop = s;
            //when while loop ends return true wich means ending loadingScreen
            while (stop) Console.Write(""); ;
            return true;
        }
        internal void WelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine("*** Quiz Game - Made by Keymil72 ***");
            Console.WriteLine();
            Console.WriteLine("Wciśnij dowolny przycisk by rozpocząć gre");
            Console.WriteLine();
            Console.WriteLine("Aktualnie dostępny tylko tryb endless");
            Console.ReadKey();
        }

        internal int SelectCategoryScreen(Dictionary<int, string> categories)
        {
            Console.Clear();
            // loop via Dictionary of translated categories
            foreach (var category in categories) Console.WriteLine($"{category.Key}. {category.Value}");
            Console.WriteLine();
            Console.WriteLine("Wybierz kategorie wpisując numer i zatwierdzając enterem");
            Console.WriteLine("Wpisanie dowolnego innego numeru skutkuje wybranie losowej kategorii!");
            int selected = verify.VerifyCategory(Console.ReadLine());

            return selected;
            
        }

        internal int SelectAmountOfQuestionsScreen()
        {
            Console.Clear();
            Console.WriteLine("Podaj ilość pytań ile mam wylosować");
            int selected = verify.VerifyAmount(Console.ReadLine());

            return selected;
        }

        internal QuestionType? SelectTypeOfQuestionScreen()
        {
            Console.Clear();
            Console.WriteLine("1. Wiele opcji wyboru (4) z czego tylko 1 jest poprawna");
            Console.WriteLine("2. Tak/Nie");
            Console.WriteLine();
            Console.WriteLine("Wybierz typ pytań wpisując numerek i zatwierdzając enterem");
            Console.WriteLine("Wpisanie dowolnie innego znaku skutkuje wybieranie losowo typu pytania!");
            int selected = verify.VerifyType(Console.ReadLine());

            return convert.ToQuestionType(selected);
        }
        internal Difficulty? SelectDifficultyScreen()
        {
            Console.Clear();
            Console.WriteLine("1. Łatwe");
            Console.WriteLine("2. Średnie");
            Console.WriteLine("3. Trudne");
            Console.WriteLine();
            Console.WriteLine("Wybierz trudność pytań wpisując numerek i zatwierdzając enterem");
            Console.WriteLine("Wpisanie dowolnie innego znaku skutkuje wybieranie losowo trudności pytań!");
            int selected = verify.VerifyDififculty(Console.ReadLine());

            return convert.toQuestionDifficulty(selected);

        }

        internal void NoQuestionsFoundScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nie odnaleziono pytań (błąd api)");
            Console.ReadLine();
            Console.ForegroundColor= ConsoleColor.White;
        }

        internal bool DisplayQuestionScreen(Question question, int questionsAmount)
        {
            Console.Clear();
            int questionNumber = question.id + 1;
            Console.Write("Pytanie nr" + questionNumber);

            if (question.difficulty == Difficulty.Easy)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (question.difficulty == Difficulty.Medium)
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(" (" + deepl.Translate(question.difficulty.ToString()) + ")");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(question.content);
            // display question answers ordered by displayorder
            foreach (var item in question.answers.OrderBy(x => x.displayOrder))
            {
                Console.WriteLine(item.displayOrder + ". " + item.content);
            }
            Console.WriteLine();
            Console.WriteLine("Wybierz poprawną odpowiedź z powyższych wpisując numerek");
            Console.WriteLine();

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string selected = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (selected == null) DisplayQuestionScreen(question, questionsAmount);

            //creating dictionary to return values

            int userAnswer = verify.VerifyAnswerInput(question, selected);
            if (userAnswer == 0)
                DisplayQuestionScreen(question, questionsAmount);

            bool toReturn = verify.CheckIfAnswerIsCorrect(question, userAnswer);

            return toReturn;
        }

        internal void GoodAnswerScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Brawo!");
            Console.WriteLine("Poprawna odpowiedź");
            Console.WriteLine("Naciśnij dowolny klawisz by przejść do następnego ptytania");
            Console.ReadKey();
        }

        internal void EndGameScreen(int points)
        {
            Console.Clear();
            Console.WriteLine("Zakończyłeś grę z wynikiem " + points + "pkt");
            Console.WriteLine("***   Gratulacje!!!   ***");
            Console.WriteLine();
            Console.WriteLine("Wciśnij dowolny klawisz by zacząć od nowa");
            Console.ReadKey();
        }
    }
}
