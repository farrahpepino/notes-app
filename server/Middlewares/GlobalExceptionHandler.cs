// using Microsoft.Exceptions.Logging;
// using Microsoft.AspNetCore.Http;


// namespace server.Middlewars{
//     public class GlobalExceptionHandler{
//         private readonly ILogger<GlobalExceptionHandler> _logger;
//         private readonly RequestDelegate _next;

//         public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, RequestDelegate next){
//             _logger = logger;
//             _next = next;
//         }

//         public async Task Invoke(HttpContext context){
//             try {
//                 await _next(context);
//             }
//             catch (Exception ex){

//             }
//         }
//     }
// }