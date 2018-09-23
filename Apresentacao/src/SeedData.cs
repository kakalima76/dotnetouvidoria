using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Context;
using System;
using System.Linq;

namespace src
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new locaisContext(
                serviceProvider.GetRequiredService<DbContextOptions<locaisContext>>()))
            {
                // Look for any movies.
                if (context.Bairro.Any())
                {
                    return;   // DB has been seeded
                }

                if (context.Geolocalizado.Any())
                {
                    return;   // DB has been seeded
                }

                 if (context.Logradouro.Any())
                {
                    return;   // DB has been seeded
                }

        }
    }
}}