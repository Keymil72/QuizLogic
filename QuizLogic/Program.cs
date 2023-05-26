using QuizLogic.Logic;
using Trivia4NET;
using QuizLogic.Logic.Models;

var service = new TriviaService();
var response = await service.RequestTokenAsync();
var token = response.SessionToken;


Messages msg = new Messages();
Play play = new Play();




while (true)
    msg.EndGameScreen(play.Start(service, token));

