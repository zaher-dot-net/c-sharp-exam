namespace CSharpExam;

public class TrueFalseQuestion : Question
{
    public TrueFalseQuestion(string header, string body, int mark, int rightAnswerId)
        : base(header, body, mark)
    {
        AnswerList = new Answer[]
        {
            new Answer(1, "True"),
            new Answer(2, "False")
        };
        RightAnswerId = rightAnswerId;
    }

    public override object Clone()
    {
        var cloned = new TrueFalseQuestion(Header, Body, Mark, RightAnswerId);
        return cloned;
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
        return $"[True/False] {base.ToString()}";
    }
}
