﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BMICalculator.Pages
{
    public class AboutModel : PageModel
    {
        [BindProperty]
        public BMI BMI { get; set; }
    }
}
