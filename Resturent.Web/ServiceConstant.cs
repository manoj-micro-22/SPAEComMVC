namespace Resturent.Web
{
    public static class ServiceConstant
    {
        public static string ProductApiBase { get; set; }

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
