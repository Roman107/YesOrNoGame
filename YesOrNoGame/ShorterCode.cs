using System;
using System.Collections.Generic;

namespace YesOrNoGame
{
    class ShorterCode
    {
        public static string ChangingAnswer(string answer)
        {
            answer = answer.Trim().ToLower();
            if (answer == "y" || answer == "yes")
                return answer = "y";
            else
                if (answer == "n" || answer == "no")
                    return answer = "n";
            return null;
        }

        public static string CapitalisingAnimal(string animal)
        {
            animal = animal.Trim().ToLower();
            if (animal.Length == 0)
                return null;
            else
                animal = char.ToUpper(animal[0]) + animal.Substring(1);
            return animal;
        }

        public static bool ContainsAnimal(List<string> animal, string upperCapAnimal)
        {
            foreach (string anim in animal)
            {
                if (anim == upperCapAnimal)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
