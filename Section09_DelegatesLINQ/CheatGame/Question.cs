using System;
using System.Collections.Generic;
using System.Text;

namespace Section09_DelegatesLINQ
{
    public class Question
    {
        public Question(string questionPhrase, bool correctAnswer, string explanation)
        {
            QuestionPhrase = questionPhrase;
            CorrectAnswer = correctAnswer;
            Explanation = explanation;
        }

        public string QuestionPhrase { get; }
        public bool CorrectAnswer { get; }
        public string Explanation { get; }

    }
}
