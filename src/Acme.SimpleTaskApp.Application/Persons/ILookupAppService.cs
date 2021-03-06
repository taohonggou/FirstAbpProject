﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Acme.SimpleTaskApp.Persons
{
    public interface ILookupAppService : IApplicationService
    {
        Task<List<ComboboxItemDto>> GetPerpleComboboxItems();
    }
}
