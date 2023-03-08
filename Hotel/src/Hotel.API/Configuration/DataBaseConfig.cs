using Hotel.Infra.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Hotel.API.Configuration
{
    public static class DataBaseConfig
    {
        public static WebApplicationBuilder AddSDatabaseConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<HotelContextDb>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            return builder;
        }
    }
}
