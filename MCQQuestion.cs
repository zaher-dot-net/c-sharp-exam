namespace CSharpExam;

public class MCQQuestion : Question
{
    public MCQQuestion(string header, string body, int mark, Answer[] answerList, int rightAnswerId)
        : base(header, body, mark, answerList, rightAnswerId)
    {
    }

    public override object Clone()
    {
        Answer[] clonedAnswers = AnswerList.Select(a => (Answer)a.Clone()).ToArray();
        return new MCQQuestion(Header, Body, Mark, clonedAnswers, RightAnswerId);
    }

    public override void DisplayQuestion()
    {
        Console.WriteLine($"\n{Header}");
        Console.WriteLine($"{Body}");
        Console.WriteLine($"Mark: {Mark}");
        Console.WriteLine("Answers:");
        foreach (var answer in AnswerList)
        {
            Console.WriteLine($"  {answer}");
        }
    }

    public override string ToString()
    {
        return $"MCQ {base.ToString()}";
    }
}

