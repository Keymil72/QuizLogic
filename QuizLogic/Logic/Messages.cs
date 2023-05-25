using QuizLogic.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Trivia4NET.Entities;
using Convert = QuizLogic.Logic.Models.Convert;
using Question = QuizLogic.Logic.Models.Question;

namespace QuizLogic.Logic
{
    internal class Messages
    {
        Play play = new Play();
        Question question = new Question();
        Convert convert = new Convert();
        Game game = new Game();
        AllCategories allCategories = new AllCategories();
        InputVerify verify = new InputVerify();
        internal Dictionary<Question, Game> WelcomeScreen()
        {
            Console.WriteLine("*** Quiz Game - Made by Keymil72 ***");
            Console.WriteLine();
            Console.WriteLine("Wciśnij dowolny przycisk by rozpocząć gre");
            Console.WriteLine();
            Console.WriteLine("Aktualnie dostępny tylko tryb endless");
            Console.ReadKey();
            game.id = 0;
            game.gameType = 1;
            SelectCategoryScreen();
            Dictionary<Question, Game> toReturn = new Dictionary<Question, Game>();
            toReturn.Add(question, game);
            return toReturn;
        }

        void SelectCategoryScreen()
        {
            Console.Clear();
            var categories = allCategories.Get();
            foreach (var category in categories) Console.WriteLine($"{category.Key}. {category.Value}");
            Console.WriteLine();
            Console.WriteLine("Wybierz kategorie wpisując numer i zatwierdzając enterem");
            Console.WriteLine("Wpisanie dowolnego innego numeru skutkuje wybranie losowej kategorii!");
            int selected = verify.VerifyCategory(Console.ReadLine());
            question.questionCategory = selected;
            SelectAmountOfQuestionsScreen();
            
        }

        void SelectAmountOfQuestionsScreen()
        {
            Console.Clear();
            Console.WriteLine("Podaj ilość pytań ile mam wylosować");
            int selected = verify.VerifyAmount(Console.ReadLine());
            game.questionsAmount = selected;
            SelectTypeOfQuestionScreen();
        }

        void SelectTypeOfQuestionScreen()
        {
            Console.Clear();
            Console.WriteLine("1. Wiele opcji wyboru (4) z czego tylko 1 jest poprawna");
            Console.WriteLine("2. Tak/Nie");
            Console.WriteLine();
            Console.WriteLine("Wybierz typ pytań wpisując numerek i zatwierdzając enterem");
            Console.WriteLine("Wpisanie dowolnie innego znaku skutkuje wybieranie losowo typu pytania!");
            int selected = verify.VerifyType(Console.ReadLine());
#pragma warning disable CS8629 // Nullable value type may be null.
            question.questionType = (QuestionType)convert.ToQuestionType(selected);
            SelectDifficultyScreen();
        }
        void SelectDifficultyScreen()
        {
            Console.Clear();
            Console.WriteLine("1. Łatwe");
            Console.WriteLine("2. Średnie");
            Console.WriteLine("3. Trudne");
            Console.WriteLine();
            Console.WriteLine("Wybierz trudność pytań wpisując numerek i zatwierdzając enterem");
            Console.WriteLine("Wpisanie dowolnie innego znaku skutkuje wybieranie losowo trudności pytań!");
            int selected = verify.VerifyDififculty(Console.ReadLine());
            question.difficulty = (Difficulty)convert.toQuestionDifficulty(selected);
            
        }

        internal Dictionary<Question, string> DisplayQuestionScreen(Question question)
        {
            Console.Clear();
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

        internal void CorrectAnswerScreen()
        {
            Console.WriteLine();
            Console.WriteLine("Gratulacje poprawna odpowiedź");
        }

        internal void WrongAnswerScreen()
        {
            Console.WriteLine();
            Console.WriteLine("Błędna odpowiedź!");
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
