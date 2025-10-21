namespace CSharpExam;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("   EXAMINATION SYSTEM");

        // Create a subject
        Console.Write("Enter Subject ID: ");
        string? subjectIdEntered = Console.ReadLine();
        
        int subjectId =string.IsNullOrWhiteSpace(subjectIdEntered) ? 1 : int.Parse(subjectIdEntered);
        
        Console.Write("Enter Subject Name: ");
        string? subjectName = Console.ReadLine();
        
        // Handle empty input by using default value
        if (string.IsNullOrWhiteSpace(subjectName))
        {
            subjectName = "Programming";
        }

        Subject subject = new Subject(subjectId, subjectName);
        Console.WriteLine($"\nSubject Created: {subject}");

        // Create exam for the subject
        subject.CreateExam();

        // Conduct the exam
        if (subject.ExamOfSubject != null)
        {
            subject.ExamOfSubject.ConductExam();

            // Show exam results
            subject.ExamOfSubject.ShowExam();
        }

        Console.WriteLine("\n\nPress any key to exit...");
        Console.ReadKey();
    }
}