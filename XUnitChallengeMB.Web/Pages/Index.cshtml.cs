using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using XUnitChallengeMB.Web.Models;
using XUnitChallengeMB.Web.Services;

namespace XUnitChallengeMB.Web.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public CalcModel CurrentResult{ get; set; }

        public CalcModel PreviousResult { get; set; }

        public ICalcService _calcService;

        public IndexModel(ICalcService calcService)
        {
            _calcService = calcService;
        }

        public IActionResult OnGet()
        {
            CurrentResult = new CalcModel();
            PreviousResult = _calcService.GetPreviousResult();
            return Page();
        }

        public IActionResult OnPostMultiplyNumbers()
        {
            if (!ModelState.IsValid)
            {
                //not good ux, but works for demo purposes
                return BadRequest();
            }

            //Get new previous calcuation
            PreviousResult = _calcService.GetPreviousResult();
            //Save current calculation
            _calcService.StoreResult(CurrentResult);

            return Page();
        }
    }
}
