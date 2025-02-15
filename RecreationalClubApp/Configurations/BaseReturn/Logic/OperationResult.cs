using Configurations.BaseReturn.Interface;
using Microsoft.AspNetCore.Mvc;


namespace Configurations.BaseReturn.Logic
{

    public class OperationResult<T> : IOperationResult<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Data { get; private set; }

        public OperationResult(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(new { Success, Message, Data })
            {
                StatusCode = Success ? 200 : 400
            };
            await objectResult.ExecuteResultAsync(context);
        }
    }
}
