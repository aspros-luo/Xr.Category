﻿using System.ComponentModel.DataAnnotations;

namespace Aspros.SaaS.System.Domain.ValueObjects
{
    public enum Sex
    {
        [Display(Description = "男")]
        Man = 1,
        [Display(Description = "女")]
        Female = 2
    }
}
