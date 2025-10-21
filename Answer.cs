namespace CSharpExam;

public class Answer : ICloneable
{
    public int AnswerId { get; set; }
    public string AnswerText { get; set; }

    public Answer(int answerId, string answerText)
    {
        AnswerId = answerId;
        AnswerText = answerText;
    }

    public object Clone()
    {
        return new Answer(AnswerId, AnswerText);
    }

    public override string ToString()
    {
        return $"{AnswerId}. {AnswerText}";
    }
}

