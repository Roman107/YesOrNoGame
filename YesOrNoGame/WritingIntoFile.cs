using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesOrNoGame
{
    class WritingIntoFile
    {

        public static void WritingIntoFiles(List<string> questions, List<string> animal, List<string> answers)
        {
            using (var questionWriter = new StreamWriter("questions.txt"))
            {

                foreach (string q in questions)
                {
                    questionWriter.WriteLine(q);
                }
            }

            using (StreamWriter animalWriter = new StreamWriter("animal.txt"))
            {

                foreach (string a in animal)
                {
                    animalWriter.WriteLine(a);
                }
            }

            using (StreamWriter answerWriter = new StreamWriter("answers.txt"))
            {

                foreach (string an in answers)
                {
                    answerWriter.WriteLine(an);
                }
            }
        }

    }
}
