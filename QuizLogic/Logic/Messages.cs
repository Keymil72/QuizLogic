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
                await Task.Delay(delay);
            }
            Console.ForegroundColor= ConsoleColor.White;
            stop = false;
        }

        internal bool StopLoadingScreen(bool s)
        {
            stop = s;
            while (stop);
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

        internal Dictionary<Question, string> DisplayQuestionScreen(Question question)
        {
            Console.Clear();
            Console.Write("Kategoria nr: " + question.questionCategory);

            if (question.difficulty == Difficulty.Easy)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (question.difficulty == Difficulty.Medium)
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(" (" + deepl.Translate(question.difficulty.ToString()) + ")");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(question.content);
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

            if (selected == null) DisplayQuestionScreen(question);

            Dictionary<Question, string> toReturn = new Dictionary<Question, string>();
            toReturn.Add(question, selected);

            return toReturn;
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
