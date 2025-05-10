using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Entities;
using Todo.Core.Interfaces;
using Todo.Infrastructure.Data;
using Todo.Infrastructure.Repositories;

namespace Todo.Infrastructure
{
    public static class InfrastructreConfiguration
    {
        public static IServiceCollection AddInfraStructure(this IServiceCollection services , IConfiguration configuration) 
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            services.AddScoped<ITodoRepository, TodoRepository>();
           // services.AddScoped<IRepository<TodoItem>, Repository<TodoItem>>();

            return services;

        }
    }
}
