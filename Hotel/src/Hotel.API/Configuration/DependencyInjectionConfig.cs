using Hotel.Application.ApplicationServices;
using Hotel.Application.Contracts;
using Hotel.Domain.Contracts.DomainServices;
using Hotel.Domain.Contracts.Repositories;
using Hotel.Domain.DomainServices;
using Hotel.Infra.Repository.Repositories;
using MSConfig = Microsoft.Extensions.Configuration;

namespace Hotel.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static WebApplicationBuilder AddDependencyInjectionResolver(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IHotelApplicationService, HotelApplicationService>();
            builder.Services.AddScoped<IHotelDomainService, HotelDomainService>();
            builder.Services.AddScoped<IHotelRepository, HotelRepository>();

            builder.Services.AddScoped<ICustomerApplicationService, CustomerApplicationService>();
            builder.Services.AddScoped<ICustomerDomainService, CustomerDomainService>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

            builder.Services.AddScoped<IRoomApplicationService, RoomApplicationService>();
            builder.Services.AddScoped<IRoomDomainService, RoomDomainService>();
            builder.Services.AddScoped<IRoomRepository, RoomRepository>();

            builder.Services.AddScoped<IBookingApplicationService, BookingApplicationService>();
            builder.Services.AddScoped<IBookingDomainService, BookingDomainService>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();

            return builder;
        }
    }
}
