﻿using Base.Core.Entity;
using Base.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Infrastructure.IService;

public interface IServiceService
{
    Task<Service?> AddNewService(Service? service);
    IEnumerable<Service>? GetAllService();
    Task<Service?> GetServiceById(int id);
}