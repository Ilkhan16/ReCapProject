namespace Core.Utilites.Results.Concrete;

public class SuccessDataResult<T>:DataResult<T>
{
    public SuccessDataResult(T data, string messages) : base(data, true, messages)
    {
    }

    public SuccessDataResult(T data) : base(data, true)
    {
    }
    public SuccessDataResult() : base(default, true)
    {
    }
}