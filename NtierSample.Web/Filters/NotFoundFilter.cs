using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NtierSample.Core.Services;
using NtierSample.Web.ApiServices;
using NtierSample.Web.DTOs;

namespace NtierSample.Web.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        //Notfound Filter generic değil, bütün enttyleri kontrol edebilecek jenerik bir filter yapılmalı.!
        private readonly CategoryApiService _categoryApiService;

        public NotFoundFilter(CategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int) context.ActionArguments.Values.FirstOrDefault();

            var category = await _categoryApiService.GetByIdAsync(id);

            if (category!=null)
            {
                await next();
            }
            
            else
            {
                ErrorDto errorDto = new ErrorDto();

                errorDto.Status = 404;

                errorDto.Errors.Add($"id'si {id} olan kategori veritabanında bulunamadı.");

                context.Result = new RedirectToActionResult("Error","Home",errorDto);
            }
        }
    }
}