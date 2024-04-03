using Buying.Application.Common.Accessors;
using Buying.Application.Instructions.Responses;
using Buying.Application.Instructions.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Buying.Application.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);

            services.AddAutoMapper(option =>
            {
                option.AddProfile<InstructionMapping>();
            });

            services.AddFluentValidationAutoValidation()
                    .AddValidatorsFromAssemblyContaining<CreateInstructionValidator>();

            services.AddHttpContextAccessor();

            services.AddTransient<IUserAccessor, UserAccessor>();

            return services;
        }
    }
}