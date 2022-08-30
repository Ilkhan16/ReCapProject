namespace Core.Utilites.Results.Concrete;

public class SuccessResult:Result
{
    public SuccessResult(string messages) : base(true, messages)
    {
    }

    public SuccessResult() : base(true)
    {
    }
}