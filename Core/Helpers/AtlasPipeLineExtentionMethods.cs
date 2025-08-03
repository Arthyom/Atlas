using System;
using System.Reflection;
using Atlas.Core.Entities;
using Core.Enums;
using Core.Models.Context;
using Core.Services.Implementations.Base;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Helpers;

public static class AtlasPipeLineExtentionMethods
{

    public static void ApplyMigrations(this IApplicationBuilder application)
    {
        using (var scope = application.ApplicationServices.CreateScope())
        {
            try
            {
                AtlasDbContext context = scope.ServiceProvider.GetService<AtlasDbContext>() ?? throw new ArgumentNullException("No context");
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

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
    

        public static void ApplySeeders(this IApplicationBuilder application)
    {
        using (var scope = application.ApplicationServices.CreateScope())
        {
            try
            {
                AtlasDbContext context = scope.ServiceProvider.GetService<AtlasDbContext>() ?? throw new ArgumentNullException("No context");
                IUnitOfWork unitOfWork  = scope.ServiceProvider.GetService<IUnitOfWork>() ?? throw new ArgumentNullException("No context");


                foreach (var type in Constants.SeederTypesAndOrder)
                {
                    var specific = typeof(SeederFacade<>).MakeGenericType(type);
                    var target = Activator.CreateInstance(specific, context, unitOfWork);

                    var mInfo = specific.GetMethod("Seed");

                    if (mInfo == null)
                        throw new Exception("Error seeding data");
                    else
                        mInfo.Invoke(target, null);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }


}
