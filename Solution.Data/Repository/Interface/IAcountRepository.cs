﻿using Solution.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Repository.Interface
{
    public interface IAcountRepository
    {
        Task<bool> IsValidUser(Login login);
        Task<bool> IsValidUserAsync(Login loginModel);
        Task<bool> Register(Register registerDetails);
    }
}
