namespace Business.Utilities;

public interface IDataResult<T>:IResult
{
    T Data { get; }
    
}