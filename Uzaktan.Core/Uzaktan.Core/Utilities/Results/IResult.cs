﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Uzaktan.Core.Utilities.Results
{
    public interface IResult
    {
        bool Success { get; set; }
        string Message { get; set; }
    }
}
