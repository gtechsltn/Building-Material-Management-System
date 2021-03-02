﻿using System;
using System.Collections.Generic;
using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;

namespace com.Github.Haseoo.BMMS.Business.Services.Ports
{
    public interface ICompanyService : ITransactionalService<CompanyOperationDto, CompanyDto>
    {
        IList<CompanyDto> GetList();
        IList<CompanyDto> SearchByName(string partialName);
        CompanyDto GetById(Guid id);
        CompanyDto Update(Guid id, CompanyOperationDto operation);
    }
}
