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
        internal void WelcomeScreen()
        {

        }

        void SelectCategoryScreen() 
        {
            
        }

        void SelectAmountOfQuestionsScreen()
        {

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
