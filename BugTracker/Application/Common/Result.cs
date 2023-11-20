namespace BugTracker.Application.Common
{
    public class Result<T>
    {
        public T Value { get; set; }
        public string[] Errors { get; set; }
        public bool IsSuccess { get; set; }
        public Result() { }

        public static Result<T> Success(T value) => new() { IsSuccess = true, Value = value };
        public static Result<T> Failure(params string[] errors) => new() { Errors = errors };

    }
}
