namespace Core.Ultilities.Results
{
    //Voidler için
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}