namespace Hotel.API.Proxy.RoutesMapper
{
    public class ExternalApiRouteMapping
    {
        public static string BASE_URL = "https://localhost:7112/"; 
        
        public static string POST_HOTEL_URL = BASE_URL + "api/hotels";
        public static string PUT_HOTEL_URL = BASE_URL+ "api/hotels";
        public static string GET_HOTEL_BY_ID_URL = BASE_URL + "api/hotels/";
        public static string GET_HOTELS_URL = BASE_URL + "api/hotels";
        public static string DELETE_HOTEL_URL = BASE_URL+ "api/hotels/";

        public static string POST_CUSTOMER_URL = BASE_URL + "api/customers";
        public static string PUT_CUSTOMER_URL = BASE_URL + "api/customers";
        public static string GET_CUSTOMER_BY_ID_URL = BASE_URL + "api/customers/";
        public static string GET_CUSTOMERS_URL = BASE_URL + "api/customers";
        public static string DELETE_CUSTOMER_URL = BASE_URL + "api/customers/";

        public static string POST_ROOM_URL = BASE_URL + "api/rooms";
        public static string PUT_ROOM_URL = BASE_URL + "api/rooms";
        public static string GET_ROOM_BY_ID_URL = BASE_URL + "api/rooms/";
        public static string GET_ROOMS_URL = BASE_URL + "api/rooms";
        public static string DELETE_ROOM_URL = BASE_URL + "api/rooms/";

        public static string POST_BOOKING_URL = BASE_URL + "api/bookings";
        public static string PUT_BOOKING_URL = BASE_URL + "api/bookings";
        public static string GET_BOOKING_BY_ID_URL = BASE_URL + "api/bookings/";
        public static string GET_BOOKINGS_URL = BASE_URL + "api/bookings";
        public static string DELETE_BOOKING_URL = BASE_URL + "api/bookings/";
    }
}
