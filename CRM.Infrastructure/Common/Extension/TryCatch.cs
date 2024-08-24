using ErrorOr;

namespace CRM.Infrastructure.Common.Extension;



public static class SafeExecutor<T>
{

    public static async Task<ErrorOr<T>> RunAsync(Func<Task<T>> invoke)
    {
        try
        {
            return await invoke();
        }
        catch (Exception ex)
        {
            return Error.Validation(description: ex.Message);
        }
    }


    public static ErrorOr<T> Run(Func<ErrorOr<T>> invoke)
    {
        try
        {
            return invoke();
        }
        catch (Exception ex)
        {
            return Error.Validation(description: ex.Message);
        }
    }

}