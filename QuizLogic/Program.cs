using QuizLogic.Logic;
using Trivia4NET;
using QuizLogic.Logic.Models;
using Trivia4NET.Entities;
using Question = QuizLogic.Logic.Models.Question;

var service = new TriviaService();

var response = await service.RequestTokenAsync();
var token = response.SessionToken;

TranslatorDeepl translator = new TranslatorDeepl();


AllCategories allCategories = new AllCategories();

Dictionary<int, string> categories = allCategories.Get();
QuestionsGenerator generator = new QuestionsGenerator();
List<Question> questions = generator.Get(service, token, QuestionType.Multiple, 15, Difficulty.Easy, 2);
Question question = questions.First();



//foreach (var category in categories)
//    Console.WriteLine(category.Key + ". " + category.Value);


//string text = translator.Translate(question.Content);
//Console.WriteLine(text);
//Console.WriteLine(translator.Translate(question.Category));

//foreach (var item in question.IncorrectAnswers)
//{
//    Console.WriteLine(translator.Translate(item));
//}
//Console.WriteLine(translator.Translate(question.Answer));
