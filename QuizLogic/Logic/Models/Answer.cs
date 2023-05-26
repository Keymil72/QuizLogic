

namespace QuizLogic.Logic.Models
{
    internal class Answer
    {
        public int id { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string content { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public bool isCorrect { get; set; }
        public int displayOrder { get; set; }

    }
}
