namespace _024B_Rate_Limiting_Test
{
    internal class Program
    {
        // Change the base URL based on your project settings
        private const string BaseUrl = "http://localhost:5087/api/Values/"; 

        static async Task Main(string[] args)
        {
            // Give a delay to the API to run first, then run this test to check
            await Task.Delay(10000);
            using var client = new HttpClient { BaseAddress = new Uri(BaseUrl) };

            for (int i = 0; i < 100; i++)
            {
                var response = await client.GetAsync("get-cache-values");

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.StatusCode.ToString());
                    Console.WriteLine("Request successful!");
                }
                else if (response.StatusCode == (System.Net.HttpStatusCode)429)
                {
                    Console.WriteLine("Rate limit exceeded.");
                    break;
                }
                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseBody);
            }

            Console.ReadLine();
        }
    }
}
