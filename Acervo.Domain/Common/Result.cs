namespace Acervo.Domain.Common
{
    public class Result
    {
        public bool Succeeded { get; }
        public string? Error { get; }

        public Result(bool succeeded, string? error = null)
        {
            Succeeded = succeeded;
            Error = error;
        }

        public static Result Success() => new(true);
        public static Result Failure(string error) => new(false, error);
    }

    public class Result<T> : Result
    {
        protected Result(bool succeeded, T? value, string? error = null)
            : base(succeeded, error)
        {
            Value = value;
        }

        public T? Value { get; }

        public static Result<T> Success(T value) => new(true, value);
        public static new Result<T> Failure(string error) => new(false, default, error);
    }
}
