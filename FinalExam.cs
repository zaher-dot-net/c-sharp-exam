namespace CSharpExam;

public class FinalExam : Exam
{
    public FinalExam(int timeOfExam, int numberOfQuestions)
        : base(timeOfExam, numberOfQuestions)
    {
    }

    public override void ShowExam()
    {
        Console.WriteLine("\n" + new string('=', 70));
        Console.WriteLine("FINAL EXAM RESULTS");
        Console.WriteLine(new string('=', 70));

        int totalMarks = 0;
        int earnedMarks = 0;

        for (int i = 0; i < Questions.Length; i++)
        {
            if (Questions[i] != null)
            {
                Console.WriteLine($"\n--- Question {i + 1} ---");
                Console.WriteLine($"{Questions[i].Header}");
                Console.WriteLine($"{Questions[i].Body}");
                Console.WriteLine($"Mark: {Questions[i].Mark}");
                
                Console.WriteLine("\nAnswers:");
                foreach (var answer in Questions[i].AnswerList)
                {
                    Console.WriteLine($"  {answer}");
                }

                Console.WriteLine($"\nYour Answer: {StudentAnswers[i]}");
                
                bool isCorrect = StudentAnswers[i] == Questions[i].RightAnswerId;
                totalMarks += Questions[i].Mark;
                
                if (isCorrect)
                {
                    earnedMarks += Questions[i].Mark;
                    Console.WriteLine($"Result: ✓ Correct! (+{Questions[i].Mark} marks)");
                }
                else
                {
                    Console.WriteLine($"Result: ✗ Incorrect (0 marks)");
                }
            }
        }

        int grade = CalculateGrade();
        Console.WriteLine("\n" + new string('=', 70));
        Console.WriteLine($"FINAL GRADE: {earnedMarks}/{totalMarks} ({grade}%)");
        Console.WriteLine(new string('=', 70));
    }

    public override object Clone()
    {
        var cloned = new FinalExam(TimeOfExam, NumberOfQuestions);
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
        return $"[Final Exam] {base.ToString()}";
    }
}

