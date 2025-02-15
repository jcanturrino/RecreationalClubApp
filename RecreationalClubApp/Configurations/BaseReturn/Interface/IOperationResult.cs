using Configurations.BaseReturn.Logic;
using Microsoft.AspNetCore.Mvc;

namespace Configurations.BaseReturn.Interface
{
    public interface IOperationResult<T> : IActionResult
    {
        bool Success { get; }
        string Message { get; }
        T Data { get; }
        static IOperationResult<T> SuccessResult(T data, string message = "Operación exitosa")
        {
            return new OperationResult<T>(true, message, data);
        }
        static IOperationResult<T> ErrorResult(string message)
        {
            return new OperationResult<T>(false, message, default(T));
        }
        static async Task<IOperationResult<T>> TryExecuteAsync(Func<Task<T>> operation)
        {
            try
            {
                var data = await operation();
                return SuccessResult(data);
            }
            catch (Exception ex)
            {
                return ErrorResult($"Error: {ex.Message}");
            }
        }
        static async Task<IOperationResult<T>> TryExecuteAsync(Func<Task> operation)
        {
            try
            {
                await operation();
                return SuccessResult(default(T));
            }
            catch (Exception ex)
            {
                return ErrorResult($"Error: {ex.Message}");
            }
        }
    }
}
