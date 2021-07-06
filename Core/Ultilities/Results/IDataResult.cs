namespace Core.Ultilities.Results
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}