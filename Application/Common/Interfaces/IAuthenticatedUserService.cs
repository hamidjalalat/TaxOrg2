﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IAuthenticatedUserService
    {
       
        string UserId { get; }
        string IPAddress { get; }
        string ComputerName { get; }
    }
}
