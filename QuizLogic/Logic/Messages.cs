using QuizLogic.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace QuizLogic.Logic
{
    internal class Messages
    {
        Game game = new Game();
        Question question = new Question();
        AllCategories allCategories = new AllCategories();
        InputVerify verify = new InputVerify();
        internal void WelcomeScreen()
        {
            Console.WriteLine("*** Quiz Game - Made by Keymil72 ***");
            Console.WriteLine();
            Console.WriteLine("Wciśnij dowolny przycisk by rozpocząć gre");
            Console.WriteLine();
            Console.WriteLine("Aktualnie dostępny tylko tryb endless");
            Console.ReadKey();
            SelectCategoryScreen();

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
            Console.ReadLine();

        }

        void SelectTypeOfQuestionScreen()
        {

        }
        void SelectDifficultyScreen()
        {

        }
        
        internal void DisplayQuestionScreen(Question question)
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

            string selected = Console.ReadLine();
            
            game.CheckIfAnswerIsCorrect(question, selected);
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
    }
}
