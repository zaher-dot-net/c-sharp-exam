namespace CSharpExam;

public class Subject : ICloneable
{
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    public Exam? ExamOfSubject { get; set; }

    public Subject(int subjectId, string subjectName)
    {
        SubjectId = subjectId;
        SubjectName = subjectName;
    }

    public void CreateExam()
    {
        Console.WriteLine($"\n{'='} Creating Exam for {SubjectName} {new string('=', 40)}");
        Console.WriteLine("\nSelect Exam Type:");
        Console.WriteLine("1. Final Exam");
        Console.WriteLine("2. Practical Exam");
        Console.Write("Enter your choice (1 or 2): ");

        string? choice = Console.ReadLine();

        Console.Write("Enter time of exam (in minutes): ");

        string? timeOfExamEnterd = Console.ReadLine();

        int timeOfExam = string.IsNullOrWhiteSpace(timeOfExamEnterd) ? 60 : int.Parse(timeOfExamEnterd);

        Console.Write("Enter number of questions: ");
        string? numberOfQuestionsEnterd = Console.ReadLine();

        int numberOfQuestions =
            string.IsNullOrWhiteSpace(numberOfQuestionsEnterd) ? 5 : int.Parse(numberOfQuestionsEnterd);


        if (choice == "1")
        {
            ExamOfSubject = new FinalExam(timeOfExam, numberOfQuestions);
            CreateFinalExamQuestions(numberOfQuestions);
        }
        else if (choice == "2")
        {
            ExamOfSubject = new PracticalExam(timeOfExam, numberOfQuestions);
            CreatePracticalExamQuestions(numberOfQuestions);
        }
        else
        {
            Console.WriteLine("Invalid choice! Creating Final Exam by default.");
            ExamOfSubject = new FinalExam(timeOfExam, numberOfQuestions);
            CreateFinalExamQuestions(numberOfQuestions);
        }

        Console.WriteLine($"\nExam created successfully for {SubjectName}!");
    }

    private void CreateFinalExamQuestions(int numberOfQuestions)
    {
        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.WriteLine($"\n--- Creating Question {i + 1} ---");
            Console.WriteLine("Select Question Type:");
            Console.WriteLine("1. True/False");
            Console.WriteLine("2. MCQ");
            Console.Write("Enter your choice (1 or 2): ");

            string? questionType = Console.ReadLine();

            Console.Write("Enter question header: ");
            string? header = Console.ReadLine() ?? "Question";

            Console.Write("Enter question body: ");
            string? body = Console.ReadLine() ?? "Question body";

            Console.Write("Enter marks for this question: ");
            string? marksInput = Console.ReadLine() ?? "5";

            int marks = 5;

            if (int.TryParse(marksInput, out var parsedMarks))
                marks = parsedMarks;

            if (questionType == "1")
            {
                Console.Write("Enter correct answer (1 for True, 2 for False): ");
                int rightAnswer = int.Parse(Console.ReadLine() ?? "1");
                ExamOfSubject!.Questions[i] = new TrueFalseQuestion(header, body, marks, rightAnswer);
            }
            else
            {
                Console.Write("Enter number of choices: ");
                string? numChoicesInput = Console.ReadLine() ?? "4";

                int numChoices = 4;

                if (int.TryParse(numChoicesInput, out var parsedNumChoices))
                    numChoices = parsedNumChoices;

                Answer[] answers = new Answer[numChoices];
                for (int j = 0; j < numChoices; j++)
                {
                    Console.Write($"Enter choice {j + 1}: ");
                    string? answerText = Console.ReadLine() ?? $"Choice {j + 1}";
                    answers[j] = new Answer(j + 1, answerText);
                }

                Console.Write("Enter correct answer ID (1-" + numChoices + "): ");
                string? rightAnswerInput = Console.ReadLine() ?? "1";

                int rightAnswer = 1;

                if (int.TryParse(rightAnswerInput, out var parsedRightAnswer))
                    rightAnswer = parsedRightAnswer;


                ExamOfSubject!.Questions[i] = new MCQQuestion(header, body, marks, answers, rightAnswer);
            }
        }
    }

    private void CreatePracticalExamQuestions(int numberOfQuestions)
    {
        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.WriteLine($"\n--- Creating Question {i + 1} (MCQ) ---");

            Console.Write("Enter question header: ");
            string? header = Console.ReadLine() ?? "Question";

            Console.Write("Enter question body: ");
            string? body = Console.ReadLine() ?? "Question body";

            Console.Write("Enter marks for this question: ");
            int marks = int.Parse(Console.ReadLine() ?? "5");

            Console.Write("Enter number of choices: ");
            string? numChoicesInput = Console.ReadLine() ?? "4";

            int numChoices = 4;

            if (int.TryParse(numChoicesInput, out var parsedNumChoices))
                numChoices = parsedNumChoices;

            Answer[] answers = new Answer[numChoices];
            for (int j = 0; j < numChoices; j++)
            {
                Console.Write($"Enter choice {j + 1}: ");
                string? answerText = Console.ReadLine() ?? $"Choice {j + 1}";
                answers[j] = new Answer(j + 1, answerText);
            }

            Console.Write("Enter correct answer ID (1-" + numChoices + "): ");
            int rightAnswer = int.Parse(Console.ReadLine() ?? "1");

            ExamOfSubject!.Questions[i] = new MCQQuestion(header, body, marks, answers, rightAnswer);
        }
    }

    public object Clone()
    {
        var cloned = new Subject(SubjectId, SubjectName);
        if (ExamOfSubject != null)
        {
            cloned.ExamOfSubject = (Exam)ExamOfSubject.Clone();
        }

        return cloned;
    }

    public override string ToString()
    {
        return $"Subject: {SubjectName} (ID: {SubjectId})";
    }
}