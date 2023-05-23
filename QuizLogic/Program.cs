using QuizLogic.Logic;
using Trivia4NET;
using QuizLogic.Logic.Models;
using Trivia4NET.Entities;
using Question = QuizLogic.Logic.Models.Question;

var service = new TriviaService();

var response = await service.RequestTokenAsync();
var token = response.SessionToken;

AllCategories allCategories = new AllCategories();

Dictionary<int, string> categories = allCategories.Get();
QuestionsGenerator generator = new QuestionsGenerator();

List<Question> questions = generator.Get(service, token, QuestionType.Multiple, 15, Difficulty.Easy, 1);
Question question = questions.First();

Messages msg = new Messages();

msg.DisplayQuestionScreen(question);
