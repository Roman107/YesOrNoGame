using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesOrNoGame
{
    class UI
    {
        // interduction
        public static void Interduction()
        {
            Console.WriteLine("Think of an animal that you'd like the program to guess.\n" +
                                  "You will answer some questions about your animal.\n" +
                                  "Press enter.");
            Console.ReadLine();
            Console.Clear();
        }

        // warning user to answer with yes or no
        public static void OnlyYesOrNo()
        {
            Console.WriteLine("You didn't answer yes or no, try that again.");
        }

        // asking user serious of questions
        public static void DoesItQuestion(List<string> questions, int i)
        {
            Console.WriteLine($"Does it {questions[i]}\ny/n");
        }

        // informing user about his answers
        public static void NoAnimalWasFoundInfo(string possibleRightAnimal, bool onlyOneValue, string theRightAnimalYesNo)
        {
            if (possibleRightAnimal == null)
                Console.WriteLine("No animal with matching answers has been found, in order to improve your next game you will add some information about your animal.");
            else
                if (onlyOneValue == false || theRightAnimalYesNo == "n")
                Console.WriteLine("Now you can add the animal you've been thinking about.");
        }
    }
}
