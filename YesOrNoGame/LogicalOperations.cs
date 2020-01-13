using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesOrNoGame
{
    class LogicalOperations
    {

        // asking the questions
        public static void GettingAnswersForQuestions(List<string> questions, ref string answersFromUser)
        {
            for (int i = 0; i < questions.Count; i++)
            {
                bool rightAnswer = false;
                string answer = null;
                do
                {
                    UI.DoesItQuestion(questions, i);

                    answer = Console.ReadLine();
                    answer = ShorterCode.ChangingAnswer(answer);
                    if (answer == "y" || answer == "n")
                    {
                        answersFromUser += answer;
                        rightAnswer = true;
                    }
                    else
                        UI.OnlyYesOrNo();
                } while (rightAnswer == false);
                Console.Clear();
            }
        }

        // evaluating possible answer
        public static void EvaluatingPossibleAnswer(List<string> answers, string answersFromUser, List<string> matchingAnswers)
        {
            foreach (string ansr in answers)
            {
                if (answersFromUser == ansr)
                    matchingAnswers.Add(ansr);
            }
        }

        // evaluating how manny matches got found
        public static void HowMannyMatches(List<string> matchingAnswers, ref bool onlyOneValue, string possibleRightAnswer, int possibleIndexOfRightAnimal, List<string> answers, ref string possibleRightAnimal, List<string> animal)
        {
            if (matchingAnswers.Count == 0 || matchingAnswers.Count >= 2)
                onlyOneValue = false;
            if (matchingAnswers.Count == 1)
            {
                possibleRightAnswer = matchingAnswers[0];
                possibleIndexOfRightAnimal = answers.IndexOf(possibleRightAnswer);
                possibleRightAnimal = animal[possibleIndexOfRightAnimal];
                onlyOneValue = true;
            }
        }

        // evaluating the possible answer
        public static void ConfirmationFromUser(string possibleRightAnimal, ref string theRightAnimalYesNo, ref bool again, bool onlyOneValue)
        {
            if (possibleRightAnimal != null && onlyOneValue == true)
            {
                bool rightAnswer = false;
                bool rightAnswer2 = false;
                string answer = null;

                do
                {
                    Console.WriteLine($"Is {possibleRightAnimal} the animal you've been thinking about?\ny/n");
                    theRightAnimalYesNo = Console.ReadLine();
                    theRightAnimalYesNo = ShorterCode.ChangingAnswer(theRightAnimalYesNo);
                    Console.Clear();

                    // checking the right answer
                    if (theRightAnimalYesNo == "y" || theRightAnimalYesNo == "n")
                    {
                        rightAnswer = true;
                        if (theRightAnimalYesNo == "y")
                        {
                            do
                            {
                                Console.WriteLine("Well played, would you like to play again?\ny/n");
                                answer = Console.ReadLine();
                                answer = ShorterCode.ChangingAnswer(answer);
                                Console.Clear();

                                if (answer == "y" || answer == "n")
                                {
                                    rightAnswer2 = true;
                                    if (answer == "n")
                                    {
                                        again = false;
                                        Console.WriteLine("Thank you for playing this game and remember to rate this project on Moodle and on Spsejecna :)");
                                        System.Threading.Thread.Sleep(7000);
                                    }
                                }
                                else
                                    UI.OnlyYesOrNo();
                            } while (rightAnswer2 == false);
                        }
                    }
                    else
                        UI.OnlyYesOrNo();
                } while (rightAnswer == false);
            }
        }

        // adding new animal
        public static void AddingNewAnimal(ref string theRightAnimal, List<string> animal, bool rightAnswer)
        {
            do
            {
                Console.WriteLine("What is the name of the animal you've been thinking about:");
                theRightAnimal = Console.ReadLine();
                theRightAnimal = ShorterCode.CapitalisingAnimal(theRightAnimal);
                if (theRightAnimal != null)
                {
                        if (!(ShorterCode.ContainsAnimal(animal, theRightAnimal)))
                        {
                            rightAnswer = true;
                            animal.Add(theRightAnimal);
                        }
                        else
                            Console.WriteLine("You can't add existing animal!");
                }
                else
                    Console.WriteLine("You need to enter animal!");

            } while (rightAnswer == false);
            Console.Clear();
        }

        // asking new question
        public static void AddingNewQuestionTheQuestion(string theRightAnimal, string theNewQuestion, List<string> questions)
        {
            bool rightAnswer = false;
            do
            {
                Console.WriteLine($"What new question would you ask in order to separate {theRightAnimal} from the others?\nEnter the question in this format 'have 4 legs', 'have tail', 'bark', 'meow'!");
                theNewQuestion = Console.ReadLine();
                theNewQuestion = theNewQuestion.Trim();
                if (theNewQuestion != null && theNewQuestion != "")
                {
                    theNewQuestion += "?";
                    questions.Add(theNewQuestion);
                    rightAnswer = true;
                }
                else
                    Console.WriteLine("You need to enter some question!");
            } while (rightAnswer == false);
            
            Console.Clear();
        }

        // getting additional answers for the new question
        public static void GettingAdditionalAnswers(List<string> animal, List<string> questions, ref int startingQuestionCount, string savingValue, string newAnswers, List<string> answers)
        {
            Console.WriteLine("You will answer some questions about some animals, so the program has more information to work with.\nPress enter.");
            Console.Clear();
            for (int a = 0; a < animal.Count; a++)
            {
                for (int i = 0; i < (questions.Count - startingQuestionCount); i++)
                {
                    bool rightAnswer = false;
                    string answer = null;
                    do
                    {
                        Console.WriteLine($"Does {animal[a]} {questions[startingQuestionCount]}\ny/n");
                        answer = Console.ReadLine();
                        answer = ShorterCode.ChangingAnswer(answer);
                        Console.Clear();

                        if (answer == "y" || answer == "n")
                        {
                            savingValue += answer;
                            rightAnswer = true;
                        }
                        else
                            UI.OnlyYesOrNo();
                    } while (rightAnswer == false);
                }
                newAnswers = answers[a];
                newAnswers += savingValue;
                answers[a] = newAnswers;
                savingValue = null;
            }
            startingQuestionCount++;
        }

        // adding new answer if there needs to be one added
        public static void AddingNewQuestionWhole(bool onlyOneValue, string theRightAnimalYesNo, string theRightAnimal, string theNewQuestion, List<string> questions, List<string> animal, ref int startingQuestionCount, string savingValue, string newAnswers, List<string> answers, int startingAnimalCount)
        {
            if (onlyOneValue != false || theRightAnimalYesNo == "n")
            {
                AddingNewQuestionTheQuestion(theRightAnimal, theNewQuestion, questions);

                // getting additional answers for the new question
                GettingAdditionalAnswers(animal, questions, ref startingQuestionCount, savingValue, newAnswers, answers);
            }
            startingAnimalCount++;
        }

        // there was either no match or there were more than one matches or the guessed animal was wrong
        public static void NoMatchMoreMatchesWrongAnimal(bool onlyOneValue, string theRightAnimalYesNo, string theRightAnimal, string theNewQuestion, List<string> questions, List<string> animal, ref int startingQuestionCount, string savingValue, string newAnswers, List<string> answers, int startingAnimalCount, string possibleRightAnimal, string answersFromUser, List<string> matchingAnswers)
        {
            if (possibleRightAnimal == null || onlyOneValue == false || theRightAnimalYesNo == "n")
            {
                UI.NoAnimalWasFoundInfo(possibleRightAnimal, onlyOneValue, theRightAnimalYesNo);

                bool rightAnswer = false;
                answers.Add(answersFromUser);

                // adding new animal
                LogicalOperations.AddingNewAnimal(ref theRightAnimal, animal, rightAnswer);

                // adding new answer if there needs to be one added
                LogicalOperations.AddingNewQuestionWhole(onlyOneValue, theRightAnimalYesNo, theRightAnimal, theNewQuestion, questions, animal, ref startingQuestionCount, savingValue, newAnswers, answers, startingAnimalCount);
            }
            matchingAnswers.RemoveRange(0, matchingAnswers.Count);
        }
    }
}
