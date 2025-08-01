using System;
using System.Reflection;
using Atlas.Core.Entities;
using Core.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Helpers;

public static class AtlasPipeLineExtentionMethods
{

    public static void AddDbContext(this IServiceCollection services, IConfiguration conf)
    {
        string defProf = conf.GetConnectionString("def") ?? throw new ArgumentNullException(nameof(conf));
        string defCon = conf.GetConnectionString(defProf) ?? throw new ArgumentNullException(nameof(defProf));


        services.AddDbContext<AtlasDbContext>(config => config.UseSqlServer(defCon));
    }
    
    public static void AddAutoMapper(this IServiceCollection services)
    {
       services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
