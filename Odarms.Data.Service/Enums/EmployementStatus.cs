﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odarms.Data.Service.Enums
{
    public class EmployementStatus
    {
        Active,
        Retired,
        Suspended,
        [Display(Name = "On Leave")]
        OnLeave,
    }
}
