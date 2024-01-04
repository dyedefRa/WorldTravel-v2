using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using WorldTravel.Abstract;
using WorldTravel.Dtos.Receipts;
using WorldTravel.Enums;

namespace WorldTravel.Web.Pages.Admin.Customer
{
    public class FormDetail : PageModel
    {

        //admin 1q2w3E*

        [Parameter]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int FormIsOk { get; set; }
        public string PhoneNumber { get; set; }
        public GenderType? Gender { get; set; }

        private readonly IFormAppService _formAppService;

        public FormDetail(IFormAppService formAppService)
        {
            _formAppService = formAppService;
        }

        public async Task OnGet(int id)
        {
            Id = id;
            var form = await _formAppService.GetFormAsync(id);
            if (form == null)
            {
                throw new UserFriendlyException("Form bulunamadý.");
            }
            else
            {
                FullName = form.Data.Name;
                Email = form.Data.Email;
                PhoneNumber = form.Data.PhoneNumber;
                Gender = form.Data.Gender;
                FormIsOk = form.Data.FormIsOk;
            }
        }
    }
}
