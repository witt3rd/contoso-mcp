using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using ModelContextProtocol.Server;

namespace ContosoMcpServer.Tools
{
    [McpServerToolType]
    public class ProductTools
    {
        private static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://127.0.0.1:8000/"),
        };

        [McpServerTool(Name = "search_products")]
        [Description(
            "Search for products by name or description using fuzzy matching. Returns a list of potential matches with confidence scores."
        )]
        public static async Task<string> SearchProductsAsync(
            [Description("Search query for product name or description")] string query
        )
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(
                    $"search_products/?query={Uri.EscapeDataString(query)}"
                );
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                // Consider logging the full exception e
                return $"{{\"error\": \"Failed to search products. {e.Message}\"}}";
            }
            catch (Exception ex) // Catch other potential exceptions
            {
                // Consider logging the full exception ex
                return $"{{\"error\": \"An unexpected error occurred while searching products. {ex.Message}\"}}";
            }
        }

        [McpServerTool(Name = "get_product")]
        [Description("Get product details by ID.")]
        public static async Task<string> GetProductAsync(
            [Description("The ID of the product to retrieve")] int productId
        )
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"product/{productId}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                // Consider logging the full exception e
                return $"{{\"error\": \"Failed to get product with ID {productId}. {e.Message}\"}}";
            }
            catch (Exception ex) // Catch other potential exceptions
            {
                // Consider logging the full exception ex
                return $"{{\"error\": \"An unexpected error occurred while getting product with ID {productId}. {ex.Message}\"}}";
            }
        }
    }
}
