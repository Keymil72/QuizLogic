using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia4NET;
using Trivia4NET.Entities;

namespace QuizLogic.Logic.Models
{
    internal class QuestionsGenerator
    {
        internal List<Question> Get(TriviaService service, string token, Game g, Question q)
        {

            //generate a list of questions from Trivia4NET
            var engQuestions = service.GetQuestionsAsync(token, g.questionsAmount, q.difficulty, q.questionType, q.questionCategory);

            //translation deepl class
            TranslatorDeepl deepl = new TranslatorDeepl();

            //translated list of questions
            List<Question> questions = new List<Question>();

            //id of question in list
            int id = 0;
            

            //loop foreach of generated questions
            foreach (var question in engQuestions.Result.Questions)
            {
                //temporary question and answer wich will be added to translated list of questions
                Question temp = new Question();
                Answer answer = new Answer();
                
                //temporary list of answers
                List<Answer> answerList = new List<Answer>();
                
                //id of answer
                int answerId = 0;

                //max value to for loop
                int max;

                //if statment setting max value for question type to for loop
                if(question.Type.Equals(QuestionType.YesNo)) 
                    max = 2;
                else
                    max = 4;

                //lists to generate not repeating display order to question answer
                List<int> possible = Enumerable.Range(0, max).ToList();
                List<int> listNumbers = new List<int>();

                Random rng = new Random();

                //for loop to generate not repeating display order value
                for (int i = 0; i < max; i++)
                {
                    int index = rng.Next(0, possible.Count);
                    listNumbers.Add(possible[index]);
                    possible.RemoveAt(index);

                }

                //add correct answer to answerList
                answer.id = answerId;
                answer.content = deepl.Translate(question.Answer);
                answer.isCorrect = true;
                answer.displayOrder = listNumbers[answerId] + 1;
                answerList.Add(answer);
                answerId++;

                //for loop adding incorrect answers to answerList with multiple answers
                for (int i = 0; i < max-1; i++)
                {
                    Answer answerIncorrect = new Answer();
                    answerIncorrect.id = answerId;
                    answerIncorrect.content = deepl.Translate(question.IncorrectAnswers.ElementAt(i));
                    answerIncorrect.isCorrect = false;
                    answerIncorrect.displayOrder = listNumbers[answerId] + 1;
                    answerList.Add(answerIncorrect);
                    answerId++;
                }


                //question add to list of questions
                temp.id = id;
                temp.questionType = question.Type;
                temp.difficulty = question.Difficulty;
                temp.content = deepl.Translate(question.Content);
                temp.answers = answerList;
                questions.Add(temp);
                id++;
            }
            //return list of question
            return questions;
        }
    }
}
