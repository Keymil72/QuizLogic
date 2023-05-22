using QuizLogic.Logic;
using Trivia4NET;
using Trivia4NET.Entities;
using DeepL;
using DeepL.Model;

var service = new TriviaService();

var response = await service.RequestTokenAsync();
var token = response.SessionToken;

var categories = await service.GetCategoriesAsync();
var cats = categories.Categories;
var questions = await service.GetQuestionsAsync(token,
    amount: 1, difficulty: Difficulty.Easy, QuestionType.Multiple, 10);

var question = questions.Questions[0];
TranslatorDeepl translator = new TranslatorDeepl();
string text = translator.Translate(question.Content);
Console.WriteLine(text);

//Console.WriteLine();
//foreach (var category in cats)
//{
//    Console.WriteLine(category);
//}
//foreach (var item in question.IncorrectAnswers)
//{
//    Console.WriteLine(item);
//}
//Console.WriteLine(question.Answer);
