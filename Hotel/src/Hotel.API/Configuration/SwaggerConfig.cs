using System.Reflection;

namespace Hotel.API.Configuration
{
    public static class SwaggerConfig
    {
        public static WebApplicationBuilder AddSwaggerDoc(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(s => {

                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Description = "",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Email = "gm.natanael@gmail.com",
                        Name = "Natanael Maia",
                        Url = new Uri("https://github.com/nmaia")
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense()
                    {
                        Name = "MIT",
                        Url = new Uri("https://mit-license.org/")
                    },
                    Title = "Hotel.API",
                    Version = "v1",
                    TermsOfService = new Uri("https://br.linkedin.com/in/maianatanael1986/en")
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                s.IncludeXmlComments(xmlPath);

            });

            return builder;
        }
    }
}
