using Trivia4NET.Entities;

namespace QuizLogic.Logic.Models
{
    internal class Convert
    {
        internal QuestionType? ToQuestionType(int type)
        {
            QuestionType? questionType;
            switch (type)
            {
                case 1:
                    questionType = QuestionType.Multiple;
                    break;
                case 2:
                    questionType = QuestionType.YesNo;
                    break;
                default:
                    questionType = null;
                    break;
            }
            return questionType;
        }

        internal Difficulty? toQuestionDifficulty(int diff)
        {
            Difficulty? difficulty;
            switch (diff)
            {
                case 1:
                    difficulty = Difficulty.Easy;
                    break;
                case 2:
                    difficulty = Difficulty.Medium;
                    break;
                case 3:
                    difficulty = Difficulty.Hard;
                    break;
                default:
                    difficulty = null;
                    break;
            }
            return difficulty;
        }

    }
}
