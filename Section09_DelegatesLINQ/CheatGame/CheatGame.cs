using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Section09_DelegatesLINQ
{
    public class CheatGame
    {
        private int _mistakesCount;
        private List<Question> _questions;
        private int counter;

        public GameStatusEnum GameStatus { get; private set; }
        public event EventHandler<CheatGameEventArg> EndOfGameEvent;
        public event Action<string> WrongAnswerEvent;

        public CheatGame(int maxNumberOfMistakes, string questionsFile)
        {
            MaxNumberOfMistakes = maxNumberOfMistakes;
            QuestionsFile = questionsFile;
            GameStatus = GameStatusEnum.NotStarted;
        }

        public int MaxNumberOfMistakes { get; }
        public string QuestionsFile { get; }

        public void Start()
        {
            List<Question> questions = File.ReadAllLines(QuestionsFile)
                                   .Select(x =>
                                   {
                                       string[] parts = x.Split(";");
                                       string questionPhrase = parts[0].Trim();
                                       bool correctAnswer = parts[1].Trim() == "Yes";
                                       string explanation = parts[2].Trim();

                                       return new Question(questionPhrase, correctAnswer, explanation);
                                   })
                                   .ToList();
            this._questions = questions;
            GameStatus = GameStatusEnum.InProgress;
        }

        public string GetNextQuestion()
        {
            return _questions[counter].QuestionPhrase;
        }

        public void ValidateAnswer(bool answer)
        {
            if (_questions[counter].CorrectAnswer != answer)
            {
                _mistakesCount++;
                WrongAnswerEvent?.Invoke(_questions[counter].Explanation);
            }

            if (counter == _questions.Count - 1 || _mistakesCount == MaxNumberOfMistakes)
            {
                GameStatus = GameStatusEnum.GameIsOver;

                if (EndOfGameEvent != null)
                    EndOfGameEvent(this, new CheatGameEventArg(counter, _mistakesCount ==
                        MaxNumberOfMistakes? false : true));
            }

            counter++;
        }
    }
}