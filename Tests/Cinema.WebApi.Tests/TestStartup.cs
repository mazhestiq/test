using Cinema.DataAccess;
using Cinema.WebApi.Host;
using Cinema.WebApi.Host.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using Cinema.Domains.Entities;
using Cinema.Domains.Enums;
using Microsoft.AspNetCore.Builder;

namespace Cinema.WebApi.Tests;

public class TestStartup : Startup
{
    public TestStartup(IWebHostEnvironment env) : base(env)
    {
        
    }
}