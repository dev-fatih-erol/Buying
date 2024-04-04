using Buying.Application.Common.Accessors;
using Buying.Application.Instructions.Consumers;
using Buying.Application.Instructions.Responses;
using Buying.Application.Instructions.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Buying.Application.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
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

            services.AddMassTransit(options =>
            {
                options.AddDelayedMessageScheduler();

                options.AddConsumer<InstructionCreatedConsumer>();

                options.UsingRabbitMq((context, config) =>
                {
                    config.Host(configuration.GetSection("RabbitMQ:Host").Value, "/", options =>
                    {
                        options.Username(configuration.GetSection("RabbitMQ:Username").Value);
                        options.Password(configuration.GetSection("RabbitMQ:Password").Value);
                    });

                    config.ReceiveEndpoint("Instruction-Created-Event", options =>
                    {
                        options.ConfigureConsumer<InstructionCreatedConsumer>(context);
                    });

                    config.UseDelayedMessageScheduler();

                    config.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}