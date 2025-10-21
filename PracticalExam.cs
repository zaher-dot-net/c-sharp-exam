namespace CSharpExam;

public class PracticalExam : Exam
{
    public PracticalExam(int timeOfExam, int numberOfQuestions)
        : base(timeOfExam, numberOfQuestions)
    {
    }

    public override void ShowExam()
    {
        Console.WriteLine("\n" + new string('=', 70));
        Console.WriteLine("PRACTICAL EXAM - ANSWER KEY");
        Console.WriteLine(new string('=', 70));

        for (int i = 0; i < Questions.Length; i++)
        {
            if (Questions[i] != null)
            {
                Console.WriteLine($"\n--- Question {i + 1} ---");
                Console.WriteLine($"{Questions[i].Header}");
                Console.WriteLine($"{Questions[i].Body}");
                
                // Find the right answer text
                var rightAnswer = Questions[i].AnswerList
                    .FirstOrDefault(a => a.AnswerId == Questions[i].RightAnswerId);
                
                Console.WriteLine($"\nCorrect Answer: {rightAnswer}");
                Console.WriteLine($"Your Answer: {StudentAnswers[i]}");
                
                bool isCorrect = StudentAnswers[i] == Questions[i].RightAnswerId;
                Console.WriteLine(isCorrect ? "✓ Correct!" : "✗ Incorrect");
            }
        }

        Console.WriteLine("\n" + new string('=', 70));
    }

    public override object Clone()
    {
        var cloned = new PracticalExam(TimeOfExam, NumberOfQuestions);
        for (int i = 0; i < Questions.Length; i++)
        {
            if (Questions[i] != null)
            {
                cloned.Questions[i] = (Question)Questions[i].Clone();
            }
        }
        return cloned;
    }

    public override string ToString()
    {
        return $"[Practical Exam] {base.ToString()}";
    }
}

