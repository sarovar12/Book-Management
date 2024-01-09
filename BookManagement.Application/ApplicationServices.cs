﻿using BookManagement.Application.Manager.ImplementingManager;
using BookManagement.Application.Manager.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BookManagement.Application
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddInApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBookManager, BookManager>();
            return services;
        }
    }
}