namespace CSharpExam;

public abstract class Question : ICloneable, IComparable<Question>
{
    public string Header { get; set; }
    public string Body { get; set; }
    public int Mark { get; set; }
    public Answer[] AnswerList { get; set; } = Array.Empty<Answer>();
    public int RightAnswerId { get; set; }

    // Constructor chaining - base constructor
    protected Question(string header, string body, int mark)
    {
        Header = header;
        Body = body;
        Mark = mark;
    }

    // Constructor chaining - extended constructor
    protected Question(string header, string body, int mark, Answer[] answerList, int rightAnswerId)
        : this(header, body, mark)
    {
        AnswerList = answerList;
        RightAnswerId = rightAnswerId;
    }

    public abstract object Clone();

    public int CompareTo(Question? other)
    {
        if (other == null) return 1;
        return this.Mark.CompareTo(other.Mark);
    }

    public override string ToString()
    {
        return $"{Header}\n{Body} ({Mark} marks)";
    }

    public abstract void DisplayQuestion();
}

