using System;
using System.Collections.Generic;
using System.IO;

namespace YesOrNoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // storing of the question, animals and answers for the questions for each animal

                List<string> questions = new List<string>(System.IO.File.ReadAllLines(@"questions.txt"));
                List<string> animal = new List<string>(System.IO.File.ReadAllLines(@"animal.txt"));
                List<string> answers = new List<string>(System.IO.File.ReadAllLines(@"answers.txt"));
                List<string> matchingAnswers = new List<string>();

                // variables that needed to be created before the do while cycle (i created them here just to make sure)
                int startingQuestionCount = questions.Count;
                int startingAnimalCount = animal.Count;
                bool again = true;

                // guessing the animal
                do
                {
                    // helping variables
                    string answersFromUser = null;
                    string possibleRightAnswer = null;
                    string possibleRightAnimal = null;
                    string theNewQuestion = null;
                    string theRightAnimalYesNo = null;
                    string theRightAnimal = null;
                    string savingValue = null;
                    string newAnswers = null;
                    bool onlyOneValue = false;
                    int possibleIndexOfRightAnimal = 0;

                    // interduction
                    UI.Interduction();

                    // asking the questions
                    LogicalOperations.GettingAnswersForQuestions(questions, ref answersFromUser);


                    // evaluating possible answer
                    LogicalOperations.EvaluatingPossibleAnswer(answers, answersFromUser, matchingAnswers);


                    // evaluating how manny matches got found
                    LogicalOperations.HowMannyMatches(matchingAnswers, ref onlyOneValue, possibleRightAnswer, possibleIndexOfRightAnimal, answers, ref possibleRightAnimal, animal);


                    // evaluating the possible answer
                    LogicalOperations.ConfirmationFromUser(possibleRightAnimal, ref theRightAnimalYesNo, ref again, onlyOneValue);


                    // there was either no match or there were more than one matches or the guessed animal was wrong
                    LogicalOperations.NoMatchMoreMatchesWrongAnimal(onlyOneValue, theRightAnimalYesNo, theRightAnimal, theNewQuestion, questions, animal, ref startingQuestionCount, savingValue, newAnswers, answers, startingAnimalCount, possibleRightAnimal, answersFromUser, matchingAnswers);
                }
                while (again == true);

                WritingIntoFile.WritingIntoFiles(questions, animal, answers);

            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception caught: {e}");
            }
        }
    }
}