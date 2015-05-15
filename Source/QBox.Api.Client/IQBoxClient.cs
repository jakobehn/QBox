﻿using System.Collections.Generic;
using System.Threading.Tasks;
using QBox.Api.DTO;

namespace QBox.Api.Client
{
    public interface IQBoxClient
    {
        Task<List<CategoryDTO>> GetCategories();
    }
}