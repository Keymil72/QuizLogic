using Trivia4NET;
using QuizLogic.Logic.Models;


Messages msg = new Messages();
Play play = new Play();

while (true)
{
    var service = new TriviaService();
    var response = await service.RequestTokenAsync();
    var token = response.SessionToken;
    msg.EndGameScreen(play.Start(service, token));
}
    

