﻿using Base.Core.Application;
using System.Security.Claims;

namespace Base.API.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid UserId => 
        Guid.Parse(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? 
            throw new InvalidOperationException("Unauthenticated User"));

    public string UserName => 
        _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name) ??
            throw new InvalidOperationException("Unauthenticated User");
}
