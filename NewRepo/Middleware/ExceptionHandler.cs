using NewRepo.Exceptions;

namespace NewRepo.Middleware
{
    public class ExceptionHandler : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (EntityNotFound ex)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Resource not found");
            }
            catch(OrderImpossibleToUpdate ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Cannot update the order because it has already been processed.");
            }
            catch(ArgumentException ex) {
                context.Response.StatusCode=400;
                await context.Response.WriteAsync("You put wrong arguments, please check given data.");
            }
            catch (FileFormatNotSupported ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("File format it's not supported.");
            }
            catch (FinalizeOrderException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("The order was finalized incorrectly. Please contact the support department.");
            }
            catch (FileIsEmpty ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Your file is empty. Put correct file and try again.");
            }
            
        }
    }
}
