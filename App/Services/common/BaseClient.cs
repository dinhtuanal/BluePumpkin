namespace App.Services.common
{
    public class BaseClient
    {
        protected HttpClient httpClient = null;
        public BaseClient()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44366/");
        }
    }
}
