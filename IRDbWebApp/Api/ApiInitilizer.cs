namespace IRDbWebApp.Api
{
    public static class ApiInitilizer
    {
        public static HttpClient Client { get; } = new HttpClient();

        public static void Init() 
        {
            Client.BaseAddress = new Uri("https://localhost:7074/api/");
        }

    }
}
