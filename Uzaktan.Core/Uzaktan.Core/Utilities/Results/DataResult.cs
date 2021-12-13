
namespace Uzaktan.Core.Utilities.Results
{
    public class DataResult<T>:Result,IDataResult<T>
    {
        public T Data { get; set; }

        public DataResult(bool success,string message,T data):base(success,message)
        {
            Data = data;
        }
    }
}
