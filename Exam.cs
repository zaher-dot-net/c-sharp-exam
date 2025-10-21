namespace CSharpExam;

public abstract class Exam : ICloneable
{
    public int TimeOfExam { get; set; } // in minutes
    public int NumberOfQuestions { get; set; }
    public Question[] Questions { get; set; }
    public int[] StudentAnswers { get; set; }

    // Constructor chaining
    protected Exam(int timeOfExam, int numberOfQuestions)
    {
        TimeOfExam = timeOfExam;
        NumberOfQuestions = numberOfQuestions;
        Questions = new Question[numberOfQuestions];
        StudentAnswers = new int[numberOfQuestions];
    }

    public abstract void ShowExam();
    public abstract object Clone();

    public override string ToString()
    {
        return $"Exam: {NumberOfQuestions} questions, {TimeOfExam} minutes";
    }

    public void ConductExam()
    {
        Console.WriteLine($"\n{'='} EXAM STARTED {new string('=', 50)}");
        Console.WriteLine($"Time: {TimeOfExam} minutes");
        Console.WriteLine($"Number of Questions: {NumberOfQuestions}");
        Console.WriteLine(new string('=', 70));

        for (int i = 0; i < Questions.Length; i++)
        {
            if (Questions[i] != null)
            {
                Console.WriteLine($"\n--- Question {i + 1} ---");
                Questions[i].DisplayQuestion();
                
                Console.Write("\nYour Answer (Enter Answer ID): ");
                if (int.TryParse(Console.ReadLine(), out int answer))
                {
                    StudentAnswers[i] = answer;
                }
                else
                {
                    StudentAnswers[i] = 0; // Invalid answer
                }
            }
        }

        Console.WriteLine($"\n{new string('=', 70)}");
        Console.WriteLine("EXAM FINISHED");
        Console.WriteLine(new string('=', 70));
    }

    protected int CalculateGrade()
    {
        int totalMarks = 0;
        int earnedMarks = 0;

        for (int i = 0; i < Questions.Length; i++)
        {
            if (Questions[i] != null)
            {
                totalMarks += Questions[i].Mark;
                if (StudentAnswers[i] == Questions[i].RightAnswerId)
                {
                    earnedMarks += Questions[i].Mark;
                }
            }
        }

        return totalMarks > 0 ? (earnedMarks * 100) / totalMarks : 0;
    }
}

