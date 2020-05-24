using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TripleTriad;
using TripleTriad.Commands;
using TripleTriad.Services;
using TripleTriad.Validators;

namespace TripleTriadWebApplication.DependencyInjection
{
    public static class DependencyInjectionExtension
    {
        public static void TripleTriad(this IServiceCollection services)
        {
            services.AddScoped<IGameService, GameService>();

            services.AddScoped<IValidator<Card>, CardValidator>();
            services.AddScoped<IValidator<NewGameCommand>, NewGameCommandValidator>();
            services.AddScoped<IValidator<Player>, PlayerValidator>();
        }
    }
}